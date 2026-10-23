using System;
using Celeste.Core.Components;
using Celeste.Physics.Collision;
using Celeste.Physics.Collision.Shapes;

namespace Celeste.Simulation.Gameplay.Holdables
{
    public class HoldableColliderState : SourceComponentState
    {
        private ColliderGeometry collider;
        public Action<HoldableState> OnCollide;

        public HoldableColliderState(Action<HoldableState> onCollide, ColliderGeometry collider = null)
            : base(false, false)
        {
            this.collider = collider;
            OnCollide = onCollide;
        }

        public bool Check(HoldableState holdable)
        {
            var entity = (ISourceEntityCollider)Entity;
            var previous = entity.Collider;
            if (collider != null) entity.Collider = collider;
            bool result = SourceEntityCollision.Check((ISourceEntityCollider)holdable.Entity, entity);
            entity.Collider = previous;
            return result;
        }
    }
}
