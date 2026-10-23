using System;

namespace Celeste.Core.Scheduling
{
    // Only native operations constrained to the host thread cross this boundary.
    // Content parsing and source loading policy stay on their original thread.
    public interface ISourceEngineMainThreadDispatcher
    {
        void Invoke(Action action);
        T Invoke<T>(Func<T> action);
    }
}
