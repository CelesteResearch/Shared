using System;
using System.Numerics;

namespace Celeste.Core.Mathematics.LinearAlgebra
{
    public static class SourceMatrixMath
    {
        public static Matrix4x4 CreateRotationZ(float radians)
        {
            CreateRotationZ(radians, out var result);
            return result;
        }

        public static void CreateRotationZ(float radians, out Matrix4x4 result)
        {
            result = Matrix4x4.Identity;
            var cosine = (float)Math.Cos(radians);
            var sine = (float)Math.Sin(radians);
            result.M11 = cosine;
            result.M12 = sine;
            result.M21 = -sine;
            result.M22 = cosine;
        }

        public static Matrix4x4 CreateScale(float scale)
        {
            CreateScale(scale, scale, scale, out var result);
            return result;
        }

        public static void CreateScale(float scale, out Matrix4x4 result)
        {
            CreateScale(scale, scale, scale, out result);
        }

        public static Matrix4x4 Multiply(Matrix4x4 matrix1, Matrix4x4 matrix2)
        {
            var m = matrix1.M11 * matrix2.M11 + matrix1.M12 * matrix2.M21 + matrix1.M13 * matrix2.M31 +
                    matrix1.M14 * matrix2.M41;
            var m2 = matrix1.M11 * matrix2.M12 + matrix1.M12 * matrix2.M22 + matrix1.M13 * matrix2.M32 +
                     matrix1.M14 * matrix2.M42;
            var m3 = matrix1.M11 * matrix2.M13 + matrix1.M12 * matrix2.M23 + matrix1.M13 * matrix2.M33 +
                     matrix1.M14 * matrix2.M43;
            var m4 = matrix1.M11 * matrix2.M14 + matrix1.M12 * matrix2.M24 + matrix1.M13 * matrix2.M34 +
                     matrix1.M14 * matrix2.M44;
            var m5 = matrix1.M21 * matrix2.M11 + matrix1.M22 * matrix2.M21 + matrix1.M23 * matrix2.M31 +
                     matrix1.M24 * matrix2.M41;
            var m6 = matrix1.M21 * matrix2.M12 + matrix1.M22 * matrix2.M22 + matrix1.M23 * matrix2.M32 +
                     matrix1.M24 * matrix2.M42;
            var m7 = matrix1.M21 * matrix2.M13 + matrix1.M22 * matrix2.M23 + matrix1.M23 * matrix2.M33 +
                     matrix1.M24 * matrix2.M43;
            var m8 = matrix1.M21 * matrix2.M14 + matrix1.M22 * matrix2.M24 + matrix1.M23 * matrix2.M34 +
                     matrix1.M24 * matrix2.M44;
            var m9 = matrix1.M31 * matrix2.M11 + matrix1.M32 * matrix2.M21 + matrix1.M33 * matrix2.M31 +
                     matrix1.M34 * matrix2.M41;
            var m10 = matrix1.M31 * matrix2.M12 + matrix1.M32 * matrix2.M22 + matrix1.M33 * matrix2.M32 +
                      matrix1.M34 * matrix2.M42;
            var m11 = matrix1.M31 * matrix2.M13 + matrix1.M32 * matrix2.M23 + matrix1.M33 * matrix2.M33 +
                      matrix1.M34 * matrix2.M43;
            var m12 = matrix1.M31 * matrix2.M14 + matrix1.M32 * matrix2.M24 + matrix1.M33 * matrix2.M34 +
                      matrix1.M34 * matrix2.M44;
            var m13 = matrix1.M41 * matrix2.M11 + matrix1.M42 * matrix2.M21 + matrix1.M43 * matrix2.M31 +
                      matrix1.M44 * matrix2.M41;
            var m14 = matrix1.M41 * matrix2.M12 + matrix1.M42 * matrix2.M22 + matrix1.M43 * matrix2.M32 +
                      matrix1.M44 * matrix2.M42;
            var m15 = matrix1.M41 * matrix2.M13 + matrix1.M42 * matrix2.M23 + matrix1.M43 * matrix2.M33 +
                      matrix1.M44 * matrix2.M43;
            var m16 = matrix1.M41 * matrix2.M14 + matrix1.M42 * matrix2.M24 + matrix1.M43 * matrix2.M34 +
                      matrix1.M44 * matrix2.M44;
            matrix1.M11 = m;
            matrix1.M12 = m2;
            matrix1.M13 = m3;
            matrix1.M14 = m4;
            matrix1.M21 = m5;
            matrix1.M22 = m6;
            matrix1.M23 = m7;
            matrix1.M24 = m8;
            matrix1.M31 = m9;
            matrix1.M32 = m10;
            matrix1.M33 = m11;
            matrix1.M34 = m12;
            matrix1.M41 = m13;
            matrix1.M42 = m14;
            matrix1.M43 = m15;
            matrix1.M44 = m16;
            return matrix1;
        }

