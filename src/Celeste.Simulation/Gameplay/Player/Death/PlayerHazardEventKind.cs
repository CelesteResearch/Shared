using System;
using System.Numerics;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Player.Death
{
    public enum PlayerHazardEventKind
    {
        SpikeContact,
        DeathRequested,
        DeathSuppressed,
        Died
    }
}
