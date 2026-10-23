using System;

namespace Celeste.Graphics.Content.Compiled
{
    // Required source CLR identity mapping, implemented by the shared content type
    // catalog. This is not a native asset loader or an original FNA reflection route.
    public interface ISourceContentTypeIdentity
    {
        Type ResolveActualType(string preparedSourceTypeName);
    }
}
