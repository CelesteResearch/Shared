using System;
using System.Collections;
using System.Collections.Generic;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Hazards.Lightning
{
    public interface ILightningRemovalRenderer
    {
        float Fade { get; set; }
        bool UpdateSeeds { get; set; }
        void StopAmbience();
    }
}
