using Celeste.Game.Execution.Areas;

namespace Celeste.Everest.Content.Maps.Metadata
{
    public sealed class EverestCheckpointData : OriginalCheckpointData
    {
        public OriginalAreaKey Area;

        public EverestCheckpointData(string level, string name,
            global::Celeste.Simulation.Gameplay.Player.Inventory.RoomPlayerInventory? inventory = null,
            bool dreaming = false, global::Celeste.Simulation.Audio.RoomAudioState audioState = null) : base(level,
            name,
            inventory, dreaming, audioState)
        {
        }
    }
}
