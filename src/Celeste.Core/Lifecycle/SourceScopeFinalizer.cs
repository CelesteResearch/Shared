using System;

namespace Celeste.Core.Lifecycle
{
    public sealed class SourceScopeFinalizer : IDisposable
    {
        private Action onExit;

        public SourceScopeFinalizer(Action onExit)
        {
            this.onExit = onExit;
        }

        public void Dispose()
        {
            onExit();
        }
    }
}
