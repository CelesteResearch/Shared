using System.Numerics;

namespace Celeste.Core.Mathematics.LinearAlgebra
{
    public static class SourceVector3Math
    {
        public static Vector3 Transform(Vector3 position, Matrix4x4 matrix)
        {
            Transform(ref position, ref matrix, out position);
            return position;
        }

        public static void Transform(ref Vector3 position, ref Matrix4x4 matrix, out Vector3 result)
        {
            float x = position.X * matrix.M11 + position.Y * matrix.M21 + position.Z * matrix.M31 + matrix.M41;
            float y = position.X * matrix.M12 + position.Y * matrix.M22 + position.Z * matrix.M32 + matrix.M42;
            float z = position.X * matrix.M13 + position.Y * matrix.M23 + position.Z * matrix.M33 + matrix.M43;
            result.X = x;
            result.Y = y;
            result.Z = z;
        }

        public static Vector3 Cross(Vector3 first, Vector3 second)
        {
            Cross(ref first, ref second, out first);
            return first;
        }

        public static void Cross(ref Vector3 first, ref Vector3 second, out Vector3 result)
        {
            float x = first.Y * second.Z - second.Y * first.Z;
            float y = -(first.X * second.Z - second.X * first.Z);
            float z = first.X * second.Y - second.X * first.Y;
            result = new Vector3(x, y, z);
        }

        public static Vector3 Transform(Vector3 value, Quaternion rotation)
        {
            Transform(ref value, ref rotation, out var result);
            return result;
        }

        public static void Transform(ref Vector3 value, ref Quaternion rotation, out Vector3 result)
        {
            float num = 2f * (rotation.Y * value.Z - rotation.Z * value.Y);
            float num2 = 2f * (rotation.Z * value.X - rotation.X * value.Z);
            float num3 = 2f * (rotation.X * value.Y - rotation.Y * value.X);
            result.X = value.X + num * rotation.W + (rotation.Y * num3 - rotation.Z * num2);
            result.Y = value.Y + num2 * rotation.W + (rotation.Z * num - rotation.X * num3);
            result.Z = value.Z + num3 * rotation.W + (rotation.X * num2 - rotation.Y * num);
        }

        public static Vector3 Lerp(Vector3 first, Vector3 second, float amount, ISourceScalarArithmetic arithmetic)
            => new Vector3(arithmetic.Lerp(first.X, second.X, amount),
                arithmetic.Lerp(first.Y, second.Y, amount), arithmetic.Lerp(first.Z, second.Z, amount));

        public static void Lerp(ref Vector3 first, ref Vector3 second, float amount,
            ISourceScalarArithmetic arithmetic, out Vector3 result)
        {
            result.X = arithmetic.Lerp(first.X, second.X, amount);
            result.Y = arithmetic.Lerp(first.Y, second.Y, amount);
            result.Z = arithmetic.Lerp(first.Z, second.Z, amount);
        }

        public static Vector3 Add(Vector3 first, Vector3 second)
        {
            first.X += second.X;
            first.Y += second.Y;
            first.Z += second.Z;
            return first;
        }

        public static void Add(ref Vector3 first, ref Vector3 second, out Vector3 result)
        {
            result.X = first.X + second.X;
            result.Y = first.Y + second.Y;
            result.Z = first.Z + second.Z;
        }

        public static Vector3 Multiply(Vector3 first, Vector3 second)
        {
            first.X *= second.X;
            first.Y *= second.Y;
            first.Z *= second.Z;
            return first;
        }

        public static Vector3 Multiply(Vector3 value, float scale)
        {
            value.X *= scale;
            value.Y *= scale;
            value.Z *= scale;
            return value;
        }

        public static Vector3 Multiply(float scale, Vector3 value) => Multiply(value, scale);

        public static void Multiply(ref Vector3 value, float scale, out Vector3 result)
        {
            result.X = value.X * scale;
            result.Y = value.Y * scale;
            result.Z = value.Z * scale;
        }

        public static void Multiply(ref Vector3 first, ref Vector3 second, out Vector3 result)
        {
            result.X = first.X * second.X;
            result.Y = first.Y * second.Y;
            result.Z = first.Z * second.Z;
        }

        public static Vector3 Subtract(Vector3 first, Vector3 second)
        {
            first.X -= second.X;
            first.Y -= second.Y;
            first.Z -= second.Z;
            return first;
        }

        public static void Subtract(ref Vector3 first, ref Vector3 second, out Vector3 result)
        {
            result.X = first.X - second.X;
            result.Y = first.Y - second.Y;
            result.Z = first.Z - second.Z;
        }
    }
}
