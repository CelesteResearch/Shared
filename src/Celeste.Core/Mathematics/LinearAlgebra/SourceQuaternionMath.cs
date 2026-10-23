using System;
using System.Numerics;

namespace Celeste.Core.Mathematics.LinearAlgebra
{
    public static class SourceQuaternionMath
    {
        public static Quaternion CreateFromRotationMatrix(Matrix4x4 matrix)
        {
            CreateFromRotationMatrix(ref matrix, out var result);
            return result;
        }

        public static void CreateFromRotationMatrix(ref Matrix4x4 matrix, out Quaternion result)
        {
            var num = matrix.M11 + matrix.M22 + matrix.M33;
            if (num > 0f)
            {
                var num2 = (float)Math.Sqrt(num + 1f);
                result.W = num2 * 0.5f;
                num2 = 0.5f / num2;
                result.X = (matrix.M23 - matrix.M32) * num2;
                result.Y = (matrix.M31 - matrix.M13) * num2;
                result.Z = (matrix.M12 - matrix.M21) * num2;
            }
            else if (matrix.M11 >= matrix.M22 && matrix.M11 >= matrix.M33)
            {
                var num2 = (float)Math.Sqrt(1f + matrix.M11 - matrix.M22 - matrix.M33);
                var num3 = 0.5f / num2;
                result.X = 0.5f * num2;
                result.Y = (matrix.M12 + matrix.M21) * num3;
                result.Z = (matrix.M13 + matrix.M31) * num3;
                result.W = (matrix.M23 - matrix.M32) * num3;
            }
            else if (matrix.M22 > matrix.M33)
            {
                var num2 = (float)Math.Sqrt(1f + matrix.M22 - matrix.M11 - matrix.M33);
                var num3 = 0.5f / num2;
                result.X = (matrix.M21 + matrix.M12) * num3;
                result.Y = 0.5f * num2;
                result.Z = (matrix.M32 + matrix.M23) * num3;
                result.W = (matrix.M31 - matrix.M13) * num3;
            }
            else
            {
                var num2 = (float)Math.Sqrt(1f + matrix.M33 - matrix.M11 - matrix.M22);
                var num3 = 0.5f / num2;
                result.X = (matrix.M31 + matrix.M13) * num3;
                result.Y = (matrix.M32 + matrix.M23) * num3;
                result.Z = 0.5f * num2;
                result.W = (matrix.M12 - matrix.M21) * num3;
            }
        }

        public static Quaternion CreateFromAxisAngle(Vector3 axis, float angle)
        {
            CreateFromAxisAngle(ref axis, angle, out var result);
            return result;
        }

        public static void CreateFromAxisAngle(ref Vector3 axis, float angle, out Quaternion result)
        {
            var num = angle * 0.5f;
            var num2 = (float)Math.Sin(num);
            var w = (float)Math.Cos(num);
            result.X = axis.X * num2;
            result.Y = axis.Y * num2;
            result.Z = axis.Z * num2;
            result.W = w;
        }

        public static Quaternion Slerp(Quaternion quaternion1, Quaternion quaternion2, float amount)
        {
            Slerp(ref quaternion1, ref quaternion2, amount, out var result);
            return result;
        }

        public static void Slerp(ref Quaternion quaternion1, ref Quaternion quaternion2, float amount,
            out Quaternion result)
        {
            var num = quaternion1.X * quaternion2.X + quaternion1.Y * quaternion2.Y + quaternion1.Z * quaternion2.Z +
                      quaternion1.W * quaternion2.W;
            var num2 = 1f;
            if (num < 0f)
            {
                num2 = -1f;
                num = -num;
            }

            float num3;
            float num4;
            if (num > 0.999999f)
            {
                num3 = 1f - amount;
                num4 = amount * num2;
            }
            else
            {
                var num5 = (float)Math.Acos(num);
                var num6 = (float)(1.0 / Math.Sin(num5));
                num3 = (float)Math.Sin((1f - amount) * num5) * num6;
                num4 = num2 * ((float)Math.Sin(amount * num5) * num6);
            }

            result.X = num3 * quaternion1.X + num4 * quaternion2.X;
            result.Y = num3 * quaternion1.Y + num4 * quaternion2.Y;
            result.Z = num3 * quaternion1.Z + num4 * quaternion2.Z;
            result.W = num3 * quaternion1.W + num4 * quaternion2.W;
        }

        public static Quaternion Multiply(Quaternion quaternion1, Quaternion quaternion2)
        {
            Multiply(ref quaternion1, ref quaternion2, out var result);
            return result;
        }

        public static void Multiply(ref Quaternion quaternion1, ref Quaternion quaternion2, out Quaternion result)
        {
            var x = quaternion1.X;
            var y = quaternion1.Y;
            var z = quaternion1.Z;
            var w = quaternion1.W;
            var x2 = quaternion2.X;
            var y2 = quaternion2.Y;
            var z2 = quaternion2.Z;
            var w2 = quaternion2.W;
            var num = y * z2 - z * y2;
            var num2 = z * x2 - x * z2;
            var num3 = x * y2 - y * x2;
            var num4 = x * x2 + y * y2 + z * z2;
            result.X = x * w2 + x2 * w + num;
            result.Y = y * w2 + y2 * w + num2;
            result.Z = z * w2 + z2 * w + num3;
            result.W = w * w2 - num4;
        }

        public static Quaternion Conjugate(Quaternion value)
        {
            return new(-value.X, -value.Y, -value.Z, value.W);
        }

        public static Quaternion LookAt(Vector3 from, Vector3 to, Vector3 up, ISourceVectorArithmetic arithmetic)
        {
            return CreateFromRotationMatrix(SourceMatrixMath.CreateLookAt(from, to, up, arithmetic));
        }

        public static Quaternion LookAt(Vector3 direction, Vector3 up, ISourceVectorArithmetic arithmetic)
        {
            return CreateFromRotationMatrix(SourceMatrixMath.CreateLookAt(Vector3.Zero, direction, up, arithmetic));
        }

        public static Vector3 Forward(Quaternion value)
        {
            return SourceVector3Math.Transform(new(0f, 0f, -1f), Conjugate(value));
        }

        public static Vector3 Left(Quaternion value)
        {
            return SourceVector3Math.Transform(new(-1f, 0f, 0f), Conjugate(value));
        }

        public static Vector3 Up(Quaternion value)
        {
            return SourceVector3Math.Transform(Vector3.UnitY, Conjugate(value));
        }
    }
}
