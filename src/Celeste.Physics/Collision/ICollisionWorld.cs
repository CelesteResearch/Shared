using System;
using System.Collections.Generic;
using System.Numerics;

namespace Celeste.Physics.Collision
{
    public interface ICollisionWorld
    {
        bool SolidAt(global::Celeste.Core.Geometry.Bounds bounds);
        bool SolidAt(Vector2 point);
        bool JumpThruAt(global::Celeste.Core.Geometry.Bounds bounds);
        bool JumpThruAt(global::Celeste.Core.Geometry.Bounds bounds, global::Celeste.Core.Geometry.Bounds previous);
    }
}
