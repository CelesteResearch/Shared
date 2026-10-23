using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Geometry;
using Celeste.Physics.Collision.Shapes;

namespace Celeste.Physics.Collision
{
    public static class SourceEntityGeometryCollision
    {
        public static bool Point(ISourceEntityCollider actual, Vector2 point)
            => actual.Collider != null && actual.Collider.Collide(point);

        public static bool Line(ISourceEntityCollider actual, Vector2 from, Vector2 to)
            => actual.Collider != null && actual.Collider.Collide(from, to);

        public static bool Rectangle(ISourceEntityCollider actual, IntRect rectangle)
            => actual.Collider != null && Rectangle(actual.Collider, rectangle);

        public static bool Rectangle(ColliderGeometry collider, IntRect rectangle)
            => collider.Collide(rectangle);

        public static bool PointAt(ISourceEntityCollider actual, Vector2 point, Vector2 at)
        {
            var mutable = (ISourceMutableEntityPosition)actual;
            Vector2 previous = mutable.Position;
            mutable.Position = at;
            bool result = Point(actual, point);
            mutable.Position = previous;
            return result;
        }

        public static bool LineAt(ISourceEntityCollider actual, Vector2 from, Vector2 to, Vector2 at)
        {
            var mutable = (ISourceMutableEntityPosition)actual;
            Vector2 previous = mutable.Position;
            mutable.Position = at;
            bool result = Line(actual, from, to);
            mutable.Position = previous;
            return result;
        }

        public static bool RectangleAt(ISourceEntityCollider actual, IntRect rectangle, Vector2 at)
        {
            var mutable = (ISourceMutableEntityPosition)actual;
            Vector2 previous = mutable.Position;
            mutable.Position = at;
            bool result = Rectangle(actual, rectangle);
            mutable.Position = previous;
            return result;
        }
    }
}
