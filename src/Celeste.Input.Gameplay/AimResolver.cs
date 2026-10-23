using System;
using System.Numerics;

namespace Celeste.Input.Gameplay
{
    public sealed class AimResolver
    {
        public Vector2 LastAim;

        public Vector2 Resolve(Vector2 value, int defaultFacing = 1, bool dashAssist = false, bool fullCircle = false)
        {
            if (value == Vector2.Zero)
            {
                if (dashAssist) return LastAim;
                LastAim = Vector2.UnitX * defaultFacing;
            }
            else if (fullCircle) LastAim = Normalize(value);
            else
            {
                float angle = (float)Math.Atan2(value.Y, value.X);
                int upper = angle < 0 ? 1 : 0;
                float window = (float)Math.PI / 8f - upper * .08726646f;
                if (Difference(angle, 0) < window) LastAim = new Vector2(1, 0);
                else if (Difference(angle, (float)Math.PI) < window) LastAim = new Vector2(-1, 0);
                else if (Difference(angle, -(float)Math.PI / 2f) < window) LastAim = new Vector2(0, -1);
                else if (Difference(angle, (float)Math.PI / 2f) < window) LastAim = new Vector2(0, 1);
                else LastAim = Normalize(new Vector2(Math.Sign(value.X), Math.Sign(value.Y)));
            }

            return LastAim;
        }

        private static float Difference(float a, float b)
        {
            float result = b - a;
            while (result > (float)Math.PI) result -= (float)Math.PI * 2f;
            while (result <= -(float)Math.PI) result += (float)Math.PI * 2f;
            return Math.Abs(result);
        }

        private static Vector2 Normalize(Vector2 value)
        {
            // XNA normalizes by multiplying by a single reciprocal, rather than vector division.
            float inverse = 1f / (float)Math.Sqrt(value.X * value.X + value.Y * value.Y);
            return new Vector2(value.X * inverse, value.Y * inverse);
        }
    }
}
