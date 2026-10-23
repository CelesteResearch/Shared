using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using Celeste.Audio.Fmod.Banks;
using Celeste.Audio.Fmod.Events;
using Celeste.Audio.Fmod.Interop;
using Celeste.Audio.Fmod.IO;
using Celeste.Audio.Fmod.Runtime;
using Celeste.Core.IO.Content;
using Celeste.Core.Scheduling;
using Celeste.Everest.Content.Assets;
using Celeste.Everest.Content.Registry;
using Celeste.Everest.Content.Types.Audio;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Everest.Modules.Runtime;
using Celeste.Everest.Runtime;
using Celeste.Game.Audio.Runtime;
using Celeste.Game.Execution;
using Celeste.Game.Settings;

namespace Celeste.Everest.Audio
{
    public sealed class EverestGameAudioSession : OriginalGameAudioSession, ISourceFmodEventDescriptionPolicy
    {
        private readonly ISourceEngineContext engine;
        private bool IsHeadless => ((IEverestHeadlessEnvironment)engine).IsHeadless;
        private EverestCoreSettings Settings => ((IEverestCoreSettingsEnvironment)engine).CurrentCoreSettings;
        private SettingsState OriginalSettings => ((ISettingsContext)engine).Settings;
        private EverestContentRegistry Content => ((IEverestContentRegistryEnvironment)engine).SourceContentRegistry;
        private EverestLoggerProcess Logger => ((IEverestLoggerProcessEnvironment)engine).Logger;
        private EverestAudioEventNamePolicy Names => (EverestAudioEventNamePolicy)EventNamePolicy;
        private EverestAudioBanks SourceBanks => (EverestAudioBanks)Banks;

        public Dictionary<string, FmodEventDescriptionReference> cachedModEvents = new();

        private readonly Dictionary<string, HashSet<Guid>> usedGuids = new();
        private readonly HashSet<string> ingestedModBankPaths = [];
        private int modBankHandleLast = 2782;
        private readonly Dictionary<nint, EverestContentAsset> modBankAssets = new();
        private readonly Dictionary<nint, Stream> modBankStreams = new();
        private readonly FmodFileOpenCallback ModBankOpen;
        private readonly FmodFileCloseCallback ModBankClose;
        private readonly FmodFileReadCallback ModBankRead;
        private readonly FmodFileSeekCallback ModBankSeek;
        public bool AudioInitialized { get; private set; }

        public EverestGameAudioSession(ISourceEngineContext engine)
            : this(engine, NativeFmodStudioDeviceIO.Instance)
        {
        }

        public EverestGameAudioSession(ISourceEngineContext engine,
            IFmodStudioDeviceIO studioDeviceIO,
            IContentMemorySource bankContentSource = null)
            : base(false, studioDeviceIO, bankContentSource)
        {
            this.engine = engine;
            Banks = new EverestAudioBanks(this, engine);
            ModBankOpen = OpenModBank;
            ModBankClose = CloseModBank;
            ModBankRead = ReadModBank;
            ModBankSeek = SeekModBank;
        }

        private FmodResult OpenModBank(FmodStringWrapper name, ref uint filesize, ref nint handle, nint userdata)
        {
            var stream = modBankAssets[userdata].Stream;
            filesize = (uint)stream.Length;
            modBankStreams[handle = ++modBankHandleLast] = stream;
            return FmodResult.OK;
        }

        private FmodResult CloseModBank(nint handle, nint userdata)
        {
            modBankStreams[handle].Dispose();
            modBankStreams[handle] = null;
            return FmodResult.OK;
        }

        private FmodResult ReadModBank(nint handle, nint buffer, uint sizebytes, ref uint bytesread, nint userdata)
        {
            bytesread = 0u;
            var stream = modBankStreams[handle];
            var array = new byte[Math.Min(65536u, sizebytes)];
            int num;
            while ((num = stream.Read(array, 0, Math.Min(array.Length, (int)(sizebytes - bytesread)))) > 0)
            {
                Marshal.Copy(array, 0, (nint)(buffer + bytesread), num);
                bytesread += (uint)num;
            }

            return bytesread < sizebytes ? FmodResult.ERR_FILE_EOF : FmodResult.OK;
        }

        private FmodResult SeekModBank(nint handle, uint pos, nint userdata)
        {
            modBankStreams[handle].Seek(pos, SeekOrigin.Begin);
            return FmodResult.OK;
        }

