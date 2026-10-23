using System;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Graphics.Rendering;

namespace Celeste.Simulation.Presentation.Backdrops.WindDust
{
    public static class WindDustParticleMotion
    {
        public static void Fill<TColor, TState>(in TState state) where TColor : struct
            where TState : struct, IWindDustState<TColor>
        {
            for (int i = 0; i < state.Particles.Length; i++)
                Reset<TColor, TState>(in state, i, SourceRandomMath.NextFloat(state.Random));
        }

        private static void Reset<TColor, TState>(in TState state, int index, float percent) where TColor : struct
            where TState : struct, IWindDustState<TColor>
        {
            state.Particles[index].Percent = percent;
            state.Particles[index].Position = new Vector2(SourceRandomMath.Range(state.Random, 0, 320),
                SourceRandomMath.Range(state.Random, 0, 180));
            state.Particles[index].Speed = SourceRandomMath.Range(state.Random, 4, 14);
            state.Particles[index].Spin = SourceRandomMath.Range(state.Random, .25f, (float)Math.PI * 6f);
            state.Particles[index].Duration = SourceRandomMath.Range(state.Random, 1f, 4f);
            state.Particles[index].Direction =
                Vector2Geometry.AngleToVector(SourceRandomMath.NextFloat(state.Random, (float)Math.PI * 2f), 1f);
            state.Particles[index].Color = state.NextColor();
        }

        public static void Advance<TColor, TState>(in TState state, ref Vector2 scale, ref float fade)
            where TColor : struct where TState : struct, IWindDustState<TColor>
        {
            Vector2 wind = Vector2.Zero;
            if (state.Wind.Y == 0f)
            {
                scale.X = Math.Max(1f, Math.Abs(state.Wind.X) / 100f);
                scale.Y = 1f;
                wind = new Vector2(state.Wind.X, 0f);
            }
            else
            {
                scale.X = 1f;
                scale.Y = Math.Max(1f, Math.Abs(state.Wind.Y) / 40f);
                wind = new Vector2(0f, state.Wind.Y * 2f);
            }

            for (int i = 0; i < state.Particles.Length; i++)
            {
                if (state.Particles[i].Percent >= 1f) Reset<TColor, TState>(in state, i, 0f);
                state.Particles[i].Percent += state.DeltaTime / state.Particles[i].Duration;
                state.Particles[i].Position +=
                    (state.Particles[i].Direction * state.Particles[i].Speed + wind) * state.DeltaTime;
                // The original returns a new vector and deliberately does not assign it back.
                state.VectorArithmetic.Rotate(state.Particles[i].Direction, state.Particles[i].Spin * state.DeltaTime);
            }

            fade = ScalarMath.Approach(fade, state.Visible ? 1f : 0f, state.DeltaTime);
        }

        public static void Render<TColor, TState>(in TState state, ISourceRenderContext context) where TColor : struct
            where TState : struct, IWindDustState<TColor>
        {
            if (!(state.Fade <= 0f))
            {
                var camera = state.Camera;
                for (int i = 0; i < state.Particles.Length; i++)
                {
                    Vector2 position = new Vector2(Mod(state.Particles[i].Position.X - camera.X, 320f),
                        Mod(state.Particles[i].Position.Y - camera.Y, 180f));
                    float percent = state.Particles[i].Percent;
                    float alpha = !(percent < .7f)
                        ? ScalarMath.ClampedMap(percent, .7f, 1f, 1f, 0f)
                        : ScalarMath.ClampedMap(percent, 0f, .3f);
                    alpha *= state.FadeAlphaMultiplier;
                    SourcePrimitiveDrawing.Rect(context, null, position.X, position.Y, state.Scale.X, state.Scale.Y,
                        state.ResolveColor(state.Particles[i].Color) * (state.Fade * alpha));
                }
            }
        }

        private static float Mod(float value, float modulus) => ((value % modulus) + modulus) % modulus;
    }
}
