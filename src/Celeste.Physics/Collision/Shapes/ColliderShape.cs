using System.Collections.Generic;
using System.Numerics;

namespace Celeste.Physics.Collision.Shapes
{
    public sealed class ColliderShape
    {
        public readonly global::Celeste.Core.Geometry.Bounds Bounds;

        public ColliderShape(global::Celeste.Core.Geometry.Bounds bounds)
        {
            Bounds = bounds;
        }
    }
}
