namespace Celeste.Physics.Collision.Vertical
{
    public interface IVerticalOneWayCollider : Riding.ISourceJumpThruCollider
    {
        bool AllowPositiveVerticalMovement { get; }
    }
}
