using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Celeste.Simulation
{
    public interface IOldSiteDreamBlock
    {
        IEnumerator Activate();
        void ActivateNoRoutine();
    }
}
