using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Physics.Collision;
using Celeste.Scene.Tracking;

namespace Celeste.Scene.Entities
{
    public static class SourceSceneCollision
    {
        public static bool CheckLine(SceneEntityRegistry registry, string sourceType, Vector2 from, Vector2 to)
        {
            var entities = registry.GetTrackedEntities(sourceType);
            for (var i = 0; i < entities.Count; i++)
                if (((ISourceEntityCollider)entities[i]).Collidable &&
                    CollideLine((ISourceEntityCollider)entities[i], from, to))
                    return true;

            return false;
        }

        public static bool CheckRect(SceneEntityRegistry registry, string sourceType, IntRect rectangle)
        {
            var entities = registry.GetTrackedEntities(sourceType);
            for (var i = 0; i < entities.Count; i++)
                if (((ISourceEntityCollider)entities[i]).Collidable &&
                    CollideRectangle((ISourceEntityCollider)entities[i], rectangle))
                    return true;

            return false;
        }

        public static T FirstLine<T>(SceneEntityRegistry registry, string sourceType, Vector2 from, Vector2 to)
            where T : class
        {
            var entities = registry.GetTrackedEntities(sourceType);
            for (var i = 0; i < entities.Count; i++)
                if (((ISourceEntityCollider)entities[i]).Collidable
                    && CollideLine((ISourceEntityCollider)entities[i], from, to))
                    return entities[i] as T;
            return null;
        }

        public static T FirstPoint<T>(SceneEntityRegistry registry, string sourceType, Vector2 point)
            where T : class
        {
            var entities = registry.GetTrackedEntities(sourceType);
            for (var i = 0; i < entities.Count; i++)
                if (((ISourceEntityCollider)entities[i]).Collidable
                    && CollidePoint((ISourceEntityCollider)entities[i], point))
                    return entities[i] as T;
            return null;
        }

        public static T FirstRect<T>(SceneEntityRegistry registry, string sourceType, IntRect rectangle)
            where T : class
        {
            var entities = registry.GetTrackedEntities(sourceType);
            for (var i = 0; i < entities.Count; i++)
                if (((ISourceEntityCollider)entities[i]).Collidable
                    && CollideRectangle((ISourceEntityCollider)entities[i], rectangle))
                    return entities[i] as T;
            return null;
        }

        public static List<T> AllPoint<T>(SceneEntityRegistry registry, string sourceType, Vector2 point)
            where T : class
        {
            var result = new List<T>();
            IntoPoint(registry, sourceType, point, result);
            return result;
        }

        public static void IntoPoint<T>(SceneEntityRegistry registry, string sourceType, Vector2 point, List<T> hits)
            where T : class
        {
            var entities = registry.GetTrackedEntities(sourceType);
            for (var i = 0; i < entities.Count; i++)
                if (((ISourceEntityCollider)entities[i]).Collidable
                    && CollidePoint((ISourceEntityCollider)entities[i], point))
                    hits.Add(entities[i] as T);
        }

        public static List<T> AllRect<T>(SceneEntityRegistry registry, string sourceType, IntRect rectangle)
            where T : class
        {
            var result = new List<T>();
            IntoRect(registry, sourceType, rectangle, result);
            return result;
        }

        public static void IntoRect<T>(SceneEntityRegistry registry, string sourceType, IntRect rectangle, List<T> hits)
            where T : class
        {
            var entities = registry.GetTrackedEntities(sourceType);
            for (var i = 0; i < entities.Count; i++)
                if (((ISourceEntityCollider)entities[i]).Collidable
                    && CollideRectangle((ISourceEntityCollider)entities[i], rectangle))
                    hits.Add(entities[i] as T);
        }

        public static bool CheckRect(IntRect rectangle, ISourceEntityCollider entity)
        {
            if (entity.Collidable) return CollideRectangle(entity, rectangle);

            return false;
        }

        private static bool CollideRectangle(ISourceEntityCollider entity, IntRect rectangle)
        {
            return SourceEntityGeometryCollision.Rectangle(entity, rectangle);
        }

        private static bool CollidePoint(ISourceEntityCollider entity, Vector2 point)
        {
            return SourceEntityGeometryCollision.Point(entity, point);
        }

        private static bool CollideLine(ISourceEntityCollider entity, Vector2 from, Vector2 to)
        {
            return SourceEntityGeometryCollision.Line(entity, from, to);
        }

        public static bool CheckPoint(SceneEntityRegistry registry, string sourceType, Vector2 point)
        {
            var entities = registry.GetTrackedEntities(sourceType);
            for (var i = 0; i < entities.Count; i++)
                if (((ISourceEntityCollider)entities[i]).Collidable
                    && CollidePoint((ISourceEntityCollider)entities[i], point))
                    return true;

            return false;
        }
    }
}
