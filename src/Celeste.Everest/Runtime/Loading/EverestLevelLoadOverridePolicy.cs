using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Player.Presentation.Sprites;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.LevelLoader;

namespace Celeste.Everest.Runtime.Loading
{
    public sealed class EverestLevelLoadOverridePolicy : IOriginalLevelLoadOverridePolicy
    {
        public RoomPlayerSession CreatePlayer(OriginalLevelSceneRoot level, Vector2 position, PlayerSpriteMode mode)
            => EverestLevelLoadOverrides.LoadNewPlayerForLevel(position, mode, level);

        public bool SkipWipe(OriginalLevelSceneRoot level, Action onComplete, bool hiresSnow)
            => EverestLevelLoadOverrides.SkipWipe(level, onComplete, hiresSnow);
    }
}
