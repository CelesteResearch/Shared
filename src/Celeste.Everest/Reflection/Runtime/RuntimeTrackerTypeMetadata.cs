using System;
using Celeste.Core.Reflection;

namespace Celeste.Everest.Reflection.Runtime
{
    internal sealed class RuntimeTrackerTypeMetadata : ISourceTypeMetadata
    {
        internal readonly ISourceTypeMetadata Source;

        private readonly Type declaredActualType;

        // ReSharper disable once ConvertToPrimaryConstructor
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

        public Type RequireActualType()
        {
            return declaredActualType ?? Source.RequireActualType();
        }

        public bool HasBaseType(string identity)
        {
            return Source.HasBaseType(identity);
        }

        public bool[] ReadDeclaredTrackedAttributes()
        {
            return Source.ReadDeclaredTrackedAttributes();
        }

        public SourceTrackedAliasMetadata[] ReadDeclaredTrackedAsAttributes()
        {
            return Source.ReadDeclaredTrackedAsAttributes();
        }

        public bool IsAssignableFrom(ISourceTypeMetadata other)
        {
            return declaredActualType != null || other is RuntimeTypeMetadata
                ? RequireActualType().IsAssignableFrom(other.RequireActualType())
                : Source.IsAssignableFrom(other is RuntimeTrackerTypeMetadata adapter ? adapter.Source : other);
        }
    }
}
