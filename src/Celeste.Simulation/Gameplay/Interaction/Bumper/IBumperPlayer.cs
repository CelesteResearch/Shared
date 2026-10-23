using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Celeste.Simulation.Rendering;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Interaction.Bumper
{
    public interface IBumperPlayer
    {
        Vector2 Center { get; }
        global::Celeste.Core.Geometry.Bounds? ColliderBounds { get; }
        void Die(Vector2 direction);
        Vector2 ExplodeLaunch(Vector2 from, bool snapUp);
    }
}
