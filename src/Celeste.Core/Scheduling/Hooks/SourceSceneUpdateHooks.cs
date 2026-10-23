using System;

namespace Celeste.Core.Scheduling.Hooks
{
    public sealed class SourceSceneUpdateHooks
    {
        public event Action<ISourceSceneExecution> AfterUpdate;

        public void InvokeAfterUpdate(ISourceSceneExecution scene)
        {
            AfterUpdate?.Invoke(scene);
        }
    }
}
