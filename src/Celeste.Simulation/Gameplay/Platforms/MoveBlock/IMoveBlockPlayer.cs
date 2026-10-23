using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation.Rendering;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Platforms.MoveBlock
{
    public interface IMoveBlockPlayer
    {
        Vector2 Position { get; }
        bool CollideSolidAt(Vector2 position);
    }
}
