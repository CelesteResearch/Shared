using System.Numerics;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        public Vector2 GetSpawnPoint(Vector2 from) => Session.GetSpawnPoint(from);
    }
}
