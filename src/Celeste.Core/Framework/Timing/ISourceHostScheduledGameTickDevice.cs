namespace Celeste.Core.Framework.Timing
{
    // The host supplies opportunities instead of blocking for the next fixed step.
    // Tick returns before PollEvents/Update/Draw when elapsed time is insufficient.
    // Invoke Tick once per host callback; the host must not retry in a tight loop.
    public interface ISourceHostScheduledGameTickDevice : ISourceGameTickDevice
    {
        // Read live before each source Update; resource readiness may change during catchup.
        bool SourceUpdatesBlocked { get; }
    }
}
