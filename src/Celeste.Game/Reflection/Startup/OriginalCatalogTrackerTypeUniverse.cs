using System;
using Celeste.Core.Reflection;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Reflection.Startup
{
    public sealed class OriginalCatalogTrackerTypeUniverse : ISourceTrackerTypeUniverse
    {
        private readonly SceneEntityCatalog catalog;
        private readonly string assemblyIdentity;

        public OriginalCatalogTrackerTypeUniverse(SceneEntityCatalog catalog, string assemblyIdentity)
        {
            this.catalog = catalog ?? throw new ArgumentNullException(nameof(catalog));
            this.assemblyIdentity = assemblyIdentity ?? throw new ArgumentNullException(nameof(assemblyIdentity));
        }

        public ISourceTypeMetadata EntityType =>
            catalog.Find(typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName) ??
            throw new InvalidOperationException("Entity metadata is not published.");

        public ISourceTypeMetadata ComponentType => catalog.Find("Monocle.Component") ??
                                                    throw new InvalidOperationException(
                                                        "Component metadata is not published.");

        public ISourceTypeMetadata[] GetTypes() => catalog.GetRuntimeAssemblyTypeMetadata(assemblyIdentity);
    }
}
