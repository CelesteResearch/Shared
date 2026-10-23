using System;
using System.Numerics;
using Celeste.Game.Execution.Levels;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Player.Presentation.Sprites;

namespace Celeste.Game.Execution.LevelLoader
{
    public sealed class OriginalLevelLoadOverridePolicy : IOriginalLevelLoadOverridePolicy
    {
        public RoomPlayerSession CreatePlayer(OriginalLevelSceneRoot level, Vector2 position, PlayerSpriteMode mode)
        {
            return level.CreateOriginalPlayer(position, mode);
        }

        public bool SkipWipe(OriginalLevelSceneRoot level, Action onComplete, bool hiresSnow)
        {
            return false;
        }
    }
}
