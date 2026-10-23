using System.Numerics;

namespace Celeste.Core.Rendering
{
    public readonly struct SourceDebugRectangle
    {
        public readonly int X, Y, Width, Height;
        public readonly Vector4 Color;

        public SourceDebugRectangle(int x, int y, int width, int height, Vector4 color)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Color = color;
        }
    }
}
