using System;
using Celeste.Everest.Content.Maps.Metadata;
using Celeste.Simulation.Gameplay.Environment.Core;

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
        public EverestModeAudioYaml AudioState { get; set; }

        public EverestCheckpointMetadata Convert()
        {
            return new()
            {
                Level = Level, Name = Name, Dreaming = Dreaming, Flags = Flags,
                Inventory = Inventory,
                CoreMode = string.IsNullOrEmpty(CoreMode)
                    ? null
                    : (RoomCoreMode?)Enum.Parse(
                        typeof(RoomCoreMode), CoreMode, true),
                AudioState = AudioState == null
                    ? null
                    : new EverestAudioMetadata
                        { Music = AudioState.Music, Ambience = AudioState.Ambience },
            };
        }
    }
}
