using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Randomness;

namespace Celeste.Simulation.Presentation.Barriers
{
    public interface IBarrierParticleMotionState
    {
        List<Vector2> Particles { get; }
        float[] Speeds { get; }
        float Width { get; }
        float Height { get; }
        float DeltaTime { get; }
        ISourceRandom Random { get; }
    }
}
