namespace Celeste.Core.Scheduling.Hooks
{
    public interface ISourceUpdateMethodHooksEnvironment
    {
        SourceEngineUpdateHooks SourceEngineUpdateHooks { get; }
        SourceSceneUpdateHooks SourceSceneUpdateHooks { get; }
    }
}
