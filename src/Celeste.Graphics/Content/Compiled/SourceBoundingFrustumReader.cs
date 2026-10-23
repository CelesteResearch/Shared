using Celeste.Core.Geometry.Intersections;

namespace Celeste.Graphics.Content.Compiled
{
    internal class SourceBoundingFrustumReader : SourceContentTypeReader<BoundingFrustum>
    {
        // ReSharper disable once EmptyConstructor
        internal SourceBoundingFrustumReader()
        {
        }

        protected internal override BoundingFrustum Read(SourceContentReader input, BoundingFrustum existingInstance)
        {
            return new(input.ReadMatrix(), input.ContentManager.Process.VectorArithmetic,
                input.ContentManager.Process.ExtremaArithmetic);
        }
    }
}
