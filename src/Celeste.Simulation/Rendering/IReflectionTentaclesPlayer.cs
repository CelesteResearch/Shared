using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Celeste.Simulation.Rendering
{
    public interface IReflectionTentaclesPlayer
    {
        Vector2 Position { get; }
        Vector2 Center { get; }
    }
}
