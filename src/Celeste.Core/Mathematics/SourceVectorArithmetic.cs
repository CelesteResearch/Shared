using System.Numerics;

namespace Celeste.Core.Mathematics
{
    public abstract class SourceVectorArithmetic : ISourceVectorArithmetic
    {
        public abstract float Length(Vector3 value);
        public abstract float LengthSquared(Vector3 value);
        public abstract float Dot(Vector3 first, Vector3 second);
        public abstract float Distance(Vector3 first, Vector3 second);
        public abstract float DistanceSquared(Vector3 first, Vector3 second);
        public abstract Vector3 Normalize(Vector3 value);
        public abstract Vector3 Divide(Vector3 value, float divisor);

        public abstract float Length(Vector2 value);
        public abstract float LengthSquared(Vector2 value);
        public abstract float Dot(Vector2 first, Vector2 second);
        public abstract float Distance(Vector2 first, Vector2 second);
        public abstract float DistanceSquared(Vector2 first, Vector2 second);
        public abstract Vector2 Normalize(Vector2 value);
        public abstract Vector2 Divide(Vector2 value, float divisor);

        public Vector2 SafeNormalize(Vector2 value)
        {
            return SafeNormalize(value, Vector2.Zero);
        }

        public Vector2 SafeNormalize(Vector2 value, float length)
        {
            return SafeNormalize(value, Vector2.Zero, length);
        }

        public Vector2 SafeNormalize(Vector2 value, Vector2 ifZero)
        {
            return value == Vector2.Zero ? ifZero : Normalize(value);
        }

        public Vector2 SafeNormalize(Vector2 value, Vector2 ifZero, float length)
        {
            return value == Vector2.Zero ? ifZero * length : Normalize(value) * length;
        }

        public Vector2 Rotate(Vector2 value, float radians)
        {
            return Vector2Geometry.AngleToVector(Vector2Geometry.Angle(value) + radians, Length(value));
        }

        public Vector2 RotateTowards(Vector2 value, float targetAngle, float maxMove)
        {
            return Vector2Geometry.AngleToVector(
                ScalarMath.AngleApproach(Vector2Geometry.Angle(value), targetAngle, maxMove),
                Length(value));
        }

        public Vector2 ClosestPointOnLine(Vector2 lineA, Vector2 lineB, Vector2 point)
        {
            var delta = lineB - lineA;
            var amount = Dot(point - lineA, delta) / Dot(delta, delta);
            amount = ScalarMath.Clamp(amount, 0f, 1f);
            var scaled = delta * amount;
            return lineA + scaled;
        }

        protected abstract Vector2 AddScaled(Vector2 value, Vector2 direction, float amount);

        public Vector2 Approach(Vector2 value, Vector2 target, float maxMove)
        {
            if (maxMove == 0f || value == target) return value;
            var delta = target - value;
            if (Length(delta) < maxMove) return target;
            delta = Normalize(delta);
            return AddScaled(value, delta, maxMove);
        }

        public Vector3 SafeNormalize(Vector3 value)
        {
            var length = Length(value);
            if (length > 0f) return Divide(value, length);
            return Vector3.Zero;
        }
    }
}
