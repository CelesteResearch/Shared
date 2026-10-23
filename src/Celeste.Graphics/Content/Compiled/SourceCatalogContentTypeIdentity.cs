using System;
using Celeste.Core.Reflection;

namespace Celeste.Graphics.Content.Compiled
{
    public sealed class SourceCatalogContentTypeIdentity(ISourceActualTypeCatalog catalog) : ISourceContentTypeIdentity
    {
        private readonly ISourceActualTypeCatalog catalog = catalog;

        public Type ResolveActualType(string preparedSourceTypeName)
        {
            return SourceXnbWireTypeResolver.Resolve(preparedSourceTypeName) ??
                   catalog.ResolveRegisteredSourceType(preparedSourceTypeName);
        }
    }
}
