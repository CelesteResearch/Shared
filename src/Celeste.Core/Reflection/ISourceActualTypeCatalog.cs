using System;

namespace Celeste.Core.Reflection
{
    public interface ISourceActualTypeCatalog
    {
        void RegisterActualType(string sourceIdentity, string logicalTypeName,
            string logicalAssemblyIdentity, string logicalAssemblySimpleName, Type actualType);

        Type ResolveRegisteredSourceType(string preparedSourceTypeName);
    }
}
