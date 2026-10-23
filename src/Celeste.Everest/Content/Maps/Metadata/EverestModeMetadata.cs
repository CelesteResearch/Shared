using Celeste.Everest.Content.Maps.Registry;
using Celeste.Game.Execution.Areas;
using Celeste.Simulation.Audio;
using Celeste.Simulation.Gameplay.Player.Inventory;

namespace Celeste.Everest.Content.Maps.Metadata
{
    public partial class EverestModeMetadata
    {
        public EverestAudioMetadata AudioState { get; set; }
        public EverestCheckpointMetadata[] Checkpoints { get; set; }
        public bool? IgnoreLevelAudioLayerData { get; set; }
        public string Inventory { get; set; }
        public string Path { get; set; }

        public string PoemID { get; set; }
        public string StartLevel { get; set; }
        public bool? HeartIsEnd { get; set; }
        public bool? SeekerSlowdown { get; set; }
        public bool? TheoInBubble { get; set; }
        public bool? CoreModeIceTileOverlay { get; set; }

        public OriginalAreaModeData Convert()
        {
            return new EverestAreaModeData
            {
                AudioState = AudioState?.Convert() ??
                             new RoomAudioState("event:/music/lvl1/main", "event:/env/amb/01_main"),
                Checkpoints = EverestMapMetadata.Convert(Checkpoints),
                IgnoreLevelAudioLayerData = IgnoreLevelAudioLayerData == true,
                Inventory = EverestMapMetadata.GetInventory(Inventory) ?? RoomPlayerInventory.Default,
                Path = Path, PoemID = PoemID,
            };
        }
    }
}
