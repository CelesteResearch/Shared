using Celeste.Simulation.Gameplay.Enemies.Badeline.Chasers;

namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        public bool GetChasePosition(float sceneTime, float timeAgo, out ChaserState chaseState)
            => ChaseHistory.GetChasePosition(sceneTime, timeAgo, Dead, out chaseState);
    }
}
