using System;

namespace Celeste.Core.Reflection.Interop
{
    internal sealed class SourceModInteropRegistrationLease : IDisposable
    {
        private Action unregister;
        private readonly Action validateDisposal;

        internal SourceModInteropRegistrationLease(Action unregister, Action validateDisposal)
        {
            this.unregister = unregister;
            this.validateDisposal = validateDisposal;
        }

        public void Dispose()
        {
            var action = unregister;
            if (action == null) return;
            validateDisposal();
            unregister = null;
            action();
        }
    }
}
