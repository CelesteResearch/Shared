using System;
using System.Numerics;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Player.Collision.Responses
{
    public enum PlayerSquishResult
    {
        Ducked,
        DuckedAtTarget,
        Wiggled,
        DeathRequested
    }
}
