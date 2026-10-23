using System;
using System.Numerics;

namespace Celeste.Core.Mathematics
{
    public sealed class InstalledVectorArithmetic : SourceVectorArithmetic
    {
        public override float Length(Vector3 value)
            => (float)Math.Sqrt((double)value.X * value.X + (double)value.Y * value.Y + (double)value.Z * value.Z);

        public override float LengthSquared(Vector3 value)
            => (float)((double)value.X * value.X + (double)value.Y * value.Y + (double)value.Z * value.Z);

        public override float Dot(Vector3 first, Vector3 second)
            => (float)((double)first.X * second.X + (double)first.Y * second.Y + (double)first.Z * second.Z);

        public override float Distance(Vector3 first, Vector3 second)
        {
            double x = (double)first.X - second.X, y = (double)first.Y - second.Y, z = (double)first.Z - second.Z;
            return (float)Math.Sqrt(x * x + y * y + z * z);
        }

        public override float DistanceSquared(Vector3 first, Vector3 second)
        {
            double x = (double)first.X - second.X, y = (double)first.Y - second.Y, z = (double)first.Z - second.Z;
            return (float)(x * x + y * y + z * z);
        }

        public override Vector3 Normalize(Vector3 value)
        {
            double inverse = 1.0 /
                             (double)(float)Math.Sqrt((double)value.X * value.X + (double)value.Y * value.Y +
                                                      (double)value.Z * value.Z);
            return new Vector3((float)((double)value.X * inverse), (float)((double)value.Y * inverse),
                (float)((double)value.Z * inverse));
        }

        public override Vector3 Divide(Vector3 value, float divisor)
            => new Vector3(value.X / divisor, value.Y / divisor, value.Z / divisor);

        public static InstalledVectorArithmetic Shared { get; } = new();

        protected override Vector2 AddScaled(Vector2 value, Vector2 direction, float amount)
            => new((float)((double)value.X + (double)direction.X * amount),
                (float)((double)value.Y + (double)direction.Y * amount));

        public override float Length(Vector2 value)
            => (float)Math.Sqrt((double)value.X * value.X + (double)value.Y * value.Y);

        public override float LengthSquared(Vector2 value)
            => (float)((double)value.X * value.X + (double)value.Y * value.Y);

        public override float Dot(Vector2 first, Vector2 second)
            => (float)((double)first.X * second.X + (double)first.Y * second.Y);

        public override float Distance(Vector2 first, Vector2 second)
        {
            double x = (double)first.X - second.X, y = (double)first.Y - second.Y;
            return (float)Math.Sqrt(x * x + y * y);
        }

        public override float DistanceSquared(Vector2 first, Vector2 second)
        {
            double x = (double)first.X - second.X, y = (double)first.Y - second.Y;
            return (float)(x * x + y * y);
        }

        public override Vector2 Divide(Vector2 value, float divisor)
            => new Vector2(value.X / divisor, value.Y / divisor);

        public override Vector2 Normalize(Vector2 value)
        {
            double scale = 1.0 / (double)(float)Math.Sqrt((double)value.X * value.X + (double)value.Y * value.Y);
            return new Vector2((float)((double)value.X * scale), (float)((double)value.Y * scale));
        }
    }
}
