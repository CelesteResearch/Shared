using System;
using System.Numerics;

namespace Celeste.Physics.Collision.Shapes
{
    public static class ColliderIntersections
    {
        // Same four sector tests and strict segment distance as Monocle.Collide.RectToCircle.
        public static bool CircleOverlaps(Vector2 center, float radius, global::Celeste.Core.Geometry.Bounds rect)
        {
            float right = rect.X + rect.Width, bottom = rect.Y + rect.Height;
            if (center.X >= rect.X && center.Y >= rect.Y && center.X < right && center.Y < bottom) return true;
            if (center.Y < rect.Y && Line(new Vector2(rect.X, rect.Y), new Vector2(right, rect.Y))) return true;
            if (center.Y >= bottom && Line(new Vector2(rect.X, bottom), new Vector2(right, bottom))) return true;
            if (center.X < rect.X && Line(new Vector2(rect.X, rect.Y), new Vector2(rect.X, bottom))) return true;
            return center.X >= right && Line(new Vector2(right, rect.Y), new Vector2(right, bottom));

            bool Line(Vector2 from, Vector2 to)
            {
                var line = to - from;
                float along = Vector2.Dot(center - from, line) / line.LengthSquared();
                along = Math.Max(Math.Min(along, 1), 0);
                return Vector2.DistanceSquared(center, from + line * along) < radius * radius;
            }
        }
    }
}
