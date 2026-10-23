using Celeste.Simulation.Rendering;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation;

namespace Celeste.Game.Stories.CelestialResort
{
    public interface IOshiroClutterDoor
    {
        Vector2 Position { get; }
        bool IsLocked { get; }
        IEnumerator UnlockRoutine();
        void InstantUnlock();
    }
}
