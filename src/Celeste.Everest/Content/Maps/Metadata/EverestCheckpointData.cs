using Celeste.Game.Execution.Areas;
using Celeste.Simulation.Audio;
using Celeste.Simulation.Gameplay.Player.Inventory;

namespace Celeste.Everest.Content.Maps.Metadata
{
    public sealed class EverestCheckpointData : OriginalCheckpointData
    {
        public OriginalAreaKey Area;

        // ReSharper disable once ConvertToPrimaryConstructor
        public EverestCheckpointData(string level, string name,
            RoomPlayerInventory? inventory = null,
            bool dreaming = false, RoomAudioState audioState = null) : base(level,
            name,
            inventory, dreaming, audioState)
        {
        }
    }
}
