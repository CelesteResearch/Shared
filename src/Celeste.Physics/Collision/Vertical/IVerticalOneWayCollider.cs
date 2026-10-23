using Celeste.Physics.Collision.Riding;

namespace Celeste.Physics.Collision.Vertical
{
    public interface IVerticalOneWayCollider : ISourceJumpThruCollider
    {
        bool AllowPositiveVerticalMovement { get; }
    }
}
