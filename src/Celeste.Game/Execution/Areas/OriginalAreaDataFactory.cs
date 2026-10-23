using Celeste.Simulation.Audio;
using Celeste.Simulation.Gameplay.Player.Inventory;

namespace Celeste.Game.Execution.Areas
{
    public sealed class OriginalAreaDataFactory : IOriginalAreaDataFactory
    {
        public OriginalAreaData Create()
        {
            return new();
        }

        public OriginalAreaModeData CreateMode()
        {
            return new();
        }

        public OriginalCheckpointData CreateCheckpoint(string level, string name,
            RoomPlayerInventory? inventory = null,
            bool dreaming = false, RoomAudioState audioState = null)
        {
            return new(level, name, inventory, dreaming, audioState);
        }
    }
}
