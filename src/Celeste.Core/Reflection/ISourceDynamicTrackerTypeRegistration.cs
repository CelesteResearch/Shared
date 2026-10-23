namespace Celeste.Core.Reflection
{
    public interface ISourceDynamicTrackerTypeRegistration
    {
        int TrackedTypeVersion { get; }
        void AddTypeToTracker(ISourceTypeMetadata type, ISourceTypeMetadata trackedAs = null, bool inheritAll = false);
    }
}
