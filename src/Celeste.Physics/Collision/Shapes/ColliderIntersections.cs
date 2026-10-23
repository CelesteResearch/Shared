using System;
using System.Numerics;
using Celeste.Core.Geometry;

namespace Celeste.Physics.Collision.Shapes
{
    public static class ColliderIntersections
    {
        // Same four sector tests and strict segment distance as Monocle.Collide.RectToCircle.
        public static bool CircleOverlaps(Vector2 center, float radius, Bounds rect)
        {
            float right = rect.X + rect.Width, bottom = rect.Y + rect.Height;
            if (center.X >= rect.X && center.Y >= rect.Y && center.X < right && center.Y < bottom) return true;
            if (center.Y < rect.Y && Line(new(rect.X, rect.Y), new(right, rect.Y))) return true;
            if (center.Y >= bottom && Line(new(rect.X, bottom), new(right, bottom))) return true;
            if (center.X < rect.X && Line(new(rect.X, rect.Y), new(rect.X, bottom))) return true;
            return center.X >= right && Line(new(right, rect.Y), new(right, bottom));

            bool Line(Vector2 from, Vector2 to)
            {
                var line = to - from;
                var along = Vector2.Dot(center - from, line) / line.LengthSquared();
                along = Math.Max(Math.Min(along, 1), 0);
                return Vector2.DistanceSquared(center, from + line * along) < radius * radius;
            }
        }
    }
}
