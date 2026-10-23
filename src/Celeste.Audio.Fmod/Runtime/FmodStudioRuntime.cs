using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using Celeste.Audio.Fmod.Banks;
using Celeste.Audio.Fmod.Capture;
using Celeste.Audio.Fmod.Events;
using Celeste.Audio.Fmod.Interop;
using Celeste.Audio.Fmod.IO;
using Celeste.Audio.Fmod.Mixing;
using Celeste.Audio.Fmod.Parameters;
using Celeste.Core.Audio;
using Celeste.Core.IO.Content;

namespace Celeste.Audio.Fmod.Runtime
{
    public sealed partial class FmodStudioRuntime : IDisposable
    {
        public const uint HeaderVersion = 0x00011014;
        private IntPtr system;
        public IFmodStudioDeviceIO DeviceIO { get; }
        private readonly IContentMemorySource bankContentSource;
        private readonly PathReader bankPathReader;
        internal readonly PathReader eventDescriptionPathReader;
        private readonly PathReader busPathReader;
        private readonly PathReader vcaPathReader;

        private readonly Dictionary<string, IntPtr> banks = new(StringComparer.OrdinalIgnoreCase);

        private readonly Dictionary<string, FmodEventDescriptionReference>
            genericDescriptions;

        private readonly ISourceFmodEventDescriptionCache sourceDescriptionsOwner;

        private Dictionary<string, FmodEventDescriptionReference> descriptions =>
            sourceDescriptionsOwner != null ? sourceDescriptionsOwner.CachedEventDescriptions : genericDescriptions;

        private readonly HashSet<FmodEventInstance> instances = [];

        public uint Version { get; }
        public bool NoSound { get; private set; }
        private readonly bool requestedNoSound;
        public event Action<bool> AudioOutputCreated;
        public bool LiveUpdate { get; }
        public bool IsDisposed => system == IntPtr.Zero;

        public FmodAudioCapture CreateAudioCapture(Action<float[], int, int> receive)
        {
            Alive();
            var result =
                DeviceIO.StudioSystemGetLowLevelSystem(system,
                    out var core);
            if (result != 0) throw new FmodException(result, "getLowLevelSystem");
            return DeviceIO.CreateAudioCapture(core, receive);
        }

        public long RejectedParameterCount { get; private set; }
        public FmodParameterFailure LastParameterFailure { get; private set; }
        public event Action<FmodParameterFailure> ParameterRejected;

        public void ReportParameterFailure(string path, string parameter, float value,
            FmodResult result)
        {
            RejectedParameterCount++;
            LastParameterFailure = new() { EventPath = path, Parameter = parameter, Value = value, Result = result };
            ParameterRejected?.Invoke(LastParameterFailure);
        }

        private FmodEventInstance currentMusic;

        public FmodEventInstance CurrentMusic
        {
            get => currentMusic;
            set
            {
                Alive();
                if (value != null && (value.Owner != this || value.IsReleased))
                    throw new ArgumentException("Current music must be an unreleased event owned by this runtime.",
                        nameof(value));
                currentMusic = value;
            }
        }

        public IReadOnlyCollection<string> LoadedBanks => banks.Keys;

        // Match FMOD Studio System.getBankList, which OuiSoundTest indexes by its
        // two leading hexadecimal digits. Dictionary/load order is not enough.
        private IntPtr[] NativeBankList()
        {
            Alive();
            Check(
                DeviceIO.StudioSystemGetBankCount(system, out var count),
                "Get bank count");
            var result = new IntPtr[count];
            if (count != 0)
                Check(
                    DeviceIO.StudioSystemGetBankList(system, result,
                        count,
                        out count), "Get bank list");
            if (count < result.Length) Array.Resize(ref result, count);
            return result;
        }

        public string[] BankNames()
        {
            return
            [
                .. NativeBankList()
                    .Select(bank => ReadPath(bank, bankPathReader)),
            ];
        }

