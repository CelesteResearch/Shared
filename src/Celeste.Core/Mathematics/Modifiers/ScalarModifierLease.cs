using System;

namespace Celeste.Core.Mathematics.Modifiers
{
    public sealed class ScalarModifierLease : IDisposable
    {
        private ScalarModifierChain owner;
        internal Func<float, float> Modifier;

        internal ScalarModifierLease(ScalarModifierChain owner, Func<float, float> modifier)
        {
            this.owner = owner;
            Modifier = modifier;
        }

        public void Dispose()
        {
            if (owner == null) return;
            owner.Remove(this);
            Modifier = null;
            owner = null;
        }
    }
}
