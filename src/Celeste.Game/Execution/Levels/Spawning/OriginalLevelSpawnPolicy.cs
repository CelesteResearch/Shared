using System.Numerics;

namespace Celeste.Game.Execution.Levels.Spawning
{
    public sealed class OriginalLevelSpawnPolicy : IOriginalLevelSpawnPolicy
    {
        public Vector2 GetDefaultSpawnPoint(OriginalLevelSceneRoot level) =>
            level.GetSpawnPoint(new Vector2(level.Bounds.Left, level.Bounds.Bottom));
    }
}
