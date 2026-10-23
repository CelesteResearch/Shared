using System;
using Celeste.Audio.Fmod.Gameplay;
using Celeste.Game.Audio.Banks;
using Celeste.Game.Audio.Channels;
using Celeste.Game.Audio.Devices;
using Celeste.Game.Audio.Spatial;
using Celeste.Audio.Fmod.Gameplay.Audio;

namespace Celeste.Game.Audio.Runtime
{
    public partial class OriginalGameAudioSession : IDisposable, global::Celeste.Core.Audio.ISourceAudio,
        global::Celeste.Core.Audio.ISourceSoundSourceAudio,
        global::Celeste.Audio.Fmod.Runtime.ISourceFmodEventDescriptionCache,
        global::Celeste.Audio.Fmod.Events.ISourceAudioInterceptionOwner
    {
        private readonly object gate = new object();
        private string bankDirectory;
        private bool disposed;
        protected bool ready;
        protected global::Celeste.Audio.Fmod.Interop.FmodAttributes attributes3d;
        public OriginalAudioBanks Banks { get; protected set; }
        public readonly GameAudioDevice Device;
        public readonly OriginalLevelAudioState LevelState = new OriginalLevelAudioState();
        public OriginalAudioChannelOutput ChannelOutput { get; }

        public global::System.Collections.Generic.Dictionary<string,
            global::Celeste.Audio.Fmod.Events.FmodEventDescriptionReference> cachedEventDescriptions = new();

        global::System.Collections.Generic.Dictionary<string,
                global::Celeste.Audio.Fmod.Events.FmodEventDescriptionReference>
            global::Celeste.Audio.Fmod.Runtime.ISourceFmodEventDescriptionCache.CachedEventDescriptions =>
            cachedEventDescriptions;

        public OriginalGameAudioSession() : this(true)
        {
        }

        public OriginalGameAudioSession(global::Celeste.Audio.Fmod.IO.IFmodStudioDeviceIO studioDeviceIO,
            global::Celeste.Core.IO.Content.IContentMemorySource bankContentSource = null)
            : this(true, studioDeviceIO, bankContentSource)
        {
        }

        protected OriginalGameAudioSession(bool initializeOriginalBanks)
            : this(initializeOriginalBanks, global::Celeste.Audio.Fmod.IO.NativeFmodStudioDeviceIO.Instance)
        {
        }

        protected OriginalGameAudioSession(bool initializeOriginalBanks,
            global::Celeste.Audio.Fmod.IO.IFmodStudioDeviceIO studioDeviceIO,
            global::Celeste.Core.IO.Content.IContentMemorySource bankContentSource = null)
        {
            Device = new GameAudioDevice(studioDeviceIO, bankContentSource);
            ChannelOutput = new OriginalAudioChannelOutput(this);
            if (initializeOriginalBanks) Banks = new OriginalAudioBanks(this);
        }

        global::Celeste.Core.Audio.ISourceAudioEventReference global::Celeste.Core.Audio.ISourceAudio.Play(string path)
        {
            return Play(path);
        }

        public float VCAVolume(string path, float? volume = null)
            => global::Celeste.Game.Audio.Mixing.OriginalAudioVcaPolicy.VCAVolume(Runtime, path, volume);

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
        private global::Celeste.Audio.Fmod.Events.FmodEventReference currentMusicEvent;
        private global::Celeste.Audio.Fmod.Events.FmodEventReference currentAmbientEvent;
        private global::Celeste.Audio.Fmod.Events.FmodEventReference currentAltMusicEvent;
        private global::Celeste.Audio.Fmod.Events.FmodEventReference mainDownSnapshot;
        private IOriginalAudioEventNamePolicy eventNamePolicy;
        public IOriginalAudioEventNamePolicy EventNamePolicy => eventNamePolicy;

        public void InitializeSourceEventNamePolicy(IOriginalAudioEventNamePolicy policy)
        {
            if (policy == null) throw new ArgumentNullException(nameof(policy));
            if (eventNamePolicy != null)
                throw new InvalidOperationException("Audio event name policy already initialized.");
            eventNamePolicy = policy;
        }

        public global::Celeste.Audio.Fmod.Events.FmodEventReference CurrentMusicEventInstance => currentMusicEvent;
        public global::Celeste.Audio.Fmod.Events.FmodEventReference CurrentAmbienceEventInstance => currentAmbientEvent;

        public string GetEventName(global::Celeste.Audio.Fmod.Events.FmodEventReference instance)
            => (eventNamePolicy ?? throw new InvalidOperationException("Audio event name policy not initialized."))
                .GetEventName(instance);

        private global::Celeste.Core.Scheduling.ISourceRuntimeExtensionEnvironment runtimeExtensions;

        public void BindSourceRuntimeExtensions(
            global::Celeste.Core.Scheduling.ISourceRuntimeExtensionEnvironment environment)
        {
            if (environment == null) throw new ArgumentNullException(nameof(environment));
            if (runtimeExtensions != null)
                throw new InvalidOperationException("Audio runtime extensions are already bound.");
            runtimeExtensions = environment;
        }

        private global::Celeste.Audio.Fmod.Events.ISourceAudioInterceptionPolicy AudioInterceptionPolicy =>
            runtimeExtensions?.GetRuntimeExtension<global::Celeste.Audio.Fmod.Events.ISourceAudioInterceptionPolicy>();

        global::Celeste.Audio.Fmod.Events.ISourceAudioInterceptionPolicy
            global::Celeste.Audio.Fmod.Events.ISourceAudioInterceptionOwner.AudioInterceptionPolicy =>
            AudioInterceptionPolicy;

        string global::Celeste.Audio.Fmod.Events.ISourceAudioInterceptionOwner.GetEventName(
            global::Celeste.Audio.Fmod.Events.FmodEventDescriptionReference description)
            => (eventNamePolicy ?? throw new InvalidOperationException("Audio event name policy not initialized."))
                .GetEventName(description);

        public bool SetMusic(string path, bool startPlaying = true, bool allowFadeOut = true)
            => AudioInterceptionPolicy is { } policy
                ? policy.InvokeSetMusic(() =>
                    SetMusicOriginal(path, startPlaying, allowFadeOut))
                : SetMusicOriginal(path, startPlaying, allowFadeOut);

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

        public global::Celeste.Audio.Fmod.Events.FmodEventReference Loop(string path)
        {
            var instance = CreateInstance(path, null, null);
            if (instance != null) instance.Start();
            return instance;
        }

        public global::Celeste.Graphics.Geometry.TwoD.Camera.CameraState CurrentCamera;

        private System.Numerics.Vector3 SpatialPosition(System.Numerics.Vector2 position,
            global::Celeste.Game.Save.Runtime.IOriginalGameSaveContext saveContext)
        {
            var center = CurrentCamera == null
                ? System.Numerics.Vector2.Zero
                : CurrentCamera.Position + new System.Numerics.Vector2(320f, 180f) / 2f;
            return OriginalAudioSpatialMapping.Position(position, center,
                saveContext.CurrentSave?.Assists.MirrorMode == true);
        }

        private bool musicUnderwater;
        private global::Celeste.Audio.Fmod.Events.FmodEventReference musicUnderwaterSnapshot;
        public global::Celeste.Audio.Fmod.Events.FmodEventReference DialogSnapshot;

        public global::Celeste.Audio.Fmod.Events.FmodEventReference CreateSnapshot(string name, bool start = true)
        {
            return Runtime.CreateSourceSnapshotReference(name, start);
        }

        public void ResumeSnapshot(global::Celeste.Audio.Fmod.Events.FmodEventReference snapshot)
        {
            if (snapshot != null) snapshot.Start();
        }

        public void EndSnapshot(global::Celeste.Audio.Fmod.Events.FmodEventReference snapshot)
        {
            if (snapshot != null) snapshot.Stop(true);
        }

        public void ReleaseSnapshot(global::Celeste.Audio.Fmod.Events.FmodEventReference snapshot)
        {
            if (snapshot != null)
            {
                snapshot.Stop(true);
                snapshot.Release();
            }
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
                    EndSnapshot(musicUnderwaterSnapshot);
            }
        }

