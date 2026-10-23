namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        public bool Completed;

        public void RegisterAreaComplete()
            => ((Completion.IOriginalLevelCompletionPolicyEnvironment)EngineContext)
                .LevelCompletion.RegisterAreaComplete(this);
    }
}
