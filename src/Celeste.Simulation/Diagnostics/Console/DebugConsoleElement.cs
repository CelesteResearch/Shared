using System;
using System.Numerics;
using Celeste.Simulation;

namespace Celeste.Simulation.Diagnostics.Console
{
    // One primitive of the console's rendering. Monocle/Commands.cs:557-581 draws the input line and
    // the echo buffer with Draw.Rect + Draw.SpriteBatch.DrawString; the layout (positions, sizes,
    // wrapping) is computed in the pure console and rasterised by the host, because only the host
    // owns a font and a 1x1 pixel texture.
    public readonly struct DebugConsoleElement
    {
        public readonly bool IsText;
        public readonly float X, Y, Width, Height;
        public readonly string Text;
        public readonly Vector4 Color;

        public DebugConsoleElement(float x, float y, float width, float height, Vector4 color)
        {
            IsText = false;
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Text = null;
            Color = color;
        }

        public DebugConsoleElement(string text, float x, float y, Vector4 color)
        {
            IsText = true;
            X = x;
            Y = y;
            Width = 0f;
            Height = 0f;
            Text = text;
            Color = color;
        }
    }
}
