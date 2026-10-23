using Celeste.Simulation.Gameplay.Enemies.Badeline.Chasers;

// ReSharper disable once CheckNamespace
namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        public bool GetChasePosition(float sceneTime, float timeAgo, out ChaserState chaseState)
        {
            return ChaseHistory.GetChasePosition(sceneTime, timeAgo, Dead, out chaseState);
        }
    }
}
