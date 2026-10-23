using Celeste.Audio.Fmod.Interop;

namespace Celeste.Game.Audio.Devices
{
    public static class OriginalAudioListenerProfile
    {
        public static FmodAttributes Attributes => new FmodAttributes
        {
            Position = new FmodVector(0, 0, -345),
            Forward = new FmodVector(0, 0, 1),
            Up = new FmodVector(0, 1, 0)
        };
    }
}
