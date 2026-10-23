using System;
using System.Collections.Generic;
using Celeste.Core.Scheduling;

namespace Celeste.Core.Components.Timing
{
    // One logical Engine owns the original immediate-reuse LIFO cache.
    public sealed class SourceAlarmPool
    {
        public ISourceEngineContext EngineContext { get; }

        public SourceAlarmPool(ISourceEngineContext engine)
        {
            EngineContext = engine;
        }

        private readonly Stack<SourceAlarmState> _cached = new();

        internal SourceAlarmState Acquire()
        {
            return _cached.Count != 0 ? _cached.Pop() : new(this);
        }

        internal void Cache(SourceAlarmState alarm)
        {
            _cached.Push(alarm);
        }

        public SourceAlarmPoolMemento CaptureMemento()
        {
            return new( /* ReSharper disable once UseCollectionExpression */ _cached.ToArray());
        }

        public void RestoreMemento(SourceAlarmPoolMemento memento)
        {
            if (memento == null) throw new ArgumentNullException(nameof(memento));
            var alarms = memento.CachedAlarms;
            foreach (var alarm in alarms)
                if (alarm == null || !ReferenceEquals(alarm.Pool, this))
                    throw new ArgumentException("Cached alarms must belong to the same logical Engine pool.",
                        nameof(memento));
            _cached.Clear();
            for (var i = alarms.Length - 1; i >= 0; i--) _cached.Push(alarms[i]);
        }
    }
}
