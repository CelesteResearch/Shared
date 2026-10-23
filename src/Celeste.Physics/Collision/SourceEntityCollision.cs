using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Geometry;

namespace Celeste.Physics.Collision
{
    public static class SourceEntityCollision
    {
        public static bool Check(ISourceEntityCollider a, ISourceEntityCollider b)
        {
            if (a.Collider == null || b.Collider == null) return false;
            if (!ReferenceEquals(a, b) && b.Collidable)
                return a.Collider.Collide(b.Collider);
            return false;
        }

        public static bool CheckAt(ISourceEntityCollider a, ISourceEntityCollider b, Vector2 at)
        {
            var mutable = (ISourceMutableEntityPosition)a;
            var position = mutable.Position;
            mutable.Position = at;
            var result = Check(a, b);
            mutable.Position = position;
            return result;
        }

        public static bool CheckRect(ISourceEntityCollider entity, IntRect rectangle)
        {
            if (entity.Collider == null) return false;
            return entity.Collider.Collide(rectangle);
        }
    }
}
