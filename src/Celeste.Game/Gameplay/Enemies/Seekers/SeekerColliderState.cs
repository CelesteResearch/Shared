using System;
using Celeste.Core.Components;
using Celeste.Physics.Collision;
using Celeste.Physics.Collision.Shapes;

namespace Celeste.Game.Gameplay.Enemies.Seekers
{
    public class SeekerColliderState : SourceComponentState
    {
        public Action<OriginalSeekerState> OnCollide;
        public ColliderGeometry Collider;

        public SeekerColliderState(Action<OriginalSeekerState> onCollide, ColliderGeometry collider = null)
            : base(false, false)
        {
            OnCollide = onCollide;
            // Both source DLLs set null here, even when the argument is non-null.
            Collider = null;
        }

        public void Check(OriginalSeekerState seeker)
        {
            if (OnCollide != null)
            {
                var actualEntity = (ISourceEntityCollider)Entity;
                var collider = actualEntity.Collider;
                if (Collider != null) actualEntity.Collider = Collider;
                if (SourceEntityCollision.Check(seeker, actualEntity)) OnCollide(seeker);
                // Match the source's normal-return restoration, including exceptions.
                actualEntity.Collider = collider;
            }
        }
    }
}
