using System;

namespace Celeste.Simulation.Presentation.Backdrops.Runtime
{
    public readonly struct BackdropViewport
    {
        public readonly int Width;
        public readonly int Height;

        public BackdropViewport(int width, int height)
        {
            if (width <= 0) throw new ArgumentOutOfRangeException(nameof(width));
            if (height <= 0) throw new ArgumentOutOfRangeException(nameof(height));
            Width = width;
            Height = height;
        }
    }
}
