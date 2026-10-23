using System;
using System.Numerics;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Player.Presentation.Sprites;
using Celeste.Game.Execution.Levels;

namespace Celeste.Game.Execution.LevelLoader
{
    public interface IOriginalLevelLoadOverrideEnvironment
    {
        IOriginalLevelLoadOverridePolicy LevelLoadOverrides { get; }
    }
}
