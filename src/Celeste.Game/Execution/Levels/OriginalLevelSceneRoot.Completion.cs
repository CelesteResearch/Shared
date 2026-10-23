using Celeste.Game.Execution.Levels.Completion;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        public bool Completed;

        public void RegisterAreaComplete()
        {
            ((IOriginalLevelCompletionPolicyEnvironment)EngineContext)
                .LevelCompletion.RegisterAreaComplete(this);
        }
    }
}
