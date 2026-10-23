using System.Numerics;

namespace Celeste.Graphics.Particles.Events
{
    public readonly struct EntityParticleEvent(
        string type,
        int count,
        Vector2 position,
        Vector2 range,
        float? direction = null)
    {
        public readonly string Type = type;
        public readonly int Count = count;
        public readonly Vector2 Position = position, Range = range;
        public readonly float? Direction = direction;
    }
}