        public static Matrix4x4 CreateScale(float xScale, float yScale, float zScale)
        {
            CreateScale(xScale, yScale, zScale, out var result);
            return result;
        }

        public static void CreateScale(float xScale, float yScale, float zScale, out Matrix4x4 result)
        {
            result.M11 = xScale;
            result.M12 = 0f;
            result.M13 = 0f;
            result.M14 = 0f;
            result.M21 = 0f;
            result.M22 = yScale;
            result.M23 = 0f;
            result.M24 = 0f;
            result.M31 = 0f;
            result.M32 = 0f;
            result.M33 = zScale;
            result.M34 = 0f;
            result.M41 = 0f;
            result.M42 = 0f;
            result.M43 = 0f;
            result.M44 = 1f;
        }

        public static Matrix4x4 CreateTranslation(Vector3 position)
        {
            CreateTranslation(ref position, out var result);
            return result;
        }

        public static void CreateTranslation(ref Vector3 position, out Matrix4x4 result)
        {
            result.M11 = 1f;
            result.M12 = 0f;
            result.M13 = 0f;
            result.M14 = 0f;
            result.M21 = 0f;
            result.M22 = 1f;
            result.M23 = 0f;
            result.M24 = 0f;
            result.M31 = 0f;
            result.M32 = 0f;
            result.M33 = 1f;
            result.M34 = 0f;
            result.M41 = position.X;
            result.M42 = position.Y;
            result.M43 = position.Z;
            result.M44 = 1f;
        }

        public static Matrix4x4 CreateTranslation(float xPosition, float yPosition, float zPosition)
        {
            CreateTranslation(xPosition, yPosition, zPosition, out var result);
            return result;
        }

        public static void CreateTranslation(float xPosition, float yPosition, float zPosition, out Matrix4x4 result)
        {
            result.M11 = 1f;
            result.M12 = 0f;
            result.M13 = 0f;
            result.M14 = 0f;
            result.M21 = 0f;
            result.M22 = 1f;
            result.M23 = 0f;
            result.M24 = 0f;
            result.M31 = 0f;
            result.M32 = 0f;
            result.M33 = 1f;
            result.M34 = 0f;
            result.M41 = xPosition;
            result.M42 = yPosition;
            result.M43 = zPosition;
            result.M44 = 1f;
        }


        public static Matrix4x4 Invert(Matrix4x4 matrix)
        {
            Invert(ref matrix, out matrix);
            return matrix;
        }

