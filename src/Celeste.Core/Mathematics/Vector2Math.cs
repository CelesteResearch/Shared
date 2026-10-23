using System;
using System.Numerics;

namespace Celeste.Core.Mathematics
{
    // The installed FNA Vector2 arithmetic, operating on engine-neutral vector data.
    // Keep intermediate precision and source cast points; Numerics same-named APIs
    // are not substitutes when evaluating an original source expression.
    public static class Vector2Math
    {
        public static float Dot(Vector2 first, Vector2 second)
            => (float)((double)first.X * second.X + (double)first.Y * second.Y);

        public static float LengthSquared(Vector2 value)
            => (float)((double)value.X * value.X + (double)value.Y * value.Y);

        public static float Length(Vector2 value)
            => (float)Math.Sqrt((double)value.X * value.X + (double)value.Y * value.Y);

        public static float DistanceSquared(Vector2 first, Vector2 second)
        {
            double x = (double)first.X - second.X, y = (double)first.Y - second.Y;
            return (float)(x * x + y * y);
        }

        public static float Distance(Vector2 first, Vector2 second)
        {
            double x = (double)first.X - second.X, y = (double)first.Y - second.Y;
            return (float)Math.Sqrt(x * x + y * y);
        }

        public static Vector2 Normalize(Vector2 value)
        {
            double scale = 1.0 / (double)(float)Math.Sqrt((double)value.X * value.X + (double)value.Y * value.Y);
            return new Vector2((float)((double)value.X * scale), (float)((double)value.Y * scale));
        }

        public static Vector2 SafeNormalize(Vector2 value) => SafeNormalize(value, Vector2.Zero);
        public static Vector2 SafeNormalize(Vector2 value, float length) => SafeNormalize(value, Vector2.Zero, length);

        public static Vector2 SafeNormalize(Vector2 value, Vector2 ifZero)
            => value == Vector2.Zero ? ifZero : Normalize(value);

        public static Vector2 SafeNormalize(Vector2 value, Vector2 ifZero, float length)
            => value == Vector2.Zero ? ifZero * length : Normalize(value) * length;

        public static Vector2 Lerp(Vector2 first, Vector2 second, float amount, ISourceScalarArithmetic arithmetic)
            => Vector2Interpolation.Lerp(first, second, amount, arithmetic);

        public static Vector2 Round(Vector2 value)
            => new Vector2((float)Math.Round(value.X), (float)Math.Round(value.Y));
    }
}
