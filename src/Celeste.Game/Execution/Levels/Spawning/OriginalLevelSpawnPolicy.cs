using System.Numerics;

namespace Celeste.Game.Execution.Levels.Spawning
{
    public sealed class OriginalLevelSpawnPolicy : IOriginalLevelSpawnPolicy
    {
        public Vector2 GetDefaultSpawnPoint(OriginalLevelSceneRoot level)
        {
            return level.GetSpawnPoint(new(level.Bounds.Left, level.Bounds.Bottom));
        }
    }
}
