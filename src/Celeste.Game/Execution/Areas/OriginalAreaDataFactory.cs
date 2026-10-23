namespace Celeste.Game.Execution.Areas
{
    public sealed class OriginalAreaDataFactory : IOriginalAreaDataFactory
    {
        public OriginalAreaData Create() => new OriginalAreaData();
        public OriginalAreaModeData CreateMode() => new OriginalAreaModeData();

        public OriginalCheckpointData CreateCheckpoint(string level, string name,
            global::Celeste.Simulation.Gameplay.Player.Inventory.RoomPlayerInventory? inventory = null,
            bool dreaming = false, global::Celeste.Simulation.Audio.RoomAudioState audioState = null)
            => new OriginalCheckpointData(level, name, inventory, dreaming, audioState);
    }
}
