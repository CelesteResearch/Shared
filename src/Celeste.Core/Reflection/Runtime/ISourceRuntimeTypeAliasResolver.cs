using System;

namespace Celeste.Core.Reflection.Runtime
{
    public interface ISourceRuntimeTypeAliasResolver
    {
        Type ResolveRuntimeTypeAlias(string name, bool ignoreCase = false);
        bool RuntimeTypeNameMatches(Type type, string name, bool allowShortName = false, bool ignoreCase = false);
    }
}