        public static void Invert(ref Matrix4x4 matrix, out Matrix4x4 result)
        {
            var m = matrix.M11;
            var m2 = matrix.M12;
            var m3 = matrix.M13;
            var m4 = matrix.M14;
            var m5 = matrix.M21;
            var m6 = matrix.M22;
            var m7 = matrix.M23;
            var m8 = matrix.M24;
            var m9 = matrix.M31;
            var m10 = matrix.M32;
            var m11 = matrix.M33;
            var m12 = matrix.M34;
            var m13 = matrix.M41;
            var m14 = matrix.M42;
            var m15 = matrix.M43;
            var m16 = matrix.M44;
            var num = (float)(m11 * (double)m16 - m12 * (double)m15);
            var num2 = (float)(m10 * (double)m16 - m12 * (double)m14);
            var num3 = (float)(m10 * (double)m15 - m11 * (double)m14);
            var num4 = (float)(m9 * (double)m16 - m12 * (double)m13);
            var num5 = (float)(m9 * (double)m15 - m11 * (double)m13);
            var num6 = (float)(m9 * (double)m14 - m10 * (double)m13);
            var num7 = (float)(m6 * (double)num - m7 * (double)num2 + m8 * (double)num3);
            var num8 =
                (float)(0.0 - (m5 * (double)num - m7 * (double)num4 + m8 * (double)num5));
            var num9 = (float)(m5 * (double)num2 - m6 * (double)num4 + m8 * (double)num6);
            var num10 =
                (float)(0.0 - (m5 * (double)num3 - m6 * (double)num5 + m7 * (double)num6));
            var num11 = (float)(1.0 / (m * (double)num7 + m2 * (double)num8 +
                                       m3 * (double)num9 +
                                       m4 * (double)num10));
            result.M11 = num7 * num11;
            result.M21 = num8 * num11;
            result.M31 = num9 * num11;
            result.M41 = num10 * num11;
            result.M12 =
                (float)((0.0 - (m2 * (double)num - m3 * (double)num2 + m4 * (double)num3)) *
                        num11);
            result.M22 = (float)((m * (double)num - m3 * (double)num4 + m4 * (double)num5) *
                                 num11);
            result.M32 =
                (float)((0.0 - (m * (double)num2 - m2 * (double)num4 + m4 * (double)num6)) *
                        num11);
            result.M42 = (float)((m * (double)num3 - m2 * (double)num5 + m3 * (double)num6) *
                                 num11);
            var num12 = (float)(m7 * (double)m16 - m8 * (double)m15);
            var num13 = (float)(m6 * (double)m16 - m8 * (double)m14);
            var num14 = (float)(m6 * (double)m15 - m7 * (double)m14);
            var num15 = (float)(m5 * (double)m16 - m8 * (double)m13);
            var num16 = (float)(m5 * (double)m15 - m7 * (double)m13);
            var num17 = (float)(m5 * (double)m14 - m6 * (double)m13);
            result.M13 =
                (float)((m2 * (double)num12 - m3 * (double)num13 + m4 * (double)num14) *
                        num11);
            result.M23 =
                (float)((0.0 - (m * (double)num12 - m3 * (double)num15 + m4 * (double)num16)) *
                        num11);
            result.M33 = (float)((m * (double)num13 - m2 * (double)num15 + m4 * (double)num17) *
                                 num11);
            result.M43 =
                (float)((0.0 - (m * (double)num14 - m2 * (double)num16 + m3 * (double)num17)) *
                        num11);
            var num18 = (float)(m7 * (double)m12 - m8 * (double)m11);
            var num19 = (float)(m6 * (double)m12 - m8 * (double)m10);
            var num20 = (float)(m6 * (double)m11 - m7 * (double)m10);
            var num21 = (float)(m5 * (double)m12 - m8 * (double)m9);
            var num22 = (float)(m5 * (double)m11 - m7 * (double)m9);
            var num23 = (float)(m5 * (double)m10 - m6 * (double)m9);
            result.M14 =
                (float)((0.0 - (m2 * (double)num18 - m3 * (double)num19 + m4 * (double)num20)) *
                        num11);
            result.M24 = (float)((m * (double)num18 - m3 * (double)num21 + m4 * (double)num22) *
                                 num11);
            result.M34 =
                (float)((0.0 - (m * (double)num19 - m2 * (double)num21 + m4 * (double)num23)) *
                        num11);
            result.M44 = (float)((m * (double)num20 - m2 * (double)num22 + m3 * (double)num23) *
                                 num11);
        }

        public static Matrix4x4 Transpose(Matrix4x4 matrix)
        {
            Transpose(ref matrix, out var result);
            return result;
        }

        public static void Transpose(ref Matrix4x4 matrix, out Matrix4x4 result)
        {
            var matrix2 = default(Matrix4x4);
            matrix2.M11 = matrix.M11;
            matrix2.M12 = matrix.M21;
            matrix2.M13 = matrix.M31;
            matrix2.M14 = matrix.M41;
            matrix2.M21 = matrix.M12;
            matrix2.M22 = matrix.M22;
            matrix2.M23 = matrix.M32;
            matrix2.M24 = matrix.M42;
            matrix2.M31 = matrix.M13;
            matrix2.M32 = matrix.M23;
            matrix2.M33 = matrix.M33;
            matrix2.M34 = matrix.M43;
            matrix2.M41 = matrix.M14;
            matrix2.M42 = matrix.M24;
            matrix2.M43 = matrix.M34;
            matrix2.M44 = matrix.M44;
            result = matrix2;
        }

        public static Matrix4x4 CreatePerspectiveFieldOfView(float fieldOfView, float aspectRatio,
            float nearPlaneDistance,
            float farPlaneDistance)
        {
            CreatePerspectiveFieldOfView(fieldOfView, aspectRatio, nearPlaneDistance, farPlaneDistance, out var result);
            return result;
        }