        public FmodEventInfo[] BankEvents(int index)
        {
            var list = NativeBankList();
            if (index < 0 || index >= list.Length)
                return [];
            var bank = list[index];
            Check(DeviceIO.StudioBankGetEventCount(bank, out var count),
                "Get bank event count");
            if (count == 0) return [];
            var events = new IntPtr[count];
            Check(
                DeviceIO.StudioBankGetEventList(bank, events, count,
                    out count), "Get bank event list");
            return
            [
                .. events.Take(Math.Min(count, events.Length)).Select(Describe)
                    .OrderBy(info => info.Path, StringComparer.Ordinal),
            ];
        }

        public Dictionary<string, FmodEventDescriptionReference>
            CachedEventDescriptions =>
            descriptions;

        public FmodEventDescriptionReference BorrowCachedEventDescription(
            IntPtr actualHandle)
        {
            return new(actualHandle, DeviceIO);
        }

        public int OwnedInstanceCount => instances.Count;

        private enum SourceAllocation
        {
            Uninitialized,
        }

        private FmodStudioRuntime(SourceAllocation allocation, bool liveUpdate,
            ISourceFmodEventDescriptionCache sourceCache, bool noSound, IFmodStudioDeviceIO deviceIO,
            IContentMemorySource bankContentSource)
        {
            DeviceIO = deviceIO ?? throw new ArgumentNullException(nameof(deviceIO));
            this.bankContentSource = bankContentSource;
            bankPathReader = DeviceIO.StudioBankGetPath;
            eventDescriptionPathReader = DeviceIO.StudioEventDescriptionGetPath;
            busPathReader = DeviceIO.StudioBusGetPath;
            vcaPathReader = DeviceIO.StudioVCAGetPath;
            LiveUpdate = liveUpdate;
            sourceDescriptionsOwner = sourceCache;
            requestedNoSound = noSound;
            if (sourceCache == null)
                genericDescriptions =
                    new(
                        StringComparer
                            .Ordinal);
        }

        public static FmodStudioRuntime AllocateSourceSystem(bool liveUpdate,
            ISourceFmodEventDescriptionCache sourceCache = null,
            bool noSound = false)
        {
            return AllocateSourceSystem(NativeFmodStudioDeviceIO.Instance, liveUpdate, sourceCache, noSound);
        }

        public static FmodStudioRuntime AllocateSourceSystem(IFmodStudioDeviceIO deviceIO, bool liveUpdate,
            ISourceFmodEventDescriptionCache sourceCache = null, bool noSound = false,
            IContentMemorySource bankContentSource = null)
        {
            return new(SourceAllocation.Uninitialized, liveUpdate, sourceCache, noSound, deviceIO,
                bankContentSource);
        }

        public FmodResult CreateSourceSystemNative()
        {
            var result =
                DeviceIO.StudioSystemCreate(out system, DeviceIO.HeaderVersion);
            if (result != FmodResult.OK || !requestedNoSound) return result;
            result = DeviceIO.StudioSystemGetLowLevelSystem(system,
                out var core);
            if (result != FmodResult.OK) return result;
            return DeviceIO.SystemSetOutput(core, 2);
        }

        public FmodResult InitializeSourceSystemNative(int channels,
            uint studioFlags)
        {
            var result = DeviceIO.StudioSystemInitialize(system,
                channels,
                studioFlags, 0, IntPtr.Zero);
            if (result != FmodResult.OK) return result;
            return VerifySourceOutputNative();
        }

        private FmodResult VerifySourceOutputNative()
        {
            var result =
                DeviceIO.StudioSystemGetLowLevelSystem(system,
                    out var core);
            if (result != FmodResult.OK) return result;
            result = DeviceIO.SystemGetOutput(core, out var output);
            if (result != FmodResult.OK) return result;
            NoSound = output == 2;
            AudioOutputCreated?.Invoke(NoSound);
            return result;
        }

