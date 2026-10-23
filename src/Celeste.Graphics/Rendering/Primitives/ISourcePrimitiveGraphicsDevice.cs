using Celeste.Graphics.Rendering.Effects;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Rendering.States;
using Celeste.Graphics.Rendering.Vertices;

namespace Celeste.Graphics.Rendering.Primitives
{
    public interface ISourcePrimitiveGraphicsDevice
    {
        SourceEffect FxPrimitive { get; }
        int ViewportWidth { get; }
        int ViewportHeight { get; }
        void SetRasterizerState(SourceRasterizerState state);
        void SetBlendState(SourceBlendState state);

        void DrawUserTriangleList<T>(T[] vertices, int vertexOffset, int primitiveCount)
            where T : struct, ISourceVertexType;

        void DrawUserIndexedTriangleList<T>(T[] vertices, int vertexOffset, int vertexCount, int[] indices,
            int indexOffset,
            int primitiveCount) where T : struct, ISourceVertexType;
    }
}
