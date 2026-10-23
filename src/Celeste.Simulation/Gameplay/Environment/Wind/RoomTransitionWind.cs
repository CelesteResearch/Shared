using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Environment.Wind
{
    public readonly struct RoomTransitionWind
    {
        public readonly object Entity;
        public readonly int Pattern;

        public RoomTransitionWind(object entity, int pattern)
        {
            Entity = entity;
            Pattern = pattern;
        }
    }
}
