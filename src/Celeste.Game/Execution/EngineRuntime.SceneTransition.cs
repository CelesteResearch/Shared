using Celeste.Core.Framework.GarbageCollection;
using Celeste.Core.Scheduling;
using global::Celeste.Game.Execution.Engine;
using global::Celeste.Game.Execution;

namespace Celeste.Game.Execution
{
    public partial class EngineRuntime
    {
        public void DispatchSourceSceneTransition(ISourceSceneExecution previous, ISourceSceneExecution next)
            => OnSceneTransition(previous, next);

        protected virtual void OnSceneTransition(ISourceSceneExecution previous, ISourceSceneExecution next)
        {
            var environment = Process as ISourceGarbageCollectionEnvironment;
            if (environment != null)
            {
                var collectionPolicy = environment.GarbageCollectionPolicy;
                collectionPolicy.CollectOnSceneTransition();
            }
            else
            {
                SystemGarbageCollectionDevice.Instance.CollectOnSceneTransition();
            }

            Process.Effects.TimeRate = 1f;
            Process.Effects.DashAssistFreeze = false;
        }
    }
}
