using System;
using System.Numerics;
using System.Text;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.LinearAlgebra;

namespace Celeste.Core.Geometry.Intersections
{
    public class BoundingFrustum : IEquatable<BoundingFrustum>
    {
        public const int CornerCount = 8;

        private Matrix4x4 _matrix;
        private readonly ISourceVectorArithmetic _arithmetic;
        private readonly ISourceExtremaArithmetic _extrema;

        private readonly Vector3[] _corners = new Vector3[8];

        private readonly Plane[] _planes = new Plane[6];

        private const int PlaneCount = 6;

        public Matrix4x4 Matrix
        {
            get => _matrix;
            set
            {
                _matrix = value;
                CreatePlanes();
                CreateCorners();
            }
        }

        public Plane Near => _planes[0];

        public Plane Far => _planes[1];

        public Plane Left => _planes[2];

        public Plane Right => _planes[3];

        public Plane Top => _planes[4];

        public Plane Bottom => _planes[5];


        public BoundingFrustum(Matrix4x4 value, ISourceVectorArithmetic arithmetic, ISourceExtremaArithmetic extrema)
        {
            _arithmetic = arithmetic;
            _extrema = extrema;
            _matrix = value;
            CreatePlanes();
            CreateCorners();
        }

        public ContainmentType Contains(BoundingFrustum frustum)
        {
            if (this == frustum) return ContainmentType.Contains;

            var flag = false;
            for (var i = 0; i < 6; i++)
            {
                frustum.Intersects(ref _planes[i], out var result);
                switch (result)
                {
                    case PlaneIntersectionType.Front:
                        return ContainmentType.Disjoint;
                    case PlaneIntersectionType.Intersecting:
                        flag = true;
                        break;
                }
            }

            if (!flag) return ContainmentType.Contains;

            return ContainmentType.Intersects;
        }

        public ContainmentType Contains(BoundingBox box)
        {
            var result = ContainmentType.Disjoint;
            Contains(ref box, out result);
            return result;
        }

