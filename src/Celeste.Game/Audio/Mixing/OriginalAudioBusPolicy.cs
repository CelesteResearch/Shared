using Celeste.Audio.Fmod.Events;
using Celeste.Audio.Fmod.Runtime;

namespace Celeste.Game.Audio.Mixing
{
    public static class OriginalAudioBusPolicy
    {
        public static bool BusPaused(FmodStudioRuntime runtime, string path, bool? pause = null)
        {
            return runtime != null && runtime.BusPausedNative(path, pause);
        }

        public static bool BusMuted(FmodStudioRuntime runtime, string path, bool? mute)
        {
            return runtime.BusMutedNative(path, mute);
        }

        public static void SetMusicPaused(this FmodStudioRuntime runtime, bool paused)
        {
            BusPaused(runtime, "bus:/music", paused);
        }

        public static void SetGameplaySfxPaused(this FmodStudioRuntime runtime, bool paused)
        {
            BusPaused(runtime, "bus:/gameplay_sfx", paused);
            BusPaused(runtime, "bus:/music/stings", paused);
        }

        // Audio.BusStopAll(path, immediate): preserve the caller's fade choice.
        public static void StopGameplaySfx(this FmodStudioRuntime runtime, bool immediate = false)
        {
            runtime?.BusStopAllNative("bus:/gameplay_sfx", immediate);
        }

        public static FmodEventInstance SetDebugFreezePaused(
            this FmodStudioRuntime runtime, FmodEventInstance snapshot, bool paused)
        {
            runtime.SetGameplaySfxPaused(paused);
            if (paused)
            {
                if (snapshot == null) snapshot = runtime.CreateSnapshot("snapshot:/pause_menu");
            }
            else
            {
                if (snapshot != null && !snapshot.IsReleased)
                {
                    snapshot.Stop();
                    snapshot.Release();
                }

                snapshot = null;
            }

            return snapshot;
        }
    }
}
