using System.Numerics;
using Celeste.Physics.Collision;
using Celeste.Simulation.Gameplay.Player.Collision.Surfaces;

namespace Celeste.Simulation.Gameplay.Mechanisms.Switches
{
    public interface ISourceDashSwitch : ISourceEntityCollider
    {
        DashCollisionResult OnDashCollide(RoomPlayerSession player, Vector2 direction);
    }
}
