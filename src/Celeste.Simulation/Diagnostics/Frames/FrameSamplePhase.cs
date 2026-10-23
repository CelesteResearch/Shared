namespace Celeste.Simulation.Diagnostics.Frames
{
    // Shared frame-sampling phase; neither engine owns the gameplay-state sample.
    public enum FrameSamplePhase : byte
    {
        AfterRoomTick = 1,
    }
}
