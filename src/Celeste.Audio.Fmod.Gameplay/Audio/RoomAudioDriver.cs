using Celeste.Simulation.Audio;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace Celeste.Audio.Fmod.Gameplay.Audio
{
    public sealed class RoomAudioDriver : IDisposable, IRoomAudioOutput
    {
        public readonly global::Celeste.Audio.Fmod.Runtime.FmodStudioRuntime Runtime;

        public static RoomAudioDriver Current { get; private set; }

        // Optional module adapter: applied after Audio.Play(string) starts an event,
        // matching the original CelesteTAS Audio.Play_string hook.
        public static Func<string, float?> OneShotVolumeOverride;
        public static Func<bool> LiveUpdateRequested;
        public static event Action<RoomAudioDriver> Created;
        public static event Action<RoomAudioDriver> Disposing;
        private global::Celeste.Audio.Fmod.Events.FmodEventInstance ambience, alternate, mainDown;
        public global::Celeste.Audio.Fmod.Events.FmodEventInstance DebugFreezeSnapshot;
        private readonly IRoomAudioChannelPolicy channelPolicy;
        public string CurrentMusicName { get; set; } = "";

        public global::Celeste.Audio.Fmod.Events.FmodEventInstance AmbienceEvent
        {
            get => ambience;
            set => ambience = value;
        }

        public global::Celeste.Audio.Fmod.Events.FmodEventInstance AlternateEvent
        {
            get => alternate;
            set => alternate = value;
        }

        public global::Celeste.Audio.Fmod.Events.FmodEventInstance MainDownSnapshot
        {
            get => mainDown;
            set => mainDown = value;
        }

        private readonly Dictionary<string, global::Celeste.Audio.Fmod.Events.FmodEventInstance> loops =
            new Dictionary<string, global::Celeste.Audio.Fmod.Events.FmodEventInstance>();

        private readonly HashSet<string> playingLoops = new HashSet<string>();
        private readonly Dictionary<string, bool> sourceOneShots = new Dictionary<string, bool>();

        private readonly Dictionary<string, bool> spatialEvents =
            new Dictionary<string, bool>(StringComparer.OrdinalIgnoreCase);

        private readonly HashSet<global::Celeste.Audio.Fmod.Events.FmodEventInstance> retainedSounds =
            new HashSet<global::Celeste.Audio.Fmod.Events.FmodEventInstance>();

        public readonly HashSet<string> UnboundParameters = new HashSet<string>();
        public readonly HashSet<string> MissingEvents = new HashSet<string>();
        public Vector2 CameraCenter;
        public Func<Vector2> ReadCameraCenter;
        public bool MirrorMode;
        public Func<bool> ReadMirrorMode;
        private readonly Func<Vector2, Vector2, bool, Vector3> spatialPosition;
        private Vector2 CurrentCameraCenter => ReadCameraCenter?.Invoke() ?? CameraCenter;

        private Vector3 SpatialPosition(Vector2 position)
            => spatialPosition(position, CurrentCameraCenter, ReadMirrorMode?.Invoke() ?? MirrorMode);

        public bool HasMusic => Runtime.CurrentMusic != null;
        public bool HasAmbience => ambience != null;

        public string CurrentAmbienceName => ambience?.GetCanonicalPath() ?? "";

        public RoomAudioDriver(IEnumerable<global::Celeste.Audio.Fmod.Banks.FmodBankLoadRequest> banks,
            global::Celeste.Audio.Fmod.Interop.FmodAttributes listener,
            Func<Vector2, Vector2, bool, Vector3> spatialPosition,
            IRoomAudioChannelPolicy channelPolicy, bool noSound = false, bool activate = true)
        {
            this.spatialPosition = spatialPosition ?? throw new ArgumentNullException(nameof(spatialPosition));
            this.channelPolicy = channelPolicy ?? throw new ArgumentNullException(nameof(channelPolicy));
            Runtime = new global::Celeste.Audio.Fmod.Runtime.FmodStudioRuntime(noSound,
                liveUpdate: LiveUpdateRequested?.Invoke() == true);
            try
            {
                Runtime.SetListenerAttributes(listener);
                Runtime.LoadBanks(banks);
            }
            catch
            {
                Runtime.Dispose();
                throw;
            }

            if (activate) Activate();
            Created?.Invoke(this);
        }

        public void Activate() => Current = this;

        public global::Celeste.Audio.Fmod.Events.FmodEventInstance Create(string path)
        {
            try
            {
                return Runtime.CreateEvent(path);
            }
            catch (global::Celeste.Audio.Fmod.Interop.FmodException error) when (error.Result ==
                 global::Celeste.Audio.Fmod.Interop.FmodResult
                     .ERR_EVENT_NOTFOUND)
            {
                MissingEvents.Add(path);
                return null;
            }
        }

        public static void StopRelease(global::Celeste.Audio.Fmod.Events.FmodEventInstance instance, bool fade = true)
        {
            if (instance != null && !instance.IsReleased)
            {
                instance.Stop(fade);
                instance.Release();
            }
        }

        private void Parameter(global::Celeste.Audio.Fmod.Events.FmodEventInstance instance, string name, float value)
        {
            if (instance == null) return;
            try
            {
                instance.SetParameter(name, value);
            }
            catch (global::Celeste.Audio.Fmod.Interop.FmodException error) when (error.Result ==
                 global::Celeste.Audio.Fmod.Interop.FmodResult
                     .ERR_EVENT_NOTFOUND)
            {
                UnboundParameters.Add(instance.Path + ":" + name);
            }
        }

        private bool IsSpatial(string path)
        {
            if (!spatialEvents.TryGetValue(path, out bool spatial))
            {
                spatial = Runtime.EventInfo(path).Is3D;
                spatialEvents.Add(path, spatial);
            }

            return spatial;
        }

        private void PositionIfSpatial(global::Celeste.Audio.Fmod.Events.FmodEventInstance instance, Vector2 position)
        {
            if (IsSpatial(instance.Path)) instance.SetPosition(SpatialPosition(position));
        }

        public bool SetMusic(string path, bool startPlaying = true, bool allowFadeOut = true)
            => channelPolicy.SetMusic(this, path, startPlaying, allowFadeOut);

        public bool SetAmbience(string path, bool startPlaying = true)
            => channelPolicy.SetAmbience(this, path, startPlaying);

        public void StartMusic() => Runtime.CurrentMusic?.Start();
        public void StartAmbience() => ambience?.Start();
        public void SetMusicParam(string name, float value) => Parameter(Runtime.CurrentMusic, name, value);
        public void SetAmbienceParam(string name, float value) => Parameter(ambience, name, value);

        public void SetAmbienceVolume(float value)
        {
            if (ambience != null) ambience.Volume = value;
        }

        public void SetAltMusic(string path) => channelPolicy.SetAltMusic(this, path);

        public void Play(string path)
        {
            global::Celeste.Audio.Fmod.Events.FmodEventInstance instance = Create(path);
            if (instance == null) return;
            try
            {
                instance.Start();
                var volume = OneShotVolumeOverride?.Invoke(path);
                if (volume.HasValue) instance.Volume = volume.Value;
            }
            finally
            {
                instance.Release();
            }
        }

        public void Play(string path, Vector2 position, string parameter = null, float value = 0)
        {
            global::Celeste.Audio.Fmod.Events.FmodEventInstance instance = Create(path);
            if (instance == null) return;
            try
            {
                PositionIfSpatial(instance, position);
                if (parameter != null) Parameter(instance, parameter, value);
                instance.Start();
            }
            finally
            {
                instance.Release();
            }
        }

        // Generic ordered native write. Original Player policy supplies which missing
        // parameters are diagnostic, while this adapter owns event lifetime.
        public void PlayOrdered(string path, Vector2 position,
            global::Celeste.Audio.Fmod.Events.FmodEventParameter first,
            global::Celeste.Audio.Fmod.Events.FmodEventParameter second)
        {
            global::Celeste.Audio.Fmod.Events.FmodEventInstance instance = Create(path);
            if (instance == null) return;
            try
            {
                PositionIfSpatial(instance, position);
                ApplyOrderedParameter(instance, first);
                ApplyOrderedParameter(instance, second);
                instance.Start();
            }
            finally
            {
                instance.Release();
            }
        }

        private void ApplyOrderedParameter(global::Celeste.Audio.Fmod.Events.FmodEventInstance instance,
            global::Celeste.Audio.Fmod.Events.FmodEventParameter parameter)
        {
            if (parameter.Name == null) return;
            if (parameter.MissingBehavior == global::Celeste.Audio.Fmod.Events.MissingParameterBehavior.Report)
            {
                Parameter(instance, parameter.Name, parameter.Value);
                return;
            }

            try
            {
                instance.SetParameter(parameter.Name, parameter.Value);
            }
            catch (global::Celeste.Audio.Fmod.Interop.FmodException error) when (error.Result ==
                 global::Celeste.Audio.Fmod.Interop.FmodResult
                     .ERR_EVENT_NOTFOUND)
            {
            }
        }

        public void PlayParameters(string path, Vector2 position, string parameter, float value, string parameter2,
            float value2)
        {
            global::Celeste.Audio.Fmod.Events.FmodEventInstance instance = Create(path);
            if (instance == null) return;
            try
            {
                PositionIfSpatial(instance, position);
                if (parameter != null) Parameter(instance, parameter, value);
                if (parameter2 != null) Parameter(instance, parameter2, value2);
                instance.Start();
            }
            finally
            {
                instance.Release();
            }
        }

        public void SetLoop(string key, string path, Vector2 position, bool active)
        {
            if (!active)
            {
                if (loops.TryGetValue(key, out global::Celeste.Audio.Fmod.Events.FmodEventInstance old))
                {
                    StopRelease(old);
                    loops.Remove(key);
                }

                playingLoops.Remove(key);
                sourceOneShots.Remove(key);
                return;
            }

            if (!loops.TryGetValue(key, out global::Celeste.Audio.Fmod.Events.FmodEventInstance instance))
            {
                instance = Create(path);
                if (instance == null) return;
                try
                {
                    // Audio.Loop(path, position) positions the new event before start.
                    PositionIfSpatial(instance, position);
                    instance.Start();
                    loops.Add(key, instance);
                    playingLoops.Add(key);
                }
                catch
                {
                    StopRelease(instance);
                    throw;
                }

                return;
            }

            PositionIfSpatial(instance, position);
        }

        // SoundSource.Playing is a logical flag; FMOD playback state is consulted
        // separately by SoundSource.InstancePlaying and one-shot cleanup.
        public bool IsLoopPlaying(string key)
            => key != null &&
               loops.TryGetValue(key, out global::Celeste.Audio.Fmod.Events.FmodEventInstance instance) &&
               !instance.IsReleased && playingLoops.Contains(key);

        public void SetLoopPlaying(string key, bool playing)
        {
            if (key == null ||
                !loops.TryGetValue(key, out global::Celeste.Audio.Fmod.Events.FmodEventInstance instance) ||
                instance.IsReleased) return;
            if (playing) playingLoops.Add(key);
            else playingLoops.Remove(key);
        }

        public global::Celeste.Audio.Fmod.Events.FmodEventInstance GetLoopSource(string key)
            => key != null &&
               loops.TryGetValue(key, out global::Celeste.Audio.Fmod.Events.FmodEventInstance instance) &&
               !instance.IsReleased
                ? instance
                : null;

        public void SetLoopParameter(string key, string name, float value)
        {
            if (key != null &&
                loops.TryGetValue(key, out global::Celeste.Audio.Fmod.Events.FmodEventInstance instance) &&
                !instance.IsReleased)
                ParameterTracked(instance, name, value);
        }

        public void SetLoopPaused(string key, bool paused)
        {
            if (key != null &&
                loops.TryGetValue(key, out global::Celeste.Audio.Fmod.Events.FmodEventInstance instance) &&
                !instance.IsReleased)
            {
                instance.Paused = paused;
                SetLoopPlaying(key, !paused);
            }
        }

        public void StopLoop(string key, bool allowFadeOut = true)
        {
            if (loops.TryGetValue(key, out global::Celeste.Audio.Fmod.Events.FmodEventInstance instance))
            {
                StopRelease(instance, allowFadeOut);
                loops.Remove(key);
            }

            playingLoops.Remove(key);
            sourceOneShots.Remove(key);
        }

        public void ReleaseSource(string key)
        {
            if (key != null && loops.TryGetValue(key, out global::Celeste.Audio.Fmod.Events.FmodEventInstance instance))
            {
                if (!instance.IsReleased) instance.Release();
                loops.Remove(key);
            }

            playingLoops.Remove(key);
            sourceOneShots.Remove(key);
        }

        public void PlaySource(string key, string path, Vector2 position)
            => PlaySource(key, path, position, null, 0);

        public void PlaySource(string key, string path, Vector2 position, string parameter, float value)
        {
            SetLoop(key, null, position, false);
            global::Celeste.Audio.Fmod.Events.FmodEventInstance instance = Create(path);
            if (instance == null) return;
            sourceOneShots[key] = Runtime.EventInfo(path).IsOneShot;
            if (IsSpatial(path)) instance.SetPosition(SpatialPosition(position));
            if (parameter != null) Parameter(instance, parameter, value);
            loops.Add(key, instance);
            instance.Start();
            playingLoops.Add(key);
        }

        public void UpdateSourcePosition(string key, Vector2 position)
        {
            if (!loops.TryGetValue(key, out global::Celeste.Audio.Fmod.Events.FmodEventInstance instance)) return;
            PositionIfSpatial(instance, position);
            if (sourceOneShots.TryGetValue(key, out bool oneShot) && oneShot &&
                instance.PlaybackState == global::Celeste.Audio.Fmod.Events.FmodPlaybackState.Stopped)
            {
                instance.Release();
                loops.Remove(key);
                playingLoops.Remove(key);
                sourceOneShots.Remove(key);
            }
        }

        // SoundSource.Update moves an existing event; stopping it must not restart the loop.
        public void UpdateLoopPosition(string key, Vector2 position)
        {
            if (loops.TryGetValue(key, out global::Celeste.Audio.Fmod.Events.FmodEventInstance instance))
                PositionIfSpatial(instance, position);
        }

        public global::Celeste.Audio.Fmod.Events.FmodEventInstance PlayTracked(string path)
        {
            global::Celeste.Audio.Fmod.Events.FmodEventInstance instance = Create(path);
            if (instance == null) return null;
            try
            {
                instance.Start();
                retainedSounds.Add(instance);
                return instance;
            }
            catch
            {
                instance.Release();
                throw;
            }
        }

        public global::Celeste.Audio.Fmod.Events.FmodEventInstance PlayTracked(string path, Vector2 position,
            string parameter = null, float value = 0)
        {
            global::Celeste.Audio.Fmod.Events.FmodEventInstance instance = Create(path);
            if (instance == null) return null;
            try
            {
                PositionIfSpatial(instance, position);
                if (parameter != null) Parameter(instance, parameter, value);
                instance.Start();
                retainedSounds.Add(instance);
                return instance;
            }
            catch
            {
                instance.Release();
                throw;
            }
        }

        public global::Celeste.Audio.Fmod.Events.FmodEventInstance PlaySoundSource(string path, Vector2 position,
            out global::Celeste.Audio.Fmod.Events.FmodEventInfo info,
            string parameter = null, float value = 0)
        {
            info = null;
            if (string.IsNullOrEmpty(path)) return null;
            global::Celeste.Audio.Fmod.Events.FmodEventInstance instance = Create(path);
            if (instance == null) return null;
            try
            {
                info = Runtime.EventInfo(path);
                if (info.Is3D) instance.SetPosition(SpatialPosition(position));
                if (parameter != null) Parameter(instance, parameter, value);
                instance.Start();
                return instance;
            }
            catch
            {
                instance.Release();
                throw;
            }
        }

        public void StopTracked(global::Celeste.Audio.Fmod.Events.FmodEventInstance instance)
        {
            if (instance == null) return;
            StopRelease(instance);
            retainedSounds.Remove(instance);
        }

        public void ReleaseTracked(global::Celeste.Audio.Fmod.Events.FmodEventInstance instance)
        {
            if (instance == null) return;
            try
            {
                if (!instance.IsReleased) instance.Release();
            }
            finally
            {
                retainedSounds.Remove(instance);
            }
        }

        public void PositionTracked(global::Celeste.Audio.Fmod.Events.FmodEventInstance instance, Vector2 position)
        {
            if (instance != null && !instance.IsReleased) instance.SetPosition(SpatialPosition(position));
        }

        public void ParameterTracked(global::Celeste.Audio.Fmod.Events.FmodEventInstance instance, string name,
            float value)
        {
            if (instance != null && !instance.IsReleased) Parameter(instance, name, value);
        }

        public void Update()
        {
            Runtime.Update();
            // Snapshot is required because releasing an instance can change retainedSounds.
            // ReSharper disable once UseCollectionExpression
            foreach (global::Celeste.Audio.Fmod.Events.FmodEventInstance instance in
                     new List<global::Celeste.Audio.Fmod.Events.FmodEventInstance>(retainedSounds))
                if (instance.IsReleased ||
                    instance.PlaybackState == global::Celeste.Audio.Fmod.Events.FmodPlaybackState.Stopped)
                {
                    if (!instance.IsReleased) instance.Release();
                    retainedSounds.Remove(instance);
                }
        }

        public void ClearRoomLoops()
        {
            foreach (global::Celeste.Audio.Fmod.Events.FmodEventInstance instance in loops.Values)
                StopRelease(instance);
            loops.Clear();
            playingLoops.Clear();
            sourceOneShots.Clear();
        }

        // The native FMOD owner is never cloned. Capture every event retained by this
        // driver so a scene graph restore can reuse the same restored handles.
        public AudioSnapshot CaptureSnapshot() => new AudioSnapshot(this);

        public sealed class AudioSnapshot
        {
            private readonly RoomAudioDriver owner;

            private readonly Dictionary<global::Celeste.Audio.Fmod.Events.FmodEventInstance,
                global::Celeste.Audio.Fmod.Events.FmodEventSnapshot> events =
                new Dictionary<global::Celeste.Audio.Fmod.Events.FmodEventInstance,
                    global::Celeste.Audio.Fmod.Events.FmodEventSnapshot>();

            private readonly Dictionary<global::Celeste.Audio.Fmod.Events.FmodEventInstance,
                global::Celeste.Audio.Fmod.Events.FmodEventInstance> restored =
                new Dictionary<global::Celeste.Audio.Fmod.Events.FmodEventInstance,
                    global::Celeste.Audio.Fmod.Events.FmodEventInstance>();

            private readonly global::Celeste.Audio.Fmod.Events.FmodEventInstance music,
                ambience,
                alternate,
                mainDown,
                debugFreezeSnapshot;

            private readonly string currentMusicName;
            private readonly Dictionary<string, global::Celeste.Audio.Fmod.Events.FmodEventInstance> loops;
            private readonly HashSet<string> playingLoops;
            private readonly Dictionary<string, bool> sourceOneShots;
            private readonly HashSet<global::Celeste.Audio.Fmod.Events.FmodEventInstance> retainedSounds;
            private readonly global::Celeste.Audio.Fmod.Mixing.FmodMixerSnapshot mixer;
            private readonly Vector2 cameraCenter;
            private readonly bool mirrorMode;

            internal AudioSnapshot(RoomAudioDriver driver)
            {
                owner = driver;
                music = driver.Runtime.CurrentMusic;
                currentMusicName = driver.CurrentMusicName;
                ambience = driver.ambience;
                alternate = driver.alternate;
                mainDown = driver.mainDown;
                debugFreezeSnapshot = driver.DebugFreezeSnapshot;
                loops = new Dictionary<string, global::Celeste.Audio.Fmod.Events.FmodEventInstance>(driver.loops);
                playingLoops = new HashSet<string>(driver.playingLoops);
                sourceOneShots = new Dictionary<string, bool>(driver.sourceOneShots);
                retainedSounds =
                    new HashSet<global::Celeste.Audio.Fmod.Events.FmodEventInstance>(driver.retainedSounds);
                cameraCenter = driver.CameraCenter;
                mirrorMode = driver.MirrorMode;
                mixer = new global::Celeste.Audio.Fmod.Mixing.FmodMixerSnapshot(driver.Runtime);
                Capture(music);
                Capture(ambience);
                Capture(alternate);
                Capture(mainDown);
                Capture(debugFreezeSnapshot);
                foreach (global::Celeste.Audio.Fmod.Events.FmodEventInstance instance in loops.Values)
                    Capture(instance);
                foreach (global::Celeste.Audio.Fmod.Events.FmodEventInstance instance in retainedSounds)
                    Capture(instance);
            }

            private void Capture(global::Celeste.Audio.Fmod.Events.FmodEventInstance instance)
            {
                if (instance != null && !events.ContainsKey(instance))
                    events.Add(instance, new global::Celeste.Audio.Fmod.Events.FmodEventSnapshot(instance));
            }

            public global::Celeste.Audio.Fmod.Events.FmodEventInstance RestoredEvent(
                global::Celeste.Audio.Fmod.Events.FmodEventInstance original)
                => original != null &&
                   restored.TryGetValue(original, out global::Celeste.Audio.Fmod.Events.FmodEventInstance value)
                    ? value
                    : null;

            public void Restore()
            {
                using (var prepared = PrepareRestore()) prepared.Apply();
            }

            public PreparedRestore PrepareRestore()
            {
                if (owner.Runtime.IsDisposed) throw new ObjectDisposedException(nameof(RoomAudioDriver));
                global::Celeste.Audio.Fmod.Runtime.FmodStudioRuntime runtime = owner.Runtime;
                var next =
                    new Dictionary<global::Celeste.Audio.Fmod.Events.FmodEventInstance,
                        global::Celeste.Audio.Fmod.Events.FmodEventInstance>();
                try
                {
                    foreach (var pair in events)
                        next.Add(pair.Key, pair.Value.Restore(runtime, remainPaused: true));
                }
                catch
                {
                    foreach (global::Celeste.Audio.Fmod.Events.FmodEventInstance instance in next.Values)
                        instance.Dispose();
                    throw;
                }

                return new PreparedRestore(this, next);
            }

            public sealed class PreparedRestore : IDisposable
            {
                private readonly AudioSnapshot snapshot;

                private readonly Dictionary<global::Celeste.Audio.Fmod.Events.FmodEventInstance,
                    global::Celeste.Audio.Fmod.Events.FmodEventInstance> next;

                private bool applied;

                internal PreparedRestore(AudioSnapshot snapshot,
                    Dictionary<global::Celeste.Audio.Fmod.Events.FmodEventInstance,
                        global::Celeste.Audio.Fmod.Events.FmodEventInstance> next)
                {
                    this.snapshot = snapshot;
                    this.next = next;
                }

                public global::Celeste.Audio.Fmod.Events.FmodEventInstance RestoredEvent(
                    global::Celeste.Audio.Fmod.Events.FmodEventInstance original)
                    => original != null &&
                       next.TryGetValue(original, out global::Celeste.Audio.Fmod.Events.FmodEventInstance value)
                        ? value
                        : null;

                public void Apply()
                {
                    if (applied) throw new InvalidOperationException("Audio restore was already applied.");
                    var owner = snapshot.owner;
                    global::Celeste.Audio.Fmod.Runtime.FmodStudioRuntime runtime = owner.Runtime;
                    var old = new HashSet<global::Celeste.Audio.Fmod.Events.FmodEventInstance>();
                    if (runtime.CurrentMusic != null) old.Add(runtime.CurrentMusic);
                    if (owner.ambience != null) old.Add(owner.ambience);
                    if (owner.alternate != null) old.Add(owner.alternate);
                    if (owner.mainDown != null) old.Add(owner.mainDown);
                    if (owner.DebugFreezeSnapshot != null) old.Add(owner.DebugFreezeSnapshot);
                    foreach (global::Celeste.Audio.Fmod.Events.FmodEventInstance instance in owner.loops.Values)
                        if (instance != null)
                            old.Add(instance);
                    foreach (global::Celeste.Audio.Fmod.Events.FmodEventInstance instance in owner.retainedSounds)
                        if (instance != null)
                            old.Add(instance);

                    // Assign all roots before retiring the old native handles. A repeated
                    // load then replaces the previous restored set instead of accumulating it.
                    runtime.CurrentMusic = Lookup(snapshot.music, next);
                    owner.CurrentMusicName = snapshot.currentMusicName;
                    owner.ambience = Lookup(snapshot.ambience, next);
                    owner.alternate = Lookup(snapshot.alternate, next);
                    owner.mainDown = Lookup(snapshot.mainDown, next);
                    owner.DebugFreezeSnapshot = Lookup(snapshot.debugFreezeSnapshot, next);
                    owner.loops.Clear();
                    foreach (var pair in snapshot.loops) owner.loops.Add(pair.Key, Lookup(pair.Value, next));
                    owner.playingLoops.Clear();
                    foreach (var key in snapshot.playingLoops) owner.playingLoops.Add(key);
                    owner.sourceOneShots.Clear();
                    foreach (var pair in snapshot.sourceOneShots) owner.sourceOneShots.Add(pair.Key, pair.Value);
                    owner.retainedSounds.Clear();
                    foreach (global::Celeste.Audio.Fmod.Events.FmodEventInstance instance in snapshot.retainedSounds)
                        owner.retainedSounds.Add(Lookup(instance, next));
                    owner.CameraCenter = snapshot.cameraCenter;
                    owner.MirrorMode = snapshot.mirrorMode;
                    snapshot.restored.Clear();
                    foreach (var pair in next) snapshot.restored.Add(pair.Key, pair.Value);
                    applied = true;
                    foreach (global::Celeste.Audio.Fmod.Events.FmodEventInstance instance in old)
                        if (!instance.IsReleased && !next.ContainsValue(instance))
                        {
                            instance.Stop(false);
                            instance.Release();
                        }

                    snapshot.mixer.Restore(runtime);
                    runtime.Flush();
                }

                public void Dispose()
                {
                    if (applied) return;
                    foreach (global::Celeste.Audio.Fmod.Events.FmodEventInstance instance in next.Values)
                        instance.Dispose();
                    next.Clear();
                }
            }

            public void Activate()
            {
                foreach (var pair in restored)
                    if (!events[pair.Key].Paused && !pair.Value.IsReleased)
                        pair.Value.Paused = false;
            }

            private static global::Celeste.Audio.Fmod.Events.FmodEventInstance Lookup(
                global::Celeste.Audio.Fmod.Events.FmodEventInstance original,
                Dictionary<global::Celeste.Audio.Fmod.Events.FmodEventInstance,
                        global::Celeste.Audio.Fmod.Events.FmodEventInstance>
                    map)
                => original == null ? null : map[original];
        }

        public void Dispose()
        {
            Disposing?.Invoke(this);
            if (ReferenceEquals(Current, this)) Current = null;
            Runtime.Dispose();
        }
    }
}
