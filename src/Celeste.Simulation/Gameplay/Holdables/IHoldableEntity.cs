using Celeste.Physics.Collision;
using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Holdables
{
    public interface IHoldableEntity
    {
        PixelActor Body { get; }
        bool Collidable { get; }
        bool Visible { get; set; }
        int Depth { get; set; }
        bool ScenePresent { get; }
    }
}
