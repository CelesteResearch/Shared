namespace Celeste.Simulation.Gameplay.Platforms.Cassette
{
    public interface ICassetteRhythmOptions
    {
        float TempoMult { get; }
        int LeadBeats { get; }
        int BeatsPerTick { get; }
        int TicksPerSwap { get; }
        int Blocks { get; }
        int BeatsMax { get; }
        int BeatIndexOffset { get; }
        bool ActiveDuringTransitions { get; }
        bool OldBehavior { get; }
    }
}
