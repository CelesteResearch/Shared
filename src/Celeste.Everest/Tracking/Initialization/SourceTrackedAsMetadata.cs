using Celeste.Core.Reflection;

namespace Celeste.Everest.Tracking.Initialization
{
// Declared source attribute arguments, not a replacement System.Type or MemberInfo.
    public readonly struct SourceTrackedAsMetadata
    {
        public readonly ISourceTypeMetadata TrackedAsType;
        public readonly bool Inherited;

        public SourceTrackedAsMetadata(ISourceTypeMetadata trackedAsType, bool inherited)
        {
            TrackedAsType = trackedAsType;
            Inherited = inherited;
        }
    }
}