        public FmodResult LoadSourceBankNative(string path,
            out FmodBankReference bank)
        {
            if (bankContentSource != null)
                return LoadSourceBankMemoryNative(bankContentSource.OpenTitleMemory(path), out bank);
            var result = DeviceIO.StudioSystemLoadBankFile(
                system, Encoding.UTF8.GetBytes(path + "\0"), 0, out var handle);
            bank = result == FmodResult.OK
                ? new FmodBankReference(handle, DeviceIO)
                : null;
            return result;
        }

        public FmodResult LoadSourceBankMemoryNative(ReadOnlyMemory<byte> buffer,
            out FmodBankReference bank)
        {
            var result = DeviceIO.StudioSystemLoadBankMemory(system, buffer, out var handle);
            bank = result == FmodResult.OK
                ? new FmodBankReference(handle, DeviceIO)
                : null;
            return result;
        }

        private FmodResult LoadBankHandle(string path, out IntPtr bank)
        {
            if (bankContentSource != null)
                return DeviceIO.StudioSystemLoadBankMemory(system, bankContentSource.OpenTitleMemory(path), out bank);
            return DeviceIO.StudioSystemLoadBankFile(system, Utf8(path), 0, out bank);
        }

        public FmodResult SetSourceListenerNative(
            FmodAttributes attributes)
        {
            return DeviceIO.StudioSystemSetListenerAttributes(system, 0,
                ref attributes);
        }

        public FmodResult UnloadSourceBanksNative()
        {
            return DeviceIO.StudioSystemUnloadAll(system);
        }

        public FmodResult ReleaseSourceSystemNative()
        {
            return DeviceIO.StudioSystemRelease(system);
        }

        public FmodStudioRuntime(bool noSound = false, int maxChannels = 1024, bool liveUpdate = false)
            : this(NativeFmodStudioDeviceIO.Instance, noSound, maxChannels, liveUpdate)
        {
        }

        public FmodStudioRuntime(IFmodStudioDeviceIO deviceIO, bool noSound = false, int maxChannels = 1024,
            bool liveUpdate = false, IContentMemorySource bankContentSource = null)
        {
            DeviceIO = deviceIO ?? throw new ArgumentNullException(nameof(deviceIO));
            this.bankContentSource = bankContentSource;
            bankPathReader = DeviceIO.StudioBankGetPath;
            eventDescriptionPathReader = DeviceIO.StudioEventDescriptionGetPath;
            busPathReader = DeviceIO.StudioBusGetPath;
            vcaPathReader = DeviceIO.StudioVCAGetPath;
            genericDescriptions =
                new(
                    StringComparer.Ordinal);
            DeviceIO.ValidateRuntimeArchitecture();
            if (maxChannels <= 0) throw new ArgumentOutOfRangeException(nameof(maxChannels));
            requestedNoSound = noSound;
            LiveUpdate = liveUpdate;
            Check(DeviceIO.StudioSystemCreate(out system, DeviceIO.HeaderVersion),
                "Create FMOD Studio 1.10.14");
            try
            {
                Check(
                    DeviceIO.StudioSystemGetLowLevelSystem(system,
                        out var lowLevel),
                    "Get low-level FMOD system");
                Check(
                    DeviceIO.SystemGetVersion(lowLevel, out var version),
                    "Get FMOD native version");
                Version = version;
                if (version != DeviceIO.HeaderVersion)
                    throw new InvalidOperationException("FMOD native version 0x" + version.ToString("X8") +
                                                        " differs from required 0x" +
                                                        DeviceIO.HeaderVersion.ToString("X8") +
                                                        ".");
                if (noSound)
                    Check(DeviceIO.SystemSetOutput(lowLevel, 2),
                        "Select no-sound FMOD output");
                // FMOD_STUDIO_INIT_LIVEUPDATE = 0x00000001. The original
                // Audio.Init chooses this flag before initializing the system.
                Check(DeviceIO.StudioSystemInitialize(system,
                    maxChannels,
                    liveUpdate ? 0x00000001u : 0u, 0, IntPtr.Zero), "Initialize FMOD Studio");
                Check(VerifySourceOutputNative(), "Verify FMOD output");
            }
            catch (Exception error)
            {
                var handle = system;
                system = IntPtr.Zero;
                var cleanup =
                    DeviceIO.StudioSystemRelease(handle);
                if (cleanup != FmodResult.OK)
                    throw new AggregateException(error,
                        new FmodException(cleanup,
                            "Release partially initialized FMOD system"));
                throw;
            }
        }

