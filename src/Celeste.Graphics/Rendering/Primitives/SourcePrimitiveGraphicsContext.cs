using Celeste.Core.Rendering.States;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Effects;
using Celeste.Graphics.Rendering.Vertices;

namespace Celeste.Graphics.Rendering.Primitives
{
    // Source scope over the existing actual device and current process GFX resources.
    // It does not allocate a physical device or own copied device state.
    public sealed class SourcePrimitiveGraphicsContext : ISourcePrimitiveGraphicsDevice
    {
        private readonly SourceGraphicsDevice device;
        private readonly ISourcePrimitiveEffectResources resources;

        public SourcePrimitiveGraphicsContext(SourceGraphicsDevice device, ISourcePrimitiveEffectResources resources)
        {
            this.device = device;
            this.resources = resources;
        }

        public SourceEffect FxPrimitive => resources.FxPrimitive;
        public int ViewportWidth => device.Viewport.Width;
        public int ViewportHeight => device.Viewport.Height;
        public void SetRasterizerState(SourceRasterizerState state) => device.RasterizerState = state;
        public void SetBlendState(SourceBlendState state) => device.BlendState = state;

        public void DrawUserTriangleList<T>(T[] vertices, int vertexOffset, int primitiveCount)
            where T : struct, ISourceVertexType
            => device.DrawUserPrimitives(SourcePrimitiveType.TriangleList, vertices, vertexOffset, primitiveCount);

        public void DrawUserIndexedTriangleList<T>(T[] vertices, int vertexOffset, int vertexCount, int[] indices,
            int indexOffset, int primitiveCount) where T : struct, ISourceVertexType
            => device.DrawUserIndexedPrimitives(SourcePrimitiveType.TriangleList, vertices, vertexOffset, vertexCount,
                indices, indexOffset, primitiveCount);
    }
}
