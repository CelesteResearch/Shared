using Celeste.Game.Cheats;
using Celeste.Game.Execution.Areas;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        private bool ShouldCreateCassetteManager
        {
            get
            {
                if (((IOriginalAreaKeyEnvironment)EngineContext).AreaKeys.GetSessionArea(Session).Mode == 0)
                    return !Session.Cassette;
                return true;
            }
        }

        private void AddSourceUnlockEverything()
            => Scheduler.QueueSourceEntity(
                new OriginalUnlockEverythingThingy((IOriginalUnlockEverythingProcess)EngineContext));
    }
}
