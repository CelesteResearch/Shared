using System.Numerics;

namespace Celeste.Game.Execution.Levels.Spawning
{
    public interface IOriginalLevelSpawnPolicy
    {
        Vector2 GetDefaultSpawnPoint(OriginalLevelSceneRoot level);
    }
}
