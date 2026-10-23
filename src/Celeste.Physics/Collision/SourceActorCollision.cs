using System.Numerics;

namespace Celeste.Physics.Collision
{
    public static class SourceActorCollision
    {
        public static bool CheckAt(PixelActor actor, ISourceEntityCollider other, Vector2 at)
        {
            // Monocle.Collide.Check(Entity, Entity, at): assign and restore only on success.
            Vector2 position = actor.Position;
            actor.Position = at;
            bool result = SourceEntityCollision.Check(actor.SourceColliderOwner, other);
            actor.Position = position;
            return result;
        }
    }
}
