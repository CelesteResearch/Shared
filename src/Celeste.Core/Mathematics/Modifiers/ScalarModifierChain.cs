using System;
using System.Collections.Generic;

namespace Celeste.Core.Mathematics.Modifiers
{
    // The simulation owner mutates this chain between evaluations, on its execution thread.
    public sealed class ScalarModifierChain
    {
        private readonly List<ScalarModifierLease> modifiers = new List<ScalarModifierLease>();

        public ScalarModifierLease Add(Func<float, float> modifier)
        {
            var lease = new ScalarModifierLease(this, modifier);
            modifiers.Add(lease);
            return lease;
        }

        internal void Remove(ScalarModifierLease lease) => modifiers.Remove(lease);

        public float Evaluate(float value)
        {
            for (int i = 0; i < modifiers.Count; i++) value = modifiers[i].Modifier(value);
            return value;
        }
    }
}
