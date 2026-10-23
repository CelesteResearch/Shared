using Celeste.Game.Execution.Levels;

namespace Celeste.Game.Cheats
{
    public interface IOriginalUnlockEverythingPolicy
    {
        void UnlockEverything(OriginalLevelSceneRoot level, IOriginalUnlockEverythingProcess engine);
    }
}
