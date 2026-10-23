using System.Numerics;
using Celeste.Core.Components;
using Celeste.Physics.Collision;
using Celeste.Scene.Tracking;

namespace Celeste.Scene.Entities
{
    public static class SourceTrackedEntityCollision
    {
        public static bool Check(SceneEntityRegistry registry, string sourceType, ISourceEntityCollider actual)
        {
            var entities = registry.GetTrackedEntities(sourceType);
            foreach (var entity in entities)
                if (SourceEntityCollision.Check(actual, (ISourceEntityCollider)entity))
                    return true;
            return false;
        }

        public static bool CheckAt(SceneEntityRegistry registry, string sourceType, ISourceEntityCollider actual,
            Vector2 at)
        {
            var entities = registry.GetTrackedEntities(sourceType);
            var mutable = (ISourceMutableEntityPosition)actual;
            var previous = mutable.Position;
            mutable.Position = at;
            var result = false;
            foreach (var entity in entities)
                if (SourceEntityCollision.Check(actual, (ISourceEntityCollider)entity))
                {
                    result = true;
                    break;
                }

            mutable.Position = previous;
            return result;
        }

        public static T First<T>(SceneEntityRegistry registry, string sourceType, ISourceEntityCollider actual)
            where T : class
        {
            var entities = registry.GetTrackedEntities(sourceType);
            foreach (var entity in entities)
                if (SourceEntityCollision.Check(actual, (ISourceEntityCollider)entity))
                    return entity as T;
            return null;
        }

        public static T FirstAt<T>(SceneEntityRegistry registry, string sourceType, ISourceEntityCollider actual,
            Vector2 at) where T : class
        {
            var entities = registry.GetTrackedEntities(sourceType);
            var mutable = (ISourceMutableEntityPosition)actual;
            var previous = mutable.Position;
            mutable.Position = at;
            object first = null;
            foreach (var entity in entities)
                if (SourceEntityCollision.Check(actual, (ISourceEntityCollider)entity))
                {
                    first = entity;
                    break;
                }

            mutable.Position = previous;
            return first as T;
        }

        public static T FirstOutsideAt<T, TActual>(SceneEntityRegistry registry, string sourceType,
            TActual actual, Vector2 at) where T : class
            where TActual : ISourceEntityCollider, ISourceMutableEntityPosition
        {
            var entities = registry.GetTrackedEntities(sourceType);
            foreach (var entity in entities)
                if (!SourceEntityCollision.Check(actual, (ISourceEntityCollider)entity)
                    && SourceEntityCollision.CheckAt(actual, (ISourceEntityCollider)entity, at))
                    return entity as T;
            return null;
        }

        public static bool CheckAtExcept(SceneEntityRegistry registry, string sourceType,
            string excludedSourceType, ISourceEntityCollider actual, Vector2 at)
        {
            var mutable = (ISourceMutableEntityPosition)actual;
            var previous = mutable.Position;
            mutable.Position = at;
            var excluded = registry.GetTrackedEntities(excludedSourceType);
            foreach (var entity in registry.GetTrackedEntities(sourceType))
                if (!excluded.Contains(entity) && SourceEntityCollision.Check(actual, (ISourceEntityCollider)entity))
                {
                    mutable.Position = previous;
                    return true;
                }

            mutable.Position = previous;
            return false;
        }

        public static bool CheckAtExcept(SceneEntityRegistry registry, string sourceType,
            string excludedSourceType, string secondExcludedSourceType,
            ISourceEntityCollider actual, Vector2 at)
        {
            var mutable = (ISourceMutableEntityPosition)actual;
            var previous = mutable.Position;
            mutable.Position = at;
            var excluded = registry.GetTrackedEntities(excludedSourceType);
            var secondExcluded = registry.GetTrackedEntities(secondExcludedSourceType);
            var result = false;
            foreach (var entity in registry.GetTrackedEntities(sourceType))
                if (!excluded.Contains(entity) && !secondExcluded.Contains(entity)
                                               && SourceEntityCollision.Check(actual, (ISourceEntityCollider)entity))
                {
                    result = true;
                    break;
                }

            mutable.Position = previous;
            return result;
        }
    }
}
