using System;
using System.Collections.Generic;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Scheduling;

namespace Celeste.Core.Components.Animation
{
    // A single original Engine process owns this cache across its scene transitions.
    public sealed class SourceTweenPool
    {
        public ISourceEngineContext EngineContext { get; }

        private readonly Func<ulong> _frameCounter;
        public ISourceExtremaArithmetic ExtremaArithmetic { get; }

        private readonly List<SourceTweenState> _cached = [];

        // ReSharper disable once ConvertToPrimaryConstructor
        public SourceTweenPool(ISourceEngineContext engine, Func<ulong> actualEngineFrameCounter,
            ISourceExtremaArithmetic actualRuntimeArithmetic)
        {
            EngineContext = engine;
            ExtremaArithmetic = actualRuntimeArithmetic ??
                                throw new ArgumentNullException(nameof(actualRuntimeArithmetic));
            _frameCounter = actualEngineFrameCounter ??
                            throw new ArgumentNullException(nameof(actualEngineFrameCounter));
        }

        public SourceTweenPoolMemento CaptureMemento()
        {
            return new([.. _cached]);
        }

        public void RestoreMemento(SourceTweenPoolMemento memento)
        {
            if (memento == null)
                throw new ArgumentNullException(nameof(memento));
            if (memento.CachedTweens == null)
                throw new ArgumentException("Tween cache snapshot has no logical array.", nameof(memento));
            foreach (var tween in memento.CachedTweens)
                if (tween == null || !ReferenceEquals(tween.Pool, this))
                    throw new ArgumentException("Tween snapshot must remap its engine pool before restoration.",
                        nameof(memento));
            _cached.Clear();
            _cached.AddRange(memento.CachedTweens);
        }

        internal SourceTweenState Acquire()
        {
            foreach (var item in _cached)
                if (_frameCounter() > item.CachedFrame + 3)
                {
                    _cached.Remove(item);
                    return item;
                }

            return new(this);
        }

        internal void Cache(SourceTweenState tween)
        {
            _cached.Add(tween);
            tween.CachedFrame = _frameCounter();
        }
    }
}
