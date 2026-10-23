using System;

namespace Celeste.Everest.Modules.Updating
{
    internal sealed class EverestLoadModFinalizer : IDisposable
    {
        private readonly Action action;
        public EverestLoadModFinalizer(Action action) => this.action = action;
        public void Dispose() => action();
    }
}
