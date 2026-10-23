using System.Numerics;
using System.Runtime.CompilerServices;
using Celeste.Core.Display;

namespace Celeste.Graphics.Rendering.Vertices
{
    public static class VertexColorQuadWriter
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write(SourceVertexPositionColor[] vertices, ref int index,
            Vector2 a, PackedColor ca, Vector2 b, PackedColor cb,
            Vector2 c, PackedColor cc, Vector2 d, PackedColor cd)
        {
            vertices[index].Position.X = a.X;
            vertices[index].Position.Y = a.Y;
            vertices[index++].Color = ca;
            vertices[index].Position.X = b.X;
            vertices[index].Position.Y = b.Y;
            vertices[index++].Color = cb;
            vertices[index].Position.X = c.X;
            vertices[index].Position.Y = c.Y;
            vertices[index++].Color = cc;
            vertices[index].Position.X = a.X;
            vertices[index].Position.Y = a.Y;
            vertices[index++].Color = ca;
            vertices[index].Position.X = c.X;
            vertices[index].Position.Y = c.Y;
            vertices[index++].Color = cc;
            vertices[index].Position.X = d.X;
            vertices[index].Position.Y = d.Y;
            vertices[index++].Color = cd;
        }
    }
}
