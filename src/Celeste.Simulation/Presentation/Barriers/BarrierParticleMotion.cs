using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Randomness;

namespace Celeste.Simulation.Presentation.Barriers
{
    public static class BarrierParticleMotion
    {
        public static void Fill(List<Vector2> particles, float width, float height, ISourceRandom random)
        {
            for (int i = 0; i < width * height / 16f; i++)
                particles.Add(new Vector2(SourceRandomMath.NextFloat(random, width - 1f),
                    SourceRandomMath.NextFloat(random, height - 1f)));
        }

        public static void FillUp<TState>(TState state) where TState : struct, IBarrierParticleMotionState
        {
            for (int i = 0; i < state.Width * state.Height / 16f; i++)
                state.Particles.Add(new Vector2(SourceRandomMath.NextFloat(state.Random, state.Width - 1f),
                    SourceRandomMath.NextFloat(state.Random, state.Height - 1f) - state.Height));
        }

        public static void AdvanceUp<TState>(TState state) where TState : struct, IBarrierParticleMotionState
        {
            int speedsCount = state.Speeds.Length;
            float height = state.Height;
            int i = 0;
            for (int count = state.Particles.Count; i < count; i++)
            {
                Vector2 value = state.Particles[i] - Vector2.UnitY * state.Speeds[i % speedsCount] * state.DeltaTime;
                value.Y %= height - 1f;
                state.Particles[i] = value;
            }
        }

        public static void FillDown<TState>(TState state) where TState : struct, IBarrierParticleMotionState
        {
            for (int i = 0; (double)i < (double)state.Width * (double)state.Height / 16.0; i++)
                state.Particles.Add(new Vector2(SourceRandomMath.NextFloat(state.Random, state.Width - 1f),
                    SourceRandomMath.NextFloat(state.Random, state.Height - 1f)));
        }

        public static void AdvanceDown<TState>(TState state) where TState : struct, IBarrierParticleMotionState
        {
            int speedsCount = state.Speeds.Length;
            int i = 0;
            for (int count = state.Particles.Count; i < count; i++)
            {
                Vector2 value = state.Particles[i] + Vector2.UnitY * state.Speeds[i % speedsCount] * state.DeltaTime;
                value.Y %= state.Height - 1f;
                state.Particles[i] = value;
            }
        }

        public static void AdvanceDown(List<Vector2> particles, float[] speeds, float height, float deltaTime)
        {
            int num = speeds.Length;
            for (int i = 0, count = particles.Count; i < count; i++)
            {
                Vector2 value = particles[i] + Vector2.UnitY * speeds[i % num] * deltaTime;
                value.Y %= height - 1f;
                particles[i] = value;
            }
        }

        public static void AdvanceWrapped(List<Vector2> particles, float[] speeds, float width, float height,
            Vector2 direction, float deltaTime)
        {
            for (int i = 0; i < particles.Count; i++)
            {
                Vector2 value = particles[i] + direction * speeds[i % speeds.Length] * deltaTime;
                while (value.X < 0) value.X += width;
                while (value.Y < 0) value.Y += height;
                value.X %= width;
                value.Y %= height;
                particles[i] = value;
            }
        }
    }
}
