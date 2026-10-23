using Celeste.Core.Geometry.Intersections;

namespace Celeste.Graphics.Content.Compiled
{
    internal class SourceBoundingBoxReader : SourceContentTypeReader<BoundingBox>
    {
        protected internal override BoundingBox Read(SourceContentReader input, BoundingBox existingInstance)
        {
            return new(input.ReadVector3(), input.ReadVector3());
        }
    }
}
