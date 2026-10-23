using System;
using System.Collections;
using System.Numerics;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Hazards.Lightning
{
    public interface ILightningPlayer
    {
        float X { get; }
        void Die(Vector2 direction);
    }
}
