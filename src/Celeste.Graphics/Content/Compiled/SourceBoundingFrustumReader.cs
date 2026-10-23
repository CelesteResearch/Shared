using System.Numerics;
using Celeste.Core.Geometry.Intersections;

namespace Celeste.Graphics.Content.Compiled
{
    internal class SourceBoundingFrustumReader : SourceContentTypeReader<BoundingFrustum>
    {
        internal SourceBoundingFrustumReader()
        {
        }

        protected internal override BoundingFrustum Read(SourceContentReader input, BoundingFrustum existingInstance)
        {
            return new BoundingFrustum(input.ReadMatrix(), input.ContentManager.Process.VectorArithmetic,
                input.ContentManager.Process.ExtremaArithmetic);
        }
    }
}
