using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Runtime.InteropServices;
using Celeste.Audio.Fmod.Events;
using Celeste.Audio.Fmod.Gameplay.Audio;
using Celeste.Audio.Fmod.Interop;
using Celeste.Audio.Fmod.IO;
using Celeste.Audio.Fmod.Runtime;
using Celeste.Core.Audio;
using Celeste.Core.IO.Content;
using Celeste.Core.Scheduling;
using Celeste.Game.Audio.Banks;
using Celeste.Game.Audio.Channels;
using Celeste.Game.Audio.Devices;
using Celeste.Game.Audio.Mixing;
using Celeste.Game.Audio.Spatial;
using Celeste.Game.Save.Runtime;
using Celeste.Graphics.Geometry.TwoD.Camera;
using JetBrains.Annotations;

namespace Celeste.Game.Audio.Runtime
{
    public partial class OriginalGameAudioSession : IDisposable, ISourceAudio,
        ISourceSoundSourceAudio,
        ISourceFmodEventDescriptionCache,
        ISourceAudioInterceptionOwner
    {
        private readonly object gate = new();
        private string bankDirectory;
        private bool disposed;
        protected bool ready;
        protected FmodAttributes attributes3d;
        public OriginalAudioBanks Banks { get; protected set; }
        public readonly GameAudioDevice Device;
        public readonly OriginalLevelAudioState LevelState = new();
        public OriginalAudioChannelOutput ChannelOutput { get; }

        public Dictionary<string,
            FmodEventDescriptionReference> cachedEventDescriptions = new();

        Dictionary<string,
                FmodEventDescriptionReference>
            ISourceFmodEventDescriptionCache.CachedEventDescriptions =>
            cachedEventDescriptions;

        public OriginalGameAudioSession() : this(true)
        {
        }

        public OriginalGameAudioSession(IFmodStudioDeviceIO studioDeviceIO,
            IContentMemorySource bankContentSource = null)
            : this(true, studioDeviceIO, bankContentSource)
        {
        }

        protected OriginalGameAudioSession(bool initializeOriginalBanks)
            : this(initializeOriginalBanks, NativeFmodStudioDeviceIO.Instance)
        {
        }

        protected OriginalGameAudioSession(bool initializeOriginalBanks,
            IFmodStudioDeviceIO studioDeviceIO,
            IContentMemorySource bankContentSource = null)
        {
            Device = new(studioDeviceIO, bankContentSource);
            ChannelOutput = new(this);
            if (initializeOriginalBanks) Banks = new(this);
        }

        ISourceAudioEventReference ISourceAudio.Play(string path)
        {
            return Play(path);
        }

        public float VCAVolume(string path, float? volume = null)
        {
            return OriginalAudioVcaPolicy.VCAVolume(Runtime, path, volume);
        }

        public float MusicVolume
        {
            get => VCAVolume("vca:/music");
            set => VCAVolume("vca:/music", value);
        }

        public float SfxVolume
        {
            get => VCAVolume("vca:/gameplay_sfx");
            set
            {
                VCAVolume("vca:/gameplay_sfx", value);
                VCAVolume("vca:/ui_sfx", value);
            }
        }

        public string CurrentMusic = "";

        [UsedImplicitly(ImplicitUseKindFlags.Access |
                        ImplicitUseKindFlags.Assign)]
        private FmodEventReference currentMusicEvent;

        [UsedImplicitly(ImplicitUseKindFlags.Access |
                        ImplicitUseKindFlags.Assign)]
        private FmodEventReference currentAmbientEvent;

        private FmodEventReference currentAltMusicEvent;
        private FmodEventReference mainDownSnapshot;

        [UsedImplicitly(ImplicitUseKindFlags.Access |
                        ImplicitUseKindFlags.Assign)]
        private IOriginalAudioEventNamePolicy eventNamePolicy;

        public IOriginalAudioEventNamePolicy EventNamePolicy => eventNamePolicy;

        public void InitializeSourceEventNamePolicy(IOriginalAudioEventNamePolicy policy)
        {
            if (policy == null) throw new ArgumentNullException(nameof(policy));
            if (eventNamePolicy != null)
                throw new InvalidOperationException("Audio event name policy already initialized.");
            eventNamePolicy = policy;
        }

        public FmodEventReference CurrentMusicEventInstance => currentMusicEvent;
        public FmodEventReference CurrentAmbienceEventInstance => currentAmbientEvent;

        public string GetEventName(FmodEventReference instance)
        {
            return (eventNamePolicy ?? throw new InvalidOperationException("Audio event name policy not initialized."))
                .GetEventName(instance);
        }

        private ISourceRuntimeExtensionEnvironment runtimeExtensions;

        public void BindSourceRuntimeExtensions(
            ISourceRuntimeExtensionEnvironment environment)
        {
            if (environment == null) throw new ArgumentNullException(nameof(environment));
            if (runtimeExtensions != null)
                throw new InvalidOperationException("Audio runtime extensions are already bound.");
            runtimeExtensions = environment;
        }

        private ISourceAudioInterceptionPolicy AudioInterceptionPolicy =>
            runtimeExtensions?.GetRuntimeExtension<ISourceAudioInterceptionPolicy>();

        ISourceAudioInterceptionPolicy
            ISourceAudioInterceptionOwner.AudioInterceptionPolicy =>
            AudioInterceptionPolicy;

        string ISourceAudioInterceptionOwner.GetEventName(
            FmodEventDescriptionReference description)
        {
            return (eventNamePolicy ?? throw new InvalidOperationException("Audio event name policy not initialized."))
                .GetEventName(description);
        }

        public bool SetMusic(string path, bool startPlaying = true, bool allowFadeOut = true)
        {
            return AudioInterceptionPolicy is { } policy
                ? policy.InvokeSetMusic(() =>
                    SetMusicOriginal(path, startPlaying, allowFadeOut))
                : SetMusicOriginal(path, startPlaying, allowFadeOut);
        }

        private bool SetMusicOriginal(string path, bool startPlaying, bool allowFadeOut)
        {
            if (string.IsNullOrEmpty(path) || path == "null")
            {
                Stop(currentMusicEvent, allowFadeOut);
                currentMusicEvent = null;
                CurrentMusic = "";
            }
            else if (!CurrentMusic.Equals(path, StringComparison.OrdinalIgnoreCase))
            {
                Stop(currentMusicEvent, allowFadeOut);
                var instance = CreateInstance(path, null, null);
                if (instance != null && startPlaying) instance.Start();
                currentMusicEvent = instance;
                CurrentMusic = GetEventName(instance);
                return true;
            }

            return false;
        }

        public bool SetAmbience(string path, bool startPlaying = true)
        {
            if (string.IsNullOrEmpty(path) || path == "null")
            {
                Stop(currentAmbientEvent);
                currentAmbientEvent = null;
            }
            else if (!GetEventName(currentAmbientEvent).Equals(path, StringComparison.OrdinalIgnoreCase))
            {
                Stop(currentAmbientEvent);
                var instance = CreateInstance(path, null, null);
                if (instance != null && startPlaying) instance.Start();
                currentAmbientEvent = instance;
                return true;
            }

            return false;
        }

        public void SetMusicParam(string path, float value)
        {
            if (currentMusicEvent != null) currentMusicEvent.SetParameter(path, value);
        }

        public void SetAltMusic(string path)
        {
            if (AudioInterceptionPolicy is { } policy)
                policy.InvokeSetAltMusic(() => SetAltMusicOriginal(path));
            else SetAltMusicOriginal(path);
        }

        private void SetAltMusicOriginal(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                EndSnapshot(mainDownSnapshot);
                Stop(currentAltMusicEvent);
                currentAltMusicEvent = null;
            }
            else if (!GetEventName(currentAltMusicEvent).Equals(path, StringComparison.OrdinalIgnoreCase))
            {
                if (mainDownSnapshot == null)
                    mainDownSnapshot = CreateSnapshot("snapshot:/music_mains_mute");
                else
                    ResumeSnapshot(mainDownSnapshot);
                Stop(currentAltMusicEvent);
                currentAltMusicEvent = Loop(path);
            }
        }

