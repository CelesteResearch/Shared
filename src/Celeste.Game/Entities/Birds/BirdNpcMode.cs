using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation.Rendering;
using Celeste.Simulation;

namespace Celeste.Game.Entities.Birds
{
    public enum BirdNpcMode
    {
        ClimbingTutorial,
        DashingTutorial,
        DreamJumpTutorial,
        SuperWallJumpTutorial,
        HyperJumpTutorial,
        FlyAway,
        None,
        Sleeping,
        MoveToNodes,
        WaitForLightningOff
    }
}
