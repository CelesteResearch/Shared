namespace Celeste.Physics.Collision
{
    public static class SourceEntityCollision
    {
        public static bool Check(ISourceEntityCollider a, ISourceEntityCollider b)
        {
            if (a.Collider == null || b.Collider == null) return false;
            if (!object.ReferenceEquals(a, b) && b.Collidable)
                return a.Collider.Collide(b.Collider);
            return false;
        }

        public static bool CheckAt(ISourceEntityCollider a, ISourceEntityCollider b, System.Numerics.Vector2 at)
        {
            var mutable = (global::Celeste.Core.Components.ISourceMutableEntityPosition)a;
            var position = mutable.Position;
            mutable.Position = at;
            bool result = Check(a, b);
            mutable.Position = position;
            return result;
        }

        public static bool CheckRect(ISourceEntityCollider entity, global::Celeste.Core.Geometry.IntRect rectangle)
        {
            if (entity.Collider == null) return false;
            return entity.Collider.Collide(rectangle);
        }
    }
}
