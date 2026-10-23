using System;
using System.Numerics;
using System.Runtime.InteropServices;
using Celeste.Core.Display;

namespace Celeste.Graphics.Rendering.Vertices
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SourceVertexPositionColor(Vector3 position, PackedColor color) : ISourceVertexType
    {
        public Vector3 Position = position;
        public PackedColor Color = color;
        public static readonly SourceVertexDeclaration VertexDeclaration;
        SourceVertexDeclaration ISourceVertexType.VertexDeclaration => VertexDeclaration;

        static SourceVertexPositionColor()
        {
            VertexDeclaration =
                new(new SourceVertexElement(0, SourceVertexElementFormat.Vector3, SourceVertexElementUsage.Position, 0),
                    new SourceVertexElement(12, SourceVertexElementFormat.Color, SourceVertexElementUsage.Color, 0));
        }
    }
}
