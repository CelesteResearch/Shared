using System;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Simulation.Presentation.Backdrops.Runtime;

namespace Celeste.Simulation.Presentation.Backdrops.Weather.Snow
{
    public class SnowBackdropPresentation : BackdropPresentation
    {
        private struct Particle
        {
            public Vector2 Position;
            public int Color;
            public float Speed, Sin;

            public void Init(SnowBackdropPresentation owner, int maxColors, float min, float max)
            {
                Position = new(SourceRandomMath.NextFloat(owner.Random, 320f),
                    SourceRandomMath.NextFloat(owner.Random, 180f));
                Color = owner.Random.Next(maxColors);
                Speed = SourceRandomMath.Range(owner.Random, min, max);
                Sin = SourceRandomMath.NextFloat(owner.Random, (float)Math.PI * 2f);
            }
        }

        public static readonly PackedColor[] ForegroundColors = [PackedColor.White, PackedColor.CornflowerBlue];

        public static readonly PackedColor[] BackgroundColors =
            [new(.2f, .2f, .2f, 1f), new(.1f, .2f, .5f, 1f)];

        private readonly ISourceEngineContext engine;
        private ISourceRandom Random => ((ISourceRandomEnvironment)engine).Random;
        public float Alpha = 1f;
        private float visibleFade = 1f, linearFade = 1f;
        private readonly PackedColor[] colors;
        private readonly PackedColor[] blendedColors;
        private readonly Particle[] particles = new Particle[60];

        public SnowBackdropPresentation(ISourceEngineContext engine, bool foreground)
        {
            this.engine = engine;
            colors = foreground ? ForegroundColors : BackgroundColors;
            blendedColors = new PackedColor[colors.Length];
            int min = foreground ? 120 : 40, max = foreground ? 300 : 100;
            for (var i = 0; i < particles.Length; i++) particles[i].Init(this, colors.Length, min, max);
        }

        public override void Update(ISourceBackdropScene scene)
        {
            base.Update(scene);
            visibleFade = ScalarMath.Approach(visibleFade, IsVisible(scene) ? 1 : 0, engine.Frame.DeltaTime * 2f,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            if (FadeX != null) linearFade = FadeX.Value(scene.Camera.X + 160f);
            for (var i = 0; i < particles.Length; i++)
            {
                particles[i].Position.X -= particles[i].Speed * engine.Frame.DeltaTime;
                particles[i].Position.Y +=
                    (float)Math.Sin(particles[i].Sin) * particles[i].Speed * .2f * engine.Frame.DeltaTime;
                particles[i].Sin += engine.Frame.DeltaTime;
            }
        }

        public override void Render(ISourceRenderContext context, ISourceBackdropScene scene)
        {
            if (!(Alpha <= 0f) && !(visibleFade <= 0f) && !(linearFade <= 0f))
            {
                for (var i = 0; i < blendedColors.Length; i++)
                    blendedColors[i] = colors[i] * (Alpha * visibleFade * linearFade);
                var camera = scene.Camera;
                for (var i = 0; i < particles.Length; i++)
                {
                    var position = new Vector2(ScalarMath.Mod(particles[i].Position.X - camera.X, 320f),
                        ScalarMath.Mod(particles[i].Position.Y - camera.Y, 180f));
                    var color = blendedColors[particles[i].Color];
                    var pixel = ((ISourceDrawScope)scene.EngineContext).Draw
                        .Pixel;
                    var draw = new AtlasTextureDraw(pixel, position, pixel.Center, color, Vector2.One);
                    ((ISourceRenderCommandSink<AtlasTextureDraw>)context).Draw(in draw, null);
                }
            }
        }
    }
}
