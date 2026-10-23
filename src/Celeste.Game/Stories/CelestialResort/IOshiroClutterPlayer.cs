using Celeste.Simulation.Rendering;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation;

namespace Celeste.Game.Stories.CelestialResort
{
    public interface IOshiroClutterPlayer : INpcPlayer
    {
        bool Dead { get; }
        Vector2 Center { get; }
    }
}