        public FmodEventReference Loop(string path)
        {
            var instance = CreateInstance(path, null, null);
            if (instance != null) instance.Start();
            return instance;
        }

        public CameraState CurrentCamera;

        private Vector3 SpatialPosition(Vector2 position,
            IOriginalGameSaveContext saveContext)
        {
            var center = CurrentCamera == null
                ? Vector2.Zero
                : CurrentCamera.Position + new Vector2(320f, 180f) / 2f;
            return OriginalAudioSpatialMapping.Position(position, center,
                saveContext.CurrentSave?.Assists.MirrorMode == true);
        }

        private bool musicUnderwater;
        private FmodEventReference musicUnderwaterSnapshot;
        public FmodEventReference DialogSnapshot;

        public FmodEventReference CreateSnapshot(string name, bool start = true)
        {
            return Runtime.CreateSourceSnapshotReference(name, start);
        }

        public void ResumeSnapshot(FmodEventReference snapshot)
        {
            if (snapshot != null) snapshot.Start();
        }

        public void EndSnapshot(FmodEventReference snapshot)
        {
            if (snapshot != null) snapshot.Stop();
        }

        public void ReleaseSnapshot(FmodEventReference snapshot)
        {
            if (!(snapshot != null))
                return;
            snapshot.Stop();
            snapshot.Release();
        }

