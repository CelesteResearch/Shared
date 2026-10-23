using System;

namespace Celeste.Core.Components.Timing
{
    public sealed class SourceAlarmPoolMemento(SourceAlarmState[] cachedAlarms)
    {
        // Top first, matching Stack enumeration; cloned with live alarms in one graph.
        public SourceAlarmState[] CachedAlarms { get; }
            = cachedAlarms ?? throw new ArgumentNullException(nameof(cachedAlarms));
    }
}