        internal void Alive()
        {
            if (IsDisposed)
                throw new ObjectDisposedException(nameof(FmodStudioRuntime));
        }

        internal static void Check(FmodResult result, string operation)
        {
            if (result != FmodResult.OK)
                throw new FmodException(result, operation);
        }

        internal static byte[] Utf8(string value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            if (value.IndexOf('\0') >= 0)
                throw new ArgumentException("FMOD strings cannot contain embedded null characters.", nameof(value));
            return Encoding.UTF8.GetBytes(value + "\0");
        }

        internal delegate FmodResult PathReader(IntPtr handle, byte[] path, int size,
            out int retrieved);

        internal static string ReadPath(IntPtr handle, PathReader reader)
        {
            var buffer = new byte[256];
            var result = reader(handle, buffer, buffer.Length, out var size);
            if (result == FmodResult.ERR_TRUNCATED && size > buffer.Length)
            {
                if (size > 1024 * 1024) throw new InvalidOperationException("FMOD returned an invalid path length.");
                buffer = new byte[size];
                result = reader(handle, buffer, buffer.Length, out size);
            }

            Check(result, "Read FMOD UTF-8 path");
            var length = Array.IndexOf(buffer, (byte)0);
            return Encoding.UTF8.GetString(buffer, 0, length < 0 ? Math.Min(buffer.Length, size) : length);
        }

        public void LoadBank(string path, bool loadSampleData = true)
        {
            Alive();
            path = Path.GetFullPath(path);
            if (bankContentSource == null && !File.Exists(path))
                throw new FileNotFoundException("FMOD bank not found.", path);
            if (banks.ContainsKey(path)) return;
            Check(
                LoadBankHandle(path, out var bank),
                "Load bank " + path);
            try
            {
                if (loadSampleData)
                    Check(DeviceIO.StudioBankLoadSampleData(bank),
                        "Load bank sample data " + path);
            }
            catch (Exception error)
            {
                var cleanup =
                    DeviceIO.StudioBankUnload(bank);
                if (cleanup != FmodResult.OK)
                    throw new AggregateException(error,
                        new FmodException(cleanup,
                            "Unload bank after sample loading failed"));
                throw;
            }

            banks.Add(path, bank);
        }

        public void LoadBanks(IEnumerable<FmodBankLoadRequest> requests)
        {
            if (requests == null) throw new ArgumentNullException(nameof(requests));
            foreach (var request in requests) LoadBank(request.Path, request.LoadSamples);
        }

        public void Update()
        {
            Alive();
            Check(DeviceIO.StudioSystemUpdate(system),
                "Update FMOD Studio");
        }

        public void Flush()
        {
            Alive();
            Check(DeviceIO.StudioSystemFlushCommands(system),
                "Flush FMOD commands");
            Check(DeviceIO.StudioSystemFlushSampleLoading(system),
                "Flush FMOD sample loading");
        }

        internal IntPtr Description(string path)
        {
            Alive();
            if (descriptions.TryGetValue(path, out var description)) return description.RawHandle;
            Check(
                DeviceIO.StudioSystemGetEvent(system, Utf8(path),
                    out var handle), "Find event " + path);
            descriptions.Add(path,
                new(handle, DeviceIO));
            return handle;
        }

        public FmodEventInfo EventInfo(string path)
        {
            return Describe(Description(path));
        }

