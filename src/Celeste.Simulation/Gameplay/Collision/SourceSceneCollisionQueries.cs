using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Physics.Collision;

namespace Celeste.Simulation.Gameplay.Collision
{
    public static class SourceSceneCollisionQueries
    {
        public static List<object> All(ISourceEntityCollider from, List<object> entities)
            => All(from, entities, new List<object>());

        public static List<object> All(ISourceEntityCollider from, List<object> entities, List<object> into)
        {
            foreach (var entry in entities)
                if (SourceEntityCollision.Check(from, (ISourceEntityCollider)entry))
                    into.Add(entry);
            return into;
        }

        public static bool Check(ISourceEntityCollider from, List<object> entities)
        {
            foreach (var entry in entities)
                if (SourceEntityCollision.Check(from, (ISourceEntityCollider)entry))
                    return true;
            return false;
        }

        public static bool CheckAt(ISourceEntityCollider from, List<object> entities, Vector2 at)
        {
            var mutable = (ISourceMutableEntityPosition)from;
            Vector2 position = mutable.Position;
            mutable.Position = at;
            bool result = Check(from, entities);
            mutable.Position = position;
            return result;
        }

        public static object First(ISourceEntityCollider from, List<object> entities)
        {
            foreach (var entry in entities)
                if (SourceEntityCollision.Check(from, (ISourceEntityCollider)entry))
                    return entry;
            return null;
        }

        public static T First<T>(global::Celeste.Core.Geometry.IntRect rectangle,
            List<object> entities) where T : class
        {
            for (int i = 0; i < entities.Count; i++)
            {
                if (((ISourceEntityCollider)entities[i]).Collidable
                    && SourceEntityCollision.CheckRect((ISourceEntityCollider)entities[i], rectangle))
                    return entities[i] as T;
            }

            return null;
        }
    }
}
