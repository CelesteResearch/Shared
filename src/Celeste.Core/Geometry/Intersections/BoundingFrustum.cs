using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.LinearAlgebra;
using System;
using System.Text;

namespace Celeste.Core.Geometry.Intersections
{
    public class BoundingFrustum : IEquatable<BoundingFrustum>
    {
        public const int CornerCount = 8;

        private Matrix4x4 matrix;
        private readonly ISourceVectorArithmetic arithmetic;
        private readonly ISourceExtremaArithmetic extrema;

        private readonly Vector3[] corners = new Vector3[8];

        private readonly Plane[] planes = new Plane[6];

        private const int PlaneCount = 6;

        public Matrix4x4 Matrix
        {
            get { return matrix; }
            set
            {
                matrix = value;
                CreatePlanes();
                CreateCorners();
            }
        }

        public Plane Near => planes[0];

        public Plane Far => planes[1];

        public Plane Left => planes[2];

        public Plane Right => planes[3];

        public Plane Top => planes[4];

        public Plane Bottom => planes[5];


        public BoundingFrustum(Matrix4x4 value, ISourceVectorArithmetic arithmetic, ISourceExtremaArithmetic extrema)
        {
            this.arithmetic = arithmetic;
            this.extrema = extrema;
            matrix = value;
            CreatePlanes();
            CreateCorners();
        }

        public ContainmentType Contains(BoundingFrustum frustum)
        {
            if (this == frustum)
            {
                return ContainmentType.Contains;
            }

            bool flag = false;
            for (int i = 0; i < 6; i++)
            {
                frustum.Intersects(ref planes[i], out var result);
                switch (result)
                {
                    case PlaneIntersectionType.Front:
                        return ContainmentType.Disjoint;
                    case PlaneIntersectionType.Intersecting:
                        flag = true;
                        break;
                }
            }

            if (!flag)
            {
                return ContainmentType.Contains;
            }

            return ContainmentType.Intersects;
        }

        public ContainmentType Contains(BoundingBox box)
        {
            ContainmentType result = ContainmentType.Disjoint;
            Contains(ref box, out result);
            return result;
        }

        public void Contains(ref BoundingBox box, out ContainmentType result)
        {
            bool flag = false;
            for (int i = 0; i < 6; i++)
            {
                PlaneIntersectionType result2 = PlaneIntersectionType.Front;
                box.Intersects(ref planes[i], out result2, arithmetic, extrema);
                switch (result2)
                {
                    case PlaneIntersectionType.Front:
                        result = ContainmentType.Disjoint;
                        return;
                    case PlaneIntersectionType.Intersecting:
                        flag = true;
                        break;
                }
            }

            result = ((!flag) ? ContainmentType.Contains : ContainmentType.Intersects);
        }

        public ContainmentType Contains(BoundingSphere sphere)
        {
            ContainmentType result = ContainmentType.Disjoint;
            Contains(ref sphere, out result);
            return result;
        }

        public void Contains(ref BoundingSphere sphere, out ContainmentType result)
        {
            bool flag = false;
            for (int i = 0; i < 6; i++)
            {
                PlaneIntersectionType result2 = PlaneIntersectionType.Front;
                sphere.Intersects(ref planes[i], out result2, arithmetic, extrema);
                switch (result2)
                {
                    case PlaneIntersectionType.Front:
                        result = ContainmentType.Disjoint;
                        return;
                    case PlaneIntersectionType.Intersecting:
                        flag = true;
                        break;
                }
            }

            result = ((!flag) ? ContainmentType.Contains : ContainmentType.Intersects);
        }

        public ContainmentType Contains(Vector3 point)
        {
            ContainmentType result = ContainmentType.Disjoint;
            Contains(ref point, out result);
            return result;
        }

        public void Contains(ref Vector3 point, out ContainmentType result)
        {
            bool flag = false;
            for (int i = 0; i < 6; i++)
            {
                float num = point.X * planes[i].Normal.X + point.Y * planes[i].Normal.Y + point.Z * planes[i].Normal.Z +
                            planes[i].D;
                if (num > 0f)
                {
                    result = ContainmentType.Disjoint;
                    return;
                }

                if (num == 0f)
                {
                    flag = true;
                    break;
                }
            }

            result = ((!flag) ? ContainmentType.Contains : ContainmentType.Intersects);
        }

