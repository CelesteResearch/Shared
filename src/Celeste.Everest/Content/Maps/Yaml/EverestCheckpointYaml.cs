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
    internal sealed class EverestCheckpointYaml
    {
        public string Level { get; set; }
        public string Name { get; set; }
        public bool Dreaming { get; set; }
        public string Inventory { get; set; }
        public string CoreMode { get; set; }
        public string[] Flags { get; set; }
        public global::Celeste.Everest.Content.Maps.Yaml.EverestModeAudioYaml AudioState { get; set; }

        public global::Celeste.Everest.Content.Maps.Metadata.EverestCheckpointMetadata Convert() =>
            new global::Celeste.Everest.Content.Maps.Metadata.EverestCheckpointMetadata
            {
                Level = Level, Name = Name, Dreaming = Dreaming, Flags = Flags,
                Inventory = Inventory,
                CoreMode = string.IsNullOrEmpty(CoreMode)
                    ? null
                    : (global::Celeste.Simulation.Gameplay.Environment.Core.RoomCoreMode?)Enum.Parse(
                        typeof(global::Celeste.Simulation.Gameplay.Environment.Core.RoomCoreMode), CoreMode, true),
                AudioState = AudioState == null
                    ? null
                    : new global::Celeste.Everest.Content.Maps.Metadata.EverestAudioMetadata
                        { Music = AudioState.Music, Ambience = AudioState.Ambience }
            };
    }
}
