using System.Numerics;
using Celeste.Simulation.Gameplay.Platforms.Collision;
using Celeste.Simulation.Gameplay.Player.Presentation.Particles;

namespace Celeste.Simulation.Gameplay.Player.Events
{
    public readonly struct RoomPlayerEvent
    {
        public readonly RoomPlayerEventKind Kind;
        public readonly Vector2 Position, Direction;
        public readonly string Name, Parameter;
        public readonly bool RecordForChase;
        public readonly float Value;
        public readonly CollisionPlatform Platform;
        public readonly PlayerDustEmission? Dust;

        public RoomPlayerEvent(RoomPlayerEventKind kind,
            Vector2 position, Vector2 direction, string name,
            float value = 0, CollisionPlatform platform = null,
            PlayerDustEmission? dust = null,
            string parameter = null, bool recordForChase = true)
        {
            Kind = kind;
            Position = position;
            Direction = direction;
            Name = name;
            Value = value;
            Platform = platform;
            Dust = dust;
            Parameter = parameter;
            RecordForChase = recordForChase;
        }
    }
}
