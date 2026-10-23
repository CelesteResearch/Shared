using Celeste.Core.Geometry;

namespace Celeste.Physics.Collision.Shapes
{
    public sealed class ColliderShape
    {
        public readonly Bounds Bounds;

        public ColliderShape(Bounds bounds)
        {
            Bounds = bounds;
        }
    }
}
