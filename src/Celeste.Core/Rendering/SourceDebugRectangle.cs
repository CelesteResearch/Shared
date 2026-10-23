using System.Numerics;

namespace Celeste.Core.Rendering
{
    public readonly struct SourceDebugRectangle(int x, int y, int width, int height, Vector4 color)
    {
        public readonly int X = x, Y = y, Width = width, Height = height;
        public readonly Vector4 Color = color;
    }
}
