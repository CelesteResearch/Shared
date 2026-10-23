using System;
using System.Collections;
using System.Numerics;

namespace Celeste.Graphics.Particles.Events
{
    public readonly struct EntityParticleEvent
    {
        public readonly string Type;
        public readonly int Count;
        public readonly Vector2 Position, Range;
        public readonly float? Direction;

        public EntityParticleEvent(string type, int count, Vector2 position, Vector2 range, float? direction = null)
        {
            Type = type;
            Count = count;
            Position = position;
            Range = range;
            Direction = direction;
        }
    }
}
