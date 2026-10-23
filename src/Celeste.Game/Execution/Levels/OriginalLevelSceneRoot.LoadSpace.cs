using Celeste.Game.Entities.Environment.Space;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        private void AddSourceSpaceController()
            => Scheduler.QueueSourceEntity(new OriginalSpaceController(EngineContext));
    }
}
