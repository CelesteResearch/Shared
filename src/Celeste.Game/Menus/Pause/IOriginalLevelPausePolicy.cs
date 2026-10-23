using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Levels;

namespace Celeste.Game.Menus.Pause
{
    public interface IOriginalLevelPausePolicy
    {
        bool IsPauseBlockedBySaving(bool saving);
        void Pause(OriginalLevelSceneRoot level, int startIndex, bool minimal, bool quickReset);
        ReturnMapHintPresentation CreateReturnMapHint(ISourceEngineContext engine);
    }
}
