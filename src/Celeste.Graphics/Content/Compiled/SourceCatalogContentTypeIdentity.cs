using System;
using Celeste.Core.Reflection;

namespace Celeste.Graphics.Content.Compiled
{
    public sealed class SourceCatalogContentTypeIdentity : ISourceContentTypeIdentity
    {
        private readonly ISourceActualTypeCatalog catalog;

        public SourceCatalogContentTypeIdentity(ISourceActualTypeCatalog catalog)
        {
            this.catalog = catalog;
        }

        public Type ResolveActualType(string preparedSourceTypeName)
            => SourceXnbWireTypeResolver.Resolve(preparedSourceTypeName)
               ?? catalog.ResolveRegisteredSourceType(preparedSourceTypeName);
    }
}
