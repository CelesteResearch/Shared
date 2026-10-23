using System;
using System.Collections;
using System.Numerics;
using Celeste.Input;
using Celeste.Simulation.Rendering;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Player.Launch
{
    public interface ILaunchWorld
    {
        void MoveTowardsX(float target, float maximumMove);
        bool TryPickup();
    }
}
