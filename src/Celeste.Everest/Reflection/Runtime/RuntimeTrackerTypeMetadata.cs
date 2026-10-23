using System;
using Celeste.Core.Reflection;

namespace Celeste.Everest.Reflection.Runtime
{
    internal sealed class RuntimeTrackerTypeMetadata : ISourceTypeMetadata
    {
        internal readonly ISourceTypeMetadata Source;

        private readonly Type declaredActualType;

        public RuntimeTrackerTypeMetadata(ISourceTypeMetadata source, Type declaredActualType = null)
        {
            Source = source;
            this.declaredActualType = declaredActualType;
        }

        public string Identity => Source.Identity;
        public string RegistryKey => Source.RegistryKey;
        public ISourceAssemblyMetadata Assembly => Source.Assembly;
        public string TypeName => Source.TypeName;
        public bool IsAbstract => Source.IsAbstract;
        public int DeclaredPooledAttributeCount => Source.DeclaredPooledAttributeCount;
        public bool HasPublicParameterlessConstructor => Source.HasPublicParameterlessConstructor;
        public Type RequireActualType() => declaredActualType ?? Source.RequireActualType();
        public bool HasBaseType(string identity) => Source.HasBaseType(identity);
        public bool[] ReadDeclaredTrackedAttributes() => Source.ReadDeclaredTrackedAttributes();

        public SourceTrackedAliasMetadata[] ReadDeclaredTrackedAsAttributes() =>
            Source.ReadDeclaredTrackedAsAttributes();

        public bool IsAssignableFrom(ISourceTypeMetadata other) =>
            declaredActualType != null || other is RuntimeTypeMetadata
                ? RequireActualType().IsAssignableFrom(other.RequireActualType())
                : Source.IsAssignableFrom(other is RuntimeTrackerTypeMetadata adapter ? adapter.Source : other);
    }
}