        public bool MusicUnderwater
        {
            get => musicUnderwater;
            set
            {
                if (musicUnderwater == value) return;
                musicUnderwater = value;
                if (musicUnderwater)
                {
                    if (musicUnderwaterSnapshot == null)
                        musicUnderwaterSnapshot = CreateSnapshot("snapshot:/underwater");
                    else
                        ResumeSnapshot(musicUnderwaterSnapshot);
                }
                else
                {
                    EndSnapshot(musicUnderwaterSnapshot);
                }
            }
        }

        public FmodEventReference Play(string path)
        {
            var instance = CreateInstance(path, null, null);
            if (instance != null)
            {
                instance.Start();
                instance.Release();
            }

            return instance;
        }

        public FmodEventReference Play(string path, string parameter, float value)
        {
            var instance = CreateInstance(path, null, null);
            if (instance != null)
            {
                SetParameter(instance, parameter, value);
                instance.Start();
                instance.Release();
            }

            return instance;
        }

        public void SetParameter(ISourceAudioEventReference instance,
            string parameter, float value)
        {
            if (instance != null) instance.SetParameter(parameter, value);
        }

        public FmodEventReference Play(string path, Vector2 position,
            IOriginalGameSaveContext saveContext,
            string parameter = null, float value = 0f)
        {
            var instance = CreateInstance(path, position, saveContext);
            if (instance != null)
            {
                if (parameter != null) instance.SetParameter(parameter, value);
                instance.Start();
                instance.Release();
            }

            return instance;
        }

        public FmodEventReference Play(string path, Vector2 position,
            IOriginalGameSaveContext saveContext,
            string parameter, float value, string parameter2, float value2)
        {
            var instance = CreateInstance(path, position, saveContext);
            if (instance != null)
            {
                if (parameter != null) instance.SetParameter(parameter, value);
                if (parameter2 != null) instance.SetParameter(parameter2, value2);
                instance.Start();
                instance.Release();
            }

            return instance;
        }

        public FmodEventReference CreateInstance(string path,
            Vector2? position,
            IOriginalGameSaveContext saveContext)
        {
            if (path == null) return null;
            var instance = Device.CreateReference(path, out var is3D);
            if (instance != null)
                if (is3D && position.HasValue)
                    instance.SetPosition(SpatialPosition(position.Value, saveContext));

            return instance;
        }

        public void Position(FmodEventReference instance,
            Vector2 position,
            IOriginalGameSaveContext saveContext)
        {
            if (instance != null) instance.SetPosition(SpatialPosition(position, saveContext));
        }

