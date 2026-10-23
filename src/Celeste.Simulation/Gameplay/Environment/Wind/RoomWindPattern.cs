using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Environment.Wind
{
    public enum RoomWindPattern
    {
        None,
        Left,
        Right,
        LeftStrong,
        RightStrong,
        LeftOnOff,
        RightOnOff,
        LeftOnOffFast,
        RightOnOffFast,
        Alternating,
        LeftGemsOnly,
        RightCrazy,
        Down,
        Up,
        Space
    }
}