        private FmodEventInfo Describe(IntPtr description)
        {
            var path = ReadPath(description,
                eventDescriptionPathReader);
            Check(
                DeviceIO.StudioEventDescriptionGetID(description,
                    out var id),
                "Get event ID " + path);
            Check(
                DeviceIO.StudioEventDescriptionGetLength(description,
                    out var length),
                "Get event length " + path);
            Check(
                DeviceIO.StudioEventDescriptionIsOneshot(description,
                    out var oneShot),
                "Get event one-shot flag " + path);
            Check(
                DeviceIO.StudioEventDescriptionIs3D(description,
                    out var is3D),
                "Get event spatial flag " + path);
            Check(
                DeviceIO.StudioEventDescriptionGetParameterCount(
                    description,
                    out var count),
                "Get parameter count " + path);
            var parameters = new FmodParameterInfo[count];
            for (var i = 0; i < count; i++)
            {
                Check(
                    DeviceIO.StudioEventDescriptionGetParameterInfoByIndex(
                        description, i, out var parameter),
                    "Get event parameter " + path);
                parameters[i] = new()
                {
                    Name = parameter.Name, Index = parameter.Index, Minimum = parameter.Minimum,
                    Maximum = parameter.Maximum, DefaultValue = parameter.DefaultValue, Type = parameter.Type,
                };
            }

            descriptions[path] =
                new(description, DeviceIO);
            return new()
            {
                Path = path, Id = id, LengthMilliseconds = length, IsOneShot = oneShot != 0, Is3D = is3D != 0,
                Parameters = parameters,
            };
        }

        public FmodEventInfo[] Events()
        {
            Alive();
            var events = new Dictionary<Guid, FmodEventInfo>();
            foreach (var bank in banks.Values)
            {
                Check(
                    DeviceIO.StudioBankGetEventCount(bank, out var count),
                    "Get bank event count");
                if (count == 0) continue;
                var array = new IntPtr[count];
                Check(
                    DeviceIO.StudioBankGetEventList(bank, array,
                        array.Length,
                        out count),
                    "Enumerate bank events");
                for (var i = 0; i < Math.Min(array.Length, count); i++)
                {
                    var info = Describe(array[i]);
                    events[info.Id] = info;
                }
            }

            return [.. events.Values.OrderBy(e => e.Path, StringComparer.Ordinal)];
        }

        public FmodEventInstance CreateEvent(string path)
        {
            var description = Description(path);
            Check(
                DeviceIO.StudioEventDescriptionCreateInstance(
                    description,
                    out var handle),
                "Create event instance " + path);
            var instance =
                new FmodEventInstance(this, handle, path);
            instances.Add(instance);
            return instance;
        }

        // Source Audio.GetEventDescription uses the actual shared cache and original result policy.
        private bool TrySourceDescription(string path, out IntPtr description)
        {
            var reference = GetSourceEventDescription(path);
            description = reference == null ? IntPtr.Zero : reference.RawHandle;
            return reference != null;
        }

        public FmodEventInstance CreateSourceEvent(string path)
        {
            if (!TrySourceDescription(path, out var description)) return null;
            var result =
                DeviceIO.StudioEventDescriptionCreateInstance(
                    description,
                    out var handle);
            return result == FmodResult.OK
                ? new FmodEventInstance(this, handle, path)
                : null;
        }

        public bool GetSourceEventPlaybackFlags(string path, out bool is3D, out bool isOneshot)
        {
            is3D = false;
            isOneshot = false;
            if (!TrySourceDescription(path, out var description)) return false;
            DeviceIO.StudioEventDescriptionIs3D(description,
                out var spatial);
            DeviceIO.StudioEventDescriptionIsOneshot(description,
                out var oneshot);
            is3D = spatial != 0;
            isOneshot = oneshot != 0;
            return true;
        }

        private FmodResult CreateSourceEventDescriptionInstance(IntPtr description,
            string path,
            out FmodEventReference instance)
        {
            FmodResult Original(
                out FmodEventReference resultInstance)
            {
                var result =
                    DeviceIO.StudioEventDescriptionCreateInstance(
                        description,
                        out var handle);
                resultInstance = result == FmodResult.OK
                    ? new FmodEventReference(this, handle, path)
                    : null;
                return result;
            }

            if (sourceDescriptionsOwner is ISourceAudioInterceptionOwner audio
                && audio.AudioInterceptionPolicy is { IsEventInstanceInterceptionEnabled: true } policy)
            {
                var originalDescription =
                    new FmodEventDescriptionReference(description, DeviceIO);
                var eventName = audio.GetEventName(originalDescription);
                return policy.InvokeCreateEventInstance(eventName, Original, out instance);
            }

            return Original(out instance);
        }

