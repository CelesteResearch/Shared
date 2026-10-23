using Celeste.Simulation.Audio;
using System;
using System.Globalization;
using System.Linq;
using System.Numerics;
using Celeste.Simulation;
using Celeste.Simulation.Rendering;
using YamlDotNet.Serialization;
using Celeste.Everest;

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
        public global::Celeste.Everest.Content.Maps.Yaml.EverestModeAudioYaml AudioState { get; set; }
        public global::Celeste.Everest.Content.Maps.Yaml.EverestCheckpointYaml[] Checkpoints { get; set; }

        public global::Celeste.Everest.Content.Maps.Metadata.EverestModeMetadata Convert() =>
            new global::Celeste.Everest.Content.Maps.Metadata.EverestModeMetadata
            {
                Inventory = Inventory, Path = Path, PoemID = PoemID, StartLevel = StartLevel,
                IgnoreLevelAudioLayerData = IgnoreLevelAudioLayerData, HeartIsEnd = HeartIsEnd,
                SeekerSlowdown = SeekerSlowdown, TheoInBubble = TheoInBubble,
                CoreModeIceTileOverlay = CoreModeIceTileOverlay,
                AudioState = AudioState == null
                    ? null
                    : new global::Celeste.Everest.Content.Maps.Metadata.EverestAudioMetadata
                        { Music = AudioState.Music, Ambience = AudioState.Ambience },
                Checkpoints = Checkpoints?.Select(checkpoint => checkpoint.Convert()).ToArray()
            };
    }
}
