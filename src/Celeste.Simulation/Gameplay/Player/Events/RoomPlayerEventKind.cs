using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Celeste.Input;
using Celeste.Simulation.Rendering;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Player.Events
{
    public enum RoomPlayerEventKind
    {
        Sound,
        Particles,
        Rumble,
        Dash,
        Climb,
        Collision,
        WaterRipple,
        Sweat,
        SpeedRing,
        Jump,
        SkidDust,
        Death,
        Shake,
        Displacement,
        Reload
    }
}
