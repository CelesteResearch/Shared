using Celeste.Core.Display;
using System;
using System.Numerics;
using System.Runtime.InteropServices;
using Celeste.Graphics.Display;

namespace Celeste.Graphics.Rendering.Vertices
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SourceVertexPositionColor : ISourceVertexType
    {
        public Vector3 Position;
        public PackedColor Color;

        public static readonly SourceVertexDeclaration VertexDeclaration;
        SourceVertexDeclaration ISourceVertexType.VertexDeclaration => VertexDeclaration;

        static SourceVertexPositionColor()
        {
            VertexDeclaration = new SourceVertexDeclaration(
                new SourceVertexElement(0, SourceVertexElementFormat.Vector3, SourceVertexElementUsage.Position, 0),
                new SourceVertexElement(12, SourceVertexElementFormat.Color, SourceVertexElementUsage.Color, 0));
        }

        public SourceVertexPositionColor(Vector3 position, PackedColor color)
        {
            Position = position;
            Color = color;
        }
    }
}
