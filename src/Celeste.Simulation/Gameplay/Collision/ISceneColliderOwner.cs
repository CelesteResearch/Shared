using System.Numerics;
using Celeste.Physics.Collision.Shapes;

namespace Celeste.Simulation.Gameplay.Collision
{
    public interface ISceneColliderOwner
    {
        Vector2 Position { get; }
        bool Collidable { get; }
        ColliderGeometry Collider { get; }
    }
}
