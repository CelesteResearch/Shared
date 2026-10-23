using System;
using Celeste.Core.Components;
using Celeste.Physics.Collision;
using Celeste.Physics.Collision.Shapes;

namespace Celeste.Simulation.Gameplay.Hazards.Puffer
{
    public class PufferColliderState : SourceComponentState
    {
        public Action<ISourcePufferEntity> OnCollide;

        public ColliderGeometry Collider;

        // The original constructor intentionally ignores the supplied collider.
        public PufferColliderState(Action<ISourcePufferEntity> onCollide, ColliderGeometry collider = null)
            : base(false, false)
        {
            OnCollide = onCollide;
            Collider = null;
        }

        public void Check(ISourcePufferEntity puffer)
        {
            if (OnCollide != null)
            {
                ColliderGeometry previous = ((ISourceEntityCollider)Entity).Collider;
                if (Collider != null) ((ISourceEntityCollider)Entity).Collider = Collider;
                if (SourceEntityCollision.Check((ISourceEntityCollider)(object)puffer, (ISourceEntityCollider)Entity))
                    OnCollide(puffer);
                ((ISourceEntityCollider)Entity).Collider = previous;
            }
        }
    }
}
