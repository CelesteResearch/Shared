using System;
using System.Collections;
using System.Numerics;
using Celeste.Simulation.Rendering;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Player.Intro
{
    public enum PlayerIntroType
    {
        Transition,
        Respawn,
        WalkInRight,
        WalkInLeft,
        Jump,
        WakeUp,
        Fall,
        TempleMirrorVoid,
        None,
        ThinkForABit
    }
}
