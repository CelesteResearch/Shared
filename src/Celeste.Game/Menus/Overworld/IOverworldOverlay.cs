using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation.Rendering;
using Celeste.Simulation;

namespace Celeste.Game.Menus.Overworld
{
    public interface IOverworldOverlay
    {
        bool XboxOverlay { get; }
        void Update();
    }
}
