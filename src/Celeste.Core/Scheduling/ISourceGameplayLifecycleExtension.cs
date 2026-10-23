using System;

namespace Celeste.Core.Scheduling
{
    public interface ISourceGameplayLifecycleExtension
    {
        void InvokeMainMenuExit(Action original);
        void BeforeSaveAndQuit();
        void BeforeLevelUpdate();
    }
}
