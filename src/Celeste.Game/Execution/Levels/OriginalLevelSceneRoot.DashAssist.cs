using Celeste.Game.Execution.Engine.Update;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot : IOriginalEngineDashAssistScene
    {
        public void UpdateFirstTrackedDashAssist()
            => OriginalEngineDashAssistSceneBody.UpdateFirstTrackedDashAssist(Scheduler, EngineContext);

        public void CommitEntityLists()
            => OriginalEngineDashAssistSceneBody.CommitEntityLists(Scheduler);
    }
}
