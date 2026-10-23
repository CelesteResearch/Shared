using Celeste.Core.Display;
using System;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Simulation.Presentation.Backdrops.Runtime;
using Celeste.Graphics.Content;
using Celeste.Graphics.Display;

namespace Celeste.Simulation.Presentation.Backdrops.Weather.Petals
{
    public sealed class PetalsBackdropPresentation : BackdropPresentation
    {
        public struct Particle
        {
            public Vector2 Position;
            public float Speed, Spin, MaxRotate;
            public int Color;
            public float RotationCounter;
        }

        private static readonly PackedColor[] colors = { new PackedColor(255, 58, 163) };
        private readonly Particle[] particles = new Particle[40];
        private readonly ISourceEngineContext engine;
        private float fade;
        public float Fade => fade;
        public System.Collections.Generic.IReadOnlyList<Particle> Particles => particles;
        private ISourceRandom Random => ((ISourceRandomEnvironment)engine).Random;

        public PetalsBackdropPresentation(ISourceEngineContext engine)
        {
            this.engine = engine;
            for (int i = 0; i < particles.Length; i++) Reset(i);
        }

        private void Reset(int i)
        {
            PetalParticleMotion.InitializeMotion(Random, out particles[i].Position, out particles[i].Speed,
                out particles[i].Spin);
            particles[i].Color = Random.Next(colors.Length);
            PetalParticleMotion.InitializeRotation(Random, out particles[i].RotationCounter,
                out particles[i].MaxRotate);
        }

        public override void Update(ISourceBackdropScene scene)
        {
            base.Update(scene);
            for (int i = 0; i < particles.Length; i++)
            {
                PetalParticleMotion.AdvancePosition(ref particles[i].Position, particles[i].Speed,
                    scene.EngineContext.DeltaTime);
                PetalParticleMotion.AdvanceRotation(ref particles[i].RotationCounter, particles[i].Spin,
                    scene.EngineContext.DeltaTime);
            }

            fade = ScalarMath.Approach(fade, Visible ? 1f : 0f, scene.EngineContext.DeltaTime,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
        }

        public override void Render(ISourceRenderContext context, ISourceBackdropScene scene)
        {
            if (!(fade <= 0f))
            {
                var camera = scene.Camera;
                var texture = ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas["particles/petal"];
                for (int i = 0; i < particles.Length; i++)
                {
                    Vector2 position = PetalParticleMotion.DrawPosition(particles[i].Position, camera.Position,
                        particles[i].RotationCounter, particles[i].MaxRotate, out float rotation);
                    var draw = new AtlasTextureDraw(texture, position, texture.Center,
                        (colors[particles[i].Color] * fade), Vector2.One, rotation - .8f);
                    ((ISourceRenderCommandSink<AtlasTextureDraw>)context).Draw(in draw, this);
                }
            }
        }
    }
}
