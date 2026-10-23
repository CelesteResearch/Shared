using System;
using System.Collections.Generic;

namespace Celeste.Scene.Components.Oscillation
{
    // The source process owns this cache; it participates in the same state snapshot.
    public sealed class WigglerComponentPool
    {
        internal readonly global::Celeste.Core.Scheduling.ISourceEngineContext EngineContext;

        public WigglerComponentPool(global::Celeste.Core.Scheduling.ISourceEngineContext engine)
        {
            EngineContext = engine;
        }

        private Stack<WigglerComponent> cache = new Stack<WigglerComponent>();

        public WigglerComponent Create(float duration, float frequency, Action<float> onChange = null,
            bool start = false, bool removeSelfOnFinish = false)
        {
            WigglerComponent wiggler = cache.Count == 0 ? new WigglerComponent(this) : cache.Pop();
            wiggler.Init(duration, frequency, onChange, start, removeSelfOnFinish);
            return wiggler;
        }

        internal void Return(WigglerComponent component) => cache.Push(component);
    }
}