        public void CreateSoundSourceReference(
            string path, ref ISourceAudioEventReference instance, ref bool is3D,
            ref bool isOneshot)
        {
            if (!TrySourceDescription(path, out var description)) return;
            var result = CreateSourceEventDescriptionInstance(description, path, out var actualInstance);
            instance = actualInstance;
            DeviceIO.StudioEventDescriptionIs3D(description,
                out var spatial);
            is3D = spatial != 0;
            DeviceIO.StudioEventDescriptionIsOneshot(description,
                out var oneshot);
            isOneshot = oneshot != 0;
        }

        public FmodEventReference CreateEventReference(string path)
        {
            return CreateEventReference(path, out _);
        }

        public FmodEventReference CreateEventReference(string path, out bool is3D)
        {
            is3D = false;
            if (!TrySourceDescription(path, out var description)) return null;
            var result = CreateSourceEventDescriptionInstance(description, path, out var instance);
            DeviceIO.StudioEventDescriptionIs3D(description,
                out var spatial);
            is3D = spatial != 0;
            return instance;
        }

        public FmodEventReference CreateSourceSnapshotReference(string path,
            bool start = true)
        {
            var instance = CreateSourceSnapshotReferenceOriginal(path);
            if (start) instance.Start();
            return instance;
        }

        private FmodEventReference CreateSourceSnapshotReferenceOriginal(string path)
        {
            var lookup =
                DeviceIO.StudioSystemGetEvent(system, Utf8(path),
                    out var description);
            if (lookup != FmodResult.OK)
                throw new("Snapshot " + path + " doesn't exist");
            var result = CreateSourceEventDescriptionInstance(description, path, out var instance);
            return result == FmodResult.OK ? instance : null;
        }

        internal void Forget(FmodEventInstance instance)
        {
            instances.Remove(instance);
            if (currentMusic == instance) currentMusic = null;
        }

        public int InstanceCount(string path)
        {
            Check(
                DeviceIO.StudioEventDescriptionGetInstanceCount(
                    Description(path), out var count),
                "Get instance count " + path);
            return count;
        }

        public FmodEventInstance CreateSnapshot(string path)
        {
            var instance = CreateEvent(path);
            try
            {
                instance.Start();
                return instance;
            }
            catch
            {
                instance.Dispose();
                throw;
            }
        }

        public void Play(string path)
        {
            var instance = CreateEvent(path);
            try
            {
                instance.Start();
                instance.Release();
            }
            catch
            {
                instance.Dispose();
                throw;
            }
        }

        public void Stop(FmodEventInstance instance, bool allowFadeout = true)
        {
            if (instance == null) return;
            if (instance.Owner != this)
                throw new ArgumentException("The event belongs to another FMOD runtime.", nameof(instance));
            instance.Stop(allowFadeout);
            instance.Release();
        }

        // Original Audio.BusPaused: only successful bus lookup is a gate.
        // Setter and subsequent getter results are intentionally ignored.
        public bool BusPausedNative(string path, bool? pause = null)
        {
            var paused = false;
            if (system != IntPtr.Zero &&
                DeviceIO.StudioSystemGetBus(system, Utf8(path),
                    out var bus) ==
                FmodResult.OK)
            {
                if (pause.HasValue)
                    DeviceIO.StudioBusSetPaused(bus, pause.Value ? 1 : 0);
                DeviceIO.StudioBusGetPaused(bus, out var value);
                paused = value != 0;
            }

            return paused;
        }