        internal static void CheckInstalledFmod(FmodResult result)
        {
            if (result != FmodResult.OK)
                throw new($"FMOD Failed: {result} ({FmodSourceError.String(result)})");
        }

        public override void InitializeSource(bool liveUpdate)
        {
            if (IsHeadless)
            {
                Device.PublishSourceRuntime(FmodStudioRuntime.AllocateSourceSystem(Device.StudioDeviceIO, false, this,
                    Device.SourceOutputDevice == FmodOutputDevice.NoSound, Device.BankContentSource));
                Runtime.BindSourceDescriptionPolicy(this);
                return;
            }

            var launchWithFmodLiveUpdate = OriginalSettings.LaunchWithFMODLiveUpdate;
            OriginalSettings.LaunchWithFMODLiveUpdate |= Settings.LaunchWithFMODLiveUpdateInEverest;
            var studioFlags = 0u;
            if (OriginalSettings.LaunchWithFMODLiveUpdate) studioFlags = 1u;
            Device.PublishSourceRuntime(FmodStudioRuntime.AllocateSourceSystem(
                Device.StudioDeviceIO, OriginalSettings.LaunchWithFMODLiveUpdate,
                this, Device.SourceOutputDevice == FmodOutputDevice.NoSound, Device.BankContentSource));
            CheckInstalledFmod(Runtime.CreateSourceSystemNative());
            Runtime.GetLowLevelSystemNative(out var system);
            Runtime.ConfigureSourcePlatformNative(system);
            CheckInstalledFmod(Runtime.InitializeSourceSystemNative(1024, studioFlags));
            attributes3d.Forward = new(0f, 0f, 1f);
            attributes3d.Up = new(0f, 1f, 0f);
            var listener = default(FmodAttributes);
            listener.Forward.X = 0f;
            listener.Forward.Z = 0f;
            listener.Forward.Z = 1f;
            listener.Up = new(0f, 1f, 0f);
            listener.Position = new(0f, 0f, -345f);
            Runtime.SetSourceListenerNative(listener);
            ready = true;
            OriginalSettings.LaunchWithFMODLiveUpdate = launchWithFmodLiveUpdate;
            Runtime.BindSourceDescriptionPolicy(this);
            var directory = EngineRuntime.ContentDirectory;
            Banks.Master = SourceBanks.Load(directory, "Master Bank", true);
            Banks.Music = SourceBanks.Load(directory, "music", false);
            Banks.Sfxs = SourceBanks.Load(directory, "sfx", false);
            Banks.UI = SourceBanks.Load(directory, "ui", false);
            Banks.DlcMusic = SourceBanks.Load(directory, "dlc_music", false);
            Banks.DlcSfxs = SourceBanks.Load(directory, "dlc_sfx", false);
            foreach (var value in SourceBanks.Banks.Values)
            {
                value.GetEventListNative(out var array);
                foreach (var eventDescription in array)
                    if (eventDescription.IsValidNative())
                    {
                        eventDescription.GetID(out var id);
                        eventDescription.GetPath(out var path);
                        Names.cachedPaths[id] = path;
                        usedGuids[path] = [id];
                    }
            }

            lock (Content.Map)
            {
                foreach (var item in Content.Map.Values.Where(asset =>
                             asset.Type == typeof(AssetTypeBank)))
                    if (!ingestedModBankPaths.Contains(item.PathVirtual))
                        IngestBank(item);
            }

            AudioInitialized = true;
        }

        public void IngestNewBanks()
        {
            if (IsHeadless) return;
            lock (Content.Map)
            {
                foreach (var item in Content.Map.Values.Where(asset =>
                             asset.Type == typeof(AssetTypeBank)))
                    if (!ingestedModBankPaths.Contains(item.PathVirtual))
                        IngestBank(item);
            }
        }

