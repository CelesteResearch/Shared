using System;
using System.Numerics;
using System.Runtime.InteropServices;
using Celeste.Core.Display;

namespace Celeste.Graphics.Rendering.Vertices
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 24)]
    public struct SourceVertexPositionColorTexture(Vector3 position, PackedColor color, Vector2 textureCoordinate)
        : ISourceVertexType
    {
        public Vector3 Position = position;
        public PackedColor Color = color;
        public Vector2 TextureCoordinate = textureCoordinate;
        public static readonly SourceVertexDeclaration VertexDeclaration;
        SourceVertexDeclaration ISourceVertexType.VertexDeclaration => VertexDeclaration;

        static SourceVertexPositionColorTexture()
        {
            VertexDeclaration = new(
                new SourceVertexElement(0, SourceVertexElementFormat.Vector3, SourceVertexElementUsage.Position, 0),
                new SourceVertexElement(12, SourceVertexElementFormat.Color, SourceVertexElementUsage.Color, 0),
                new SourceVertexElement(16, SourceVertexElementFormat.Vector2,
                    SourceVertexElementUsage.TextureCoordinate, 0));
        }
    }
}
