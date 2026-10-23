using System;
using Celeste.Scene.Following;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation.Rendering;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Collectibles.Strawberry
{
    public interface IStrawberrySeedPlayer
    {
        LeaderState Leader { get; }
        bool LoseShards { get; }
        Vector2 Speed { get; }
    }
}
