namespace Celeste.Physics.Collision.Riding
{
    public interface ISourceActorRiding
    {
        bool IsRiding(ISourceEntityCollider solid);
        bool IsRiding(ISourceJumpThruCollider jumpThru);
    }
}
