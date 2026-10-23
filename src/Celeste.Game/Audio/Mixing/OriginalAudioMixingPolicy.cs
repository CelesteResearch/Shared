using Celeste.Audio.Fmod.Runtime;

namespace Celeste.Game.Audio.Mixing
{
    public static class OriginalAudioMixingPolicy
    {
        public static void ApplyMusicVolume(this FmodStudioRuntime runtime, int music)
            => runtime.GetVca("vca:/music").Volume = music / 10f;

        public static void ApplySfxVolume(this FmodStudioRuntime runtime, int sfx)
        {
            runtime.GetVca("vca:/gameplay_sfx").Volume = sfx / 10f;
            runtime.GetVca("vca:/ui_sfx").Volume = sfx / 10f;
        }

        public static void ApplyVolumes(this FmodStudioRuntime runtime, int music, int sfx)
        {
            runtime.ApplySfxVolume(sfx);
            runtime.ApplyMusicVolume(music);
        }
    }
}
