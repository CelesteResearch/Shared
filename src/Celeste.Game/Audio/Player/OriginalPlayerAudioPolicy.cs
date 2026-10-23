using Celeste.Audio.Fmod.Events;
using Celeste.Simulation;

namespace Celeste.Game.Audio.Player
{
    public static class OriginalPlayerAudioPolicy
    {
        public static bool TryCreate(global::Celeste.Simulation.Gameplay.Player.Events.RoomPlayerEvent message,
            bool raining, out OriginalPlayerAudioRequest request)
        {
            if (message.Kind != global::Celeste.Simulation.Gameplay.Player.Events.RoomPlayerEventKind.Sound)
            {
                request = default;
                return false;
            }

            request = new OriginalPlayerAudioRequest(message.Name, message.Position,
                new FmodEventParameter(message.Parameter, message.Value),
                new FmodEventParameter("raining", raining ? 1 : 0, MissingParameterBehavior.Ignore));
            return true;
        }
    }
}
