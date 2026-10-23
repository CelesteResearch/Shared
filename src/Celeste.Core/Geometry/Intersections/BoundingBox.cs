using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.LinearAlgebra;
using System;
using System.Collections.Generic;

namespace Celeste.Core.Geometry.Intersections
{
    public struct BoundingBox : IEquatable<BoundingBox>
    {
        public Vector3 Min;

        public Vector3 Max;

        public const int CornerCount = 8;

        private static Vector3 MaxVector3 = new Vector3(float.MaxValue);

        private static Vector3 MinVector3 = new Vector3(float.MinValue);


        public BoundingBox(Vector3 min, Vector3 max)
        {
            Min = min;
            Max = max;
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

        public ContainmentType Contains(Vector3 point, ISourceVectorArithmetic arithmetic,
            ISourceExtremaArithmetic extrema)
        {
            Contains(ref point, out var result, arithmetic, extrema);
            return result;
        }

        public ContainmentType Contains(BoundingBox box, ISourceVectorArithmetic arithmetic,
            ISourceExtremaArithmetic extrema)
        {
            if (box.Max.X < Min.X || box.Min.X > Max.X || box.Max.Y < Min.Y || box.Min.Y > Max.Y || box.Max.Z < Min.Z ||
                box.Min.Z > Max.Z)
            {
                return ContainmentType.Disjoint;
            }

            if (box.Min.X >= Min.X && box.Max.X <= Max.X && box.Min.Y >= Min.Y && box.Max.Y <= Max.Y &&
                box.Min.Z >= Min.Z && box.Max.Z <= Max.Z)
            {
                return ContainmentType.Contains;
            }

            return ContainmentType.Intersects;
        }

        public ContainmentType Contains(BoundingFrustum frustum, ISourceVectorArithmetic arithmetic,
            ISourceExtremaArithmetic extrema)
        {
            Vector3[] corners = frustum.GetCorners();
            ContainmentType result;
            int i;
            for (i = 0; i < corners.Length; i++)
            {
                Contains(ref corners[i], out result, arithmetic, extrema);
                if (result == ContainmentType.Disjoint)
                {
                    break;
                }
            }

            if (i == corners.Length)
            {
                return ContainmentType.Contains;
            }

            if (i != 0)
            {
                return ContainmentType.Intersects;
            }

            for (i++; i < corners.Length; i++)
            {
                Contains(ref corners[i], out result, arithmetic, extrema);
                if (result != ContainmentType.Contains)
                {
                    return ContainmentType.Intersects;
                }
            }

            return ContainmentType.Contains;
        }

        public ContainmentType Contains(BoundingSphere sphere, ISourceVectorArithmetic arithmetic,
            ISourceExtremaArithmetic extrema)
        {
            if (sphere.Center.X - Min.X >= sphere.Radius && sphere.Center.Y - Min.Y >= sphere.Radius &&
                sphere.Center.Z - Min.Z >= sphere.Radius && Max.X - sphere.Center.X >= sphere.Radius &&
                Max.Y - sphere.Center.Y >= sphere.Radius && Max.Z - sphere.Center.Z >= sphere.Radius)
            {
                return ContainmentType.Contains;
            }

            double num = 0.0;
            double num2 = sphere.Center.X - Min.X;
            if (num2 < 0.0)
            {
                if (num2 < (double)(0f - sphere.Radius))
                {
                    return ContainmentType.Disjoint;
                }

                num += num2 * num2;
            }
            else
            {
                num2 = sphere.Center.X - Max.X;
                if (num2 > 0.0)
                {
                    if (num2 > (double)sphere.Radius)
                    {
                        return ContainmentType.Disjoint;
                    }

                    num += num2 * num2;
                }
            }

            num2 = sphere.Center.Y - Min.Y;
            if (num2 < 0.0)
            {
                if (num2 < (double)(0f - sphere.Radius))
                {
                    return ContainmentType.Disjoint;
                }

                num += num2 * num2;
            }
            else
            {
                num2 = sphere.Center.Y - Max.Y;
                if (num2 > 0.0)
                {
                    if (num2 > (double)sphere.Radius)
                    {
                        return ContainmentType.Disjoint;
                    }

                    num += num2 * num2;
                }
            }

            num2 = sphere.Center.Z - Min.Z;
            if (num2 < 0.0)
            {
                if (num2 < (double)(0f - sphere.Radius))
                {
                    return ContainmentType.Disjoint;
                }

                num += num2 * num2;
            }
            else
            {
                num2 = sphere.Center.Z - Max.Z;
                if (num2 > 0.0)
                {
                    if (num2 > (double)sphere.Radius)
                    {
                        return ContainmentType.Disjoint;
                    }

                    num += num2 * num2;
                }
            }

            if (num <= (double)(sphere.Radius * sphere.Radius))
            {
                return ContainmentType.Intersects;
            }

            return ContainmentType.Disjoint;
        }

        public void Contains(ref Vector3 point, out ContainmentType result, ISourceVectorArithmetic arithmetic,
            ISourceExtremaArithmetic extrema)
        {
            if (point.X < Min.X || point.X > Max.X || point.Y < Min.Y || point.Y > Max.Y || point.Z < Min.Z ||
                point.Z > Max.Z)
            {
                result = ContainmentType.Disjoint;
            }
            else
            {
                result = ContainmentType.Contains;
            }
        }

        public Vector3[] GetCorners()
        {
            return new Vector3[8]
            {
                new Vector3(Min.X, Max.Y, Max.Z),
                new Vector3(Max.X, Max.Y, Max.Z),
                new Vector3(Max.X, Min.Y, Max.Z),
                new Vector3(Min.X, Min.Y, Max.Z),
                new Vector3(Min.X, Max.Y, Min.Z),
                new Vector3(Max.X, Max.Y, Min.Z),
                new Vector3(Max.X, Min.Y, Min.Z),
                new Vector3(Min.X, Min.Y, Min.Z)
            };
        }

        public void GetCorners(Vector3[] corners)
        {
            if (corners == null)
            {
                throw new ArgumentNullException("corners");
            }

            if (corners.Length < 8)
            {
                throw new ArgumentOutOfRangeException("corners", "Not Enought Corners");
            }

            corners[0].X = Min.X;
            corners[0].Y = Max.Y;
            corners[0].Z = Max.Z;
            corners[1].X = Max.X;
            corners[1].Y = Max.Y;
            corners[1].Z = Max.Z;
            corners[2].X = Max.X;
            corners[2].Y = Min.Y;
            corners[2].Z = Max.Z;
            corners[3].X = Min.X;
            corners[3].Y = Min.Y;
            corners[3].Z = Max.Z;
            corners[4].X = Min.X;
            corners[4].Y = Max.Y;
            corners[4].Z = Min.Z;
            corners[5].X = Max.X;
            corners[5].Y = Max.Y;
            corners[5].Z = Min.Z;
            corners[6].X = Max.X;
            corners[6].Y = Min.Y;
            corners[6].Z = Min.Z;
            corners[7].X = Min.X;
            corners[7].Y = Min.Y;
            corners[7].Z = Min.Z;
        }

        public float? Intersects(Ray ray, ISourceVectorArithmetic arithmetic, ISourceExtremaArithmetic extrema)
        {
            return ray.Intersects(this, arithmetic, extrema);
        }

        public void Intersects(ref Ray ray, out float? result, ISourceVectorArithmetic arithmetic,
            ISourceExtremaArithmetic extrema)
        {
            result = Intersects(ray, arithmetic, extrema);
        }

        public bool Intersects(BoundingFrustum frustum, ISourceVectorArithmetic arithmetic,
            ISourceExtremaArithmetic extrema)
        {
            return frustum.Intersects(this);
        }

        public void Intersects(ref BoundingSphere sphere, out bool result, ISourceVectorArithmetic arithmetic,
            ISourceExtremaArithmetic extrema)
        {
            result = Intersects(sphere, arithmetic, extrema);
        }

        public bool Intersects(BoundingBox box, ISourceVectorArithmetic arithmetic, ISourceExtremaArithmetic extrema)
        {
            Intersects(ref box, out var result, arithmetic, extrema);
            return result;
        }

        public PlaneIntersectionType Intersects(Plane plane, ISourceVectorArithmetic arithmetic,
            ISourceExtremaArithmetic extrema)
        {
            Intersects(ref plane, out var result, arithmetic, extrema);
            return result;
        }

        public void Intersects(ref BoundingBox box, out bool result, ISourceVectorArithmetic arithmetic,
            ISourceExtremaArithmetic extrema)
        {
            if (Max.X >= box.Min.X && Min.X <= box.Max.X)
            {
                if (Max.Y < box.Min.Y || Min.Y > box.Max.Y)
                {
                    result = false;
                }
                else
                {
                    result = Max.Z >= box.Min.Z && Min.Z <= box.Max.Z;
                }
            }
            else
            {
                result = false;
            }
        }

        public bool Intersects(BoundingSphere sphere, ISourceVectorArithmetic arithmetic,
            ISourceExtremaArithmetic extrema)
        {
            if (sphere.Center.X - Min.X > sphere.Radius && sphere.Center.Y - Min.Y > sphere.Radius &&
                sphere.Center.Z - Min.Z > sphere.Radius && Max.X - sphere.Center.X > sphere.Radius &&
                Max.Y - sphere.Center.Y > sphere.Radius && Max.Z - sphere.Center.Z > sphere.Radius)
            {
                return true;
            }

            float num = sphere.Radius * sphere.Radius;
            double num2 = 0.0;
            if (sphere.Center.X < Min.X)
            {
                num2 += (double)((sphere.Center.X - Min.X) * (sphere.Center.X - Min.X));
            }
            else if (sphere.Center.X > Max.X)
            {
                num2 += (double)((sphere.Center.X - Max.X) * (sphere.Center.X - Max.X));
            }

            if (sphere.Center.Y < Min.Y)
            {
                num2 += (double)((sphere.Center.Y - Min.Y) * (sphere.Center.Y - Min.Y));
            }
            else if (sphere.Center.Y > Max.Y)
            {
                num2 += (double)((sphere.Center.Y - Max.Y) * (sphere.Center.Y - Max.Y));
            }

            if (sphere.Center.Z < Min.Z)
            {
                num2 += (double)((sphere.Center.Z - Min.Z) * (sphere.Center.Z - Min.Z));
            }
            else if (sphere.Center.Z > Max.Z)
            {
                num2 += (double)((sphere.Center.Z - Max.Z) * (sphere.Center.Z - Max.Z));
            }

            return num2 <= (double)num;
        }

        public void Intersects(ref Plane plane, out PlaneIntersectionType result, ISourceVectorArithmetic arithmetic,
            ISourceExtremaArithmetic extrema)
        {
            Vector3 vector = default(Vector3);
            Vector3 vector2 = default(Vector3);
            if (plane.Normal.X >= 0f)
            {
                vector.X = Max.X;
                vector2.X = Min.X;
            }
            else
            {
                vector.X = Min.X;
                vector2.X = Max.X;
            }

            if (plane.Normal.Y >= 0f)
            {
                vector.Y = Max.Y;
                vector2.Y = Min.Y;
            }
            else
            {
                vector.Y = Min.Y;
                vector2.Y = Max.Y;
            }

            if (plane.Normal.Z >= 0f)
            {
                vector.Z = Max.Z;
                vector2.Z = Min.Z;
            }
            else
            {
                vector.Z = Min.Z;
                vector2.Z = Max.Z;
            }

            if (plane.Normal.X * vector2.X + plane.Normal.Y * vector2.Y + plane.Normal.Z * vector2.Z + plane.D > 0f)
            {
                result = PlaneIntersectionType.Front;
            }
            else if (plane.Normal.X * vector.X + plane.Normal.Y * vector.Y + plane.Normal.Z * vector.Z + plane.D < 0f)
            {
                result = PlaneIntersectionType.Back;
            }
            else
            {
                result = PlaneIntersectionType.Intersecting;
            }
        }

        public bool Equals(BoundingBox other)
        {
            if (Min == other.Min)
            {
                return Max == other.Max;
            }

            return false;
        }

        public static BoundingBox CreateFromPoints(IEnumerable<Vector3> points, ISourceVectorArithmetic arithmetic,
            ISourceExtremaArithmetic extrema)
        {
            if (points == null)
            {
                throw new ArgumentNullException("points");
            }

            bool flag = true;
            Vector3 maxVector = MaxVector3;
            Vector3 minVector = MinVector3;
            foreach (Vector3 point in points)
            {
                maxVector.X = ((maxVector.X < point.X) ? maxVector.X : point.X);
                maxVector.Y = ((maxVector.Y < point.Y) ? maxVector.Y : point.Y);
                maxVector.Z = ((maxVector.Z < point.Z) ? maxVector.Z : point.Z);
                minVector.X = ((minVector.X > point.X) ? minVector.X : point.X);
                minVector.Y = ((minVector.Y > point.Y) ? minVector.Y : point.Y);
                minVector.Z = ((minVector.Z > point.Z) ? minVector.Z : point.Z);
                flag = false;
            }

            if (flag)
            {
                throw new ArgumentException("Collection is empty", "points");
            }

            return new BoundingBox(maxVector, minVector);
        }

        public static BoundingBox CreateFromSphere(BoundingSphere sphere, ISourceVectorArithmetic arithmetic,
            ISourceExtremaArithmetic extrema)
        {
            CreateFromSphere(ref sphere, out var result, arithmetic, extrema);
            return result;
        }

        public static void CreateFromSphere(ref BoundingSphere sphere, out BoundingBox result,
            ISourceVectorArithmetic arithmetic, ISourceExtremaArithmetic extrema)
        {
            Vector3 vector = new Vector3(sphere.Radius);
            result.Min = SourceVector3Math.Subtract(sphere.Center, vector);
            result.Max = SourceVector3Math.Add(sphere.Center, vector);
        }

        public static BoundingBox CreateMerged(BoundingBox original, BoundingBox additional,
            ISourceVectorArithmetic arithmetic, ISourceExtremaArithmetic extrema)
        {
            CreateMerged(ref original, ref additional, out var result, arithmetic, extrema);
            return result;
        }

        public static void CreateMerged(ref BoundingBox original, ref BoundingBox additional, out BoundingBox result,
            ISourceVectorArithmetic arithmetic, ISourceExtremaArithmetic extrema)
        {
            result.Min.X = extrema.Min(original.Min.X, additional.Min.X);
            result.Min.Y = extrema.Min(original.Min.Y, additional.Min.Y);
            result.Min.Z = extrema.Min(original.Min.Z, additional.Min.Z);
            result.Max.X = extrema.Max(original.Max.X, additional.Max.X);
            result.Max.Y = extrema.Max(original.Max.Y, additional.Max.Y);
            result.Max.Z = extrema.Max(original.Max.Z, additional.Max.Z);
        }

        public override bool Equals(object obj)
        {
            if (obj is BoundingBox)
            {
                return Equals((BoundingBox)obj);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return unchecked(unchecked(Min.X.GetHashCode() + Min.Y.GetHashCode() + Min.Z.GetHashCode()) +
                             unchecked(Max.X.GetHashCode() + Max.Y.GetHashCode() + Max.Z.GetHashCode()));
        }

        public static bool operator ==(BoundingBox a, BoundingBox b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(BoundingBox a, BoundingBox b)
        {
            return !a.Equals(b);
        }

        public string ToString(Func<float, string> format)
        {
            return "{{Min:" + SourceGeometryFormatting.Vector(Min, format) + " Max:" +
                   SourceGeometryFormatting.Vector(Max, format) + "}}";
        }
    }
}
