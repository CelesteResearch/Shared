using System.Numerics;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Player.Runtime;

namespace Celeste.Everest.Runtime.Events.Player
{
    public sealed class InstalledPlayerStarFlyExitPolicy : ISourcePlayerStarFlyExitPolicy
    {
        public void OnFailure(RoomPlayerSession actualPlayer)
        {
            actualPlayer.Die(Vector2.Zero);
        }
    }
}
