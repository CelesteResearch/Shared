using System;

namespace Celeste.Scene.Tracking
{
    public sealed partial class SceneEntityType : Celeste.Core.Reflection.ISourceTypeMetadata
    {
        private SceneEntityCatalog sourceMetadataOwner;
        public Type SelectedActualType { get; private set; }
        internal void SelectActualType(Type actualType) => SelectedActualType = actualType;
        public string LogicalIdentity { get; private set; }
        public string Identity => LogicalIdentity ?? Name;
        public string RegistryKey => Name;
        public Celeste.Core.Reflection.ISourceAssemblyMetadata Assembly { get; private set; }
        public string TypeName => LogicalTypeName;
        public bool IsAbstract => LogicalIsAbstract;

        public bool HasBaseType(string identity) => HasRuntimeTypeFacts
            ? RuntimeHasBaseType(identity)
            : Array.IndexOf(BaseTypes, identity) >= 0;

        public bool IsAssignableFrom(Celeste.Core.Reflection.ISourceTypeMetadata other)
            => HasRuntimeTypeFacts || other is SceneEntityType { HasRuntimeTypeFacts: true }
                ? RequireActualType().IsAssignableFrom(other.RequireActualType())
                : other.Identity == Identity || other.HasBaseType(Identity);

        public bool[] ReadDeclaredTrackedAttributes() => (bool[])DeclaredTrackedInherited.Clone();
        private Celeste.Core.Reflection.SourceTrackedAliasMetadata[] declaredTrackedAliases;

        public Celeste.Core.Reflection.SourceTrackedAliasMetadata[] ReadDeclaredTrackedAsAttributes()
            => (Celeste.Core.Reflection.SourceTrackedAliasMetadata[])declaredTrackedAliases.Clone();

        internal void ConfigureDeclaredTrackedAliases(Celeste.Core.Reflection.SourceTrackedAliasMetadata[] aliases)
            => declaredTrackedAliases = aliases;

        public Type RequireActualType() => HasRuntimeTypeFacts
            ? SelectedActualType
            : sourceMetadataOwner.RequireActualTypeForLogicalIdentity(Name);

        public int DeclaredPooledAttributeCount { get; private set; }
        public bool HasPublicParameterlessConstructor { get; private set; }

        internal void ConfigureDeclaredPoolFacts(int count, bool constructor)
        {
            DeclaredPooledAttributeCount = count;
            HasPublicParameterlessConstructor = constructor;
        }

        public int LogicalMetadataToken { get; private set; }
        public bool LogicalIsAbstract { get; private set; }
        public bool[] DeclaredTrackedInherited { get; private set; }

        internal void ConfigureDeclaredSourceFacts(string identity, string name, string assemblyIdentity,
            string assemblySimpleName, int metadataToken, bool isAbstract, bool[] trackedAttributes,
            SceneEntityCatalog owner, Celeste.Core.Reflection.ISourceAssemblyMetadata assembly)
        {
            if (logicalTypeName != null && logicalTypeName != name)
                throw new InvalidOperationException("Conflicting logical type-name metadata.");
            if (LogicalAssemblyIdentity != null && LogicalAssemblyIdentity != assemblyIdentity)
                throw new InvalidOperationException("Conflicting logical assembly metadata.");
            LogicalIdentity = identity;
            sourceMetadataOwner = owner;
            Assembly = assembly;
            logicalTypeName = name;
            LogicalAssemblyIdentity = assemblyIdentity;
            LogicalAssemblySimpleName = assemblySimpleName;
            LogicalMetadataToken = metadataToken;
            LogicalIsAbstract = isAbstract;
            DeclaredTrackedInherited = trackedAttributes;
        }
    }
}
