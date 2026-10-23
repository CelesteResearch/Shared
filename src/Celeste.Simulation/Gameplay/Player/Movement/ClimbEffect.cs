using System;
using System.Numerics;
using Celeste.Input;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Player.Movement
{
    public enum ClimbEffect
    {
        GrabRumble,
        GrabSurface,
        LetGo,
        ConveyorStart,
        ConveyorPosition,
        ConveyorStop,
        BoosterRumble,
        ClimbRumble,
        LedgeHop
    }
}
