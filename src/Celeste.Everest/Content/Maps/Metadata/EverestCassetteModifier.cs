namespace Celeste.Everest.Content.Maps.Metadata
{
    public sealed partial class EverestCassetteModifier
    {
        public float TempoMult { get; set; } = 1f;
        public int LeadBeats { get; set; } = 16;
        public int BeatsPerTick { get; set; } = 4;
        public int TicksPerSwap { get; set; } = 2;
        public int Blocks { get; set; } = 2;
        public int BeatsMax { get; set; } = 256;
        public int BeatIndexOffset { get; set; }
        public bool ActiveDuringTransitions { get; set; }
        public bool OldBehavior { get; set; }
    }
}
