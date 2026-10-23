using Celeste.Audio.Fmod.Events;

namespace Celeste.Audio.Fmod.Gameplay.Audio
{
    // Managed channel state is captured separately from the native device lifetime.
    public sealed class GameAudioChannels
    {
        public FmodEventInstance Music, Ambience, Alternate, MainDown, DebugFreezeSnapshot;
        public string CurrentMusicName = "";
    }
}
