using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation.Rendering;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Doors.Oshiro
{
    public interface IMrOshiroDoorWorld
    {
        Vector2 Position { get; }
        bool GetFlag(string flag);
        void PlaySound(string name, Vector2 position);
        void RumbleMediumMedium();
    }
}
