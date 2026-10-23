using System;
using System.Collections.Generic;
using System.Numerics;

namespace Celeste.Graphics.Effects.Sampling
{
    public readonly struct TextureKernelTap
    {
        public readonly Vector2 Offset;
        public readonly float Weight;

        public TextureKernelTap(Vector2 offset, float weight)
        {
            Offset = offset;
            Weight = weight;
        }
    }
}
