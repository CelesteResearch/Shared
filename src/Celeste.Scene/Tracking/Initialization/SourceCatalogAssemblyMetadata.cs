using System;
using Celeste.Core.Reflection;

namespace Celeste.Scene.Tracking.Initialization
{
    public sealed class SourceCatalogAssemblyMetadata : ISourceAssemblyMetadata
    {
        private readonly SceneEntityCatalog catalog;
        public string Identity { get; }

        public SourceCatalogAssemblyMetadata(SceneEntityCatalog catalog, string identity)
        {
            this.catalog = catalog ?? throw new ArgumentNullException(nameof(catalog));
            Identity = identity ?? throw new ArgumentNullException(nameof(identity));
        }

        public ISourceTypeMetadata[] GetTypes() => catalog.GetLogicalAssemblyTypeMetadata(Identity);
    }
}
