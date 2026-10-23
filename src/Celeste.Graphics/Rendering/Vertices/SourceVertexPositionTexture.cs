using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace Celeste.Graphics.Rendering.Vertices
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SourceVertexPositionTexture : ISourceVertexType
    {
        public Vector3 Position;
        public Vector2 TextureCoordinate;
        public static readonly SourceVertexDeclaration VertexDeclaration;
        SourceVertexDeclaration ISourceVertexType.VertexDeclaration => VertexDeclaration;

        static SourceVertexPositionTexture()
        {
            VertexDeclaration = new SourceVertexDeclaration(new SourceVertexElement(0,
                    SourceVertexElementFormat.Vector3, SourceVertexElementUsage.Position, 0),
                new SourceVertexElement(12, SourceVertexElementFormat.Vector2,
                    SourceVertexElementUsage.TextureCoordinate, 0));
        }

        public SourceVertexPositionTexture(Vector3 position, Vector2 textureCoordinate)
        {
            Position = position;
            TextureCoordinate = textureCoordinate;
        }
    }
}
