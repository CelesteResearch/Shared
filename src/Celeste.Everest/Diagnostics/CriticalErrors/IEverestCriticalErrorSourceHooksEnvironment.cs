using System;
using System.Runtime.ExceptionServices;

namespace Celeste.Everest.Diagnostics.CriticalErrors
{
    public interface IEverestCriticalErrorSourceHooksEnvironment
    {
        ExceptionDispatchInfo HandleSourceCriticalError(
            ExceptionDispatchInfo error,
            Func<ExceptionDispatchInfo, ExceptionDispatchInfo> original);
    }
}
