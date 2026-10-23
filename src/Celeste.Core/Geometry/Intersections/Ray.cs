using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.LinearAlgebra;
using System;

namespace Celeste.Core.Geometry.Intersections
{
    public struct Ray : IEquatable<Ray>
    {
        public Vector3 Position;

        public Vector3 Direction;


        public Ray(Vector3 position, Vector3 direction)
        {
            Position = position;
            Direction = direction;
        }

        public override bool Equals(object obj)
        {
            if (obj is Ray)
            {
                return Equals((Ray)obj);
            }

            return false;
        }

        public bool Equals(Ray other)
        {
            if (Position.X == other.Position.X && Position.Y == other.Position.Y && Position.Z == other.Position.Z)
            {
                return Direction.X == other.Direction.X && Direction.Y == other.Direction.Y &&
                       Direction.Z == other.Direction.Z;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return unchecked(unchecked(Position.X.GetHashCode() + Position.Y.GetHashCode() + Position.Z.GetHashCode()) ^
                             unchecked(Direction.X.GetHashCode() + Direction.Y.GetHashCode() +
                                       Direction.Z.GetHashCode()));
        }

        public float? Intersects(BoundingBox box, ISourceVectorArithmetic arithmetic, ISourceExtremaArithmetic extrema)
        {
            float? num = null;
            float? num2 = null;
            if (Math.Abs(Direction.X - 0f) < 5.9604645E-08f)
            {
                if (Position.X < box.Min.X || Position.X > box.Max.X)
                {
                    return null;
                }
            }
            else
            {
                num = (box.Min.X - Position.X) / Direction.X;
                num2 = (box.Max.X - Position.X) / Direction.X;
                if (num > num2)
                {
                    float? num3 = num;
                    num = num2;
                    num2 = num3;
                }
            }

            if (Math.Abs(Direction.Y - 0f) < 5.9604645E-08f)
            {
                if (Position.Y < box.Min.Y || Position.Y > box.Max.Y)
                {
                    return null;
                }
            }
            else
            {
                float num4 = (box.Min.Y - Position.Y) / Direction.Y;
                float num5 = (box.Max.Y - Position.Y) / Direction.Y;
                if (num4 > num5)
                {
                    float num6 = num4;
                    num4 = num5;
                    num5 = num6;
                }

                if ((num.HasValue && num > num5) || (num2.HasValue && num4 > num2))
                {
                    return null;
                }

                if (!num.HasValue || num4 > num)
                {
                    num = num4;
                }

                if (!num2.HasValue || num5 < num2)
                {
                    num2 = num5;
                }
            }

            if (Math.Abs(Direction.Z - 0f) < 5.9604645E-08f)
            {
                if (Position.Z < box.Min.Z || Position.Z > box.Max.Z)
                {
                    return null;
                }
            }
            else
            {
                float num7 = (box.Min.Z - Position.Z) / Direction.Z;
                float num8 = (box.Max.Z - Position.Z) / Direction.Z;
                if (num7 > num8)
                {
                    float num9 = num7;
                    num7 = num8;
                    num8 = num9;
                }

                if ((num.HasValue && num > num8) || (num2.HasValue && num7 > num2))
                {
                    return null;
                }

                if (!num.HasValue || num7 > num)
                {
                    num = num7;
                }

                if (!num2.HasValue || num8 < num2)
                {
                    num2 = num8;
                }
            }

            if (num.HasValue && num < 0f && num2 > 0f)
            {
                return 0f;
            }

            if (num < 0f)
            {
                return null;
            }

            return num;
        }

        public void Intersects(ref BoundingBox box, out float? result, ISourceVectorArithmetic arithmetic,
            ISourceExtremaArithmetic extrema)
        {
            result = Intersects(box, arithmetic, extrema);
        }

        public float? Intersects(BoundingSphere sphere, ISourceVectorArithmetic arithmetic,
            ISourceExtremaArithmetic extrema)
        {
            Intersects(ref sphere, out var result, arithmetic, extrema);
            return result;
        }

        public float? Intersects(Plane plane, ISourceVectorArithmetic arithmetic, ISourceExtremaArithmetic extrema)
        {
            Intersects(ref plane, out var result, arithmetic, extrema);
            return result;
        }

        public float? Intersects(BoundingFrustum frustum, ISourceVectorArithmetic arithmetic,
            ISourceExtremaArithmetic extrema)
        {
            frustum.Intersects(ref this, out var result);
            return result;
        }

        public void Intersects(ref Plane plane, out float? result, ISourceVectorArithmetic arithmetic,
            ISourceExtremaArithmetic extrema)
        {
            float num = arithmetic.Dot(Direction, plane.Normal);
            if (Math.Abs(num) < 1E-05f)
            {
                result = null;
                return;
            }

            result = (0f - plane.D - arithmetic.Dot(plane.Normal, Position)) / num;
            if (result < 0f)
            {
                if (result < -1E-05f)
                {
                    result = null;
                }
                else
                {
                    result = 0f;
                }
            }
        }

        public void Intersects(ref BoundingSphere sphere, out float? result, ISourceVectorArithmetic arithmetic,
            ISourceExtremaArithmetic extrema)
        {
            Vector3 vector = SourceVector3Math.Subtract(sphere.Center, Position);
            float num = arithmetic.LengthSquared(vector);
            float num2 = sphere.Radius * sphere.Radius;
            if (num < num2)
            {
                result = 0f;
                return;
            }

            float result2 = arithmetic.Dot(Direction, vector);
            if (result2 < 0f)
            {
                result = null;
                return;
            }

            float num3 = num2 + result2 * result2 - num;
            result = ((num3 < 0f) ? ((float?)null) : new float?(result2 - (float)Math.Sqrt(num3)));
        }

        public static bool operator !=(Ray a, Ray b)
        {
            return !a.Equals(b);
        }

        public static bool operator ==(Ray a, Ray b)
        {
            return a.Equals(b);
        }

        public string ToString(Func<float, string> format)
        {
            return "{{Position:" + SourceGeometryFormatting.Vector(Position, format) + " Direction:" +
                   SourceGeometryFormatting.Vector(Direction, format) + "}}";
        }
    }
}
