using System;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Randomness;

namespace Celeste.Simulation.Gameplay.Effects.Debris
{
    public static class CrystalDebrisPhysics
    {
        public static void Initialize(ISourceRandom random, bool boss, float? fixedDuration,
            out float duration, out Vector2 speed)
        {
            duration = fixedDuration ?? (boss
                ? SourceRandomMath.Range(random, .25f, 1f)
                : SourceRandomMath.Range(random, 1f, 2f));
            speed = Vector2Geometry.AngleToVector(SourceRandomMath.NextAngle(random),
                boss ? SourceRandomMath.Range(random, 200, 240) : SourceRandomMath.Range(random, 60, 160));
        }

        public static bool Advance(ref Vector2 speed, ref float percent, float duration, bool boss, float deltaTime,
            ISourceVectorArithmetic vectors, ISourceExtremaArithmetic extrema, out Vector2 scale, out float? rotation)
        {
            if (percent > 1f)
            {
                scale = default;
                rotation = null;
                return false;
            }

            percent += deltaTime / duration;
            if (!boss)
            {
                speed.X = ScalarMath.Approach(speed.X, 0f, deltaTime * 20f, extrema);
                speed.Y += 200f * deltaTime;
            }
            else
            {
                float value = vectors.Length(speed);
                value = ScalarMath.Approach(value, 0f, 300f * deltaTime, extrema);
                speed = vectors.SafeNormalize(speed) * value;
            }

            rotation = vectors.Length(speed) > 0f ? Vector2Geometry.Angle(speed) : null;
            scale = Vector2.One * ScalarMath.ClampedMap(percent, .8f, 1f, 1f, 0f);
            scale.X *= ScalarMath.ClampedMap(vectors.Length(speed), 0f, 400f, 1f, 2f);
            scale.Y *= ScalarMath.ClampedMap(vectors.Length(speed), 0f, 400f, 1f, .2f);
            return true;
        }

        public static void BounceHorizontal(ref Vector2 speed) => speed.X *= -.8f;

        public static bool BounceVertical(ref Vector2 speed, bool boss, ISourceRandom random)
        {
            if (boss) return false;
            if (Math.Sign(speed.X) != 0) speed.X += Math.Sign(speed.X) * 5;
            else speed.X += RandomSelection.Choose(random, -1, 1) * 5;
            speed.Y *= -1.2f;
            return true;
        }
    }
}
