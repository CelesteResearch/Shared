using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.LinearAlgebra;

namespace Celeste.Core.Geometry.Intersections
{
    public struct BoundingSphere(Vector3 center, float radius) : IEquatable<BoundingSphere>
    {
        public Vector3 Center = center;
        public float Radius = radius;

        public BoundingSphere Transform(Matrix4x4 matrix, ISourceVectorArithmetic arithmetic,
            ISourceExtremaArithmetic extrema)
        {
            return new()
            {
                Center = SourceVector3Math.Transform(Center, matrix),
                Radius = Radius * (float)Math.Sqrt(extrema.Max(
                    matrix.M11 * matrix.M11 + matrix.M12 * matrix.M12 + matrix.M13 * matrix.M13,
                    extrema.Max(matrix.M21 * matrix.M21 + matrix.M22 * matrix.M22 + matrix.M23 * matrix.M23,
                        matrix.M31 * matrix.M31 + matrix.M32 * matrix.M32 + matrix.M33 * matrix.M33))),
            };
        }

        public void Transform(ref Matrix4x4 matrix, out BoundingSphere result, ISourceVectorArithmetic arithmetic,
            ISourceExtremaArithmetic extrema)
        {
            result.Center = SourceVector3Math.Transform(Center, matrix);
            result.Radius = Radius * (float)Math.Sqrt(extrema.Max(
                matrix.M11 * matrix.M11 + matrix.M12 * matrix.M12 + matrix.M13 * matrix.M13,
                extrema.Max(matrix.M21 * matrix.M21 + matrix.M22 * matrix.M22 + matrix.M23 * matrix.M23,
                    matrix.M31 * matrix.M31 + matrix.M32 * matrix.M32 + matrix.M33 * matrix.M33)));
        }

        public void Contains(ref BoundingBox box, out ContainmentType result, ISourceVectorArithmetic arithmetic,
            ISourceExtremaArithmetic extrema)
        {
            result = Contains(box, arithmetic, extrema);
        }

        public void Contains(ref BoundingSphere sphere, out ContainmentType result, ISourceVectorArithmetic arithmetic,
            ISourceExtremaArithmetic extrema)
        {
            result = Contains(sphere, arithmetic, extrema);
        }

        public void Contains(ref Vector3 point, out ContainmentType result, ISourceVectorArithmetic arithmetic,
            ISourceExtremaArithmetic extrema)
        {
            result = Contains(point, arithmetic, extrema);
        }

        public ContainmentType Contains(BoundingBox box, ISourceVectorArithmetic arithmetic,
            ISourceExtremaArithmetic extrema)
        {
            var flag = true;
            var corners = box.GetCorners();
            foreach (var point in corners)
                if (Contains(point, arithmetic, extrema) == ContainmentType.Disjoint)
                {
                    flag = false;
                    break;
                }

            if (flag)
                return ContainmentType.Contains;
            var num = 0.0;
            if (Center.X < box.Min.X)
                num += (Center.X - box.Min.X) * (Center.X - box.Min.X);
            else if (Center.X > box.Max.X)
                num += (Center.X - box.Max.X) * (Center.X - box.Max.X);
            if (Center.Y < box.Min.Y)
                num += (Center.Y - box.Min.Y) * (Center.Y - box.Min.Y);
            else if (Center.Y > box.Max.Y)
                num += (Center.Y - box.Max.Y) * (Center.Y - box.Max.Y);
            if (Center.Z < box.Min.Z)
                num += (Center.Z - box.Min.Z) * (Center.Z - box.Min.Z);
            else if (Center.Z > box.Max.Z)
                num += (Center.Z - box.Max.Z) * (Center.Z - box.Max.Z);
            if (num <= Radius * Radius)
                return ContainmentType.Intersects;
            return ContainmentType.Disjoint;
        }

        public ContainmentType Contains(BoundingFrustum frustum, ISourceVectorArithmetic arithmetic,
            ISourceExtremaArithmetic extrema)
        {
            var flag = true;
            var corners = frustum.GetCorners();
            foreach (var point in corners)
                if (Contains(point, arithmetic, extrema) == ContainmentType.Disjoint)
                {
                    flag = false;
                    break;
                }

            if (flag)
                return ContainmentType.Contains;
            if (0.0 <= Radius * Radius)
                return ContainmentType.Intersects;
            return ContainmentType.Disjoint;
        }

