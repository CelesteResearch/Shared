using System;

namespace Celeste.Core.Scheduling.Hooks
{
    public sealed class SourceEngineUpdateHooks
    {
        public event Action AfterUpdate;

        public void InvokeAfterUpdate()
        {
            AfterUpdate?.Invoke();
        }
    }
}
