using Celeste.Simulation.Audio;
using Celeste.Simulation.Gameplay.Player.Inventory;

namespace Celeste.Game.Execution.Areas
{
    public interface IOriginalAreaDataFactory
    {
        OriginalAreaData Create();
        OriginalAreaModeData CreateMode();

        OriginalCheckpointData CreateCheckpoint(string level, string name,
            RoomPlayerInventory? inventory = null,
            bool dreaming = false, RoomAudioState audioState = null);
    }
}
