using Celeste.Core.Display;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation.Presentation.Particles.Definitions;

namespace Celeste.Game.Presentation.Particles.Definitions.ForsakenCitySatellite
{
    public sealed class ForsakenCitySatelliteParticleDefinitions
    {
        public readonly Dictionary<string, ParticleTypePresentation> Particles = new();

        public readonly Dictionary<string, global::Celeste.Core.Display.PackedColor> Colors = new()
        {
            { "U", new global::Celeste.Core.Display.PackedColor((float)240 / 255f, 240 / 255f, 240 / 255f, 1) },
            { "L", new global::Celeste.Core.Display.PackedColor((float)145 / 255f, 113 / 255f, 242 / 255f, 1) },
            { "DR", new global::Celeste.Core.Display.PackedColor((float)10 / 255f, 68 / 255f, 224 / 255f, 1) },
            { "UR", new global::Celeste.Core.Display.PackedColor((float)179 / 255f, 45 / 255f, 0, 1) },
            { "UL", new global::Celeste.Core.Display.PackedColor((float)1, 205 / 255f, 55 / 255f, 1) }
        };
    }
}
