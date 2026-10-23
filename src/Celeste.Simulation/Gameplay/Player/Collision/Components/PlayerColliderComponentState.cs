using Celeste.Core.Display;
using Celeste.Physics.Collision.Shapes;
using System;
using System.Numerics;
using Celeste.Simulation.Rendering;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Player.Collision.Components
{
    // The original PlayerCollider is an inactive, invisible Component. Its identity
    // and fields survive rebuilds of Unity-side collision/check delegates.
    public sealed class PlayerColliderComponentState : global::Celeste.Core.Components.SourceComponentState
    {
        public ColliderGeometry Collider;
        public ColliderGeometry FeatherCollider;
        public Action<RoomPlayerSession> OnCollide;

        public global::Celeste.Simulation.Gameplay.Player.Collision.Components.IPlayerColliderCollisionPort
            CollisionPort;

        public PlayerColliderComponentState(Action<RoomPlayerSession> onCollide, ColliderGeometry collider = null,
            ColliderGeometry featherCollider = null) : base(false, false)
        {
            OnCollide = onCollide;
            Collider = collider;
            FeatherCollider = featherCollider;
        }

        public override void DebugRender(global::Celeste.Core.Rendering.ISourceRenderContext context, object camera)
        {
            if (Collider != null)
            {
                var entity = (global::Celeste.Physics.Collision.ISourceEntityCollider)Entity;
                ColliderGeometry original = entity.Collider;
                entity.Collider = Collider;
                Collider.Render(camera, global::Celeste.Core.Display.PackedColor.HotPink, context);
                entity.Collider = original;
            }
        }

        public bool Check(RoomPlayerSession player)
        {
            var shape = Collider;
            if (FeatherCollider != null && player.Machine.State == 19)
                shape = FeatherCollider;
            var actualPlayer = (global::Celeste.Physics.Collision.ISourceEntityCollider)(object)player;
            if (shape == null)
            {
                if (!global::Celeste.Physics.Collision.SourceEntityCollision.Check(actualPlayer,
                        (global::Celeste.Physics.Collision.ISourceEntityCollider)Entity)) return false;
            }
            else
            {
                var original = ((global::Celeste.Physics.Collision.ISourceEntityCollider)Entity).Collider;
                ((global::Celeste.Physics.Collision.ISourceEntityCollider)Entity).Collider = shape;
                bool collided = global::Celeste.Physics.Collision.SourceEntityCollision.Check(actualPlayer,
                    (global::Celeste.Physics.Collision.ISourceEntityCollider)Entity);
                ((global::Celeste.Physics.Collision.ISourceEntityCollider)Entity).Collider = original;
                if (!collided) return false;
            }

            OnCollide(player);
            return true;
        }
    }
}
