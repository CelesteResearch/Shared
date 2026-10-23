using System;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Rendering;
using Celeste.Physics.Collision;
using Celeste.Physics.Collision.Shapes;

namespace Celeste.Simulation.Gameplay.Player.Collision.Components
{
    // The original PlayerCollider is an inactive, invisible Component. Its identity
    // and fields survive rebuilds of Unity-side collision/check delegates.
    public sealed class PlayerColliderComponentState : SourceComponentState
    {
        public ColliderGeometry Collider;
        public ColliderGeometry FeatherCollider;
        public Action<RoomPlayerSession> OnCollide;

        public IPlayerColliderCollisionPort
            CollisionPort;

        public PlayerColliderComponentState(Action<RoomPlayerSession> onCollide, ColliderGeometry collider = null,
            ColliderGeometry featherCollider = null) : base(false, false)
        {
            OnCollide = onCollide;
            Collider = collider;
            FeatherCollider = featherCollider;
        }

        public override void DebugRender(ISourceRenderContext context, object camera)
        {
            if (Collider != null)
            {
                var entity = (ISourceEntityCollider)Entity;
                var original = entity.Collider;
                entity.Collider = Collider;
                Collider.Render(camera, PackedColor.HotPink, context);
                entity.Collider = original;
            }
        }

        public bool Check(RoomPlayerSession player)
        {
            var shape = Collider;
            if (FeatherCollider != null && player.Machine.State == 19)
                shape = FeatherCollider;
            var actualPlayer = (ISourceEntityCollider)player;
            if (shape == null)
            {
                if (!SourceEntityCollision.Check(actualPlayer,
                        (ISourceEntityCollider)Entity)) return false;
            }
            else
            {
                var original = ((ISourceEntityCollider)Entity).Collider;
                ((ISourceEntityCollider)Entity).Collider = shape;
                var collided = SourceEntityCollision.Check(actualPlayer,
                    (ISourceEntityCollider)Entity);
                ((ISourceEntityCollider)Entity).Collider = original;
                if (!collided) return false;
            }

            OnCollide(player);
            return true;
        }
    }
}
