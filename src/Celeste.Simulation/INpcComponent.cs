using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation.Rendering;

namespace Celeste.Simulation
{
    public interface INpcComponent
    {
        bool Active { get; }
        void Update(float dt, float rawDt);
    }
}
