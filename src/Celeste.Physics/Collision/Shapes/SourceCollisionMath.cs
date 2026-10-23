using System;
using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Core.Mathematics;
using Bounds = Celeste.Core.Geometry.Bounds;

namespace Celeste.Physics.Collision.Shapes
{
    internal static class SourceCollisionMath
    {
        public static bool LineCheck(Vector2 a1, Vector2 a2, Vector2 b1, Vector2 b2)
        {
            var vector = a2 - a1;
            var vector2 = b2 - b1;
            var num = vector.X * vector2.Y - vector.Y * vector2.X;
            if (num == 0f) return false;

            var vector3 = b1 - a1;
            var num2 = (vector3.X * vector2.Y - vector3.Y * vector2.X) / num;
            if (num2 < 0f || num2 > 1f) return false;

            var num3 = (vector3.X * vector.Y - vector3.Y * vector.X) / num;
            if (num3 < 0f || num3 > 1f) return false;

            return true;
        }

        public static bool CircleToLine(Vector2 cPosiition, float cRadius, Vector2 lineFrom, Vector2 lineTo,
            ISourceVectorArithmetic arithmetic)
        {
            return arithmetic.DistanceSquared(cPosiition,
                       ClosestPointOnLine(lineFrom, lineTo, cPosiition, arithmetic)) <
                   cRadius * cRadius;
        }

        public static bool CircleToPoint(Vector2 cPosition, float cRadius, Vector2 point,
            ISourceVectorArithmetic arithmetic)
        {
            return arithmetic.DistanceSquared(cPosition, point) < cRadius * cRadius;
        }

        public static bool RectToCircle(float rX, float rY, float rW, float rH, Vector2 cPosition, float cRadius,
            ISourceVectorArithmetic arithmetic)
        {
            if (RectToPoint(rX, rY, rW, rH, cPosition)) return true;

            // Only the sealed installed arithmetic has the known projection and distance semantics.
            // The bounded coordinates and two-unit margin cover float projection/rounding error;
            // near contacts, unusual dimensions and custom arithmetic retain the original path.
            const float coordinateLimit = 1048576f;
            if (ReferenceEquals(arithmetic, InstalledVectorArithmetic.Shared) &&
                cRadius >= 0f && cRadius <= 4096f &&
                rW >= 0f && rW <= coordinateLimit && rH >= 0f && rH <= coordinateLimit &&
                rX >= -coordinateLimit && rX <= coordinateLimit &&
                rY >= -coordinateLimit && rY <= coordinateLimit &&
                cPosition.X >= -coordinateLimit && cPosition.X <= coordinateLimit &&
                cPosition.Y >= -coordinateLimit && cPosition.Y <= coordinateLimit &&
                (cPosition.X < (double)rX - cRadius - 2.0 ||
                 cPosition.X > (double)rX + rW + cRadius + 2.0 ||
                 cPosition.Y < (double)rY - cRadius - 2.0 ||
                 cPosition.Y > (double)rY + rH + cRadius + 2.0))
                return false;

            var sector = GetSector(rX, rY, rW, rH, cPosition);
            if ((sector & PointSector.Top) != PointSector.Center)
            {
                var lineFrom = new Vector2(rX, rY);
                var lineTo = new Vector2(rX + rW, rY);
                if (CircleToLine(cPosition, cRadius, lineFrom, lineTo, arithmetic)) return true;
            }

            if ((sector & PointSector.Bottom) != PointSector.Center)
            {
                var lineFrom = new Vector2(rX, rY + rH);
                var lineTo = new Vector2(rX + rW, rY + rH);
                if (CircleToLine(cPosition, cRadius, lineFrom, lineTo, arithmetic)) return true;
            }

            if ((sector & PointSector.Left) != PointSector.Center)
            {
                var lineFrom = new Vector2(rX, rY);
                var lineTo = new Vector2(rX, rY + rH);
                if (CircleToLine(cPosition, cRadius, lineFrom, lineTo, arithmetic)) return true;
            }

            if ((sector & PointSector.Right) != PointSector.Center)
            {
                var lineFrom = new Vector2(rX + rW, rY);
                var lineTo = new Vector2(rX + rW, rY + rH);
                if (CircleToLine(cPosition, cRadius, lineFrom, lineTo, arithmetic)) return true;
            }

            return false;
        }

        public static bool RectToCircle(Bounds rect, Vector2 cPosition, float cRadius,
            ISourceVectorArithmetic arithmetic)
        {
            return RectToCircle(rect.X, rect.Y, rect.Width, rect.Height, cPosition, cRadius, arithmetic);
        }

        public static bool RectToCircle(IntRect rect, Vector2 cPosition, float cRadius,
            ISourceVectorArithmetic arithmetic)
        {
            return RectToCircle(rect.X, rect.Y, rect.Width, rect.Height, cPosition, cRadius, arithmetic);
        }

        public static bool RectToLine(float rX, float rY, float rW, float rH, Vector2 lineFrom, Vector2 lineTo)
        {
            var sector = GetSector(rX, rY, rW, rH, lineFrom);
            var sector2 = GetSector(rX, rY, rW, rH, lineTo);
            if (sector == PointSector.Center || sector2 == PointSector.Center) return true;

            if ((sector & sector2) != PointSector.Center) return false;

            var pointSectors = sector | sector2;
            if ((pointSectors & PointSector.Top) != PointSector.Center)
            {
                var a = new Vector2(rX, rY);
                var a2 = new Vector2(rX + rW, rY);
                if (LineCheck(a, a2, lineFrom, lineTo)) return true;
            }

            if ((pointSectors & PointSector.Bottom) != PointSector.Center)
            {
                var a3 = new Vector2(rX, rY + rH);
                var a2 = new Vector2(rX + rW, rY + rH);
                if (LineCheck(a3, a2, lineFrom, lineTo)) return true;
            }

            if ((pointSectors & PointSector.Left) != PointSector.Center)
            {
                var a4 = new Vector2(rX, rY);
                var a2 = new Vector2(rX, rY + rH);
                if (LineCheck(a4, a2, lineFrom, lineTo)) return true;
            }

            if ((pointSectors & PointSector.Right) != PointSector.Center)
            {
                var a5 = new Vector2(rX + rW, rY);
                var a2 = new Vector2(rX + rW, rY + rH);
                if (LineCheck(a5, a2, lineFrom, lineTo)) return true;
            }

            return false;
        }

        public static bool RectToPoint(float rX, float rY, float rW, float rH, Vector2 point)
        {
            if (point.X >= rX && point.Y >= rY && point.X < rX + rW) return point.Y < rY + rH;

            return false;
        }

        public static PointSector GetSector(float rX, float rY, float rW, float rH, Vector2 point)
        {
            var pointSectors = PointSector.Center;
            if (point.X < rX)
                pointSectors |= PointSector.Left;
            else if (point.X >= rX + rW) pointSectors |= PointSector.Right;

            if (point.Y < rY)
                pointSectors |= PointSector.Top;
            else if (point.Y >= rY + rH) pointSectors |= PointSector.Bottom;

            return pointSectors;
        }

        public static Vector2 ClosestPointOnLine(Vector2 lineA, Vector2 lineB, Vector2 closestTo,
            ISourceVectorArithmetic arithmetic)
        {
            return arithmetic.ClosestPointOnLine(lineA, lineB, closestTo);
        }

        public static int Clamp(int value, int min, int max)
        {
            return Math.Min(Math.Max(value, min), max);
        }
    }
}