        public static void CreatePerspectiveFieldOfView(float fieldOfView, float aspectRatio, float nearPlaneDistance,
            float farPlaneDistance, out Matrix4x4 result)
        {
            if (fieldOfView <= 0f || fieldOfView >= 3.1415927f)
                throw new ArgumentException("fieldOfView <= 0 or >= PI");

            if (nearPlaneDistance <= 0f) throw new ArgumentException("nearPlaneDistance <= 0");

            if (farPlaneDistance <= 0f) throw new ArgumentException("farPlaneDistance <= 0");

            if (nearPlaneDistance >= farPlaneDistance)
                throw new ArgumentException("nearPlaneDistance >= farPlaneDistance");

            var num = 1f / (float)Math.Tan(fieldOfView * 0.5f);
            var m = num / aspectRatio;
            result.M11 = m;
            result.M12 = result.M13 = result.M14 = 0f;
            result.M22 = num;
            result.M21 = result.M23 = result.M24 = 0f;
            result.M31 = result.M32 = 0f;
            result.M33 = farPlaneDistance / (nearPlaneDistance - farPlaneDistance);
            result.M34 = -1f;
            result.M41 = result.M42 = result.M44 = 0f;
            result.M43 = nearPlaneDistance * farPlaneDistance / (nearPlaneDistance - farPlaneDistance);
        }

        public static Matrix4x4 CreateFromQuaternion(Quaternion quaternion)
        {
            CreateFromQuaternion(ref quaternion, out var result);
            return result;
        }

        public static void CreateFromQuaternion(ref Quaternion quaternion, out Matrix4x4 result)
        {
            var num = quaternion.X * quaternion.X;
            var num2 = quaternion.Y * quaternion.Y;
            var num3 = quaternion.Z * quaternion.Z;
            var num4 = quaternion.X * quaternion.Y;
            var num5 = quaternion.Z * quaternion.W;
            var num6 = quaternion.Z * quaternion.X;
            var num7 = quaternion.Y * quaternion.W;
            var num8 = quaternion.Y * quaternion.Z;
            var num9 = quaternion.X * quaternion.W;
            result.M11 = 1f - 2f * (num2 + num3);
            result.M12 = 2f * (num4 + num5);
            result.M13 = 2f * (num6 - num7);
            result.M14 = 0f;
            result.M21 = 2f * (num4 - num5);
            result.M22 = 1f - 2f * (num3 + num);
            result.M23 = 2f * (num8 + num9);
            result.M24 = 0f;
            result.M31 = 2f * (num6 + num7);
            result.M32 = 2f * (num8 - num9);
            result.M33 = 1f - 2f * (num2 + num);
            result.M34 = 0f;
            result.M41 = 0f;
            result.M42 = 0f;
            result.M43 = 0f;
            result.M44 = 1f;
        }

        public static Matrix4x4 CreateRotationX(float radians)
        {
            CreateRotationX(radians, out var result);
            return result;
        }

        public static void CreateRotationX(float radians, out Matrix4x4 result)
        {
            result = Matrix4x4.Identity;
            var num = (float)Math.Cos(radians);
            var num2 = (float)Math.Sin(radians);
            result.M22 = num;
            result.M23 = num2;
            result.M32 = -num2;
            result.M33 = num;
        }

        public static Matrix4x4 CreateRotationY(float radians)
        {
            CreateRotationY(radians, out var result);
            return result;
        }

        public static void CreateRotationY(float radians, out Matrix4x4 result)
        {
            result = Matrix4x4.Identity;
            var num = (float)Math.Cos(radians);
            var num2 = (float)Math.Sin(radians);
            result.M11 = num;
            result.M13 = -num2;
            result.M31 = num2;
            result.M33 = num;
        }

        public static Matrix4x4 CreateLookAt(Vector3 cameraPosition, Vector3 cameraTarget, Vector3 cameraUpVector,
            ISourceVectorArithmetic arithmetic)
        {
            CreateLookAt(ref cameraPosition, ref cameraTarget, ref cameraUpVector, arithmetic, out var result);
            return result;
        }

