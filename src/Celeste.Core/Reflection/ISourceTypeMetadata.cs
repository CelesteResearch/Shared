using System;

namespace Celeste.Core.Reflection
{
    // Source metadata is not System.Type and is not a reflection wrapper.
    public interface ISourceTypeMetadata
    {
        string Identity { get; }
        string RegistryKey { get; }
        ISourceAssemblyMetadata Assembly { get; }
        string TypeName { get; }
        bool IsAbstract { get; }
        int DeclaredPooledAttributeCount { get; }
        bool HasPublicParameterlessConstructor { get; }
        bool IsAssignableFrom(ISourceTypeMetadata other);
        bool HasBaseType(string identity);
        bool[] ReadDeclaredTrackedAttributes();
        SourceTrackedAliasMetadata[] ReadDeclaredTrackedAsAttributes();
        Type RequireActualType();
    }
}