        public ContainmentType Contains(BoundingSphere sphere, ISourceVectorArithmetic arithmetic,
            ISourceExtremaArithmetic extrema)
        {
            var result = arithmetic.DistanceSquared(sphere.Center, Center);
            if (result > (sphere.Radius + Radius) * (sphere.Radius + Radius))
                return ContainmentType.Disjoint;
            if (result <= (Radius - sphere.Radius) * (Radius - sphere.Radius))
                return ContainmentType.Contains;
            return ContainmentType.Intersects;
        }

        public ContainmentType Contains(Vector3 point, ISourceVectorArithmetic arithmetic,
            ISourceExtremaArithmetic extrema)
        {
            var num = Radius * Radius;
            var result = arithmetic.DistanceSquared(point, Center);
            if (result > num)
                return ContainmentType.Disjoint;
            if (result < num)
                return ContainmentType.Contains;
            return ContainmentType.Intersects;
        }

        public bool Equals(BoundingSphere other)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (Center == other.Center)
                return Radius == other.Radius;
            return false;
        }

        public static BoundingSphere CreateFromBoundingBox(BoundingBox box, ISourceVectorArithmetic arithmetic,
            ISourceExtremaArithmetic extrema)
        {
            CreateFromBoundingBox(ref box, out var result, arithmetic, extrema);
            return result;
        }

        public static void CreateFromBoundingBox(ref BoundingBox box, out BoundingSphere result,
            ISourceVectorArithmetic arithmetic, ISourceExtremaArithmetic extrema)
        {
            var vector = new Vector3((box.Min.X + box.Max.X) / 2f, (box.Min.Y + box.Max.Y) / 2f,
                (box.Min.Z + box.Max.Z) / 2f);
            var radius = arithmetic.Distance(vector, box.Max);
            result = new(vector, radius);
        }

        public static BoundingSphere CreateFromFrustum(BoundingFrustum frustum, ISourceVectorArithmetic arithmetic,
            ISourceExtremaArithmetic extrema)
        {
            return CreateFromPoints(frustum.GetCorners(), arithmetic, extrema);
        }

        public static BoundingSphere CreateFromPoints(IEnumerable<Vector3> points, ISourceVectorArithmetic arithmetic,
            ISourceExtremaArithmetic extrema)
        {
            if (points == null)
                throw new ArgumentNullException("points");
            var vector = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
            var vector2 = -vector;
            var vector3 = vector;
            var vector4 = -vector;
            var vector5 = vector;
            var vector6 = -vector;
            var num = 0;
            foreach (var point in points)
            {
                num++;
                if (point.X < vector.X)
                    vector = point;
                if (point.X > vector2.X)
                    vector2 = point;
                if (point.Y < vector3.Y)
                    vector3 = point;
                if (point.Y > vector4.Y)
                    vector4 = point;
                if (point.Z < vector5.Z)
                    vector5 = point;
                if (point.Z > vector6.Z)
                    vector6 = point;
            }

            if (num == 0)
                throw new ArgumentException("You should have at least one point in points.");
            var num2 = arithmetic.DistanceSquared(vector2, vector);
            var num3 = arithmetic.DistanceSquared(vector4, vector3);
            var num4 = arithmetic.DistanceSquared(vector6, vector5);
            var vector7 = vector;
            var vector8 = vector2;
            if (num3 > num2 && num3 > num4)
            {
                vector8 = vector4;
                vector7 = vector3;
            }

            if (num4 > num2 && num4 > num3)
            {
                vector8 = vector6;
                vector7 = vector5;
            }

            var vector9 = SourceVector3Math.Multiply(SourceVector3Math.Add(vector7, vector8), 0.5f);
            var num5 = arithmetic.Distance(vector8, vector9);
            var num6 = num5 * num5;
            foreach (var point2 in points)
            {
                var vector10 = SourceVector3Math.Subtract(point2, vector9);
                var num7 = arithmetic.LengthSquared(vector10);
                if (num7 > num6)
                {
                    var num8 = (float)Math.Sqrt(num7);
                    var vector11 = arithmetic.Divide(vector10, num8);
                    vector9 = arithmetic.Divide(
                        SourceVector3Math.Add(
                            SourceVector3Math.Subtract(vector9, SourceVector3Math.Multiply(vector11, num5)), point2),
                        2f);
                    num5 = arithmetic.Distance(point2, vector9);
                    num6 = num5 * num5;
                }
            }

            return new(vector9, num5);
        }

