using System;
using System.Numerics;
using Celeste.Physics.Collision.Shapes;

namespace Celeste.Simulation.Gameplay.Player.Collision.Components
{
    public sealed class PlayerColliderCollisionPort : IPlayerColliderCollisionPort
    {
        private readonly Func<RoomPlayerSession, ColliderGeometry, bool> check;

        public PlayerColliderCollisionPort(Func<RoomPlayerSession, ColliderGeometry, bool> check)
        {
            this.check = check ?? throw new ArgumentNullException(nameof(check));
        }

        // The common Monocle path: Entity.Collidable gates both ordinary and
        // temporary override geometry; PlayerCollider.Check invokes OnCollide
        // only after this predicate has returned and the temporary shape is gone.
        public PlayerColliderCollisionPort(Func<Vector2> entityPosition,
            Func<bool> collidable, Func<RoomPlayerSession, bool> collideDefault)
        {
            if (entityPosition == null) throw new ArgumentNullException(nameof(entityPosition));
            if (collidable == null) throw new ArgumentNullException(nameof(collidable));
            if (collideDefault == null) throw new ArgumentNullException(nameof(collideDefault));
            check = (player, overrideGeometry) =>
                collidable() && player.World.Contacts.Collider != null &&
                (overrideGeometry == null
                    ? collideDefault(player)
                    : overrideGeometry.Overlaps(player.PlayerColliderBounds, entityPosition()));
        }

        public bool Collides(RoomPlayerSession player, ColliderGeometry overrideGeometry)
        {
            return check(player, overrideGeometry);
        }
    }
}
