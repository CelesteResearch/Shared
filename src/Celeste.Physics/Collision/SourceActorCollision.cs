using System.Numerics;

namespace Celeste.Physics.Collision
{
    public static class SourceActorCollision
    {
        public static bool CheckAt(PixelActor actor, ISourceEntityCollider other, Vector2 at)
        {
            // Monocle.Collide.Check(Entity, Entity, at): assign and restore only on success.
            var position = actor.Position;
            actor.Position = at;
            var result = SourceEntityCollision.Check(actor.SourceColliderOwner, other);
            actor.Position = position;
            return result;
        }
    }
}
