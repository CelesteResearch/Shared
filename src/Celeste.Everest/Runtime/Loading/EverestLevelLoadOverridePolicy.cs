using System;
using System.Numerics;
using Celeste.Game.Execution.LevelLoader;
using Celeste.Game.Execution.Levels;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Player.Presentation.Sprites;

namespace Celeste.Everest.Runtime.Loading
{
    public sealed class EverestLevelLoadOverridePolicy : IOriginalLevelLoadOverridePolicy
    {
        public RoomPlayerSession CreatePlayer(OriginalLevelSceneRoot level, Vector2 position, PlayerSpriteMode mode)
        {
            return EverestLevelLoadOverrides.LoadNewPlayerForLevel(position, mode, level);
        }

        public bool SkipWipe(OriginalLevelSceneRoot level, Action onComplete, bool hiresSnow)
        {
            return EverestLevelLoadOverrides.SkipWipe(level, onComplete, hiresSnow);
        }
    }
}
