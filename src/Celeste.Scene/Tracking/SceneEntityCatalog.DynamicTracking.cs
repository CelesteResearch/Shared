using System;
using Celeste.Core.Reflection;

namespace Celeste.Scene.Tracking
{
    public sealed partial class SceneEntityCatalog
    {
        public void AddTypeToTracker(Type actualType, Type trackedAs = null, bool inheritAll = false)
        {
            var type = Find(actualType) ??
                       throw new InvalidOperationException(
                           "Dynamic tracker source type is not bound in the source catalog.");
            var asType = trackedAs == null
                ? null
                : Find(trackedAs) ??
                  throw new InvalidOperationException(
                      "Dynamic tracked-as source type is not bound in the source catalog.");
            var registration = (ISourceDynamicTrackerTypeRegistration)SourceTrackerInitialization;
            var previousVersion = registration.TrackedTypeVersion;
            registration.AddTypeToTracker(type, asType, inheritAll);
            if (registration.TrackedTypeVersion != previousVersion) PublishSourceTrackerOutputs();
        }
    }
}
