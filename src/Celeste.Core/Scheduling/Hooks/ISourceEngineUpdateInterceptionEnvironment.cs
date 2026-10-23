using System;

namespace Celeste.Core.Scheduling.Hooks
{
    public interface ISourceEngineUpdateInterceptionEnvironment
    {
        void InvokeSourceEngineUpdate(Action original);
    }
}
