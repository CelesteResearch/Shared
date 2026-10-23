namespace Celeste.Game.Execution.Engine
{
    public static class OriginalEngineTiming
    {
        // FNA TargetElapsedTime is 166667 TimeSpan ticks. Simulation receives
        // that rounded duration, while wall-clock pacing remains 60 Hz.
        public const float FixedDeltaTime = 166667f / 10000000f;
    }
}
