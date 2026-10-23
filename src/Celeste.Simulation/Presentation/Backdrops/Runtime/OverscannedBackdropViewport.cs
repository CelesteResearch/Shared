using System;

namespace Celeste.Simulation.Presentation.Backdrops.Runtime
{
    public readonly struct OverscannedBackdropViewport
    {
        public readonly BackdropViewport Canvas;
        public readonly int Margin, Width, Height;

        public OverscannedBackdropViewport(BackdropViewport canvas, int margin)
        {
            if (canvas.Width <= 0 || canvas.Height <= 0) throw new ArgumentOutOfRangeException(nameof(canvas));
            if (margin < 0) throw new ArgumentOutOfRangeException(nameof(margin));
            Canvas = canvas;
            Margin = margin;
            Width = checked(canvas.Width + margin * 2);
            Height = checked(canvas.Height + margin * 2);
        }
    }
}
