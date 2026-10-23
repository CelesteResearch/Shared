using System;
using System.Numerics;
using Celeste.Graphics.Display;
using Celeste.Simulation.Presentation.Drawing;

namespace Celeste.Simulation.Presentation.Backdrops.Drawing
{
    internal static class StarBackdropDrawing
    {
        internal static float Mod(float value, float max)
        {
            return (value % max + max) % max;
        }

        internal static ImagePlacement Rect(float x, float y, float width,
            float height, Vector4 color)
        {
            return new(
                PrimitiveTextures.Pixel, (int)x, (int)y, 0, (int)width,
                (int)height, color: color);
        }

        internal static float Map(float value, float min, float max, float from = 0, float to = 1)
        {
            return Math.Min(Math.Max((value - min) / (max - min), 0f), 1f) * (to - from) + from;
        }
    }
}