        public Vector3[] GetCorners()
        {
            return (Vector3[])corners.Clone();
        }

        public void GetCorners(Vector3[] corners)
        {
            if (corners == null)
            {
                throw new ArgumentNullException("corners");
            }

            if (corners.Length < 8)
            {
                throw new ArgumentOutOfRangeException("corners");
            }

            this.corners.CopyTo(corners, 0);
        }

        public bool Intersects(BoundingFrustum frustum)
        {
            return Contains(frustum) != ContainmentType.Disjoint;
        }

        public bool Intersects(BoundingBox box)
        {
            bool result = false;
            Intersects(ref box, out result);
            return result;
        }

        public void Intersects(ref BoundingBox box, out bool result)
        {
            ContainmentType result2 = ContainmentType.Disjoint;
            Contains(ref box, out result2);
            result = result2 != ContainmentType.Disjoint;
        }

        public bool Intersects(BoundingSphere sphere)
        {
            bool result = false;
            Intersects(ref sphere, out result);
            return result;
        }

        public void Intersects(ref BoundingSphere sphere, out bool result)
        {
            ContainmentType result2 = ContainmentType.Disjoint;
            Contains(ref sphere, out result2);
            result = result2 != ContainmentType.Disjoint;
        }

        public PlaneIntersectionType Intersects(Plane plane)
        {
            Intersects(ref plane, out var result);
            return result;
        }

        public void Intersects(ref Plane plane, out PlaneIntersectionType result)
        {
            result = ClassifyPlanePoint(ref plane, ref corners[0]);
            for (int i = 1; i < corners.Length; i++)
            {
                if (ClassifyPlanePoint(ref plane, ref corners[i]) != result)
                {
                    result = PlaneIntersectionType.Intersecting;
                }
            }
        }

        public float? Intersects(Ray ray)
        {
            Intersects(ref ray, out var result);
            return result;
        }

        public void Intersects(ref Ray ray, out float? result)
        {
            Contains(ref ray.Position, out var result2);
            switch (result2)
            {
                case ContainmentType.Disjoint:
                    result = null;
                    break;
                case ContainmentType.Contains:
                    result = 0f;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("ctype");
                case ContainmentType.Intersects:
                    throw new NotImplementedException();
            }
        }

        private void CreateCorners()
        {
            IntersectionPoint(ref planes[0], ref planes[2], ref planes[4], out corners[0]);
            IntersectionPoint(ref planes[0], ref planes[3], ref planes[4], out corners[1]);
            IntersectionPoint(ref planes[0], ref planes[3], ref planes[5], out corners[2]);
            IntersectionPoint(ref planes[0], ref planes[2], ref planes[5], out corners[3]);
            IntersectionPoint(ref planes[1], ref planes[2], ref planes[4], out corners[4]);
            IntersectionPoint(ref planes[1], ref planes[3], ref planes[4], out corners[5]);
            IntersectionPoint(ref planes[1], ref planes[3], ref planes[5], out corners[6]);
            IntersectionPoint(ref planes[1], ref planes[2], ref planes[5], out corners[7]);
        }

        private void CreatePlanes()
        {
            planes[0] = new Plane(0f - matrix.M13, 0f - matrix.M23, 0f - matrix.M33, 0f - matrix.M43);
            planes[1] = new Plane(matrix.M13 - matrix.M14, matrix.M23 - matrix.M24, matrix.M33 - matrix.M34,
                matrix.M43 - matrix.M44);
            planes[2] = new Plane(0f - matrix.M14 - matrix.M11, 0f - matrix.M24 - matrix.M21,
                0f - matrix.M34 - matrix.M31,
                0f - matrix.M44 - matrix.M41);
            planes[3] = new Plane(matrix.M11 - matrix.M14, matrix.M21 - matrix.M24, matrix.M31 - matrix.M34,
                matrix.M41 - matrix.M44);
            planes[4] = new Plane(matrix.M12 - matrix.M14, matrix.M22 - matrix.M24, matrix.M32 - matrix.M34,
                matrix.M42 - matrix.M44);
            planes[5] = new Plane(0f - matrix.M14 - matrix.M12, 0f - matrix.M24 - matrix.M22,
                0f - matrix.M34 - matrix.M32,
                0f - matrix.M44 - matrix.M42);
            NormalizePlane(ref planes[0]);
            NormalizePlane(ref planes[1]);
            NormalizePlane(ref planes[2]);
            NormalizePlane(ref planes[3]);
            NormalizePlane(ref planes[4]);
            NormalizePlane(ref planes[5]);
        }

