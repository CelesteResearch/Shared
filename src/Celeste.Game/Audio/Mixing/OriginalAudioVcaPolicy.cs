using Celeste.Audio.Fmod.Interop;
using Celeste.Audio.Fmod.Runtime;

namespace Celeste.Game.Audio.Mixing
{
    public static class OriginalAudioVcaPolicy
    {
        public static float VCAVolume(FmodStudioRuntime runtime,
            string path, float? volume = null)
        {
            var result = runtime.GetSourceVcaNative(path, out var vca);
            var actualVolume = 1f;
            var finalVolume = 1f;
            if (result == FmodResult.OK)
            {
                if (volume.HasValue)
                    runtime.SetSourceVcaVolumeNative(vca, volume.Value);
                runtime.GetSourceVcaVolumeNative(vca, out actualVolume, out finalVolume);
            }

            return actualVolume;
        }
    }
}
