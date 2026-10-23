namespace Celeste.Core.Components.Timing
{
    public sealed class SourceAlarmPoolMemento
    {
        // Top first, matching Stack enumeration; cloned with live alarms in one graph.
        public SourceAlarmState[] CachedAlarms { get; }

        public SourceAlarmPoolMemento(SourceAlarmState[] cachedAlarms)
        {
            CachedAlarms = cachedAlarms ?? throw new System.ArgumentNullException(nameof(cachedAlarms));
        }
    }
}
