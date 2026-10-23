using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Celeste.Simulation
{
    public interface IRoomTransitionSound
    {
        bool DisposeOnTransition { get; }
        void Stop();
    }
}
