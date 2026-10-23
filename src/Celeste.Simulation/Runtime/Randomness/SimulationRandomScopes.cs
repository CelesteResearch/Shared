using System;
using System.Numerics;

namespace Celeste.Simulation.Runtime.Randomness
{
    public static class SimulationRandomScopes
    {
        // Optional equivalent of Calc.PushRandom around debris Init/BlastFrom.
        // The caller owns the random provider; ordinary simulation leaves this unset.
        public static Func<Vector2, IDisposable> Debris;
    }
}
