using Celeste.Simulation.Audio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Celeste.Simulation;
using Celeste.Everest;

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

        public global::Celeste.Game.Execution.Areas.OriginalAreaModeData Convert() =>
            new global::Celeste.Everest.Content.Maps.Registry.EverestAreaModeData
            {
                AudioState = AudioState?.Convert() ??
                             new RoomAudioState("event:/music/lvl1/main", "event:/env/amb/01_main"),
                Checkpoints = EverestMapMetadata.Convert(Checkpoints),
                IgnoreLevelAudioLayerData = IgnoreLevelAudioLayerData == true,
                Inventory = EverestMapMetadata.GetInventory(Inventory) ?? global::Celeste.Simulation.Gameplay.Player
                    .Inventory.RoomPlayerInventory.Default,
                Path = Path, PoemID = PoemID
            };
    }
}
