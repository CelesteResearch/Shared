using System;
using Celeste.Core.Reflection;

namespace Celeste.Everest.Tracking.Initialization
{
    public interface ISourceInstalledTrackerTypeUniverse : ISourceTrackerTypeUniverse
    {
        ISourceTypeMetadata[] GetTypesSafe();
        SourceTrackedAsMetadata[] ReadDeclaredTrackedAsAttributes(ISourceTypeMetadata sourceType);
    }
}