        public void Contains(ref BoundingBox box, out ContainmentType result)
        {
            var flag = false;
            for (var i = 0; i < 6; i++)
            {
                var result2 = PlaneIntersectionType.Front;
                box.Intersects(ref _planes[i], out result2, _arithmetic, _extrema);
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

            result = !flag ? ContainmentType.Contains : ContainmentType.Intersects;
        }

        public ContainmentType Contains(BoundingSphere sphere)
        {
            var result = ContainmentType.Disjoint;
            Contains(ref sphere, out result);
            return result;
        }

        public void Contains(ref BoundingSphere sphere, out ContainmentType result)
        {
            var flag = false;
            for (var i = 0; i < 6; i++)
            {
                var result2 = PlaneIntersectionType.Front;
                sphere.Intersects(ref _planes[i], out result2, _arithmetic, _extrema);
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

            result = !flag ? ContainmentType.Contains : ContainmentType.Intersects;
        }

        public ContainmentType Contains(Vector3 point)
        {
            var result = ContainmentType.Disjoint;
            Contains(ref point, out result);
            return result;
        }

        public void Contains(ref Vector3 point, out ContainmentType result)
        {
            var flag = false;
            for (var i = 0; i < 6; i++)
            {
                var num = point.X * _planes[i].Normal.X + point.Y * _planes[i].Normal.Y +
                          point.Z * _planes[i].Normal.Z +
                          _planes[i].D;
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

            result = !flag ? ContainmentType.Contains : ContainmentType.Intersects;
        }

        public Vector3[] GetCorners()
        {
            return (Vector3[])_corners.Clone();
        }

        public void GetCorners(Vector3[] corners)
        {
            if (corners == null) throw new ArgumentNullException("corners");

            if (corners.Length < 8) throw new ArgumentOutOfRangeException("corners");

            _corners.CopyTo(corners, 0);
        }

        public bool Intersects(BoundingFrustum frustum)
        {
            return Contains(frustum) != ContainmentType.Disjoint;
        }

        public bool Intersects(BoundingBox box)
        {
            var result = false;
            Intersects(ref box, out result);
            return result;
        }

        public void Intersects(ref BoundingBox box, out bool result)
        {
            var result2 = ContainmentType.Disjoint;
            Contains(ref box, out result2);
            result = result2 != ContainmentType.Disjoint;
        }

        public bool Intersects(BoundingSphere sphere)
        {
            var result = false;
            Intersects(ref sphere, out result);
            return result;
        }

        public void Intersects(ref BoundingSphere sphere, out bool result)
        {
            var result2 = ContainmentType.Disjoint;
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
            result = ClassifyPlanePoint(ref plane, ref _corners[0]);
            for (var i = 1; i < _corners.Length; i++)
                if (ClassifyPlanePoint(ref plane, ref _corners[i]) != result)
                    result = PlaneIntersectionType.Intersecting;
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
            IntersectionPoint(ref _planes[0], ref _planes[2], ref _planes[4], out _corners[0]);
            IntersectionPoint(ref _planes[0], ref _planes[3], ref _planes[4], out _corners[1]);
            IntersectionPoint(ref _planes[0], ref _planes[3], ref _planes[5], out _corners[2]);
            IntersectionPoint(ref _planes[0], ref _planes[2], ref _planes[5], out _corners[3]);
            IntersectionPoint(ref _planes[1], ref _planes[2], ref _planes[4], out _corners[4]);
            IntersectionPoint(ref _planes[1], ref _planes[3], ref _planes[4], out _corners[5]);
            IntersectionPoint(ref _planes[1], ref _planes[3], ref _planes[5], out _corners[6]);
            IntersectionPoint(ref _planes[1], ref _planes[2], ref _planes[5], out _corners[7]);
        }

        private void CreatePlanes()
        {
            _planes[0] = new(0f - _matrix.M13, 0f - _matrix.M23, 0f - _matrix.M33, 0f - _matrix.M43);
            _planes[1] = new(_matrix.M13 - _matrix.M14, _matrix.M23 - _matrix.M24, _matrix.M33 - _matrix.M34,
                _matrix.M43 - _matrix.M44);
            _planes[2] = new(0f - _matrix.M14 - _matrix.M11, 0f - _matrix.M24 - _matrix.M21,
                0f - _matrix.M34 - _matrix.M31,
                0f - _matrix.M44 - _matrix.M41);
            _planes[3] = new(_matrix.M11 - _matrix.M14, _matrix.M21 - _matrix.M24, _matrix.M31 - _matrix.M34,
                _matrix.M41 - _matrix.M44);
            _planes[4] = new(_matrix.M12 - _matrix.M14, _matrix.M22 - _matrix.M24, _matrix.M32 - _matrix.M34,
                _matrix.M42 - _matrix.M44);
            _planes[5] = new(0f - _matrix.M14 - _matrix.M12, 0f - _matrix.M24 - _matrix.M22,
                0f - _matrix.M34 - _matrix.M32,
                0f - _matrix.M44 - _matrix.M42);
            NormalizePlane(ref _planes[0]);
            NormalizePlane(ref _planes[1]);
            NormalizePlane(ref _planes[2]);
            NormalizePlane(ref _planes[3]);
            NormalizePlane(ref _planes[4]);
            NormalizePlane(ref _planes[5]);
        }

        private void NormalizePlane(ref Plane p)
        {
            var num = 1f / _arithmetic.Length(p.Normal);
            p.Normal.X *= num;
            p.Normal.Y *= num;
            p.Normal.Z *= num;
            p.D *= num;
        }

        private void IntersectionPoint(ref Plane a, ref Plane b, ref Plane c, out Vector3 result)
        {
            SourceVector3Math.Cross(ref b.Normal, ref c.Normal, out var result2);
            var result3 = _arithmetic.Dot(a.Normal, result2);
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
            if (Equals(a, null)) return Equals(b, null);

            if (Equals(b, null)) return Equals(a, null);

            return a._matrix == b._matrix;
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
            if (obj is BoundingFrustum) return Equals((BoundingFrustum)obj);

            return false;
        }

        public string ToString(Func<float, string> format)
        {
            var stringBuilder = new StringBuilder(256);
            stringBuilder.Append("{Near:");
            stringBuilder.Append(SourceGeometryFormatting.Plane(_planes[0], format));
            stringBuilder.Append(" Far:");
            stringBuilder.Append(SourceGeometryFormatting.Plane(_planes[1], format));
            stringBuilder.Append(" Left:");
            stringBuilder.Append(SourceGeometryFormatting.Plane(_planes[2], format));
            stringBuilder.Append(" Right:");
            stringBuilder.Append(SourceGeometryFormatting.Plane(_planes[3], format));
            stringBuilder.Append(" Top:");
            stringBuilder.Append(SourceGeometryFormatting.Plane(_planes[4], format));
            stringBuilder.Append(" Bottom:");
            stringBuilder.Append(SourceGeometryFormatting.Plane(_planes[5], format));
            stringBuilder.Append("}");
            return stringBuilder.ToString();
        }

        public override int GetHashCode()
        {
            return unchecked(unchecked(_matrix.M11.GetHashCode() + _matrix.M12.GetHashCode() +
                                       _matrix.M13.GetHashCode() +
                                       _matrix.M14.GetHashCode() + _matrix.M21.GetHashCode() +
                                       _matrix.M22.GetHashCode() +
                                       _matrix.M23.GetHashCode() + _matrix.M24.GetHashCode() +
                                       _matrix.M31.GetHashCode() +
                                       _matrix.M32.GetHashCode() + _matrix.M33.GetHashCode() +
                                       _matrix.M34.GetHashCode() +
                                       _matrix.M41.GetHashCode() + _matrix.M42.GetHashCode() +
                                       _matrix.M43.GetHashCode() +
                                       _matrix.M44.GetHashCode()));
        }

        private static PlaneIntersectionType ClassifyPlanePoint(ref Plane plane, ref Vector3 point)
        {
            var result = point.X * plane.Normal.X + point.Y * plane.Normal.Y + point.Z * plane.Normal.Z + plane.D;
            if (result > 0f) return PlaneIntersectionType.Front;
            if (result < 0f) return PlaneIntersectionType.Back;
            return PlaneIntersectionType.Intersecting;
        }
    }
}
