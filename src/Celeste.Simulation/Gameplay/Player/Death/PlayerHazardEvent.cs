using System;
using System.Numerics;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Player.Death
{
    public readonly struct PlayerHazardEvent
    {
        public readonly global::Celeste.Simulation.Gameplay.Player.Death.PlayerHazardEventKind Kind;
        public readonly Vector2 Position;
        public readonly global::Celeste.Simulation.Gameplay.Player.Death.PlayerDeathRequest Request;

        public PlayerHazardEvent(global::Celeste.Simulation.Gameplay.Player.Death.PlayerHazardEventKind kind,
            Vector2 position, global::Celeste.Simulation.Gameplay.Player.Death.PlayerDeathRequest request)
        {
            Kind = kind;
            Position = position;
            Request = request;
        }
    }
}
