using Celeste.Game.Execution.Areas;
using Celeste.Simulation.Gameplay.Environment.Core;

namespace Celeste.Everest.Content.Maps.Metadata
{
    public partial class EverestCheckpointMetadata
    {
        public string Level { get; set; }
        public string Name { get; set; }
        public bool Dreaming { get; set; }
        public string Inventory { get; set; }
        public EverestAudioMetadata AudioState { get; set; }
        public string[] Flags { get; set; }
        public RoomCoreMode? CoreMode { get; set; }

        public OriginalCheckpointData Convert()
        {
            return new EverestCheckpointData(
                    Level, Name, EverestMapMetadata.GetInventory(Inventory), Dreaming, AudioState?.Convert())
                { Flags = /* ReSharper disable once UseCollectionExpression */ new(Flags ?? []), CoreMode = CoreMode };
        }
    }
}
