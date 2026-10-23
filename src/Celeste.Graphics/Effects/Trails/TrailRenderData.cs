using System.Numerics;
using Celeste.Core.Geometry;

namespace Celeste.Graphics.Effects.Trails
{
    public readonly struct TrailRenderData(IntRect source, Vector2 position, Vector4 color, int depth)
    {
        public readonly IntRect Source = source;
        public readonly Vector2 Position = position;
        public readonly Vector4 Color = color;
        public readonly int Depth = depth;
        public Vector2 Origin => new(32, 32);
    }
}
