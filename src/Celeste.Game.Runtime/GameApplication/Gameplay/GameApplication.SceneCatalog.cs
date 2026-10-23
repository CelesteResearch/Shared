using System;
using Celeste.Core.Reflection;
using Celeste.Everest.Reflection.Startup;
using Celeste.Everest.Tracking.Metadata;
using Celeste.Game.Entities;
using Celeste.Game.Entities.Tracking.Metadata;
using Celeste.Game.Profiles;
using Celeste.Game.Reflection.Startup;
using Celeste.Scene.Tracking;
using Celeste.Scene.Tracking.Initialization;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ISourceSceneCatalogEnvironment,
        ISourceTrackerInitializationEnvironment
    {
        private SceneEntityCatalog sourceSceneCatalog;
        private SourceTrackerInitialization sourceTrackerInitialization;

        public SceneEntityCatalog SceneCatalog => sourceSceneCatalog ??
                                                  throw new InvalidOperationException(
                                                      "The actual source scene catalog is not constructed.");

        public SourceTrackerInitialization TrackerInitialization => sourceTrackerInitialization ??
                                                                    throw new InvalidOperationException(
                                                                        "The actual Tracker initialization is not constructed.");

        public void ConstructSourceSceneCatalog()
        {
            if (sourceSceneCatalog != null)
                throw new InvalidOperationException("The actual source scene catalog is already constructed.");
            ISourceSceneCatalogMetadata metadata = SourceProfile == GameProfile.Original
                ? new OriginalSceneCatalogMetadata()
                : new InstalledSceneCatalogMetadata();
            sourceSceneCatalog = OriginalSceneCatalog.Create(metadata);
        }

        public void ConstructSourceTrackerInitialization()
        {
            if (sourceTrackerInitialization != null)
                throw new InvalidOperationException("The actual Tracker initialization is already constructed.");
            sourceTrackerInitialization = SourceProfile == GameProfile.Original
                ? OriginalSourceTrackerStartup.Create(SceneCatalog)
                : InstalledSourceTrackerStartup.Create(SceneCatalog, this,
                    actualModuleType => SourceMembers.GetOriginalTypeDefinition(actualModuleType).AssemblyIdentity,
                    RequireSourceTrackerAssemblyTypes);
        }

        private ISourceTypeMetadata[] RequireSourceTrackerAssemblyTypes(string assemblyIdentity)
        {
            return SceneCatalog.GetRuntimeAssemblyTypeMetadata(assemblyIdentity);
        }
    }
}