        public void BusStopAllNative(string path, bool immediate)
        {
            if (system != IntPtr.Zero &&
                DeviceIO.StudioSystemGetBus(system, Utf8(path),
                    out var bus) ==
                FmodResult.OK)
                DeviceIO.StudioBusStopAllEvents(bus, immediate ? 1 : 0);
        }

        public FmodBus GetBus(string path)
        {
            Alive();
            Check(
                DeviceIO.StudioSystemGetBus(system, Utf8(path),
                    out var handle), "Find bus " + path);
            return new(this, handle, path);
        }

        public FmodResult GetSourceVcaNative(string path, out IntPtr vca)
        {
            return DeviceIO.StudioSystemGetVCA(system, Utf8(path), out vca);
        }

        public FmodResult SetSourceVcaVolumeNative(IntPtr vca, float volume)
        {
            return DeviceIO.StudioVCASetVolume(vca, volume);
        }

        public FmodResult GetSourceVcaVolumeNative(IntPtr vca, out float volume,
            out float finalVolume)
        {
            return DeviceIO.StudioVCAGetVolume(vca, out volume,
                out finalVolume);
        }

        public FmodVca GetVca(string path)
        {
            Alive();
            Check(
                DeviceIO.StudioSystemGetVCA(system, Utf8(path),
                    out var handle), "Find VCA " + path);
            return new(this, handle, path);
        }

        public string[] Buses()
        {
            Alive();
            var paths = new HashSet<string>();
            foreach (var bank in banks.Values)
            {
                Check(
                    DeviceIO.StudioBankGetBusCount(bank, out var count),
                    "Get bank bus count");
                if (count == 0) continue;
                var array = new IntPtr[count];
                Check(
                    DeviceIO.StudioBankGetBusList(bank, array,
                        array.Length,
                        out count),
                    "Enumerate bank buses");
                for (var i = 0; i < Math.Min(count, array.Length); i++)
                    paths.Add(ReadPath(array[i],
                        busPathReader));
            }

            return [.. paths.OrderBy(p => p, StringComparer.Ordinal)];
        }

        public string[] Vcas()
        {
            Alive();
            var paths = new HashSet<string>();
            foreach (var bank in banks.Values)
            {
                Check(
                    DeviceIO.StudioBankGetVCACount(bank, out var count),
                    "Get bank VCA count");
                if (count == 0) continue;
                var array = new IntPtr[count];
                Check(
                    DeviceIO.StudioBankGetVCAList(bank, array,
                        array.Length,
                        out count),
                    "Enumerate bank VCAs");
                for (var i = 0; i < Math.Min(count, array.Length); i++)
                    paths.Add(ReadPath(array[i],
                        vcaPathReader));
            }

            return [.. paths.OrderBy(p => p, StringComparer.Ordinal)];
        }

        public void SetListener(Vector3 position, Vector3 forward,
            Vector3 up)
        {
            SetListenerAttributes(new()
            {
                Position = new(position.X, position.Y, position.Z),
                Forward = new(forward.X, forward.Y, forward.Z),
                Up = new(up.X, up.Y, up.Z),
            });
        }

        public void SetListenerAttributes(FmodAttributes attributes)
        {
            Alive();
            Check(
                DeviceIO.StudioSystemSetListenerAttributes(system, 0,
                    ref attributes),
                "Set listener attributes");
        }

        public void Dispose()
        {
            if (IsDisposed) return;
            var errors = new List<Exception>();
            foreach (var instance in instances.ToArray())
                try
                {
                    instance.Dispose();
                }
                catch (Exception error)
                {
                    errors.Add(error);
                }

            var handle = system;
            system = IntPtr.Zero;
            try
            {
                Check(DeviceIO.StudioSystemRelease(handle),
                    "Release FMOD Studio");
            }
            catch (Exception error)
            {
                errors.Add(error);
            }

            instances.Clear();
            banks.Clear();
            descriptions.Clear();
            currentMusic = null;
            if (errors.Count != 0) throw new AggregateException("FMOD runtime cleanup failed.", errors);
        }
    }
}
