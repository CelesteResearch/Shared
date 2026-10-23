using System;

namespace Celeste.Core.Lifecycle
{
    public sealed class SourceScopeFinalizer(Action onExit) : IDisposable
    {
        // ReSharper disable once ReplaceWithPrimaryConstructorParameter
        private readonly Action _onExit = onExit;


        public void Dispose()
        {
            _onExit();
        }
    }
}
