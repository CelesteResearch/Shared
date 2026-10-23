using System;
using System.Collections.Generic;

namespace Celeste.Core.Components.Animation
{
    // A single original Engine process owns this cache across its scene transitions.
    public sealed class SourceTweenPool
    {
        public Celeste.Core.Scheduling.ISourceEngineContext EngineContext { get; }
        private readonly Func<ulong> frameCounter;
        public Celeste.Core.Mathematics.Extrema.ISourceExtremaArithmetic ExtremaArithmetic { get; }
        private readonly List<SourceTweenState> cached = new List<SourceTweenState>();

        public SourceTweenPool(Celeste.Core.Scheduling.ISourceEngineContext engine,
            Func<ulong> actualEngineFrameCounter,
            Celeste.Core.Mathematics.Extrema.ISourceExtremaArithmetic actualRuntimeArithmetic)
        {
            EngineContext = engine;
            ExtremaArithmetic = actualRuntimeArithmetic ??
                                throw new ArgumentNullException(nameof(actualRuntimeArithmetic));
            frameCounter = actualEngineFrameCounter ??
                           throw new ArgumentNullException(nameof(actualEngineFrameCounter));
        }

        public SourceTweenPoolMemento CaptureMemento()
            => new SourceTweenPoolMemento(cached.ToArray());

        public void RestoreMemento(SourceTweenPoolMemento memento)
        {
            if (memento == null) throw new ArgumentNullException(nameof(memento));
            if (memento.CachedTweens == null)
                throw new ArgumentException("Tween cache snapshot has no logical array.", nameof(memento));
            foreach (var tween in memento.CachedTweens)
                if (tween == null || !ReferenceEquals(tween.Pool, this))
                    throw new ArgumentException("Tween snapshot must remap its engine pool before restoration.",
                        nameof(memento));
            cached.Clear();
            cached.AddRange(memento.CachedTweens);
        }

        internal SourceTweenState Acquire()
        {
            foreach (var item in cached)
            {
                if (frameCounter() > item.CachedFrame + 3)
                {
                    cached.Remove(item);
                    return item;
                }
            }

            return new SourceTweenState(this);
        }

        internal void Cache(SourceTweenState tween)
        {
            cached.Add(tween);
            tween.CachedFrame = frameCounter();
        }
    }
}
