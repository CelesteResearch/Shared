using Celeste.Core.Components;
using Celeste.Physics.Collision.Shapes;

namespace Celeste.Physics.Collision
{
    // Read and replace the current actual Entity.Collider at the original setter.
    public interface ISourceEntityCollider : ISourceEntityPosition
    {
        bool Collidable { get; }
        ColliderGeometry Collider { get; set; }
    }
}
