using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Celeste.Input;
using Celeste.Simulation.Rendering;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Player.Events
{
    public readonly struct RoomPlayerEvent
    {
        public readonly global::Celeste.Simulation.Gameplay.Player.Events.RoomPlayerEventKind Kind;
        public readonly Vector2 Position, Direction;
        public readonly string Name, Parameter;
        public readonly bool RecordForChase;
        public readonly float Value;
        public readonly global::Celeste.Simulation.Gameplay.Platforms.Collision.CollisionPlatform Platform;
        public readonly global::Celeste.Simulation.Gameplay.Player.Presentation.Particles.PlayerDustEmission? Dust;

        public RoomPlayerEvent(global::Celeste.Simulation.Gameplay.Player.Events.RoomPlayerEventKind kind,
            Vector2 position, Vector2 direction, string name,
            float value = 0, global::Celeste.Simulation.Gameplay.Platforms.Collision.CollisionPlatform platform = null,
            global::Celeste.Simulation.Gameplay.Player.Presentation.Particles.PlayerDustEmission? dust = null,
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
