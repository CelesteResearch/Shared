using System.Linq;
using Celeste.Everest.Content.Maps.Metadata;

namespace Celeste.Everest.Content.Maps.Yaml
{
    internal sealed class EverestModeMetaYaml
    {
        public string Inventory { get; set; }
        public string Path { get; set; }
        public string PoemID { get; set; }
        public string StartLevel { get; set; }
        public bool? IgnoreLevelAudioLayerData { get; set; }
        public bool? HeartIsEnd { get; set; }
        public bool? SeekerSlowdown { get; set; }
        public bool? TheoInBubble { get; set; }
        public bool? CoreModeIceTileOverlay { get; set; }
        public EverestModeAudioYaml AudioState { get; set; }
        public EverestCheckpointYaml[] Checkpoints { get; set; }

        public EverestModeMetadata Convert()
        {
            return new()
            {
                Inventory = Inventory, Path = Path, PoemID = PoemID, StartLevel = StartLevel,
                IgnoreLevelAudioLayerData = IgnoreLevelAudioLayerData, HeartIsEnd = HeartIsEnd,
                SeekerSlowdown = SeekerSlowdown, TheoInBubble = TheoInBubble,
                CoreModeIceTileOverlay = CoreModeIceTileOverlay,
                AudioState = AudioState == null
                    ? null
                    : new EverestAudioMetadata
                        { Music = AudioState.Music, Ambience = AudioState.Ambience },
                Checkpoints = Checkpoints?.Select(checkpoint => checkpoint.Convert()).ToArray(),
            };
        }
    }
}
