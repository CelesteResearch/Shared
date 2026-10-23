using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Audio.Fmod.Banks;
using Celeste.Audio.Fmod.Events;
using Celeste.Audio.Fmod.Interop;
using Celeste.Audio.Fmod.Mixing;
using Celeste.Audio.Fmod.Runtime;
using Celeste.Simulation.Audio;

namespace Celeste.Audio.Fmod.Gameplay.Audio
{
    public sealed class RoomAudioDriver : IDisposable, IRoomAudioOutput
    {
        public readonly FmodStudioRuntime Runtime;

        public static RoomAudioDriver Current { get; private set; }

        // Optional module adapter: applied after Audio.Play(string) starts an event,
        // matching the original CelesteTAS Audio.Play_string hook.
        public static Func<string, float?> OneShotVolumeOverride;
        public static Func<bool> LiveUpdateRequested;
        public static event Action<RoomAudioDriver> Created;
        public static event Action<RoomAudioDriver> Disposing;
        public FmodEventInstance DebugFreezeSnapshot;
        private readonly IRoomAudioChannelPolicy channelPolicy;
        public string CurrentMusicName { get; set; } = "";

        public FmodEventInstance AmbienceEvent { get; set; }

        public FmodEventInstance AlternateEvent { get; set; }

        public FmodEventInstance MainDownSnapshot { get; set; }

        private readonly Dictionary<string, FmodEventInstance> loops = new();

        private readonly HashSet<string> playingLoops = [];
        private readonly Dictionary<string, bool> sourceOneShots = new();

        private readonly Dictionary<string, bool> spatialEvents = new(StringComparer.OrdinalIgnoreCase);

        private readonly HashSet<FmodEventInstance> retainedSounds = [];

        public readonly HashSet<string> UnboundParameters = [];
        public readonly HashSet<string> MissingEvents = [];
        public Vector2 CameraCenter;
        public Func<Vector2> ReadCameraCenter;
        public bool MirrorMode;
        public Func<bool> ReadMirrorMode;
        private readonly Func<Vector2, Vector2, bool, Vector3> spatialPosition;
        private Vector2 CurrentCameraCenter => ReadCameraCenter?.Invoke() ?? CameraCenter;

        private Vector3 SpatialPosition(Vector2 position)
        {
            return spatialPosition(position, CurrentCameraCenter, ReadMirrorMode?.Invoke() ?? MirrorMode);
        }

        public bool HasMusic => Runtime.CurrentMusic != null;
        public bool HasAmbience => AmbienceEvent != null;

        public string CurrentAmbienceName => AmbienceEvent?.GetCanonicalPath() ?? "";

