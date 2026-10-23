using System;
using System.Numerics;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Platforms.Moving
{
    public interface IRotatingPlatformWorld
    {
        void MoveTo(Vector2 position);
    }
}
