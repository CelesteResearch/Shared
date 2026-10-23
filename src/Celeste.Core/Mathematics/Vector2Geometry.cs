using System;
using System.Numerics;

namespace Celeste.Core.Mathematics
{
    public static class Vector2Geometry
    {
        public static Vector2 ClosestPointOnLine(Vector2 first, Vector2 second,
            Vector2 closestTo, ISourceVectorArithmetic arithmetic)
        {
            return arithmetic.ClosestPointOnLine(first, second, closestTo);
        }

        public static Vector2 Floor(Vector2 value)
        {
            return new(unchecked((int)Math.Floor(value.X)), unchecked((int)Math.Floor(value.Y)));
        }

        public static Vector2 Round(Vector2 value)
        {
            return new((float)Math.Round(value.X), (float)Math.Round(value.Y));
        }

        public static Vector2 Perpendicular(Vector2 value)
        {
            return new(-value.Y, value.X);
        }

        public static float Angle(Vector2 value)
        {
            return (float)Math.Atan2(value.Y, value.X);
        }

        public static float Angle(Vector2 from, Vector2 to)
        {
            return (float)Math.Atan2(to.Y - from.Y, to.X - from.X);
        }

        public static Vector2 AngleToVector(float angle, float length)
        {
            return new((float)Math.Cos(angle) * length, (float)Math.Sin(angle) * length);
        }

        public static Vector2 FourWayNormal(Vector2 vec)
        {
            if (vec == Vector2.Zero) return Vector2.Zero;
            vec = AngleToVector(
                (float)Math.Floor((Angle(vec) + (float)Math.PI / 4f) / ((float)Math.PI / 2f)) * ((float)Math.PI / 2f),
                1f);
            vec.X = Math.Abs(vec.X) < .5f ? 0f : Math.Sign(vec.X);
            vec.Y = Math.Abs(vec.Y) < .5f ? 0f : Math.Sign(vec.Y);
            return vec;
        }

        public static Vector2 EightWayNormal(Vector2 vec)
        {
            if (vec == Vector2.Zero) return Vector2.Zero;

            vec = AngleToVector(
                (float)Math.Floor((Angle(vec) + (float)Math.PI / 8f) / ((float)Math.PI / 4f)) * ((float)Math.PI / 4f),
                1f);
            if (Math.Abs(vec.X) < 0.5f)
                vec.X = 0f;
            else if (Math.Abs(vec.Y) < 0.5f) vec.Y = 0f;

            return vec;
        }
    }
}
