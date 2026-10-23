using System;
using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Physics.Collision;
using Celeste.Physics.Collision.Shapes;
using Celeste.Simulation.Gameplay.Environment.Water;

namespace Celeste.Everest.Gameplay.Environment.Water
{
    public class EverestWaterInteractionState : WaterInteractionState, ISourceWaterCollisionInteraction
    {
        private readonly ColliderGeometry _collider;

        public EverestWaterInteractionState(Func<bool> isDashing) : base(isDashing)
        {
        }

        public EverestWaterInteractionState(IntRect bounds, Func<bool> isDashing)
            : this(new HitboxColliderGeometry(bounds.Width, bounds.Height, bounds.X, bounds.Y), isDashing)
        {
        }

        public EverestWaterInteractionState(ColliderGeometry collider, Func<bool> isDashing) : this(isDashing)
        {
            _collider = collider;
        }

        public Vector2 AbsoluteCenter => ((ISourceEntityCollider)Entity).Position +
                                         (_collider ?? ((ISourceEntityCollider)Entity).Collider).Center;

        public IntRect Bounds
        {
            get
            {
                var entity = (ISourceEntityCollider)Entity;
                var collider = entity.Collider;
                if (_collider != null) entity.Collider = _collider;
                var bounds = entity.Collider.Bounds;
                entity.Collider = collider;
                return bounds;
            }
        }

        public bool Check(ISourceEntityCollider water)
        {
            var entity = (ISourceEntityCollider)Entity;
            var collider = entity.Collider;
            if (_collider != null) entity.Collider = _collider;
            var result = SourceEntityCollision.Check(water, entity);
            entity.Collider = collider;
            return result;
        }
    }
}
