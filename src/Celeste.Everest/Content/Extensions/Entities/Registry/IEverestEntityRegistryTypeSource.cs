using System;

namespace Celeste.Everest.Content.Extensions.Entities.Registry
{
    public interface IEverestEntityRegistryTypeSource
    {
        Type ResolveSourceType(string sourceFullName);
    }
}
