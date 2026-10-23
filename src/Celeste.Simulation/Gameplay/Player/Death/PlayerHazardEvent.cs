using System.Numerics;

namespace Celeste.Simulation.Gameplay.Player.Death
{
    public readonly struct PlayerHazardEvent
    {
        public readonly PlayerHazardEventKind Kind;
        public readonly Vector2 Position;
        public readonly PlayerDeathRequest Request;

        public PlayerHazardEvent(PlayerHazardEventKind kind,
            Vector2 position, PlayerDeathRequest request)
        {
            Kind = kind;
            Position = position;
            Request = request;
        }
    }
}
