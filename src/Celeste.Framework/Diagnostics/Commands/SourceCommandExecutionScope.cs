using System;
using Celeste.Core.Scheduling;

namespace Celeste.Framework.Diagnostics.Commands
{
    public readonly struct SourceCommandExecutionScope : IDisposable
    {
        [ThreadStatic] private static ISourceEngineContext currentEngine;

        private readonly ISourceEngineContext previousEngine;

// ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
        public static ISourceEngineContext CurrentEngine => currentEngine;

        public SourceCommandExecutionScope(ISourceEngineContext engine)
        {
            previousEngine = CurrentEngine;
            currentEngine = engine;
        }

        public void Dispose()
        {
            currentEngine = previousEngine;
        }
    }
}
