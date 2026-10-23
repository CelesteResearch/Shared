using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace Celeste.Graphics.Rendering.Vertices
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SourceVertexPositionTexture(Vector3 position, Vector2 textureCoordinate) : ISourceVertexType
    {
        public Vector3 Position = position;
        public Vector2 TextureCoordinate = textureCoordinate;
        public static readonly SourceVertexDeclaration VertexDeclaration;
        SourceVertexDeclaration ISourceVertexType.VertexDeclaration => VertexDeclaration;

        static SourceVertexPositionTexture()
        {
            VertexDeclaration =
                new(new SourceVertexElement(0, SourceVertexElementFormat.Vector3, SourceVertexElementUsage.Position, 0),
                    new SourceVertexElement(12, SourceVertexElementFormat.Vector2,
                        SourceVertexElementUsage.TextureCoordinate, 0));
        }
    }
}
