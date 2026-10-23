namespace Celeste.Game.Execution.Areas
{
    public interface IOriginalAreaDataFactory
    {
        OriginalAreaData Create();
        OriginalAreaModeData CreateMode();

        OriginalCheckpointData CreateCheckpoint(string level, string name,
            global::Celeste.Simulation.Gameplay.Player.Inventory.RoomPlayerInventory? inventory = null,
            bool dreaming = false, global::Celeste.Simulation.Audio.RoomAudioState audioState = null);
    }
}
