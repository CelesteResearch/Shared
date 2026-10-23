using System;
using Celeste.Scene.Following;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation.Rendering;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Collectibles.Strawberry
{
    public interface IStrawberryPlayer : IFollowerEntity
    {
        LeaderState Leader { get; }
        bool InScene { get; }
        bool StrawberriesBlocked { get; }
        bool OnSafeGround { get; }
        int State { get; }
        bool InGoldenCollectTrigger { get; }
        int StrawberryCollectIndex { get; set; }
        float StrawberryCollectResetTimer { get; set; }
    }
}
