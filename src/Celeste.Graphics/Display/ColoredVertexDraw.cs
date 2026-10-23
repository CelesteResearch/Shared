using System.Numerics;

namespace Celeste.Graphics.Display
{
    public readonly struct ColoredVertexDraw
    {
        public readonly ColoredVertex[] Vertices;
        public readonly int Count;
        public readonly Matrix4x4 Matrix;

        public ColoredVertexDraw(ColoredVertex[] vertices, int count, Matrix4x4 matrix)
        {
            Vertices = vertices;
            Count = count;
            Matrix = matrix;
        }
    }
}
