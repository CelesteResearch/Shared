using System;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using Celeste.Simulation.Presentation.Particles.Definitions;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;

namespace Celeste.Game.Presentation.Particles
{
    public interface IOriginalDustBurstEnvironment
    {
        OriginalDustBurstRuntimeProfile DustBurstProfile { get; }
    }
}
