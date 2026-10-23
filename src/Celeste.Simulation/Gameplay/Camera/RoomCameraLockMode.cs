using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Camera
{
    public enum RoomCameraLockMode
    {
        None,
        BoostSequence,
        FinalBoss,
        FinalBossNoY,
        Lava
    }
}
