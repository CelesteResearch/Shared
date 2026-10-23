using Celeste.Core.Geometry;

namespace Celeste.Physics.Collision
{
    public interface IDetailedCollisionWorld : ICollisionWorld
    {
        PixelPlatform FirstSolidAt(Bounds bounds);
        PixelPlatform FirstJumpThruAt(Bounds bounds);

        PixelPlatform FirstJumpThruOutside(Bounds bounds,
            Bounds previous);
    }
}