        public static void CreateLookAt(ref Vector3 cameraPosition, ref Vector3 cameraTarget,
            ref Vector3 cameraUpVector,
            ISourceVectorArithmetic arithmetic, out Matrix4x4 result)
        {
            var vector = arithmetic.Normalize(SourceVector3Math.Subtract(cameraPosition, cameraTarget));
            var vector2 = arithmetic.Normalize(SourceVector3Math.Cross(cameraUpVector, vector));
            var vector3 = SourceVector3Math.Cross(vector, vector2);
            result.M11 = vector2.X;
            result.M12 = vector3.X;
            result.M13 = vector.X;
            result.M14 = 0f;
            result.M21 = vector2.Y;
            result.M22 = vector3.Y;
            result.M23 = vector.Y;
            result.M24 = 0f;
            result.M31 = vector2.Z;
            result.M32 = vector3.Z;
            result.M33 = vector.Z;
            result.M34 = 0f;
            result.M41 = -arithmetic.Dot(vector2, cameraPosition);
            result.M42 = -arithmetic.Dot(vector3, cameraPosition);
            result.M43 = -arithmetic.Dot(vector, cameraPosition);
            result.M44 = 1f;
        }

        public static void Multiply(ref Matrix4x4 matrix1, ref Matrix4x4 matrix2, out Matrix4x4 result)
        {
            var m = matrix1.M11 * matrix2.M11 + matrix1.M12 * matrix2.M21 + matrix1.M13 * matrix2.M31 +
                    matrix1.M14 * matrix2.M41;
            var m2 = matrix1.M11 * matrix2.M12 + matrix1.M12 * matrix2.M22 + matrix1.M13 * matrix2.M32 +
                     matrix1.M14 * matrix2.M42;
            var m3 = matrix1.M11 * matrix2.M13 + matrix1.M12 * matrix2.M23 + matrix1.M13 * matrix2.M33 +
                     matrix1.M14 * matrix2.M43;
            var m4 = matrix1.M11 * matrix2.M14 + matrix1.M12 * matrix2.M24 + matrix1.M13 * matrix2.M34 +
                     matrix1.M14 * matrix2.M44;
            var m5 = matrix1.M21 * matrix2.M11 + matrix1.M22 * matrix2.M21 + matrix1.M23 * matrix2.M31 +
                     matrix1.M24 * matrix2.M41;
            var m6 = matrix1.M21 * matrix2.M12 + matrix1.M22 * matrix2.M22 + matrix1.M23 * matrix2.M32 +
                     matrix1.M24 * matrix2.M42;
            var m7 = matrix1.M21 * matrix2.M13 + matrix1.M22 * matrix2.M23 + matrix1.M23 * matrix2.M33 +
                     matrix1.M24 * matrix2.M43;
            var m8 = matrix1.M21 * matrix2.M14 + matrix1.M22 * matrix2.M24 + matrix1.M23 * matrix2.M34 +
                     matrix1.M24 * matrix2.M44;
            var m9 = matrix1.M31 * matrix2.M11 + matrix1.M32 * matrix2.M21 + matrix1.M33 * matrix2.M31 +
                     matrix1.M34 * matrix2.M41;
            var m10 = matrix1.M31 * matrix2.M12 + matrix1.M32 * matrix2.M22 + matrix1.M33 * matrix2.M32 +
                      matrix1.M34 * matrix2.M42;
            var m11 = matrix1.M31 * matrix2.M13 + matrix1.M32 * matrix2.M23 + matrix1.M33 * matrix2.M33 +
                      matrix1.M34 * matrix2.M43;
            var m12 = matrix1.M31 * matrix2.M14 + matrix1.M32 * matrix2.M24 + matrix1.M33 * matrix2.M34 +
                      matrix1.M34 * matrix2.M44;
            var m13 = matrix1.M41 * matrix2.M11 + matrix1.M42 * matrix2.M21 + matrix1.M43 * matrix2.M31 +
                      matrix1.M44 * matrix2.M41;
            var m14 = matrix1.M41 * matrix2.M12 + matrix1.M42 * matrix2.M22 + matrix1.M43 * matrix2.M32 +
                      matrix1.M44 * matrix2.M42;
            var m15 = matrix1.M41 * matrix2.M13 + matrix1.M42 * matrix2.M23 + matrix1.M43 * matrix2.M33 +
                      matrix1.M44 * matrix2.M43;
            var m16 = matrix1.M41 * matrix2.M14 + matrix1.M42 * matrix2.M24 + matrix1.M43 * matrix2.M34 +
                      matrix1.M44 * matrix2.M44;
            result.M11 = m;
            result.M12 = m2;
            result.M13 = m3;
            result.M14 = m4;
            result.M21 = m5;
            result.M22 = m6;
            result.M23 = m7;
            result.M24 = m8;
            result.M31 = m9;
            result.M32 = m10;
            result.M33 = m11;
            result.M34 = m12;
            result.M41 = m13;
            result.M42 = m14;
            result.M43 = m15;
            result.M44 = m16;
        }
    }
}
