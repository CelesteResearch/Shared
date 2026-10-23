using System;
using System.Collections;
using System.Collections.Generic;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Characters.Birds
{
    public interface ILightningRemovalBird
    {
        bool LightningRemoved { get; set; }
    }
}