        void ISourceSoundSourceAudio.CreateInstance(
            string path, ref ISourceAudioEventReference instance, ref bool is3D,
            ref bool isOneshot)
        {
            Device.Runtime.CreateSoundSourceReference(path, ref instance, ref is3D, ref isOneshot);
        }

        public void Pause(FmodEventReference instance)
        {
            if (instance != null) instance.SetPaused(true);
        }

        public void Resume(FmodEventReference instance)
        {
            if (instance != null) instance.SetPaused(false);
        }

        public void Stop(FmodEventReference instance, bool allowFadeOut = true)
        {
            Stop((ISourceAudioEventReference)instance, allowFadeOut);
        }

        public void Stop(ISourceAudioEventReference instance, bool allowFadeOut = true)
        {
            if (!(instance != null))
                return;
            instance.Stop(allowFadeOut);
            instance.Release();
        }

        public bool PauseMusic
        {
            get => BusPaused("bus:/music");
            set => BusPaused("bus:/music", value);
        }

        public bool PauseGameplaySfx
        {
            get => BusPaused("bus:/gameplay_sfx");
            set
            {
                BusPaused("bus:/gameplay_sfx", value);
                BusPaused("bus:/music/stings", value);
            }
        }

        public bool BusPaused(string path, bool? pause = null)
        {
            return OriginalAudioBusPolicy.BusPaused(Runtime, path, pause);
        }

        public virtual void Update()
        {
            if (!(Runtime != null && ready))
                return;
            var result = Runtime.UpdateNative();
            if (result != FmodResult.OK)
                throw new("FMOD Failed: " + result);
        }

        public FmodStudioRuntime Runtime => Device.Runtime;

        public virtual void InitializeSource(bool liveUpdate)
        {
            var studioFlags = liveUpdate ? 1u : 0u;
            Device.PublishSourceRuntime(FmodStudioRuntime.AllocateSourceSystem(
                Device.StudioDeviceIO, liveUpdate,
                this, Device.SourceOutputDevice == FmodOutputDevice.NoSound,
                Device.BankContentSource));
            CheckSourceFmod(Runtime.CreateSourceSystemNative());
            CheckSourceFmod(Runtime.InitializeSourceSystemNative(1024, studioFlags));
            attributes3d.Forward = new(0, 0, 1);
            attributes3d.Up = new(0, 1, 0);
            var listener = default(FmodAttributes);
            listener.Forward.X = 0;
            listener.Forward.Z = 0;
            listener.Forward.Z = 1;
            listener.Up = new(0, 1, 0);
            listener.Position = new(0, 0, -345);
            Runtime.SetSourceListenerNative(listener);
            ready = true;
        }

        public virtual void UnloadSource()
        {
            if (!(Runtime != null))
                return;
            CheckSourceFmod(Runtime.UnloadSourceBanksNative());
            CheckSourceFmod(Runtime.ReleaseSourceSystemNative());
            Device.PublishSourceRuntime(null);
        }

        private static void CheckSourceFmod(FmodResult result)
        {
            if (result != FmodResult.OK)
                throw new("FMOD Failed: " + result);
        }

        public void Initialize(string directory, bool noSound, bool liveUpdate)
        {
            lock (gate)
            {
                if (disposed) throw new ObjectDisposedException(nameof(OriginalGameAudioSession));
                directory = Path.GetFullPath(directory);
                if (bankDirectory != null && !string.Equals(bankDirectory, directory,
                        RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
                            ? StringComparison.OrdinalIgnoreCase
                            : StringComparison.Ordinal))
                    throw new InvalidOperationException("A game audio session cannot change bank directories.");
                Device.Initialize(OriginalAudioBankProfile.Create(directory), OriginalAudioListenerProfile.Attributes,
                    noSound, liveUpdate);
                bankDirectory = directory;
                ready = true;
            }
        }

        public void Dispose()
        {
            lock (gate)
            {
                if (disposed) return;
                disposed = true;
            }

            Device.Dispose();
        }
    }
}
