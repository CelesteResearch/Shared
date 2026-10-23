using Celeste.Core.Scheduling;

namespace Celeste.Game.Execution.Engine
{
    public interface IOriginalEngineSceneTransitionEnvironment
    {
        void AfterSourceSceneTransition(ISourceSceneExecution previous, ISourceSceneExecution next);
    }
}
