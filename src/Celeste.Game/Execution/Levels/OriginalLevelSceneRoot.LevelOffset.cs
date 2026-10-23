using System.Numerics;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        public Vector2 LevelOffset => new Vector2(Bounds.Left, Bounds.Top);
    }
}
