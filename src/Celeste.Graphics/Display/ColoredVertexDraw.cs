using System.Numerics;

namespace Celeste.Graphics.Display
{
    public readonly struct ColoredVertexDraw(ColoredVertex[] vertices, int count, Matrix4x4 matrix)
    {
        public readonly ColoredVertex[] Vertices = vertices;
        public readonly int Count = count;
        public readonly Matrix4x4 Matrix = matrix;
    }
}
