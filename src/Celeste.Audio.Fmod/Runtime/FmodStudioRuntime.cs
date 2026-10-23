using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Celeste.Audio.Fmod.Runtime
{
    public sealed partial class FmodStudioRuntime : IDisposable
    {
        public const uint HeaderVersion = 0x00011014;
        private IntPtr system;
        public IO.IFmodStudioDeviceIO DeviceIO { get; }
        private readonly global::Celeste.Core.IO.Content.IContentMemorySource bankContentSource;
        private readonly PathReader bankPathReader;
        internal readonly PathReader eventDescriptionPathReader;
        private readonly PathReader busPathReader;
        private readonly PathReader vcaPathReader;

        private readonly Dictionary<string, IntPtr> banks =
            new Dictionary<string, IntPtr>(StringComparer.OrdinalIgnoreCase);

        private readonly Dictionary<string, global::Celeste.Audio.Fmod.Events.FmodEventDescriptionReference>
            genericDescriptions;

        private readonly ISourceFmodEventDescriptionCache sourceDescriptionsOwner;

        private Dictionary<string, global::Celeste.Audio.Fmod.Events.FmodEventDescriptionReference> descriptions =>
            sourceDescriptionsOwner != null ? sourceDescriptionsOwner.CachedEventDescriptions : genericDescriptions;

        private readonly HashSet<global::Celeste.Audio.Fmod.Events.FmodEventInstance> instances =
            new HashSet<global::Celeste.Audio.Fmod.Events.FmodEventInstance>();

        public uint Version { get; }
        public bool NoSound { get; private set; }
        private readonly bool requestedNoSound;
        public event Action<bool> AudioOutputCreated;
        public bool LiveUpdate { get; }
        public bool IsDisposed => system == IntPtr.Zero;

        public global::Celeste.Audio.Fmod.Capture.FmodAudioCapture CreateAudioCapture(Action<float[], int, int> receive)
        {
            Alive();
            global::Celeste.Audio.Fmod.Interop.FmodResult result =
                DeviceIO.StudioSystemGetLowLevelSystem(system,
                    out var core);
            if (result != 0) throw new global::Celeste.Audio.Fmod.Interop.FmodException(result, "getLowLevelSystem");
            return DeviceIO.CreateAudioCapture(core, receive);
        }

        public long RejectedParameterCount { get; private set; }
        public global::Celeste.Audio.Fmod.Parameters.FmodParameterFailure LastParameterFailure { get; private set; }
        public event Action<global::Celeste.Audio.Fmod.Parameters.FmodParameterFailure> ParameterRejected;

        public void ReportParameterFailure(string path, string parameter, float value,
            global::Celeste.Audio.Fmod.Interop.FmodResult result)
        {
            RejectedParameterCount++;
            LastParameterFailure = new global::Celeste.Audio.Fmod.Parameters.FmodParameterFailure
                { EventPath = path, Parameter = parameter, Value = value, Result = result };
            ParameterRejected?.Invoke(LastParameterFailure);
        }

        private global::Celeste.Audio.Fmod.Events.FmodEventInstance currentMusic;

        public global::Celeste.Audio.Fmod.Events.FmodEventInstance CurrentMusic
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
                DeviceIO.StudioSystemGetBankCount(system, out int count),
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

        public string[] BankNames() => NativeBankList()
            .Select(bank => ReadPath(bank, bankPathReader))
            .ToArray();

        public global::Celeste.Audio.Fmod.Events.FmodEventInfo[] BankEvents(int index)
        {
            IntPtr[] list = NativeBankList();
            if (index < 0 || index >= list.Length)
                return Array.Empty<global::Celeste.Audio.Fmod.Events.FmodEventInfo>();
            IntPtr bank = list[index];
            Check(DeviceIO.StudioBankGetEventCount(bank, out int count),
                "Get bank event count");
            if (count == 0) return Array.Empty<global::Celeste.Audio.Fmod.Events.FmodEventInfo>();
            var events = new IntPtr[count];
            Check(
                DeviceIO.StudioBankGetEventList(bank, events, count,
                    out count), "Get bank event list");
            return events.Take(Math.Min(count, events.Length)).Select(Describe)
                .OrderBy(info => info.Path, StringComparer.Ordinal).ToArray();
        }

        public Dictionary<string, global::Celeste.Audio.Fmod.Events.FmodEventDescriptionReference>
            CachedEventDescriptions =>
            descriptions;

        public global::Celeste.Audio.Fmod.Events.FmodEventDescriptionReference BorrowCachedEventDescription(
            IntPtr actualHandle)
            => new global::Celeste.Audio.Fmod.Events.FmodEventDescriptionReference(actualHandle, DeviceIO);

        public int OwnedInstanceCount => instances.Count;

        private enum SourceAllocation
        {
            Uninitialized
        }

        private FmodStudioRuntime(SourceAllocation allocation, bool liveUpdate,
            ISourceFmodEventDescriptionCache sourceCache, bool noSound, IO.IFmodStudioDeviceIO deviceIO,
            global::Celeste.Core.IO.Content.IContentMemorySource bankContentSource)
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
                    new Dictionary<string, global::Celeste.Audio.Fmod.Events.FmodEventDescriptionReference>(
                        StringComparer
                            .Ordinal);
        }

        public static FmodStudioRuntime AllocateSourceSystem(bool liveUpdate,
            ISourceFmodEventDescriptionCache sourceCache = null,
            bool noSound = false) =>
            AllocateSourceSystem(IO.NativeFmodStudioDeviceIO.Instance, liveUpdate, sourceCache, noSound);

        public static FmodStudioRuntime AllocateSourceSystem(IO.IFmodStudioDeviceIO deviceIO, bool liveUpdate,
            ISourceFmodEventDescriptionCache sourceCache = null, bool noSound = false,
            global::Celeste.Core.IO.Content.IContentMemorySource bankContentSource = null) =>
            new FmodStudioRuntime(SourceAllocation.Uninitialized, liveUpdate, sourceCache, noSound, deviceIO,
                bankContentSource);

        public global::Celeste.Audio.Fmod.Interop.FmodResult CreateSourceSystemNative()
        {
            var result =
                DeviceIO.StudioSystemCreate(out system, DeviceIO.HeaderVersion);
            if (result != global::Celeste.Audio.Fmod.Interop.FmodResult.OK || !requestedNoSound) return result;
            result = DeviceIO.StudioSystemGetLowLevelSystem(system,
                out var core);
            if (result != global::Celeste.Audio.Fmod.Interop.FmodResult.OK) return result;
            return DeviceIO.SystemSetOutput(core, 2);
        }

        public global::Celeste.Audio.Fmod.Interop.FmodResult InitializeSourceSystemNative(int channels,
            uint studioFlags)
        {
            var result = DeviceIO.StudioSystemInitialize(system,
                channels,
                studioFlags, 0, IntPtr.Zero);
            if (result != global::Celeste.Audio.Fmod.Interop.FmodResult.OK) return result;
            return VerifySourceOutputNative();
        }

        private global::Celeste.Audio.Fmod.Interop.FmodResult VerifySourceOutputNative()
        {
            var result =
                DeviceIO.StudioSystemGetLowLevelSystem(system,
                    out var core);
            if (result != global::Celeste.Audio.Fmod.Interop.FmodResult.OK) return result;
            result = DeviceIO.SystemGetOutput(core, out int output);
            if (result != global::Celeste.Audio.Fmod.Interop.FmodResult.OK) return result;
            NoSound = output == 2;
            AudioOutputCreated?.Invoke(NoSound);
            return result;
        }

        public global::Celeste.Audio.Fmod.Interop.FmodResult LoadSourceBankNative(string path,
            out global::Celeste.Audio.Fmod.Banks.FmodBankReference bank)
        {
            if (bankContentSource != null)
                return LoadSourceBankMemoryNative(bankContentSource.OpenTitleMemory(path), out bank);
            var result = DeviceIO.StudioSystemLoadBankFile(
                system, Encoding.UTF8.GetBytes(path + "\0"), 0, out var handle);
            bank = result == global::Celeste.Audio.Fmod.Interop.FmodResult.OK
                ? new global::Celeste.Audio.Fmod.Banks.FmodBankReference(handle, DeviceIO)
                : null;
            return result;
        }

        public global::Celeste.Audio.Fmod.Interop.FmodResult LoadSourceBankMemoryNative(ReadOnlyMemory<byte> buffer,
            out global::Celeste.Audio.Fmod.Banks.FmodBankReference bank)
        {
            var result = DeviceIO.StudioSystemLoadBankMemory(system, buffer, out var handle);
            bank = result == global::Celeste.Audio.Fmod.Interop.FmodResult.OK
                ? new global::Celeste.Audio.Fmod.Banks.FmodBankReference(handle, DeviceIO)
                : null;
            return result;
        }

        private global::Celeste.Audio.Fmod.Interop.FmodResult LoadBankHandle(string path, out IntPtr bank)
        {
            if (bankContentSource != null)
                return DeviceIO.StudioSystemLoadBankMemory(system, bankContentSource.OpenTitleMemory(path), out bank);
            return DeviceIO.StudioSystemLoadBankFile(system, Utf8(path), 0, out bank);
        }

        public global::Celeste.Audio.Fmod.Interop.FmodResult SetSourceListenerNative(
            global::Celeste.Audio.Fmod.Interop.FmodAttributes attributes) =>
            DeviceIO.StudioSystemSetListenerAttributes(system, 0,
                ref attributes);

        public global::Celeste.Audio.Fmod.Interop.FmodResult UnloadSourceBanksNative() =>
            DeviceIO.StudioSystemUnloadAll(system);

        public global::Celeste.Audio.Fmod.Interop.FmodResult ReleaseSourceSystemNative() =>
            DeviceIO.StudioSystemRelease(system);

        public FmodStudioRuntime(bool noSound = false, int maxChannels = 1024, bool liveUpdate = false)
            : this(IO.NativeFmodStudioDeviceIO.Instance, noSound, maxChannels, liveUpdate)
        {
        }

        public FmodStudioRuntime(IO.IFmodStudioDeviceIO deviceIO, bool noSound = false, int maxChannels = 1024,
            bool liveUpdate = false, global::Celeste.Core.IO.Content.IContentMemorySource bankContentSource = null)
        {
            DeviceIO = deviceIO ?? throw new ArgumentNullException(nameof(deviceIO));
            this.bankContentSource = bankContentSource;
            bankPathReader = DeviceIO.StudioBankGetPath;
            eventDescriptionPathReader = DeviceIO.StudioEventDescriptionGetPath;
            busPathReader = DeviceIO.StudioBusGetPath;
            vcaPathReader = DeviceIO.StudioVCAGetPath;
            genericDescriptions =
                new Dictionary<string, global::Celeste.Audio.Fmod.Events.FmodEventDescriptionReference>(
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
                global::Celeste.Audio.Fmod.Interop.FmodResult cleanup =
                    DeviceIO.StudioSystemRelease(handle);
                if (cleanup != global::Celeste.Audio.Fmod.Interop.FmodResult.OK)
                    throw new AggregateException(error,
                        new global::Celeste.Audio.Fmod.Interop.FmodException(cleanup,
                            "Release partially initialized FMOD system"));
                throw;
            }
        }

        internal void Alive()
        {
            if (IsDisposed)
                throw new ObjectDisposedException(nameof(global::Celeste.Audio.Fmod.Runtime.FmodStudioRuntime));
        }

        internal static void Check(global::Celeste.Audio.Fmod.Interop.FmodResult result, string operation)
        {
            if (result != global::Celeste.Audio.Fmod.Interop.FmodResult.OK)
                throw new global::Celeste.Audio.Fmod.Interop.FmodException(result, operation);
        }

        internal static byte[] Utf8(string value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            if (value.IndexOf('\0') >= 0)
                throw new ArgumentException("FMOD strings cannot contain embedded null characters.", nameof(value));
            return Encoding.UTF8.GetBytes(value + "\0");
        }

        internal delegate global::Celeste.Audio.Fmod.Interop.FmodResult PathReader(IntPtr handle, byte[] path, int size,
            out int retrieved);

        internal static string ReadPath(IntPtr handle, PathReader reader)
        {
            byte[] buffer = new byte[256];
            global::Celeste.Audio.Fmod.Interop.FmodResult result = reader(handle, buffer, buffer.Length, out int size);
            if (result == global::Celeste.Audio.Fmod.Interop.FmodResult.ERR_TRUNCATED && size > buffer.Length)
            {
                if (size > 1024 * 1024) throw new InvalidOperationException("FMOD returned an invalid path length.");
                buffer = new byte[size];
                result = reader(handle, buffer, buffer.Length, out size);
            }

            Check(result, "Read FMOD UTF-8 path");
            int length = Array.IndexOf(buffer, (byte)0);
            return Encoding.UTF8.GetString(buffer, 0, length < 0 ? Math.Min(buffer.Length, size) : length);
        }

        public void LoadBank(string path, bool loadSampleData = true)
        {
            Alive();
            path = System.IO.Path.GetFullPath(path);
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
                global::Celeste.Audio.Fmod.Interop.FmodResult cleanup =
                    DeviceIO.StudioBankUnload(bank);
                if (cleanup != global::Celeste.Audio.Fmod.Interop.FmodResult.OK)
                    throw new AggregateException(error,
                        new global::Celeste.Audio.Fmod.Interop.FmodException(cleanup,
                            "Unload bank after sample loading failed"));
                throw;
            }

            banks.Add(path, bank);
        }

        public void LoadBanks(IEnumerable<global::Celeste.Audio.Fmod.Banks.FmodBankLoadRequest> requests)
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
                new global::Celeste.Audio.Fmod.Events.FmodEventDescriptionReference(handle, DeviceIO));
            return handle;
        }

        public global::Celeste.Audio.Fmod.Events.FmodEventInfo EventInfo(string path) => Describe(Description(path));

        private global::Celeste.Audio.Fmod.Events.FmodEventInfo Describe(IntPtr description)
        {
            string path = ReadPath(description,
                eventDescriptionPathReader);
            Check(
                DeviceIO.StudioEventDescriptionGetID(description,
                    out var id),
                "Get event ID " + path);
            Check(
                DeviceIO.StudioEventDescriptionGetLength(description,
                    out int length),
                "Get event length " + path);
            Check(
                DeviceIO.StudioEventDescriptionIsOneshot(description,
                    out int oneShot),
                "Get event one-shot flag " + path);
            Check(
                DeviceIO.StudioEventDescriptionIs3D(description,
                    out int is3D),
                "Get event spatial flag " + path);
            Check(
                DeviceIO.StudioEventDescriptionGetParameterCount(
                    description,
                    out int count),
                "Get parameter count " + path);
            var parameters = new global::Celeste.Audio.Fmod.Parameters.FmodParameterInfo[count];
            for (int i = 0; i < count; i++)
            {
                Check(
                    DeviceIO.StudioEventDescriptionGetParameterInfoByIndex(
                        description, i, out global::Celeste.Audio.Fmod.Parameters.FmodParameterDescription parameter),
                    "Get event parameter " + path);
                parameters[i] = new global::Celeste.Audio.Fmod.Parameters.FmodParameterInfo
                {
                    Name = parameter.Name, Index = parameter.Index, Minimum = parameter.Minimum,
                    Maximum = parameter.Maximum, DefaultValue = parameter.DefaultValue, Type = parameter.Type
                };
            }

            descriptions[path] =
                new global::Celeste.Audio.Fmod.Events.FmodEventDescriptionReference(description, DeviceIO);
            return new global::Celeste.Audio.Fmod.Events.FmodEventInfo
            {
                Path = path, Id = id, LengthMilliseconds = length, IsOneShot = oneShot != 0, Is3D = is3D != 0,
                Parameters = parameters
            };
        }

        public global::Celeste.Audio.Fmod.Events.FmodEventInfo[] Events()
        {
            Alive();
            var events = new Dictionary<Guid, global::Celeste.Audio.Fmod.Events.FmodEventInfo>();
            foreach (var bank in banks.Values)
            {
                Check(
                    DeviceIO.StudioBankGetEventCount(bank, out int count),
                    "Get bank event count");
                if (count == 0) continue;
                var array = new IntPtr[count];
                Check(
                    DeviceIO.StudioBankGetEventList(bank, array,
                        array.Length,
                        out count),
                    "Enumerate bank events");
                for (int i = 0; i < Math.Min(array.Length, count); i++)
                {
                    global::Celeste.Audio.Fmod.Events.FmodEventInfo info = Describe(array[i]);
                    events[info.Id] = info;
                }
            }

            return events.Values.OrderBy(e => e.Path, StringComparer.Ordinal).ToArray();
        }

        public global::Celeste.Audio.Fmod.Events.FmodEventInstance CreateEvent(string path)
        {
            var description = Description(path);
            Check(
                DeviceIO.StudioEventDescriptionCreateInstance(
                    description,
                    out var handle),
                "Create event instance " + path);
            global::Celeste.Audio.Fmod.Events.FmodEventInstance instance =
                new global::Celeste.Audio.Fmod.Events.FmodEventInstance(this, handle, path);
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

        public global::Celeste.Audio.Fmod.Events.FmodEventInstance CreateSourceEvent(string path)
        {
            if (!TrySourceDescription(path, out var description)) return null;
            var result =
                DeviceIO.StudioEventDescriptionCreateInstance(
                    description,
                    out var handle);
            return result == global::Celeste.Audio.Fmod.Interop.FmodResult.OK
                ? new global::Celeste.Audio.Fmod.Events.FmodEventInstance(this, handle, path)
                : null;
        }

        public bool GetSourceEventPlaybackFlags(string path, out bool is3D, out bool isOneshot)
        {
            is3D = false;
            isOneshot = false;
            if (!TrySourceDescription(path, out var description)) return false;
            DeviceIO.StudioEventDescriptionIs3D(description,
                out int spatial);
            DeviceIO.StudioEventDescriptionIsOneshot(description,
                out int oneshot);
            is3D = spatial != 0;
            isOneshot = oneshot != 0;
            return true;
        }

        private global::Celeste.Audio.Fmod.Interop.FmodResult CreateSourceEventDescriptionInstance(IntPtr description,
            string path,
            out global::Celeste.Audio.Fmod.Events.FmodEventReference instance)
        {
            global::Celeste.Audio.Fmod.Interop.FmodResult Original(
                out global::Celeste.Audio.Fmod.Events.FmodEventReference resultInstance)
            {
                var result =
                    DeviceIO.StudioEventDescriptionCreateInstance(
                        description,
                        out var handle);
                resultInstance = result == global::Celeste.Audio.Fmod.Interop.FmodResult.OK
                    ? new global::Celeste.Audio.Fmod.Events.FmodEventReference(this, handle, path)
                    : null;
                return result;
            }

            if (sourceDescriptionsOwner is global::Celeste.Audio.Fmod.Events.ISourceAudioInterceptionOwner audio
                && audio.AudioInterceptionPolicy is { IsEventInstanceInterceptionEnabled: true } policy)
            {
                var originalDescription =
                    new global::Celeste.Audio.Fmod.Events.FmodEventDescriptionReference(description, DeviceIO);
                string eventName = audio.GetEventName(originalDescription);
                return policy.InvokeCreateEventInstance(eventName, Original, out instance);
            }

            return Original(out instance);
        }

        public void CreateSoundSourceReference(
            string path, ref global::Celeste.Core.Audio.ISourceAudioEventReference instance, ref bool is3D,
            ref bool isOneshot)
        {
            if (!TrySourceDescription(path, out var description)) return;
            var result = CreateSourceEventDescriptionInstance(description, path, out var actualInstance);
            instance = actualInstance;
            DeviceIO.StudioEventDescriptionIs3D(description,
                out int spatial);
            is3D = spatial != 0;
            DeviceIO.StudioEventDescriptionIsOneshot(description,
                out int oneshot);
            isOneshot = oneshot != 0;
        }

        public global::Celeste.Audio.Fmod.Events.FmodEventReference CreateEventReference(string path)
            => CreateEventReference(path, out _);

        public global::Celeste.Audio.Fmod.Events.FmodEventReference CreateEventReference(string path, out bool is3D)
        {
            is3D = false;
            if (!TrySourceDescription(path, out var description)) return null;
            var result = CreateSourceEventDescriptionInstance(description, path, out var instance);
            DeviceIO.StudioEventDescriptionIs3D(description,
                out int spatial);
            is3D = spatial != 0;
            return instance;
        }

        public global::Celeste.Audio.Fmod.Events.FmodEventReference CreateSourceSnapshotReference(string path,
            bool start = true)
        {
            var instance = CreateSourceSnapshotReferenceOriginal(path);
            if (start) instance.Start();
            return instance;
        }

        private global::Celeste.Audio.Fmod.Events.FmodEventReference CreateSourceSnapshotReferenceOriginal(string path)
        {
            var lookup =
                DeviceIO.StudioSystemGetEvent(system, Utf8(path),
                    out var description);
            if (lookup != global::Celeste.Audio.Fmod.Interop.FmodResult.OK)
                throw new Exception("Snapshot " + path + " doesn't exist");
            var result = CreateSourceEventDescriptionInstance(description, path, out var instance);
            return result == global::Celeste.Audio.Fmod.Interop.FmodResult.OK ? instance : null;
        }

        internal void Forget(global::Celeste.Audio.Fmod.Events.FmodEventInstance instance)
        {
            instances.Remove(instance);
            if (currentMusic == instance) currentMusic = null;
        }

        public int InstanceCount(string path)
        {
            Check(
                DeviceIO.StudioEventDescriptionGetInstanceCount(
                    Description(path), out int count),
                "Get instance count " + path);
            return count;
        }

        public global::Celeste.Audio.Fmod.Events.FmodEventInstance CreateSnapshot(string path)
        {
            global::Celeste.Audio.Fmod.Events.FmodEventInstance instance = CreateEvent(path);
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
            global::Celeste.Audio.Fmod.Events.FmodEventInstance instance = CreateEvent(path);
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

        public void Stop(global::Celeste.Audio.Fmod.Events.FmodEventInstance instance, bool allowFadeout = true)
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
            bool paused = false;
            if (system != IntPtr.Zero &&
                DeviceIO.StudioSystemGetBus(system, Utf8(path),
                    out var bus) ==
                global::Celeste.Audio.Fmod.Interop.FmodResult.OK)
            {
                if (pause.HasValue)
                    DeviceIO.StudioBusSetPaused(bus, pause.Value ? 1 : 0);
                DeviceIO.StudioBusGetPaused(bus, out int value);
                paused = value != 0;
            }

            return paused;
        }

        public void BusStopAllNative(string path, bool immediate)
        {
            if (system != IntPtr.Zero &&
                DeviceIO.StudioSystemGetBus(system, Utf8(path),
                    out var bus) ==
                global::Celeste.Audio.Fmod.Interop.FmodResult.OK)
                DeviceIO.StudioBusStopAllEvents(bus, immediate ? 1 : 0);
        }

        public global::Celeste.Audio.Fmod.Mixing.FmodBus GetBus(string path)
        {
            Alive();
            Check(
                DeviceIO.StudioSystemGetBus(system, Utf8(path),
                    out var handle), "Find bus " + path);
            return new global::Celeste.Audio.Fmod.Mixing.FmodBus(this, handle, path);
        }

        public global::Celeste.Audio.Fmod.Interop.FmodResult GetSourceVcaNative(string path, out IntPtr vca)
            => DeviceIO.StudioSystemGetVCA(system, Utf8(path), out vca);

        public global::Celeste.Audio.Fmod.Interop.FmodResult SetSourceVcaVolumeNative(IntPtr vca, float volume)
            => DeviceIO.StudioVCASetVolume(vca, volume);

        public global::Celeste.Audio.Fmod.Interop.FmodResult GetSourceVcaVolumeNative(IntPtr vca, out float volume,
            out float finalVolume)
            => DeviceIO.StudioVCAGetVolume(vca, out volume,
                out finalVolume);

        public global::Celeste.Audio.Fmod.Mixing.FmodVca GetVca(string path)
        {
            Alive();
            Check(
                DeviceIO.StudioSystemGetVCA(system, Utf8(path),
                    out var handle), "Find VCA " + path);
            return new global::Celeste.Audio.Fmod.Mixing.FmodVca(this, handle, path);
        }

        public string[] Buses()
        {
            Alive();
            var paths = new HashSet<string>();
            foreach (var bank in banks.Values)
            {
                Check(
                    DeviceIO.StudioBankGetBusCount(bank, out int count),
                    "Get bank bus count");
                if (count == 0) continue;
                var array = new IntPtr[count];
                Check(
                    DeviceIO.StudioBankGetBusList(bank, array,
                        array.Length,
                        out count),
                    "Enumerate bank buses");
                for (int i = 0; i < Math.Min(count, array.Length); i++)
                    paths.Add(ReadPath(array[i],
                        busPathReader));
            }

            return paths.OrderBy(p => p, StringComparer.Ordinal).ToArray();
        }

        public string[] Vcas()
        {
            Alive();
            var paths = new HashSet<string>();
            foreach (var bank in banks.Values)
            {
                Check(
                    DeviceIO.StudioBankGetVCACount(bank, out int count),
                    "Get bank VCA count");
                if (count == 0) continue;
                var array = new IntPtr[count];
                Check(
                    DeviceIO.StudioBankGetVCAList(bank, array,
                        array.Length,
                        out count),
                    "Enumerate bank VCAs");
                for (int i = 0; i < Math.Min(count, array.Length); i++)
                    paths.Add(ReadPath(array[i],
                        vcaPathReader));
            }

            return paths.OrderBy(p => p, StringComparer.Ordinal).ToArray();
        }

        public void SetListener(System.Numerics.Vector3 position, System.Numerics.Vector3 forward,
            System.Numerics.Vector3 up)
        {
            SetListenerAttributes(new global::Celeste.Audio.Fmod.Interop.FmodAttributes
            {
                Position = new global::Celeste.Audio.Fmod.Interop.FmodVector(position.X, position.Y, position.Z),
                Forward = new global::Celeste.Audio.Fmod.Interop.FmodVector(forward.X, forward.Y, forward.Z),
                Up = new global::Celeste.Audio.Fmod.Interop.FmodVector(up.X, up.Y, up.Z)
            });
        }

        public void SetListenerAttributes(global::Celeste.Audio.Fmod.Interop.FmodAttributes attributes)
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
            foreach (global::Celeste.Audio.Fmod.Events.FmodEventInstance instance in instances.ToArray())
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
