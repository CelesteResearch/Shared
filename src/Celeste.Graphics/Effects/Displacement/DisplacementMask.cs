using System;
using System.Collections.Generic;
using System.Numerics;

namespace Celeste.Graphics.Effects.Displacement
{
    public readonly struct DisplacementMask
    {
        public readonly float X, Y, Width, Height;

        public DisplacementMask(float x, float y, float width, float height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
    }
}
