using System;
using System.Collections.Generic;
using System.Numerics;

namespace Celeste.Physics.Collision
{
    public interface IDetailedCollisionWorld : ICollisionWorld
    {
        PixelPlatform FirstSolidAt(global::Celeste.Core.Geometry.Bounds bounds);
        PixelPlatform FirstJumpThruAt(global::Celeste.Core.Geometry.Bounds bounds);

        PixelPlatform FirstJumpThruOutside(global::Celeste.Core.Geometry.Bounds bounds,
            global::Celeste.Core.Geometry.Bounds previous);
    }
}
