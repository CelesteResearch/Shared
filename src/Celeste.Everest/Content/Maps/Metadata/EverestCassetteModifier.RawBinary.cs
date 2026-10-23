using System;
using System.Linq;
using Celeste.Formats.Map.Binary.Source;
using Celeste.Everest.Content.Maps.Binary;
using Celeste.Simulation.Gameplay.Player.Intro;
using Celeste.Simulation.Gameplay.Environment.Core;

namespace Celeste.Everest.Content.Maps.Metadata
{
    public sealed partial class EverestCassetteModifier
    {
        public EverestCassetteModifier()
        {
        }

        public EverestCassetteModifier(BinaryPackerElement meta)
        {
            Parse(meta);
        }

        public void Parse(BinaryPackerElement meta)
        {
            meta.AttrIfFloat("TempoMult", delegate(float v) { TempoMult = v; });
            meta.AttrIfInt("LeadBeats", delegate(int v) { LeadBeats = v; });
            meta.AttrIfInt("BeatsPerTick", delegate(int v) { BeatsPerTick = v; });
            meta.AttrIfInt("TicksPerSwap", delegate(int v) { TicksPerSwap = v; });
            meta.AttrIfInt("Blocks", delegate(int v) { Blocks = v; });
            meta.AttrIfInt("BeatsMax", delegate(int v) { BeatsMax = v; });
            meta.AttrIfInt("BeatIndexOffset", delegate(int v) { BeatIndexOffset = v; });
            meta.AttrIfBool("ActiveDuringTransitions", delegate(bool v) { ActiveDuringTransitions = v; });
            meta.AttrIfBool("OldBehavior", delegate(bool v) { OldBehavior = v; });
        }
    }
}
