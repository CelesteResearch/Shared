using System;
using System.Numerics;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Player.Presentation.Sprites;
using Celeste.Game.Execution.Levels;

namespace Celeste.Game.Execution.LevelLoader
{
    public interface IOriginalLevelLoadOverridePolicy
    {
        RoomPlayerSession CreatePlayer(OriginalLevelSceneRoot level, Vector2 position, PlayerSpriteMode mode);
        bool SkipWipe(OriginalLevelSceneRoot level, Action onComplete, bool hiresSnow);
    }
}
