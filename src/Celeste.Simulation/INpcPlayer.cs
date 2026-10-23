using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation.Rendering;

namespace Celeste.Simulation
{
    public interface INpcPlayer
    {
        Vector2 Position { get; }
        int State { get; set; }
        int Facing { get; set; }
        bool Locked { get; set; }
        IEnumerator DummyWalkToExact(int x);
    }
}
