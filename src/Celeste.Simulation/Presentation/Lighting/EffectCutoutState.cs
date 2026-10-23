using Celeste.Core.Components;
using Celeste.Core.Geometry;
using Celeste.Physics.Collision;

namespace Celeste.Simulation.Presentation.Lighting
{
    public class EffectCutoutState : SourceComponentState
    {
        public float Alpha = 1f;
        private IntRect lastSize;
        private bool lastVisible;
        private float lastAlpha;

        public int Left => (int)((ISourceEntityCollider)Entity).Collider.AbsoluteLeft;
        public int Right => (int)((ISourceEntityCollider)Entity).Collider.AbsoluteRight;
        public int Top => (int)((ISourceEntityCollider)Entity).Collider.AbsoluteTop;
        public int Bottom => (int)((ISourceEntityCollider)Entity).Collider.AbsoluteBottom;
        public IntRect Bounds => ((ISourceEntityCollider)Entity).Collider.Bounds;

        public EffectCutoutState() : base(true, true)
        {
        }

        public override void Update()
        {
            var flag = Visible && ((ISourceEntityVisibility)Entity).Visible;
            var rectangle = Bounds;
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (!lastSize.Equals(rectangle) || lastAlpha != Alpha || lastVisible != flag)
            {
                MakeLightsDirty();
                lastSize = rectangle;
                lastAlpha = Alpha;
                lastVisible = flag;
            }
        }

        public override void Removed(object entity)
        {
            MakeLightsDirty();
            base.Removed(entity);
        }

        public override void EntityRemoved(object scene)
        {
            MakeLightsDirty();
            base.EntityRemoved(scene);
        }

        private void MakeLightsDirty()
        {
            var rectangle = Bounds;
            var components = ((ISourceTrackedComponents)((ISourceComponentIndexScene)
                ((ISourceEntityScene)Entity).Scene).ComponentIndex).GetTrackedComponents("Celeste.VertexLight");
            foreach (VertexLightState component in components)
                if (!component.Dirty)
                {
                    var value = new IntRect((int)(component.Center.X - component.EndRadius),
                        (int)(component.Center.Y - component.EndRadius),
                        (int)component.EndRadius * 2, (int)component.EndRadius * 2);
                    if (rectangle.Intersects(value) || lastSize.Intersects(value)) component.Dirty = true;
                }
        }
    }
}
