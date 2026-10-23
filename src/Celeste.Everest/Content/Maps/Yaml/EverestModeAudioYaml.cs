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
    internal sealed class EverestModeAudioYaml
    {
        public string Music { get; set; }
        public string Ambience { get; set; }
    }
}
