using System.Numerics;
using Celeste.Physics.Collision;

namespace Celeste.Simulation.Gameplay.Collision.Blockers
{
    public interface ILedgeBlockerPlayer : ISourceEntityCollider
    {
        new Vector2 Position { get; set; }
        int Facing { get; }
    }
}
