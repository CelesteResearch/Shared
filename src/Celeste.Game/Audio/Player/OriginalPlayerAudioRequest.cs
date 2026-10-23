using System.Numerics;
using Celeste.Audio.Fmod.Events;

namespace Celeste.Game.Audio.Player
{
    public readonly struct OriginalPlayerAudioRequest
    {
        public readonly string Path;
        public readonly Vector2 Position;
        public readonly FmodEventParameter Primary;
        public readonly FmodEventParameter Rain;

        public OriginalPlayerAudioRequest(string path, Vector2 position, FmodEventParameter primary,
            FmodEventParameter rain)
        {
            Path = path;
            Position = position;
            Primary = primary;
            Rain = rain;
        }
    }
}
