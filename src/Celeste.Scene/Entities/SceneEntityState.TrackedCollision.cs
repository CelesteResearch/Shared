using System.Numerics;
using Celeste.Physics.Collision;
using Celeste.Scene.Tracking;

namespace Celeste.Scene.Entities
{
    public partial class SceneEntityState
    {
        public bool CollideCheck(string sourceType)
        {
            var entities = ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities(sourceType);
            foreach (var entity in entities)
                if (SourceEntityCollision.Check(this, (ISourceEntityCollider)entity))
                    return true;
            return false;
        }

        public bool CollideCheck(string sourceType, Vector2 at)
        {
            var entities = ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities(sourceType);
            var previous = Position;
            Position = at;
            var result = false;
            foreach (var entity in entities)
                if (SourceEntityCollision.Check(this, (ISourceEntityCollider)entity))
                {
                    result = true;
                    break;
                }

            Position = previous;
            return result;
        }

        public T CollideFirst<T>(string sourceType) where T : class
        {
            var entities = ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities(sourceType);
            foreach (var entity in entities)
                if (SourceEntityCollision.Check(this, (ISourceEntityCollider)entity))
                    return entity as T;
            return null;
        }

        public T CollideFirst<T>(string sourceType, Vector2 at) where T : class
        {
            var entities = ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities(sourceType);
            var previous = Position;
            Position = at;
            object first = null;
            foreach (var entity in entities)
                if (SourceEntityCollision.Check(this, (ISourceEntityCollider)entity))
                {
                    first = entity;
                    break;
                }

            Position = previous;
            return first as T;
        }
    }
}
