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

namespace Celeste.Simulation.Presentation.Backdrops.Weather.Rain
{
    public class RainBackdropPresentation : BackdropPresentation
    {
        private struct Particle
        {
            public Vector2 Position, Speed, Scale;
            public float Rotation;

            public void Init(RainBackdropPresentation owner)
            {
                Position = new Vector2(-32f + SourceRandomMath.NextFloat(owner.Random, 384f),
                    -32f + SourceRandomMath.NextFloat(owner.Random, 244f));
                Rotation = (float)Math.PI / 2f + SourceRandomMath.Range(owner.Random, -.05f, .05f);
                Speed = Vector2Geometry.AngleToVector(Rotation, SourceRandomMath.Range(owner.Random, 200f, 600f));
                Scale = new Vector2(4f + (((ISourceVectorEnvironment)owner.engine).VectorArithmetic.Length(Speed)
                                          - 200f) / 400f * 12f, 1f);
            }
        }

        private readonly ISourceEngineContext engine;
        private ISourceRandom Random => ((ISourceRandomEnvironment)engine).Random;
        public float Alpha = 1f;
        private float visibleFade = 1f, linearFade = 1f;
        private Particle[] particles = new Particle[240];

        public RainBackdropPresentation(ISourceEngineContext engine)
        {
            this.engine = engine;
            for (int i = 0; i < particles.Length; i++) particles[i].Init(this);
        }

        public override void Update(ISourceBackdropScene scene)
        {
            base.Update(scene);
            bool raining = scene.Raining = IsVisible(scene);
            visibleFade = ScalarMath.Approach(visibleFade, raining ? 1 : 0,
                engine.Frame.DeltaTime * (raining ? 10f : .25f),
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            if (FadeX != null) linearFade = FadeX.Value(scene.Camera.X + 160f);
            for (int i = 0; i < particles.Length; i++)
                particles[i].Position += particles[i].Speed * engine.Frame.DeltaTime;
        }

        protected virtual PackedColor GetRainColor(string original) =>
            global::Celeste.Graphics.Display.Colors.SourceHexColor.HexToColor(original);

        public override void Render(ISourceRenderContext context, ISourceBackdropScene scene)
        {
            if (!(Alpha <= 0f) && !(visibleFade <= 0f) && !(linearFade <= 0f))
            {
                PackedColor color = GetRainColor("161933") * .5f * Alpha * linearFade * visibleFade;
                var camera = scene.Camera;
                for (int i = 0; i < particles.Length; i++)
                {
                    var position = new Vector2(ScalarMath.Mod(particles[i].Position.X - camera.X - 32f, 384f),
                        ScalarMath.Mod(particles[i].Position.Y - camera.Y - 32f, 244f));
                    var pixel = ((global::Celeste.Graphics.Rendering.Drawing.ISourceDrawScope)scene.EngineContext).Draw
                        .Pixel;
                    var draw = new AtlasTextureDraw(pixel, position, pixel.Center, color,
                        particles[i].Scale, particles[i].Rotation);
                    ((ISourceRenderCommandSink<AtlasTextureDraw>)context).Draw(in draw, null);
                }
            }
        }
    }
}
