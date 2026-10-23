using System;
using System.Collections;
using System.Collections.Generic;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Hazards.Lightning
{
    public interface ILightningRemovalBlock
    {
        global::Celeste.Core.Geometry.Bounds Bounds { get; }
        bool Disappearing { get; set; }
        void Shatter();
        void RemoveSelf();
    }
}
