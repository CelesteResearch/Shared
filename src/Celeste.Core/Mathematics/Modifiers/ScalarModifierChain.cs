using System;
using System.Collections.Generic;

namespace Celeste.Core.Mathematics.Modifiers
{
    // The simulation owner mutates this chain between evaluations, on its execution thread.
    public sealed class ScalarModifierChain
    {
        private readonly List<ScalarModifierLease> _modifiers = [];

        public ScalarModifierLease Add(Func<float, float> modifier)
        {
            var lease = new ScalarModifierLease(this, modifier);
            _modifiers.Add(lease);
            return lease;
        }

        internal void Remove(ScalarModifierLease lease)
        {
            _modifiers.Remove(lease);
        }

        public float Evaluate(float value)
        {
            for (var i = 0; i < _modifiers.Count; i++) value = _modifiers[i].Modifier(value);
            return value;
        }
    }
}
