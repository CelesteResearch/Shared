using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Rendering;
using Celeste.Physics.Collision;
using Celeste.Physics.Collision.Shapes;

namespace Celeste.Simulation.Gameplay.Hazards.TriggerSpikes.Components
{
    public sealed class SafeGroundBlockerComponentState : SourceComponentState
    {
        public bool Blocking = true;
        public ColliderGeometry CheckWith;

        public SafeGroundBlockerComponentState(ColliderGeometry checkWith = null) : base(false, false)
        {
            CheckWith = checkWith;
        }

        public bool Check(ISourceEntityCollider player)
        {
            if (!Blocking) return false;
            var entity = (ISourceEntityCollider)Entity;
            var original = entity.Collider;
            if (CheckWith != null) entity.Collider = CheckWith;
            var result = SourceEntityCollision.Check(player, entity);
            entity.Collider = original;
            return result;
        }

        public override void DebugRender(ISourceRenderContext context, object camera)
        {
            var entity = (ISourceEntityCollider)Entity;
            var original = entity.Collider;
            if (CheckWith != null) entity.Collider = CheckWith;
            entity.Collider.Render(camera, PackedColor.Cyan, context);
            entity.Collider = original;
        }
    }
}
