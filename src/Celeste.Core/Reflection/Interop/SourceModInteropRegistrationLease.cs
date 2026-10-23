using System;

namespace Celeste.Core.Reflection.Interop
{
    internal sealed class SourceModInteropRegistrationLease : IDisposable
    {
        private Action _unregister;
        private readonly Action _validateDisposal;

        internal SourceModInteropRegistrationLease(Action unregister, Action validateDisposal)
        {
            _unregister = unregister;
            _validateDisposal = validateDisposal;
        }

        public void Dispose()
        {
            var action = _unregister;
            if (action == null) return;
            _validateDisposal();
            _unregister = null;
            action();
        }
    }
}
