using Celeste.Core.Components;
using Celeste.Core.Framework.Timing;
using Celeste.Core.Geometry;
using Celeste.Physics.Collision;

namespace Celeste.Simulation.Presentation.Lighting
{
    public class LightOccludeState : SourceComponentState
    {
        public float Alpha = 1f;
        private readonly IntRect? bounds;
        public IntRect RenderBounds;
        private IntRect lastSize;
        private bool lastVisible;
        private float lastAlpha;

        public int Left => bounds.HasValue
            ? (int)((ISourceEntityPosition)Entity).Position.X + bounds.Value.Left
            : (int)((ISourceEntityCollider)Entity).Collider.AbsoluteLeft;

        public int Width => bounds.HasValue ? bounds.Value.Width : (int)((ISourceEntityCollider)Entity).Collider.Width;

        public int Top => bounds.HasValue
            ? (int)((ISourceEntityPosition)Entity).Position.Y + bounds.Value.Top
            : (int)((ISourceEntityCollider)Entity).Collider.AbsoluteTop;

        public int Height =>
            bounds.HasValue ? bounds.Value.Height : (int)((ISourceEntityCollider)Entity).Collider.Height;

        public int Right => Left + Width;
        public int Bottom => Top + Height;

        public LightOccludeState(float alpha = 1f) : base(true, true)
        {
            Alpha = alpha;
        }

        public LightOccludeState(IntRect bounds, float alpha = 1f) : this(alpha)
        {
            this.bounds = bounds;
        }

        public override void Update()
        {
            var diagnostics = SourceFrameDiagnostics.Current;
            long updateStarted = 0;
            var measuringUpdate = diagnostics?.BeginLightOccludeUpdate(out updateStarted) ?? false;
            try
            {
                base.Update();
                var flag = Visible && ((ISourceEntityVisibility)Entity).Visible;
                var rectangle = new IntRect(Left, Top, Width, Height);
                // ReSharper disable once CompareOfFloatsByEqualityOperator
                if (!lastSize.Equals(rectangle) || lastVisible != flag || lastAlpha != Alpha)
                {
                    MakeLightsDirty();
                    lastVisible = flag;
                    lastSize = rectangle;
                    lastAlpha = Alpha;
                }
            }
            finally
            {
                if (measuringUpdate) diagnostics.EndLightOccludeUpdate(updateStarted);
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
            var rectangle = new IntRect(Left, Top, Width, Height);
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
