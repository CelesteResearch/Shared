using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation.Rendering;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Platforms.FinalBossMovingBlock
{
    public interface IFinalBossMovingBlock
    {
        float X { get; }
        int BossNodeIndex { get; }
        void StartMoving(float delay);
        void Destroy(float delay);
    }
}