        public RoomAudioDriver(IEnumerable<FmodBankLoadRequest> banks,
            FmodAttributes listener,
            Func<Vector2, Vector2, bool, Vector3> spatialPosition,
            IRoomAudioChannelPolicy channelPolicy, bool noSound = false, bool activate = true)
        {
            this.spatialPosition = spatialPosition ?? throw new ArgumentNullException(nameof(spatialPosition));
            this.channelPolicy = channelPolicy ?? throw new ArgumentNullException(nameof(channelPolicy));
            Runtime = new(noSound,
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

        public void Activate()
        {
            Current = this;
        }

        public FmodEventInstance Create(string path)
        {
            try
            {
                return Runtime.CreateEvent(path);
            }
            catch (FmodException error) when (error.Result ==
                                              FmodResult
                                                  .ERR_EVENT_NOTFOUND)
            {
                MissingEvents.Add(path);
                return null;
            }
        }

        public static void StopRelease(FmodEventInstance instance, bool fade = true)
        {
            if (instance != null && !instance.IsReleased)
            {
                instance.Stop(fade);
                instance.Release();
            }
        }

        private void Parameter(FmodEventInstance instance, string name, float value)
        {
            if (instance == null) return;
            try
            {
                instance.SetParameter(name, value);
            }
            catch (FmodException error) when (error.Result ==
                                              FmodResult
                                                  .ERR_EVENT_NOTFOUND)
            {
                UnboundParameters.Add(instance.Path + ":" + name);
            }
        }

        private bool IsSpatial(string path)
        {
            if (!spatialEvents.TryGetValue(path, out var spatial))
            {
                spatial = Runtime.EventInfo(path).Is3D;
                spatialEvents.Add(path, spatial);
            }

            return spatial;
        }

        private void PositionIfSpatial(FmodEventInstance instance, Vector2 position)
        {
            if (IsSpatial(instance.Path)) instance.SetPosition(SpatialPosition(position));
        }

        public bool SetMusic(string path, bool startPlaying = true, bool allowFadeOut = true)
        {
            return channelPolicy.SetMusic(this, path, startPlaying, allowFadeOut);
        }

        public bool SetAmbience(string path, bool startPlaying = true)
        {
            return channelPolicy.SetAmbience(this, path, startPlaying);
        }

        public void StartMusic()
        {
            Runtime.CurrentMusic?.Start();
        }

        public void StartAmbience()
        {
            AmbienceEvent?.Start();
        }

        public void SetMusicParam(string name, float value)
        {
            Parameter(Runtime.CurrentMusic, name, value);
        }

        public void SetAmbienceParam(string name, float value)
        {
            Parameter(AmbienceEvent, name, value);
        }

        public void SetAmbienceVolume(float value)
        {
            if (AmbienceEvent != null) AmbienceEvent.Volume = value;
        }

        public void SetAltMusic(string path)
        {
            channelPolicy.SetAltMusic(this, path);
        }

        public void Play(string path)
        {
            var instance = Create(path);
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
            var instance = Create(path);
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
            FmodEventParameter first,
            FmodEventParameter second)
        {
            var instance = Create(path);
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

        private void ApplyOrderedParameter(FmodEventInstance instance,
            FmodEventParameter parameter)
        {
            if (parameter.Name == null) return;
            if (parameter.MissingBehavior == MissingParameterBehavior.Report)
            {
                Parameter(instance, parameter.Name, parameter.Value);
                return;
            }

            try
            {
                instance.SetParameter(parameter.Name, parameter.Value);
            }
            catch (FmodException error) when (error.Result ==
                                              FmodResult
                                                  .ERR_EVENT_NOTFOUND)
            {
            }
        }

        public void PlayParameters(string path, Vector2 position, string parameter, float value, string parameter2,
            float value2)
        {
            var instance = Create(path);
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
                if (loops.TryGetValue(key, out var old))
                {
                    StopRelease(old);
                    loops.Remove(key);
                }

                playingLoops.Remove(key);
                sourceOneShots.Remove(key);
                return;
            }

            if (!loops.TryGetValue(key, out var instance))
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
        {
            return key != null &&
                   loops.TryGetValue(key, out var instance) &&
                   !instance.IsReleased && playingLoops.Contains(key);
        }

        public void SetLoopPlaying(string key, bool playing)
        {
            if (key == null ||
                !loops.TryGetValue(key, out var instance) ||
                instance.IsReleased) return;
            if (playing) playingLoops.Add(key);
            else playingLoops.Remove(key);
        }

        public FmodEventInstance GetLoopSource(string key)
        {
            return key != null &&
                   loops.TryGetValue(key, out var instance) &&
                   !instance.IsReleased
                ? instance
                : null;
        }

        public void SetLoopParameter(string key, string name, float value)
        {
            if (key != null &&
                loops.TryGetValue(key, out var instance) &&
                !instance.IsReleased)
                ParameterTracked(instance, name, value);
        }

        public void SetLoopPaused(string key, bool paused)
        {
            if (key != null &&
                loops.TryGetValue(key, out var instance) &&
                !instance.IsReleased)
            {
                instance.Paused = paused;
                SetLoopPlaying(key, !paused);
            }
        }

        public void StopLoop(string key, bool allowFadeOut = true)
        {
            if (loops.TryGetValue(key, out var instance))
            {
                StopRelease(instance, allowFadeOut);
                loops.Remove(key);
            }

            playingLoops.Remove(key);
            sourceOneShots.Remove(key);
        }

        public void ReleaseSource(string key)
        {
            if (key != null && loops.TryGetValue(key, out var instance))
            {
                if (!instance.IsReleased) instance.Release();
                loops.Remove(key);
            }

            playingLoops.Remove(key);
            sourceOneShots.Remove(key);
        }

        public void PlaySource(string key, string path, Vector2 position)
        {
            PlaySource(key, path, position, null, 0);
        }

        public void PlaySource(string key, string path, Vector2 position, string parameter, float value)
        {
            SetLoop(key, null, position, false);
            var instance = Create(path);
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
            if (!loops.TryGetValue(key, out var instance)) return;
            PositionIfSpatial(instance, position);
            if (sourceOneShots.TryGetValue(key, out var oneShot) && oneShot &&
                instance.PlaybackState == FmodPlaybackState.Stopped)
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
            if (loops.TryGetValue(key, out var instance))
                PositionIfSpatial(instance, position);
        }

        public FmodEventInstance PlayTracked(string path)
        {
            var instance = Create(path);
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

        public FmodEventInstance PlayTracked(string path, Vector2 position,
            string parameter = null, float value = 0)
        {
            var instance = Create(path);
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

        public FmodEventInstance PlaySoundSource(string path, Vector2 position,
            out FmodEventInfo info,
            string parameter = null, float value = 0)
        {
            info = null;
            if (string.IsNullOrEmpty(path)) return null;
            var instance = Create(path);
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

        public void StopTracked(FmodEventInstance instance)
        {
            if (instance == null) return;
            StopRelease(instance);
            retainedSounds.Remove(instance);
        }

        public void ReleaseTracked(FmodEventInstance instance)
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

        public void PositionTracked(FmodEventInstance instance, Vector2 position)
        {
            if (instance != null && !instance.IsReleased) instance.SetPosition(SpatialPosition(position));
        }

        public void ParameterTracked(FmodEventInstance instance, string name,
            float value)
        {
            if (instance != null && !instance.IsReleased) Parameter(instance, name, value);
        }

        public void Update()
        {
            Runtime.Update();
            // Snapshot is required because releasing an instance can change retainedSounds.
            // ReSharper disable once UseCollectionExpression
            foreach (var instance in
                     new List<FmodEventInstance>(retainedSounds))
                if (instance.IsReleased ||
                    instance.PlaybackState == FmodPlaybackState.Stopped)
                {
                    if (!instance.IsReleased) instance.Release();
                    retainedSounds.Remove(instance);
                }
        }

        public void ClearRoomLoops()
        {
            foreach (var instance in loops.Values)
                StopRelease(instance);
            loops.Clear();
            playingLoops.Clear();
            sourceOneShots.Clear();
        }

        // The native FMOD owner is never cloned. Capture every event retained by this
        // driver so a scene graph restore can reuse the same restored handles.
        public AudioSnapshot CaptureSnapshot()
        {
            return new(this);
        }

        public sealed class AudioSnapshot
        {
            private readonly RoomAudioDriver owner;

            private readonly Dictionary<FmodEventInstance,
                FmodEventSnapshot> events = new();

            private readonly Dictionary<FmodEventInstance,
                FmodEventInstance> restored = new();

            private readonly FmodEventInstance music,
                ambience,
                alternate,
                mainDown,
                debugFreezeSnapshot;

            private readonly string currentMusicName;
            private readonly Dictionary<string, FmodEventInstance> loops;
            private readonly HashSet<string> playingLoops;
            private readonly Dictionary<string, bool> sourceOneShots;
            private readonly HashSet<FmodEventInstance> retainedSounds;
            private readonly FmodMixerSnapshot mixer;
            private readonly Vector2 cameraCenter;
            private readonly bool mirrorMode;

            internal AudioSnapshot(RoomAudioDriver driver)
            {
                owner = driver;
                music = driver.Runtime.CurrentMusic;
                currentMusicName = driver.CurrentMusicName;
                ambience = driver.AmbienceEvent;
                alternate = driver.AlternateEvent;
                mainDown = driver.MainDownSnapshot;
                debugFreezeSnapshot = driver.DebugFreezeSnapshot;
                loops = new(driver.loops);
                playingLoops = /* ReSharper disable once UseCollectionExpression */ new(driver.playingLoops);
                sourceOneShots = new(driver.sourceOneShots);
                retainedSounds =
                    /* ReSharper disable once UseCollectionExpression */ new(driver.retainedSounds);
                cameraCenter = driver.CameraCenter;
                mirrorMode = driver.MirrorMode;
                mixer = new(driver.Runtime);
                Capture(music);
                Capture(ambience);
                Capture(alternate);
                Capture(mainDown);
                Capture(debugFreezeSnapshot);
                foreach (var instance in loops.Values)
                    Capture(instance);
                foreach (var instance in retainedSounds)
                    Capture(instance);
            }

            private void Capture(FmodEventInstance instance)
            {
                if (instance != null && !events.ContainsKey(instance))
                    events.Add(instance, new(instance));
            }

            public FmodEventInstance RestoredEvent(
                FmodEventInstance original)
            {
                return original != null &&
                       restored.TryGetValue(original, out var value)
                    ? value
                    : null;
            }

            public void Restore()
            {
                using (var prepared = PrepareRestore())
                {
                    prepared.Apply();
                }
            }

            public PreparedRestore PrepareRestore()
            {
                if (owner.Runtime.IsDisposed) throw new ObjectDisposedException(nameof(RoomAudioDriver));
                var runtime = owner.Runtime;
                var next =
                    new Dictionary<FmodEventInstance,
                        FmodEventInstance>();
                try
                {
                    foreach (var pair in events)
                        next.Add(pair.Key, pair.Value.Restore(runtime, true));
                }
                catch
                {
                    foreach (var instance in next.Values)
                        instance.Dispose();
                    throw;
                }

                return new(this, next);
            }

            public sealed class PreparedRestore : IDisposable
            {
                private readonly AudioSnapshot snapshot;

                private readonly Dictionary<FmodEventInstance,
                    FmodEventInstance> next;

                private bool applied;

                internal PreparedRestore(AudioSnapshot snapshot,
                    Dictionary<FmodEventInstance,
                        FmodEventInstance> next)
                {
                    this.snapshot = snapshot;
                    this.next = next;
                }

                public FmodEventInstance RestoredEvent(
                    FmodEventInstance original)
                {
                    return original != null &&
                           next.TryGetValue(original, out var value)
                        ? value
                        : null;
                }

                public void Apply()
                {
                    if (applied) throw new InvalidOperationException("Audio restore was already applied.");
                    var owner = snapshot.owner;
                    var runtime = owner.Runtime;
                    var old = new HashSet<FmodEventInstance>();
                    if (runtime.CurrentMusic != null) old.Add(runtime.CurrentMusic);
                    if (owner.AmbienceEvent != null) old.Add(owner.AmbienceEvent);
                    if (owner.AlternateEvent != null) old.Add(owner.AlternateEvent);
                    if (owner.MainDownSnapshot != null) old.Add(owner.MainDownSnapshot);
                    if (owner.DebugFreezeSnapshot != null) old.Add(owner.DebugFreezeSnapshot);
                    foreach (var instance in owner.loops.Values)
                        if (instance != null)
                            old.Add(instance);
                    foreach (var instance in owner.retainedSounds)
                        if (instance != null)
                            old.Add(instance);

                    // Assign all roots before retiring the old native handles. A repeated
                    // load then replaces the previous restored set instead of accumulating it.
                    runtime.CurrentMusic = Lookup(snapshot.music, next);
                    owner.CurrentMusicName = snapshot.currentMusicName;
                    owner.AmbienceEvent = Lookup(snapshot.ambience, next);
                    owner.AlternateEvent = Lookup(snapshot.alternate, next);
                    owner.MainDownSnapshot = Lookup(snapshot.mainDown, next);
                    owner.DebugFreezeSnapshot = Lookup(snapshot.debugFreezeSnapshot, next);
                    owner.loops.Clear();
                    foreach (var pair in snapshot.loops) owner.loops.Add(pair.Key, Lookup(pair.Value, next));
                    owner.playingLoops.Clear();
                    foreach (var key in snapshot.playingLoops) owner.playingLoops.Add(key);
                    owner.sourceOneShots.Clear();
                    foreach (var pair in snapshot.sourceOneShots) owner.sourceOneShots.Add(pair.Key, pair.Value);
                    owner.retainedSounds.Clear();
                    foreach (var instance in snapshot.retainedSounds)
                        owner.retainedSounds.Add(Lookup(instance, next));
                    owner.CameraCenter = snapshot.cameraCenter;
                    owner.MirrorMode = snapshot.mirrorMode;
                    snapshot.restored.Clear();
                    foreach (var pair in next) snapshot.restored.Add(pair.Key, pair.Value);
                    applied = true;
                    foreach (var instance in old)
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
                    foreach (var instance in next.Values)
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

            private static FmodEventInstance Lookup(
                FmodEventInstance original,
                Dictionary<FmodEventInstance,
                        FmodEventInstance>
                    map)
            {
                return original == null ? null : map[original];
            }
        }

        public void Dispose()
        {
            Disposing?.Invoke(this);
            if (ReferenceEquals(Current, this)) Current = null;
            Runtime.Dispose();
        }
    }
}
