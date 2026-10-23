using Celeste.Audio.Fmod.Interop;

namespace Celeste.Game.Audio.Devices
{
    public static class OriginalAudioListenerProfile
    {
        public static FmodAttributes Attributes => new()
        {
            Position = new(0, 0, -345),
            Forward = new(0, 0, 1),
            Up = new(0, 1, 0),
        };
    }
}
