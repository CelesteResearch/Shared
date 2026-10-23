using System;
using System.Collections.Generic;
using Celeste.Core.Scheduling;

namespace Celeste.Scene.Components.Oscillation
{
    // The source process owns this cache; it participates in the same state snapshot.
    public sealed class WigglerComponentPool
    {
        internal readonly ISourceEngineContext EngineContext;

        public WigglerComponentPool(ISourceEngineContext engine)
        {
            EngineContext = engine;
        }

        private readonly Stack<WigglerComponent> cache = new();

        public WigglerComponent Create(float duration, float frequency, Action<float> onChange = null,
            bool start = false, bool removeSelfOnFinish = false)
        {
            var wiggler = cache.Count == 0 ? new(this) : cache.Pop();
            wiggler.Init(duration, frequency, onChange, start, removeSelfOnFinish);
            return wiggler;
        }

        internal void Return(WigglerComponent component)
        {
            cache.Push(component);
        }
    }
}
