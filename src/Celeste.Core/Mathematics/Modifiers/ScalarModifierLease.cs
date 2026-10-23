using System;

namespace Celeste.Core.Mathematics.Modifiers
{
    public sealed class ScalarModifierLease : IDisposable
    {
        private ScalarModifierChain _owner;
        internal Func<float, float> Modifier;

        internal ScalarModifierLease(ScalarModifierChain owner, Func<float, float> modifier)
        {
            _owner = owner;
            Modifier = modifier;
        }

        public void Dispose()
        {
            if (_owner == null) return;
            _owner.Remove(this);
            Modifier = null;
            _owner = null;
        }
    }
}
