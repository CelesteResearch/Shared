using System;
using System.Collections.Generic;

namespace Celeste.Core.Components.Timing
{
    // One logical Engine owns the original immediate-reuse LIFO cache.
    public sealed class SourceAlarmPool
    {
        public Celeste.Core.Scheduling.ISourceEngineContext EngineContext { get; }

        public SourceAlarmPool(Celeste.Core.Scheduling.ISourceEngineContext engine)
        {
            EngineContext = engine;
        }

        private readonly Stack<SourceAlarmState> cached = new Stack<SourceAlarmState>();

        internal SourceAlarmState Acquire()
            => cached.Count != 0 ? cached.Pop() : new SourceAlarmState(this);

        internal void Cache(SourceAlarmState alarm) => cached.Push(alarm);

        public SourceAlarmPoolMemento CaptureMemento()
            => new SourceAlarmPoolMemento(cached.ToArray());

        public void RestoreMemento(SourceAlarmPoolMemento memento)
        {
            if (memento == null) throw new ArgumentNullException(nameof(memento));
            var alarms = memento.CachedAlarms;
            foreach (var alarm in alarms)
                if (alarm == null || !ReferenceEquals(alarm.Pool, this))
                    throw new ArgumentException("Cached alarms must belong to the same logical Engine pool.",
                        nameof(memento));
            cached.Clear();
            for (int i = alarms.Length - 1; i >= 0; i--) cached.Push(alarms[i]);
        }
    }
}
