using System;
using System.Linq;
using System.Numerics;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Camera
{
    public enum RoomCameraLock
    {
        None,
        BoostSequence,
        FinalBoss,
        FinalBossNoY,
        Lava
    }
}
