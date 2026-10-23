using System.Numerics;
using Celeste.Core.Display;
using Celeste.Graphics.Rendering.Vertices;

namespace Celeste.Graphics.Geometry.Backdrops.Aurora
{
    public static class AuroraRibbonGeometry
    {
        public static void EmitSegment(SourceVertexPositionColorTexture[] vertices, ref int index,
            Vector2 first, Vector2 second, float firstHeight, float secondHeight,
            float firstTextureOffset, float secondTextureOffset, float firstOffsetY, float secondOffsetY,
            PackedColor firstColor, PackedColor secondColor, float firstBottomAlpha, float firstTopAlpha,
            float secondTopAlpha, float secondBottomAlpha)
        {
            WriteVertex(vertices, ref index, first.X, first.Y + firstOffsetY, firstTextureOffset, 1f,
                firstColor * firstBottomAlpha);
            WriteVertex(vertices, ref index, first.X, first.Y - firstHeight + firstOffsetY, firstTextureOffset, .05f,
                firstColor * firstTopAlpha);
            WriteVertex(vertices, ref index, second.X, second.Y - secondHeight + secondOffsetY, secondTextureOffset,
                .05f,
                secondColor * secondTopAlpha);
            WriteVertex(vertices, ref index, first.X, first.Y + firstOffsetY, firstTextureOffset, 1f,
                firstColor * firstBottomAlpha);
            WriteVertex(vertices, ref index, second.X, second.Y - secondHeight + secondOffsetY, secondTextureOffset,
                .05f,
                secondColor * secondTopAlpha);
            WriteVertex(vertices, ref index, second.X, second.Y + secondOffsetY, secondTextureOffset, 1f,
                secondColor * secondBottomAlpha);
        }

        public static void WriteVertex(SourceVertexPositionColorTexture[] vertices, ref int index,
            float x, float y, float u, float v, PackedColor color)
        {
            vertices[index].Color = color;
            vertices[index].Position.X = x;
            vertices[index].Position.Y = y;
            vertices[index].TextureCoordinate.X = u;
            vertices[index].TextureCoordinate.Y = v;
            index++;
        }
    }
}
