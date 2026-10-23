using System;

namespace Celeste.Everest.Modules.Updating
{
    internal sealed class RegistrationUndo : IDisposable
    {
        private Action unregister;

        public RegistrationUndo(Action unregister)
        {
            this.unregister = unregister;
        }

        public void Dispose()
        {
            var action = unregister;
            unregister = null;
            action?.Invoke();
        }
    }
}
