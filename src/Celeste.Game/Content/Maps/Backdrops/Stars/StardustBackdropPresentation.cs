using System;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Geometry.TwoD.Camera;
using Celeste.Graphics.Display.Colors;
using Celeste.Simulation.Presentation.Backdrops.Runtime;
using Celeste.Simulation.Presentation.Backdrops.WindDust;

namespace Celeste.Game.Content.Maps.Backdrops.Stars
{
    public sealed class StardustBackdropPresentation : BackdropPresentation
    {
        private static readonly PackedColor[] colors = { new(76, 204, 239), new(242, 67, 189), new(66, 241, 221) };
        private readonly ISourceEngineContext engine;
        private WindDustParticle<int>[] particles = new WindDustParticle<int>[50];
        private float fade;
        private Vector2 scale = Vector2.One;

        public StardustBackdropPresentation(ISourceEngineContext engine)
        {
            this.engine = engine;
            var state = new ParticleState(this, null);
            WindDustParticleMotion.Fill<int, ParticleState>(in state);
        }

        public override void Update(ISourceBackdropScene scene)
        {
            base.Update(scene);
            var state = new ParticleState(this, scene);
            WindDustParticleMotion.Advance<int, ParticleState>(in state, ref scale, ref fade);
        }

        public override void Render(ISourceRenderContext context, ISourceBackdropScene scene)
        {
            var state = new ParticleState(this, scene);
            WindDustParticleMotion.Render<int, ParticleState>(in state, context);
        }

        private readonly struct ParticleState(StardustBackdropPresentation owner, ISourceBackdropScene scene)
            : IWindDustState<int>
        {
            public WindDustParticle<int>[] Particles => owner.particles;
            public ISourceRandom Random => ((ISourceRandomEnvironment)owner.engine).Random;
            public float DeltaTime => owner.engine.DeltaTime;
            public Vector2 Wind => scene.Wind;

            public ISourceVectorArithmetic VectorArithmetic =>
                ((ISourceVectorEnvironment)owner.engine).VectorArithmetic;

            public int NextColor() => Random.Next(colors.Length);
            public bool Visible => owner.Visible;
            public float Fade => owner.fade;
            public float FadeAlphaMultiplier => owner.FadeAlphaMultiplier;
            public Vector2 Scale => owner.scale;
            public CameraState Camera => scene.Camera;
            public PackedColor ResolveColor(int color) => colors[color];
        }
    }
}
