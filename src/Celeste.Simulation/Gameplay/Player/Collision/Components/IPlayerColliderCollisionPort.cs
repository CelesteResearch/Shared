using Celeste.Physics.Collision.Shapes;

namespace Celeste.Simulation.Gameplay.Player.Collision.Components
{
    // A host adapter supplies the live Entity.Collider fallback, Collidable flag,
    // and any temporary Entity.Collider swap required by Monocle. Check calls this
    // BEFORE invoking OnCollide, matching PlayerCollider.Check's restore order.
    public interface IPlayerColliderCollisionPort
    {
        bool Collides(RoomPlayerSession player, ColliderGeometry overrideGeometry);
    }
}
