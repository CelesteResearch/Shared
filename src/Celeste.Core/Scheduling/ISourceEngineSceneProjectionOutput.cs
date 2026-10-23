namespace Celeste.Core.Scheduling
{
    public interface ISourceEngineSceneProjectionOutput
    {
        void OnSceneTransition(ISourceSceneExecution previous, ISourceSceneExecution next);
    }
}
