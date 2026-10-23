using System;
using System.Collections.Generic;
using System.Numerics;

namespace Celeste.Graphics.Effects.Trails
{
    public readonly struct TrailRenderData
    {
        public readonly global::Celeste.Core.Geometry.IntRect Source;
        public readonly Vector2 Position;
        public readonly Vector4 Color;
        public readonly int Depth;
        public Vector2 Origin => new Vector2(32, 32);

        public TrailRenderData(global::Celeste.Core.Geometry.IntRect source, Vector2 position, Vector4 color, int depth)
        {
            Source = source;
            Position = position;
            Color = color;
            Depth = depth;
        }
    }
}
