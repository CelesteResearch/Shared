using System.Collections.Generic;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Platforms.Cassette
{
    public sealed class CassetteRhythmOptions
    {
        public float TempoMult = 1f;
        public int LeadBeats = 16, BeatsPerTick = 4, TicksPerSwap = 2, Blocks = 2, BeatsMax = 256, BeatIndexOffset;
        public bool ActiveDuringTransitions, OldBehavior;
    }
}
