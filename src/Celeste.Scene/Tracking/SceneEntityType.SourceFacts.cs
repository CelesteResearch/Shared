using System;
using Celeste.Core.Reflection;

namespace Celeste.Scene.Tracking
{
    public sealed partial class SceneEntityType : ISourceTypeMetadata
    {
        private SceneEntityCatalog sourceMetadataOwner;
        public Type SelectedActualType { get; private set; }

        internal void SelectActualType(Type actualType)
        {
            SelectedActualType = actualType;
        }

        public string LogicalIdentity { get; private set; }
        public string Identity => LogicalIdentity ?? Name;
        public string RegistryKey => Name;
        public ISourceAssemblyMetadata Assembly { get; private set; }
        public string TypeName => LogicalTypeName;
        public bool IsAbstract => LogicalIsAbstract;

        public bool HasBaseType(string identity)
        {
            return HasRuntimeTypeFacts
                ? RuntimeHasBaseType(identity)
                : Array.IndexOf(BaseTypes, identity) >= 0;
        }

        public bool IsAssignableFrom(ISourceTypeMetadata other)
        {
            return HasRuntimeTypeFacts || other is SceneEntityType { HasRuntimeTypeFacts: true }
                ? RequireActualType().IsAssignableFrom(other.RequireActualType())
                : other.Identity == Identity || other.HasBaseType(Identity);
        }

        public bool[] ReadDeclaredTrackedAttributes()
        {
            return (bool[])DeclaredTrackedInherited.Clone();
        }

        private SourceTrackedAliasMetadata[] declaredTrackedAliases;

        public SourceTrackedAliasMetadata[] ReadDeclaredTrackedAsAttributes()
        {
            return (SourceTrackedAliasMetadata[])declaredTrackedAliases.Clone();
        }

        internal void ConfigureDeclaredTrackedAliases(SourceTrackedAliasMetadata[] aliases)
        {
            declaredTrackedAliases = aliases;
        }

        public Type RequireActualType()
        {
            return HasRuntimeTypeFacts
                ? SelectedActualType
                : sourceMetadataOwner.RequireActualTypeForLogicalIdentity(Name);
        }

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
            SceneEntityCatalog owner, ISourceAssemblyMetadata assembly)
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
