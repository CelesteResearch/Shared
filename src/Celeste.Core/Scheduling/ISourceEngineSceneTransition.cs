namespace Celeste.Core.Scheduling
{
    public interface ISourceEngineSceneTransition
    {
        void OnSceneTransition(ISourceSceneExecution previous, ISourceSceneExecution next);
    }
}
