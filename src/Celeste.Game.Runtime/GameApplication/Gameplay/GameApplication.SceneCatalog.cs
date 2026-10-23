using System;
using System.Linq;
using Celeste.Core.Reflection;
using Celeste.Scene.Tracking;
using Celeste.Scene.Tracking.Initialization;
using Celeste.Game.Entities;
using Celeste.Game.Entities.Tracking.Metadata;
using Celeste.Game.Reflection.Startup;
using Celeste.Game.Profiles;
using Celeste.Everest.Tracking.Metadata;
using Celeste.Everest.Reflection.Startup;

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
            => SceneCatalog.GetRuntimeAssemblyTypeMetadata(assemblyIdentity);
    }
}
