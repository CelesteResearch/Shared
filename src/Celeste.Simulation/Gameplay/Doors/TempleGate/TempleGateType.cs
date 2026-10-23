using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Doors.TempleGate
{
    public enum TempleGateType
    {
        NearestSwitch,
        CloseBehindPlayer,
        CloseBehindPlayerAlways,
        HoldingTheo,
        TouchSwitches,
        CloseBehindPlayerAndTheo
    }
}