        public static BoundingSphere CreateMerged(BoundingSphere original, BoundingSphere additional,
            ISourceVectorArithmetic arithmetic, ISourceExtremaArithmetic extrema)
        {
            CreateMerged(ref original, ref additional, out var result, arithmetic, extrema);
            return result;
        }

        public static void CreateMerged(ref BoundingSphere original, ref BoundingSphere additional,
            out BoundingSphere result, ISourceVectorArithmetic arithmetic, ISourceExtremaArithmetic extrema)
        {
            var vector = SourceVector3Math.Subtract(additional.Center, original.Center);
            var num = arithmetic.Length(vector);
            if (num <= original.Radius + additional.Radius)
            {
                if (num <= original.Radius - additional.Radius)
                {
                    result = original;
                    return;
                }

                if (num <= additional.Radius - original.Radius)
                {
                    result = additional;
                    return;
                }
            }

            var num2 = extrema.Max(original.Radius - num, additional.Radius);
            var num3 = extrema.Max(original.Radius + num, additional.Radius);
            vector = SourceVector3Math.Add(vector,
                SourceVector3Math.Multiply(vector, (num2 - num3) / (2f * arithmetic.Length(vector))));
            result = default;
            result.Center = SourceVector3Math.Add(original.Center, vector);
            result.Radius = (num2 + num3) / 2f;
        }

        public bool Intersects(BoundingBox box, ISourceVectorArithmetic arithmetic, ISourceExtremaArithmetic extrema)
        {
            return box.Intersects(this, arithmetic, extrema);
        }

        public void Intersects(ref BoundingBox box, out bool result, ISourceVectorArithmetic arithmetic,
            ISourceExtremaArithmetic extrema)
        {
            box.Intersects(ref this, out result, arithmetic, extrema);
        }

        public bool Intersects(BoundingFrustum frustum, ISourceVectorArithmetic arithmetic,
            ISourceExtremaArithmetic extrema)
        {
            return frustum.Intersects(this);
        }

        public bool Intersects(BoundingSphere sphere, ISourceVectorArithmetic arithmetic,
            ISourceExtremaArithmetic extrema)
        {
            Intersects(ref sphere, out var result, arithmetic, extrema);
            return result;
        }

        public void Intersects(ref BoundingSphere sphere, out bool result, ISourceVectorArithmetic arithmetic,
            ISourceExtremaArithmetic extrema)
        {
            var result2 = arithmetic.DistanceSquared(sphere.Center, Center);
            result = !(result2 > (sphere.Radius + Radius) * (sphere.Radius + Radius));
        }

        public float? Intersects(Ray ray, ISourceVectorArithmetic arithmetic, ISourceExtremaArithmetic extrema)
        {
            return ray.Intersects(this, arithmetic, extrema);
        }

        public void Intersects(ref Ray ray, out float? result, ISourceVectorArithmetic arithmetic,
            ISourceExtremaArithmetic extrema)
        {
            ray.Intersects(ref this, out result, arithmetic, extrema);
        }

        public PlaneIntersectionType Intersects(Plane plane, ISourceVectorArithmetic arithmetic,
            ISourceExtremaArithmetic extrema)
        {
            var result = PlaneIntersectionType.Front;
            Intersects(ref plane, out result, arithmetic, extrema);
            return result;
        }

        public void Intersects(ref Plane plane, out PlaneIntersectionType result, ISourceVectorArithmetic arithmetic,
            ISourceExtremaArithmetic extrema)
        {
            var result2 = 0f;
            result2 = arithmetic.Dot(plane.Normal, Center);
            result2 += plane.D;
            if (result2 > Radius)
                result = PlaneIntersectionType.Front;
            else if (result2 < 0f - Radius)
                result = PlaneIntersectionType.Back;
            else
                result = PlaneIntersectionType.Intersecting;
        }

        public override bool Equals(object obj)
        {
            if (obj is BoundingSphere)
                return Equals((BoundingSphere)obj);
            return false;
        }

        public override int GetHashCode()
        {
            return unchecked(unchecked(Center.X.GetHashCode() + Center.Y.GetHashCode() + Center.Z.GetHashCode()) +
                             Radius.GetHashCode());
        }

        public string ToString(Func<float, string> format)
        {
            return "{Center:" + SourceGeometryFormatting.Vector(Center, format) + " Radius:" + format(Radius) + "}";
        }

        public static bool operator ==(BoundingSphere a, BoundingSphere b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(BoundingSphere a, BoundingSphere b)
        {
            return !a.Equals(b);
        }
    }
}
