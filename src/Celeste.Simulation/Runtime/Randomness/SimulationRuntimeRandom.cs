using System;

namespace Celeste.Simulation.Runtime.Randomness
{
    // Monocle.Calc.Random is process-owned and persists across scenes. Level.LoadLevel
    // temporarily pushes its room seed; it does not replace this default stream.
    public static class SimulationRuntimeRandom
    {
        public static readonly Random Default = new();
    }
}
