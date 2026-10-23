using Celeste.Core.Display;
using System;
using System.Numerics;
using System.Runtime.InteropServices;
using Celeste.Graphics.Display;

namespace Celeste.Graphics.Rendering.Vertices
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 24)]
    public struct SourceVertexPositionColorTexture : ISourceVertexType
    {
        public Vector3 Position;
        public PackedColor Color;
        public Vector2 TextureCoordinate;

        public static readonly SourceVertexDeclaration VertexDeclaration;

        SourceVertexDeclaration ISourceVertexType.VertexDeclaration => VertexDeclaration;

        static SourceVertexPositionColorTexture()
        {
            VertexDeclaration = new SourceVertexDeclaration(new SourceVertexElement(0,
                    SourceVertexElementFormat.Vector3, SourceVertexElementUsage.Position, 0),
                new SourceVertexElement(12, SourceVertexElementFormat.Color,
                    SourceVertexElementUsage.Color, 0),
                new SourceVertexElement(16, SourceVertexElementFormat.Vector2,
                    SourceVertexElementUsage.TextureCoordinate, 0));
        }

        public SourceVertexPositionColorTexture(Vector3 position, PackedColor color, Vector2 textureCoordinate)
        {
            Position = position;
            Color = color;
            TextureCoordinate = textureCoordinate;
        }
    }
}
