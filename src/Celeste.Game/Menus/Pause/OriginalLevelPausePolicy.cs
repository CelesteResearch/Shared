using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Levels;

namespace Celeste.Game.Menus.Pause
{
    public sealed class OriginalLevelPausePolicy : IOriginalLevelPausePolicy
    {
        public bool IsPauseBlockedBySaving(bool saving) => saving;

        public void Pause(OriginalLevelSceneRoot level, int startIndex, bool minimal, bool quickReset)
            => level.PauseOriginalGame(startIndex, minimal, quickReset);

        public ReturnMapHintPresentation CreateReturnMapHint(ISourceEngineContext engine)
            => new ReturnMapHintPresentation(engine);
    }
}
