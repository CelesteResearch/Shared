using System;
using System.Numerics;

namespace Celeste.Physics.Collision.Riding
{
    public interface ISourcePlatformActor : ISourceEntityCollider, ISourceActorRiding
    {
        bool TreatNaive { get; }
        bool AllowPushing { get; }
        new bool Collidable { get; set; }
        float Left { get; }
        float Right { get; }
        float Top { get; }
        global::Celeste.Physics.Collision.SourceCollisionHandler SquishCallback { get; }
        Vector2 LiftSpeed { get; set; }
        float Bottom { get; }
        void NaiveMove(Vector2 amount);
        bool MoveHExact(int amount);
        bool MoveVExact(int amount);

        bool MoveHExact(int amount, global::Celeste.Physics.Collision.SourceCollisionHandler onCollide,
            ISourceEntityCollider pusher);

        bool MoveVExact(int amount, global::Celeste.Physics.Collision.SourceCollisionHandler onCollide,
            ISourceEntityCollider pusher);
    }
}
