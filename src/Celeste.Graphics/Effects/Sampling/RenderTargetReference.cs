using System;
using System.Collections.Generic;
using System.Numerics;

namespace Celeste.Graphics.Effects.Sampling
{
    public readonly struct RenderTargetReference
    {
        public readonly object Handle;
        public readonly int Width, Height;

        public RenderTargetReference(object handle, int width, int height)
        {
            Handle = handle;
            Width = width;
            Height = height;
        }
    }
}
