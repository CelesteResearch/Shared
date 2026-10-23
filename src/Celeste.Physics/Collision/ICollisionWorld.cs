using System.Numerics;
using Celeste.Core.Geometry;

namespace Celeste.Physics.Collision
{
    public interface ICollisionWorld
    {
        bool SolidAt(Bounds bounds);
        bool SolidAt(Vector2 point);
        bool JumpThruAt(Bounds bounds);
        bool JumpThruAt(Bounds bounds, Bounds previous);
    }
}
