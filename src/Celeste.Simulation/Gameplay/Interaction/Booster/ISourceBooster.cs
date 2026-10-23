using System.Numerics;
using Celeste.Physics.Collision;

namespace Celeste.Simulation.Gameplay.Interaction.Booster
{
    public interface ISourceBooster : ISourceEntityCollider
    {
        Vector2 Center { get; }
        bool Ch9HubTransition { get; }
        bool BoostingPlayer { get; }
        void PlayerBoosted(RoomPlayerSession actualPlayer, Vector2 direction);
        void PlayerReleased();
        void PlayerDied();
    }
}
