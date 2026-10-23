using Celeste.Core.Display;
using System;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Simulation.Presentation.Backdrops.Runtime;
using Celeste.Simulation.Presentation.Backdrops.Parallax;
using Celeste.Graphics.Content;
using Celeste.Graphics.Display;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Rendering;

namespace Celeste.Simulation.Presentation.Backdrops.HeatWave
{
    public class HeatWaveBackdropPresentation : BackdropPresentation
    {
        private struct Particle
        {
            public Vector2 Position, Direction;
            public float Percent, Duration, Speed, Spin;
            public int Color;
        }

        private static readonly PackedColor[] hotColors = { PackedColor.Red, PackedColor.Orange };
        private static readonly PackedColor[] coldColors = { PackedColor.LightSkyBlue, PackedColor.Teal };
        private readonly ISourceEngineContext engine;
        private ISourceRandom Random => ((ISourceRandomEnvironment)engine).Random;
        private PackedColor[] currentColors;
        private float colorLerp;
        private Particle[] particles = new Particle[50];
        private float fade, heat;
        private ParallaxBackdropPresentation mist1, mist2;
        private bool show, wasShow;

        protected float FadeAmount => fade;
        protected float HeatAmount => heat;
        protected virtual int ParticleRenderCount => particles.Length;

        public HeatWaveBackdropPresentation(ISourceEngineContext engine)
        {
            this.engine = engine;
            for (int i = 0; i < particles.Length; i++) Reset(i, SourceRandomMath.NextFloat(Random));
            currentColors = new PackedColor[hotColors.Length];
            colorLerp = 1f;
            mist1 = new ParallaxBackdropPresentation(
                ((ISourceMiscAtlasResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics).MiscAtlas["mist"]);
            mist2 = new ParallaxBackdropPresentation(
                ((ISourceMiscAtlasResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics).MiscAtlas["mist"]);
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
            particles[i].Color = Random.Next(hotColors.Length);
        }

        private float Approach(float value, float target, float amount)
            => ScalarMath.Approach(value, target, amount, ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);

        private PackedColor Lerp(PackedColor from, PackedColor to, float amount)
            => SourceColorInterpolation.Lerp(from, to, amount, ((ISourceScalarEnvironment)engine).ScalarArithmetic);

        public override void Update(ISourceBackdropScene scene)
        {
            show = IsVisible(scene) && scene.CoreMode != 0;
            if (show)
            {
                if (!wasShow)
                {
                    colorLerp = scene.CoreMode == 1 ? 1 : 0;
                    scene.NextColorGrade(scene.CoreMode == 1 ? "hot" : "cold");
                }
                else scene.SnapColorGrade(scene.CoreMode == 1 ? "hot" : "cold");

                colorLerp = Approach(colorLerp, scene.CoreMode == 1 ? 1 : 0, engine.Frame.DeltaTime * 100f);
                for (int i = 0; i < currentColors.Length; i++)
                    currentColors[i] = Lerp(coldColors[i], hotColors[i], colorLerp);
            }
            else scene.NextColorGrade("none");

            for (int i = 0; i < particles.Length; i++)
            {
                if (particles[i].Percent >= 1f) Reset(i, 0f);
                float speed = 1f;
                if (scene.CoreMode == 2) speed = .25f;
                particles[i].Percent += engine.Frame.DeltaTime / particles[i].Duration;
                particles[i].Position += particles[i].Direction * particles[i].Speed * speed * engine.Frame.DeltaTime;
                // Original invokes Rotate and discards its returned Vector2.
                _ = ((ISourceVectorEnvironment)engine).VectorArithmetic.Rotate(particles[i].Direction,
                    particles[i].Spin * engine.Frame.DeltaTime);
                if (scene.CoreMode == 1) particles[i].Position.Y -= 10f * engine.Frame.DeltaTime;
            }

            fade = Approach(fade, show ? 1f : 0f, engine.Frame.DeltaTime);
            heat = Approach(heat, show && scene.CoreMode == 1 ? 1f : 0f, engine.Frame.DeltaTime * 100f);
            mist1.Color = Lerp(new PackedColor(99, 155, 255), new PackedColor(241, 178, 43), heat) * fade * .7f;
            mist2.Color = Lerp(new PackedColor(95, 205, 228), new PackedColor(241, 43, 58), heat) * fade * .7f;
            mist1.Speed = new Vector2(4f, -20f) * heat;
            mist2.Speed = new Vector2(4f, -40f) * heat;
            mist1.Update(scene);
            mist2.Update(scene);
            if (heat > 0f)
            {
                engine.Effects.WaterSineDirection = -1f;
                engine.Effects.WaterAlpha = heat * .5f;
            }
            else engine.Effects.WaterAlpha = 1f;

            wasShow = show;
        }

        public void RenderDisplacement(ISourceRenderContext context, ISourceBackdropScene scene)
        {
            if (heat > 0f)
                SourcePrimitiveDrawing.Rect(context, null, scene.Camera.X - 5f, scene.Camera.Y - 5f, 370f, 190f,
                    new PackedColor(.5f, .5f, .1f, 1f));
        }

        public override void Render(ISourceRenderContext context, ISourceBackdropScene scene)
        {
            if (!(fade <= 0f))
            {
                var camera = scene.Camera;
                int particleRenderCount = ParticleRenderCount;
                for (int i = 0; i < particleRenderCount; i++)
                {
                    Vector2 position = new Vector2(ScalarMath.Mod(particles[i].Position.X - camera.X, 320f),
                        ScalarMath.Mod(particles[i].Position.Y - camera.Y, 180f));
                    float percent = particles[i].Percent;
                    float alpha = !(percent < .7f)
                        ? ScalarMath.ClampedMap(percent, .7f, 1f, 1f, 0f)
                        : ScalarMath.ClampedMap(percent, 0f, .3f);
                    SourcePrimitiveDrawing.Rect(context, null, position.X, position.Y, 1f, 1f,
                        (currentColors[particles[i].Color] * (fade * alpha)));
                }

                mist1.Render(context, scene);
                mist2.Render(context, scene);
            }
        }
    }
}
