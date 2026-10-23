using Celeste.Core.Display;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;

namespace Celeste.Simulation.Gameplay.Enemies.Seeker
{
    public class SeekerBarrierState : SourceSolidEntityState
    {
        public float Flash;
        public float Solidify;
        public bool Flashing;
        private float solidifyDelay;
        private readonly List<Vector2> particles = new();
        private readonly List<SeekerBarrierState> adjacent = new();
        private float[] speeds = { 12f, 20f, 40f };
        private readonly ISourceEngineContext engine;
        protected IReadOnlyList<Vector2> ParticlePositions => particles;
        protected void ClearParticlePositions() => particles.Clear();
        protected float ParticleSpeed(int index) => speeds[index];
        public ISourceEngineContext BarrierEngineContext => engine;
        public virtual bool CollidesWithSeeker(bool original) => original;
        public virtual bool CollidesWithGlider(bool original) => original;
        public virtual bool CollidesWithHoldable(bool original, bool slowFall) => original;
        public virtual bool BloomMaskAllowed() => true;
        public virtual PackedColor ParticleColor() => PackedColor.White;
        public virtual float ParticleTransparency() => .5f;

        public virtual void AdvanceParticleMotion()
            => Celeste.Simulation.Presentation.Barriers.BarrierParticleMotion.AdvanceDown(particles, speeds, Height,
                engine.DeltaTime);

        public void AdvanceWrappedParticleMotion(Vector2 direction)
            => Celeste.Simulation.Presentation.Barriers.BarrierParticleMotion.AdvanceWrapped(particles, speeds, Width,
                Height, direction, engine.DeltaTime);

        protected virtual string RendererTrackerKey => "Celeste.SeekerBarrierRenderer";
        protected virtual string AdjacentTrackerKey => "Celeste.SeekerBarrier";

        public SeekerBarrierState(Vector2 position, float width, float height, ISourceSolidWorld world)
            : base(position, width, height, false, world)
        {
            engine = world.EngineContext;
            Collidable = false;
            Celeste.Simulation.Presentation.Barriers.BarrierParticleMotion.Fill(particles, Width, Height,
                ((ISourceRandomEnvironment)engine).Random);
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
                Flash = ScalarMath.Approach(Flash, 0f, engine.DeltaTime * 4f,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                if (Flash <= 0f) Flashing = false;
            }
            else if (solidifyDelay > 0f) solidifyDelay -= engine.DeltaTime;
            else if (Solidify > 0f)
                Solidify = ScalarMath.Approach(Solidify, 0f, engine.DeltaTime,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);

            AdvanceParticleMotion();

            base.Update();
        }

        public void OnReflectSeeker()
        {
            Flash = Solidify = solidifyDelay = 1f;
            Flashing = true;
            var registry = ((ISourceScene)Scene).SourceScene.Entities;
            SourceSceneCollision.IntoRect(registry, AdjacentTrackerKey,
                new IntRect((int)X, (int)Y - 2, (int)Width, (int)Height + 4), adjacent);
            SourceSceneCollision.IntoRect(registry, AdjacentTrackerKey,
                new IntRect((int)X - 2, (int)Y, (int)Width + 4, (int)Height), adjacent);
            foreach (SeekerBarrierState item in adjacent)
                if (!item.Flashing)
                    item.OnReflectSeeker();
            adjacent.Clear();
        }

        public override void Render(ISourceRenderContext context)
        {
            if (!((ISourceSeekerBarrierBehaviorEnvironment)engine).SeekerBarrierBehavior.IsVisible(engine, this))
                return;
            PackedColor color = ParticleColor() * ParticleTransparency();
            foreach (Vector2 particle in particles)
            {
                var image = new AtlasTextureDraw(
                    ((Celeste.Graphics.Rendering.Drawing.ISourceDrawScope)context).Draw.Pixel, Position + particle,
                    Vector2.Zero, color, Vector2.One);
                ((ISourceRenderCommandSink<AtlasTextureDraw>)context).Draw(in image, this);
            }

            if (Flashing)
                SourcePrimitiveDrawing.Rect(context, this, Collider.AbsoluteLeft, Collider.AbsoluteTop,
                    Collider.Width, Collider.Height, PackedColor.White * Flash * .5f);
        }
    }
}