        public global::Celeste.Audio.Fmod.Events.FmodEventReference Play(string path)
        {
            var instance = CreateInstance(path, null, null);
            if (instance != null)
            {
                instance.Start();
                instance.Release();
            }

            return instance;
        }

        public global::Celeste.Audio.Fmod.Events.FmodEventReference Play(string path, string parameter, float value)
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

        public void SetParameter(global::Celeste.Core.Audio.ISourceAudioEventReference instance,
            string parameter, float value)
        {
            if (instance != null) instance.SetParameter(parameter, value);
        }

        public global::Celeste.Audio.Fmod.Events.FmodEventReference Play(string path, System.Numerics.Vector2 position,
            global::Celeste.Game.Save.Runtime.IOriginalGameSaveContext saveContext,
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

        public global::Celeste.Audio.Fmod.Events.FmodEventReference Play(string path, System.Numerics.Vector2 position,
            global::Celeste.Game.Save.Runtime.IOriginalGameSaveContext saveContext,
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

        public global::Celeste.Audio.Fmod.Events.FmodEventReference CreateInstance(string path,
            System.Numerics.Vector2? position,
            global::Celeste.Game.Save.Runtime.IOriginalGameSaveContext saveContext)
        {
            if (path == null) return null;
            var instance = Device.CreateReference(path, out bool is3D);
            if (instance != null)
            {
                if (is3D && position.HasValue) instance.SetPosition(SpatialPosition(position.Value, saveContext));
            }

            return instance;
        }

        public void Position(global::Celeste.Audio.Fmod.Events.FmodEventReference instance,
            System.Numerics.Vector2 position,
            global::Celeste.Game.Save.Runtime.IOriginalGameSaveContext saveContext)
        {
            if (instance != null) instance.SetPosition(SpatialPosition(position, saveContext));
        }

        void global::Celeste.Core.Audio.ISourceSoundSourceAudio.CreateInstance(
            string path, ref global::Celeste.Core.Audio.ISourceAudioEventReference instance, ref bool is3D,
            ref bool isOneshot)
            => Device.Runtime.CreateSoundSourceReference(path, ref instance, ref is3D, ref isOneshot);

        public void Pause(global::Celeste.Audio.Fmod.Events.FmodEventReference instance)
        {
            if (instance != null) instance.SetPaused(true);
        }

        public void Resume(global::Celeste.Audio.Fmod.Events.FmodEventReference instance)
        {
            if (instance != null) instance.SetPaused(false);
        }

        public void Stop(global::Celeste.Audio.Fmod.Events.FmodEventReference instance, bool allowFadeOut = true)
            => Stop((global::Celeste.Core.Audio.ISourceAudioEventReference)instance, allowFadeOut);

        public void Stop(global::Celeste.Core.Audio.ISourceAudioEventReference instance, bool allowFadeOut = true)
        {
            if (instance != null)
            {
                instance.Stop(allowFadeOut);
                instance.Release();
            }
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
            => global::Celeste.Game.Audio.Mixing.OriginalAudioBusPolicy.BusPaused(Runtime, path, pause);

        public virtual void Update()
        {
            if (Runtime != null && ready)
            {
                var result = Runtime.UpdateNative();
                if (result != global::Celeste.Audio.Fmod.Interop.FmodResult.OK)
                    throw new Exception("FMOD Failed: " + result);
            }
        }

        public global::Celeste.Audio.Fmod.Runtime.FmodStudioRuntime Runtime => Device.Runtime;

        public virtual void InitializeSource(bool liveUpdate)
        {
            uint studioFlags = liveUpdate ? 1u : 0u;
            Device.PublishSourceRuntime(global::Celeste.Audio.Fmod.Runtime.FmodStudioRuntime.AllocateSourceSystem(
                Device.StudioDeviceIO, liveUpdate,
                this, Device.SourceOutputDevice == global::Celeste.Audio.Fmod.Interop.FmodOutputDevice.NoSound,
                Device.BankContentSource));
            CheckSourceFmod(Runtime.CreateSourceSystemNative());
            CheckSourceFmod(Runtime.InitializeSourceSystemNative(1024, studioFlags));
            attributes3d.Forward = new global::Celeste.Audio.Fmod.Interop.FmodVector(0, 0, 1);
            attributes3d.Up = new global::Celeste.Audio.Fmod.Interop.FmodVector(0, 1, 0);
            var listener = default(global::Celeste.Audio.Fmod.Interop.FmodAttributes);
            listener.Forward.X = 0;
            listener.Forward.Z = 0;
            listener.Forward.Z = 1;
            listener.Up = new global::Celeste.Audio.Fmod.Interop.FmodVector(0, 1, 0);
            listener.Position = new global::Celeste.Audio.Fmod.Interop.FmodVector(0, 0, -345);
            Runtime.SetSourceListenerNative(listener);
            ready = true;
        }

        public virtual void UnloadSource()
        {
            if (Runtime != null)
            {
                CheckSourceFmod(Runtime.UnloadSourceBanksNative());
                CheckSourceFmod(Runtime.ReleaseSourceSystemNative());
                Device.PublishSourceRuntime(null);
            }
        }

        private static void CheckSourceFmod(global::Celeste.Audio.Fmod.Interop.FmodResult result)
        {
            if (result != global::Celeste.Audio.Fmod.Interop.FmodResult.OK)
                throw new Exception("FMOD Failed: " + result);
        }

        public void Initialize(string directory, bool noSound, bool liveUpdate)
        {
            lock (gate)
            {
                if (disposed) throw new ObjectDisposedException(nameof(OriginalGameAudioSession));
                directory = System.IO.Path.GetFullPath(directory);
                if (bankDirectory != null && !string.Equals(bankDirectory, directory,
                        System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices
                            .OSPlatform.Windows)
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
