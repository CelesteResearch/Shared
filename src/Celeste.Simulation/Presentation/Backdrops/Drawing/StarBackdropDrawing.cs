using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation.Rendering;

namespace Celeste.Simulation.Presentation.Backdrops.Drawing
{
    internal static class StarBackdropDrawing
    {
        internal static float Mod(float value, float max) => (value % max + max) % max;

        internal static global::Celeste.Graphics.Display.ImagePlacement Rect(float x, float y, float width,
            float height, Vector4 color)
            => new global::Celeste.Graphics.Display.ImagePlacement(
                global::Celeste.Simulation.Presentation.Drawing.PrimitiveTextures.Pixel, (int)x, (int)y, 0, (int)width,
                (int)height, color: color);

        internal static float Map(float value, float min, float max, float from = 0, float to = 1)
            => Math.Min(Math.Max((value - min) / (max - min), 0f), 1f) * (to - from) + from;
    }
}
