using Celeste.Core.Display;
using System;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Simulation.Presentation.Backdrops.Runtime;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;

namespace Celeste.Game.Content.Maps.Backdrops.Stars
{
    public sealed class MirrorBackdropPresentation : BackdropPresentation
    {
        private struct Particle
        {
            public Vector2 Position, Direction;
            public float Percent, Duration, Speed, Spin;
            public int Color;
        }

        private static readonly PackedColor[] colors = { PackedColor.Red };
        private Particle[] particles = new Particle[50];
        private float fade;

        private readonly ISourceEngineContext engine;
        private ISourceRandom Random => ((ISourceRandomEnvironment)engine).Random;
        private ISourceExtremaArithmetic Extrema => ((ISourceExtremaEnvironment)engine).ExtremaArithmetic;

        public MirrorBackdropPresentation(ISourceEngineContext engine)
        {
            this.engine = engine;
            for (int i = 0; i < particles.Length; i++) Reset(i, SourceRandomMath.NextFloat(Random));
        }

        private void Reset(int i, float percent)
        {
            particles[i].Percent = percent;
            particles[i].Position =
                new Vector2(SourceRandomMath.Range(Random, 0, 320), SourceRandomMath.Range(Random, 0, 180));
            particles[i].Speed = SourceRandomMath.Range(Random, 4, 14);
            particles[i].Spin = SourceRandomMath.Range(Random, .25f, (float)Math.PI * 6f);
            particles[i].Duration = SourceRandomMath.Range(Random, 1f, 4f);
            particles[i].Direction =
                Vector2Geometry.AngleToVector(SourceRandomMath.NextFloat(Random, (float)Math.PI * 2f), 1f);
            particles[i].Color = Random.Next(colors.Length);
        }

        public override void Update(ISourceBackdropScene scene)
        {
            base.Update(scene);

            for (int i = 0; i < particles.Length; i++)
            {
                if (particles[i].Percent >= 1f) Reset(i, 0f);
                particles[i].Percent += engine.Frame.DeltaTime / particles[i].Duration;
                particles[i].Position += particles[i].Direction * particles[i].Speed * engine.Frame.DeltaTime;
                particles[i].Direction = ((ISourceVectorEnvironment)engine).VectorArithmetic.Rotate(
                    particles[i].Direction, particles[i].Spin * engine.Frame.DeltaTime);
            }

            fade = ScalarMath.Approach(fade, Visible ? 1f : 0f, engine.Frame.DeltaTime, Extrema);
        }

        public override void Render(ISourceRenderContext context, ISourceBackdropScene scene)
        {
            if (!(fade <= 0f))
            {
                var camera = scene.Camera;
                for (int i = 0; i < particles.Length; i++)
                {
                    var position = new Vector2
                    {
                        X = ScalarMath.Mod(particles[i].Position.X - camera.X, 320f),
                        Y = ScalarMath.Mod(particles[i].Position.Y - camera.Y, 180f)
                    };
                    float percent = particles[i].Percent;
                    float alpha = 0f;
                    alpha = !(percent < .7f)
                        ? ScalarMath.ClampedMap(percent, .7f, 1f, 1f, 0f)
                        : ScalarMath.ClampedMap(percent, 0f, .3f);

                    SourcePrimitiveDrawing.Rect(context, null, position.X, position.Y, 1f, 1f,
                        (colors[particles[i].Color] * (fade * alpha)));
                }
            }
        }
    }
}