        private void NormalizePlane(ref Plane p)
        {
            float num = 1f / arithmetic.Length(p.Normal);
            p.Normal.X *= num;
            p.Normal.Y *= num;
            p.Normal.Z *= num;
            p.D *= num;
        }

        private void IntersectionPoint(ref Plane a, ref Plane b, ref Plane c, out Vector3 result)
        {
            SourceVector3Math.Cross(ref b.Normal, ref c.Normal, out var result2);
            float result3 = arithmetic.Dot(a.Normal, result2);
            result3 *= -1f;
            SourceVector3Math.Cross(ref b.Normal, ref c.Normal, out result2);
            SourceVector3Math.Multiply(ref result2, a.D, out var result4);
            SourceVector3Math.Cross(ref c.Normal, ref a.Normal, out result2);
            SourceVector3Math.Multiply(ref result2, b.D, out var result5);
            SourceVector3Math.Cross(ref a.Normal, ref b.Normal, out result2);
            SourceVector3Math.Multiply(ref result2, c.D, out var result6);
            result.X = (result4.X + result5.X + result6.X) / result3;
            result.Y = (result4.Y + result5.Y + result6.Y) / result3;
            result.Z = (result4.Z + result5.Z + result6.Z) / result3;
        }

        public static bool operator ==(BoundingFrustum a, BoundingFrustum b)
        {
            if (object.Equals(a, null))
            {
                return object.Equals(b, null);
            }

            if (object.Equals(b, null))
            {
                return object.Equals(a, null);
            }

            return a.matrix == b.matrix;
        }

        public static bool operator !=(BoundingFrustum a, BoundingFrustum b)
        {
            return !(a == b);
        }

        public bool Equals(BoundingFrustum other)
        {
            return this == other;
        }

        public override bool Equals(object obj)
        {
            if (obj is BoundingFrustum)
            {
                return Equals((BoundingFrustum)obj);
            }

            return false;
        }

        public string ToString(Func<float, string> format)
        {
            StringBuilder stringBuilder = new StringBuilder(256);
            stringBuilder.Append("{Near:");
            stringBuilder.Append(SourceGeometryFormatting.Plane(planes[0], format));
            stringBuilder.Append(" Far:");
            stringBuilder.Append(SourceGeometryFormatting.Plane(planes[1], format));
            stringBuilder.Append(" Left:");
            stringBuilder.Append(SourceGeometryFormatting.Plane(planes[2], format));
            stringBuilder.Append(" Right:");
            stringBuilder.Append(SourceGeometryFormatting.Plane(planes[3], format));
            stringBuilder.Append(" Top:");
            stringBuilder.Append(SourceGeometryFormatting.Plane(planes[4], format));
            stringBuilder.Append(" Bottom:");
            stringBuilder.Append(SourceGeometryFormatting.Plane(planes[5], format));
            stringBuilder.Append("}");
            return stringBuilder.ToString();
        }

        public override int GetHashCode()
        {
            return unchecked(unchecked(matrix.M11.GetHashCode() + matrix.M12.GetHashCode() + matrix.M13.GetHashCode() +
                                       matrix.M14.GetHashCode() + matrix.M21.GetHashCode() + matrix.M22.GetHashCode() +
                                       matrix.M23.GetHashCode() + matrix.M24.GetHashCode() + matrix.M31.GetHashCode() +
                                       matrix.M32.GetHashCode() + matrix.M33.GetHashCode() + matrix.M34.GetHashCode() +
                                       matrix.M41.GetHashCode() + matrix.M42.GetHashCode() + matrix.M43.GetHashCode() +
                                       matrix.M44.GetHashCode()));
        }

        private static PlaneIntersectionType ClassifyPlanePoint(ref Plane plane, ref Vector3 point)
        {
            float result = point.X * plane.Normal.X + point.Y * plane.Normal.Y + point.Z * plane.Normal.Z + plane.D;
            if (result > 0f) return PlaneIntersectionType.Front;
            if (result < 0f) return PlaneIntersectionType.Back;
            return PlaneIntersectionType.Intersecting;
        }
    }
}
