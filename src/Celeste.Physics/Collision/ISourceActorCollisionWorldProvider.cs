namespace Celeste.Physics.Collision
{
    public interface ISourceActorCollisionWorldProvider
    {
        ICollisionWorld CollisionWorld { get; }
    }
}
