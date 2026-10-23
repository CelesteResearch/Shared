using System;
using System.Numerics;

namespace Celeste.Core.Mathematics
{
    public sealed class OriginalVectorArithmetic : SourceVectorArithmetic
    {
        public override float Length(Vector3 value)
            => (float)Math.Sqrt((double)(value.X * value.X + value.Y * value.Y + value.Z * value.Z));

        public override float LengthSquared(Vector3 value)
            => value.X * value.X + value.Y * value.Y + value.Z * value.Z;

        public override float Dot(Vector3 first, Vector3 second)
            => first.X * second.X + first.Y * second.Y + first.Z * second.Z;

        public override float Distance(Vector3 first, Vector3 second)
            => (float)Math.Sqrt((double)DistanceSquared(first, second));

        public override float DistanceSquared(Vector3 first, Vector3 second)
        {
            float x = first.X - second.X, y = first.Y - second.Y, z = first.Z - second.Z;
            return x * x + y * y + z * z;
        }

        public override Vector3 Normalize(Vector3 value)
        {
            float inverse = 1f / (float)Math.Sqrt((double)(value.X * value.X + value.Y * value.Y + value.Z * value.Z));
            return new Vector3(value.X * inverse, value.Y * inverse, value.Z * inverse);
        }

        public override Vector3 Divide(Vector3 value, float divisor)
        {
            float inverse = 1f / divisor;
            value.X *= inverse;
            value.Y *= inverse;
            value.Z *= inverse;
            return value;
        }

        public static OriginalVectorArithmetic Shared { get; } = new();

        protected override Vector2 AddScaled(Vector2 value, Vector2 direction, float amount)
            => value + direction * amount;

        public override float Length(Vector2 value)
            => (float)Math.Sqrt((double)(value.X * value.X + value.Y * value.Y));

        public override float LengthSquared(Vector2 value)
            => value.X * value.X + value.Y * value.Y;

        public override float Dot(Vector2 first, Vector2 second)
            => first.X * second.X + first.Y * second.Y;

        public override float Distance(Vector2 first, Vector2 second)
        {
            float x = first.X - second.X, y = first.Y - second.Y;
            return (float)Math.Sqrt((double)(x * x + y * y));
        }

        public override float DistanceSquared(Vector2 first, Vector2 second)
        {
            float x = first.X - second.X, y = first.Y - second.Y;
            return x * x + y * y;
        }

        public override Vector2 Divide(Vector2 value, float divisor)
        {
            float reciprocal = 1f / divisor;
            value.X *= reciprocal;
            value.Y *= reciprocal;
            return value;
        }

        public override Vector2 Normalize(Vector2 value)
        {
            float scale = 1f / (float)Math.Sqrt((double)(value.X * value.X + value.Y * value.Y));
            return new Vector2(value.X * scale, value.Y * scale);
        }
    }
}
