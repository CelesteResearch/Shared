namespace Celeste.Game.Audio.Mixing
{
    public static class OriginalAudioVcaPolicy
    {
        public static float VCAVolume(global::Celeste.Audio.Fmod.Runtime.FmodStudioRuntime runtime,
            string path, float? volume = null)
        {
            var result = runtime.GetSourceVcaNative(path, out var vca);
            float actualVolume = 1f;
            float finalVolume = 1f;
            if (result == global::Celeste.Audio.Fmod.Interop.FmodResult.OK)
            {
                if (volume.HasValue)
                    runtime.SetSourceVcaVolumeNative(vca, volume.Value);
                runtime.GetSourceVcaVolumeNative(vca, out actualVolume, out finalVolume);
            }

            return actualVolume;
        }
    }
}
