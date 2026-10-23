using Celeste.Audio.Fmod.Interop;

namespace Celeste.Everest.Audio
{
    public static class EverestFmodResultChecks
    {
        public static void CheckInstalledFmodResult(this FmodResult result)
        {
            EverestGameAudioSession.CheckInstalledFmod(result);
        }
    }
}
