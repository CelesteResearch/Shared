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
        {
            return (float)((double)first.X * second.X + (double)first.Y * second.Y);
        }

        public static float LengthSquared(Vector2 value)
        {
            return (float)((double)value.X * value.X + (double)value.Y * value.Y);
        }

        public static float Length(Vector2 value)
        {
            return (float)Math.Sqrt((double)value.X * value.X + (double)value.Y * value.Y);
        }

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
            var scale = 1.0 / (float)Math.Sqrt((double)value.X * value.X + (double)value.Y * value.Y);
            return new((float)(value.X * scale), (float)(value.Y * scale));
        }

        public static Vector2 SafeNormalize(Vector2 value)
        {
            return SafeNormalize(value, Vector2.Zero);
        }

        public static Vector2 SafeNormalize(Vector2 value, float length)
        {
            return SafeNormalize(value, Vector2.Zero, length);
        }

        public static Vector2 SafeNormalize(Vector2 value, Vector2 ifZero)
        {
            return value == Vector2.Zero ? ifZero : Normalize(value);
        }

        public static Vector2 SafeNormalize(Vector2 value, Vector2 ifZero, float length)
        {
            return value == Vector2.Zero ? ifZero * length : Normalize(value) * length;
        }

        public static Vector2 Lerp(Vector2 first, Vector2 second, float amount, ISourceScalarArithmetic arithmetic)
        {
            return Vector2Interpolation.Lerp(first, second, amount, arithmetic);
        }

        public static Vector2 Round(Vector2 value)
        {
            return new((float)Math.Round(value.X), (float)Math.Round(value.Y));
        }
    }
}
