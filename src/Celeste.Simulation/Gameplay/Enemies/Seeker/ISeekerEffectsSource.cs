using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Enemies.Seeker
{
    public interface ISeekerEffectsSource
    {
        Vector2 Center { get; }
        bool Regenerating { get; }
        bool Attacking { get; }
    }
}