        public FmodBankReference IngestBank(EverestContentAsset asset)
        {
            if (IsHeadless) return new(IntPtr.Zero, Device.StudioDeviceIO);
            Logger.Log(EverestLogLevel.Verbose, "Audio.IngestBank", asset.PathVirtual);
            ingestedModBankPaths.Add(asset.PathVirtual);
            if (SourceBanks.ModCache.TryGetValue(asset, out var value)) return value;
            FmodResult result;
            if (Settings.UnpackFMODBanks)
            {
                result = Runtime.LoadSourceBankNative(asset.GetCachedPath(), out var bank);
                value = result == FmodResult.OK ? bank : null;
            }
            else
            {
                nint userdata;
                modBankAssets[userdata = ++modBankHandleLast] = asset;
                var info = new FmodBankInfo
                {
                    size = EverestAudioBanks.SizeOfBankInfo,
                    userdata = userdata,
                    userdatalength = 0,
                    opencallback = ModBankOpen,
                    closecallback = ModBankClose,
                    readcallback = ModBankRead,
                    seekcallback = ModBankSeek,
                };
                result = Runtime.LoadBankCustomNative(info, 0, out value);
            }

            if (result == FmodResult.ERR_EVENT_ALREADY_LOADED)
            {
                if (Logger.GetLogLevel("Audio.IngestBank") <= EverestLogLevel.Warn)
                    Logger.Log(EverestLogLevel.Warn, "Audio.IngestBank",
                        $"Cannot load {asset.PathVirtual} due to conflicting events!");
                return null;
            }

            CheckInstalledFmod(result);
            if (Content.TryGet<AssetTypeGUIDs>(asset.PathVirtual + ".guids", out var metadata)) IngestGUIDs(metadata);
            SourceBanks.ModCache[asset] = value;
            value.GetID(out var id);
            var text = asset.PathVirtual;
            var length = "Audio/".Length;
            Names.cachedBankPaths[id] = "bank:/mods/" + text.Substring(length, text.Length - length);
            return value;
        }

        public void IngestGUIDs(EverestContentAsset asset)
        {
            if (IsHeadless) return;
            Logger.Log(EverestLogLevel.Verbose, "Audio.IngestGUIDs", asset.PathVirtual);
            using (asset.Stream)
            {
                using var streamReader = new StreamReader(asset.Stream);
                while (streamReader.Peek() != -1)
                {
                    var span = streamReader.ReadLine().AsSpan().Trim("\r\n").Trim();
                    var num = span.IndexOf(' ');
                    if (num != -1 && Guid.TryParse(span.Slice(0, num), out var result) &&
                        !Names.cachedPaths.ContainsKey(result) &&
                        Runtime.GetEventByIDNative(result, out var description) <= FmodResult.OK)
                    {
                        var num2 = num + 1;
                        var text = span.Slice(num2, span.Length - num2).ToString();
                        if (!usedGuids.TryGetValue(text, out var value))
                            value = usedGuids[text] = [];
                        if (value.Add(result))
                        {
                            description.UnloadSampleDataNative();
                            Names.cachedPaths[result] = text;
                            cachedModEvents[text] = description;
                        }
                    }
                }
            }
        }

        public FmodEventDescriptionReference GetEventDescription(string path)
        {
            if (IsHeadless) return FmodEventDescriptionReference.BorrowSourceHandle(IntPtr.Zero, Device.StudioDeviceIO);
            FmodEventDescriptionReference description = null;
            if (path == null || Runtime.CachedEventDescriptions.TryGetValue(path, out description)) return description;
            var result = !cachedModEvents.TryGetValue(path, out description)
                ? !path.StartsWith("guid://")
                    ? Runtime.GetEventNative(path, out description)
                    : Runtime.GetEventByIDNative(Guid.Parse(path.AsSpan(7)), out description)
                : FmodResult.OK;
            switch (result)
            {
                case FmodResult.OK:
                    description.LoadSampleDataNative();
                    Runtime.CachedEventDescriptions.Add(path, description);
                    break;
                case FmodResult.ERR_EVENT_NOTFOUND:
                    if (path != "null" && path != "event:/none" && Logger.GetLogLevel("Audio") <= EverestLogLevel.Warn)
                        Logger.Log(EverestLogLevel.Warn, "Audio", $"Event not found: {path}");
                    break;
                default:
                    throw new("FMOD getEvent failed: " + result);
            }

            return description;
        }

        public override void Update()
        {
            if (Runtime != null && ready) CheckInstalledFmod(Runtime.UpdateNative());
        }

        public override void UnloadSource()
        {
            if (!(!IsHeadless && Runtime != null))
                return;
            Runtime.UnloadSourceBanksNative();
            Runtime.ReleaseSourceSystemNative();
            Device.PublishSourceRuntime(null);
            ready = false;
        }
    }
}
