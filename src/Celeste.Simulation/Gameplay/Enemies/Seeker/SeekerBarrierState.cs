using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Presentation.Barriers;

namespace Celeste.Simulation.Gameplay.Enemies.Seeker
{
    public class SeekerBarrierState : SourceSolidEntityState
    {
        public float Flash;
        public float Solidify;
        public bool Flashing;
        private float solidifyDelay;
        private readonly List<Vector2> particles = [];
        private readonly List<SeekerBarrierState> adjacent = [];
        private readonly float[] speeds = [12f, 20f, 40f];
        protected IReadOnlyList<Vector2> ParticlePositions => particles;

        protected void ClearParticlePositions()
        {
            particles.Clear();
        }

        protected float ParticleSpeed(int index)
        {
            return speeds[index];
        }

        public ISourceEngineContext BarrierEngineContext { get; }

        public virtual bool CollidesWithSeeker(bool original)
        {
            return original;
        }

        public virtual bool CollidesWithGlider(bool original)
        {
            return original;
        }

        public virtual bool CollidesWithHoldable(bool original, bool slowFall)
        {
            return original;
        }

        public virtual bool BloomMaskAllowed()
        {
            return true;
        }

        public virtual PackedColor ParticleColor()
        {
            return PackedColor.White;
        }

        public virtual float ParticleTransparency()
        {
            return .5f;
        }

        public virtual void AdvanceParticleMotion()
        {
            BarrierParticleMotion.AdvanceDown(particles, speeds, Height,
                BarrierEngineContext.DeltaTime);
        }

        public void AdvanceWrappedParticleMotion(Vector2 direction)
        {
            BarrierParticleMotion.AdvanceWrapped(particles, speeds, Width,
                Height, direction, BarrierEngineContext.DeltaTime);
        }

        protected virtual string RendererTrackerKey => "Celeste.SeekerBarrierRenderer";
        protected virtual string AdjacentTrackerKey => "Celeste.SeekerBarrier";

        public SeekerBarrierState(Vector2 position, float width, float height, ISourceSolidWorld world)
            : base(position, width, height, false, world)
        {
            BarrierEngineContext = world.EngineContext;
            Collidable = false;
            BarrierParticleMotion.Fill(particles, Width, Height,
                ((ISourceRandomEnvironment)BarrierEngineContext).Random);
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            ((ISourceScene)scene).SourceScene.Entities
                .GetTrackedEntity<SeekerBarrierRendererState>(RendererTrackerKey).Track(this);
        }

        public override void Removed(object scene)
        {
            base.Removed(scene);
            ((ISourceScene)scene).SourceScene.Entities
                .GetTrackedEntity<SeekerBarrierRendererState>(RendererTrackerKey).Untrack(this);
        }

        public override void Update()
        {
            if (Flashing)
            {
                Flash = ScalarMath.Approach(Flash, 0f, BarrierEngineContext.DeltaTime * 4f,
                    ((ISourceExtremaEnvironment)BarrierEngineContext).ExtremaArithmetic);
                if (Flash <= 0f) Flashing = false;
            }
            else if (solidifyDelay > 0f)
            {
                solidifyDelay -= BarrierEngineContext.DeltaTime;
            }
            else if (Solidify > 0f)
            {
                Solidify = ScalarMath.Approach(Solidify, 0f, BarrierEngineContext.DeltaTime,
                    ((ISourceExtremaEnvironment)BarrierEngineContext).ExtremaArithmetic);
            }

            AdvanceParticleMotion();

            base.Update();
        }

        public void OnReflectSeeker()
        {
            Flash = Solidify = solidifyDelay = 1f;
            Flashing = true;
            var registry = ((ISourceScene)Scene).SourceScene.Entities;
            SourceSceneCollision.IntoRect(registry, AdjacentTrackerKey,
                new((int)X, (int)Y - 2, (int)Width, (int)Height + 4), adjacent);
            SourceSceneCollision.IntoRect(registry, AdjacentTrackerKey,
                new((int)X - 2, (int)Y, (int)Width + 4, (int)Height), adjacent);
            foreach (var item in adjacent)
                if (!item.Flashing)
                    item.OnReflectSeeker();
            adjacent.Clear();
        }

        public override void Render(ISourceRenderContext context)
        {
            if (!((ISourceSeekerBarrierBehaviorEnvironment)BarrierEngineContext).SeekerBarrierBehavior.IsVisible(
                    BarrierEngineContext, this))
                return;
            var color = ParticleColor() * ParticleTransparency();
            foreach (var particle in particles)
            {
                var image = new AtlasTextureDraw(
                    ((ISourceDrawScope)context).Draw.Pixel, Position + particle,
                    Vector2.Zero, color, Vector2.One);
                ((ISourceRenderCommandSink<AtlasTextureDraw>)context).Draw(in image, this);
            }

            if (Flashing)
                SourcePrimitiveDrawing.Rect(context, this, Collider.AbsoluteLeft, Collider.AbsoluteTop,
                    Collider.Width, Collider.Height, PackedColor.White * Flash * .5f);
        }
    }
}
