using Celeste.Audio.Fmod.Events;
using Celeste.Simulation.Gameplay.Player.Events;

namespace Celeste.Game.Audio.Player
{
    public static class OriginalPlayerAudioPolicy
    {
        public static bool TryCreate(RoomPlayerEvent message,
            bool raining, out OriginalPlayerAudioRequest request)
        {
            if (message.Kind != RoomPlayerEventKind.Sound)
            {
                request = default;
                return false;
            }

            request = new(message.Name, message.Position,
                new(message.Parameter, message.Value),
                new("raining", raining ? 1 : 0, MissingParameterBehavior.Ignore));
            return true;
        }
    }
}
