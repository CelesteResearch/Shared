using System;
using System.Numerics;
using Celeste.Core.Mathematics.Easing;

namespace Celeste.Simulation
{
    // Monocle Calc helpers. Only the shapes the ported entities call are reproduced.
    public static class FarewellPropsMath
    {
        public static float Clamp(float value, float min, float max)
        {
            return Math.Min(Math.Max(value, min), max);
        }

        public static float ClampedMap(float value, float min, float max, float newMin = 0f, float newMax = 1f)
        {
            return Clamp((value - min) / (max - min), 0f, 1f) * (newMax - newMin) + newMin;
        }

        // Calc.Approach(Vector2, Vector2, float); the normalisation goes through SafeNormalize,
        // which matches Calc.SafeNormalize(value) -> FNA Vector2.Normalize.
        public static Vector2 Approach(Vector2 value, Vector2 target, float maxMove)
        {
            if (maxMove == 0f || value == target) return value;
            var delta = target - value;
            return Length(delta) < maxMove ? target : value + SafeNormalize(delta) * maxMove;
        }

        public static float Angle(Vector2 vector)
        {
            return (float)Math.Atan2(vector.Y, vector.X);
        }

        public static float Angle(Vector2 from, Vector2 to)
        {
            return (float)Math.Atan2(to.Y - from.Y, to.X - from.X);
        }

        public static float AngleDiff(float radiansA, float radiansB)
        {
            float difference;
            for (difference = radiansB - radiansA; difference > (float)Math.PI; difference -= (float)Math.PI * 2f)
            {
            }

            for (; difference <= -(float)Math.PI; difference += (float)Math.PI * 2f)
            {
            }

            return difference;
        }

        public static float AngleLerp(float startAngle, float endAngle, float percent)
        {
            return startAngle + AngleDiff(startAngle, endAngle) * percent;
        }

        public static Vector2 AngleToVector(float angleRadians, float length)
        {
            return new((float)Math.Cos(angleRadians) * length, (float)Math.Sin(angleRadians) * length);
        }

        // Monocle Calc.SafeNormalize normalises through FNA's in-place Vector2.Normalize, which
        // multiplies by the reciprocal length rather than dividing by it, then scales the result.
        public static Vector2 SafeNormalize(Vector2 value, float length)
        {
            if (value == Vector2.Zero) return Vector2.Zero;
            var scale = 1f / (float)Math.Sqrt(value.X * value.X + value.Y * value.Y);
            if (float.IsNaN(scale)) return Vector2.Zero;
            return new Vector2(value.X * scale, value.Y * scale) * length;
        }

        public static Vector2 SafeNormalize(Vector2 value)
        {
            return SafeNormalize(value, 1f);
        }

        public static float Length(Vector2 value)
        {
            return (float)Math.Sqrt(value.X * value.X + value.Y * value.Y);
        }

        public static float LengthSquared(Vector2 value)
        {
            return value.X * value.X + value.Y * value.Y;
        }

        public static Vector2 Floor(Vector2 value)
        {
            return new((int)Math.Floor(value.X), (int)Math.Floor(value.Y));
        }

        public static Vector2 Clamp(Vector2 value, float minX, float minY, float maxX, float maxY)
        {
            return new(Clamp(value.X, minX, maxX), Clamp(value.Y, minY, maxY));
        }

        // Calc.Random.NextFloat(max) is `(float)Random.NextDouble() * max`.
        public static float NextFloat(Random random, float max)
        {
            return (float)random.NextDouble() * max;
        }

        public static float NextFloat(Random random)
        {
            return (float)random.NextDouble();
        }

        // Calc.Random.Range(min,max) is `min + (float)Random.NextDouble() * (max - min)`.
        public static float Range(Random random, float min, float max)
        {
            return min + (float)random.NextDouble() * (max - min);
        }

        public static int Choose(Random random, int a, int b)
        {
            return random.Next(2) == 0 ? a : b;
        }

        // XNA MathHelper.Lerp per component; System.Numerics.Vector2.Lerp blends
        // value1 * (1 - amount) + value2 * amount, which is one ulp away for the same inputs.
        public static Vector2 Lerp(Vector2 from, Vector2 to, float amount)
        {
            return new((float)(from.X + ((double)to.X - from.X) * amount),
                (float)(from.Y + ((double)to.Y - from.Y) * amount));
        }

        public static float Sin(float value)
        {
            return (float)Math.Sin(value);
        }

        public static float Cos(float value)
        {
            return (float)Math.Cos(value);
        }

        public static float Mod(float value, float modulo)
        {
            return (value % modulo + modulo) % modulo;
        }

        // Installed Ease.SineInOut uses double PI/input, rounds Cos to Single,
        // then rounds the delegate result after the half/offset calculation.
        public static float EaseSineInOut(float value)
        {
            return InstalledEasingArithmetic.EvaluateSineInOut(value);
        }

        // Installed Ease.CubeIn/Invert/Follow round at each delegate boundary,
        // not between every arithmetic operation. Keep those boundaries on Mono too.
        public static float EaseCubeInOut(float value)
        {
            if (value <= .5f)
            {
                var x = (float)((double)value * 2);
                return (float)((double)(float)((double)x * x * x) / 2);
            }

            var inner = (float)(1.0 - (float)((double)value * 2 - 1));
            var inverse = (float)(1.0 - (float)((double)inner * inner * inner));
            return (float)((double)inverse / 2 + .5);
        }

        public static float EaseSineIn(float value)
        {
            return (float)(1.0 - (float)Math.Cos((double)((float)Math.PI / 2f) * value));
        }

        // Draw.Rect truncates its float destination to int before submitting the quad.
        public static int Truncate(float value)
        {
            return (int)value;
        }
    }
}
