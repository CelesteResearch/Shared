using Celeste.Core.Reflection;

namespace Celeste.Scene.Tracking
{
    public sealed partial class SceneEntityType
    {
        internal bool HasRuntimeTypeFacts { get; private set; }

        private bool RuntimeHasBaseType(string identity)
        {
            for (var type = SelectedActualType.BaseType; type != null; type = type.BaseType)
                if (type.FullName == identity || type.AssemblyQualifiedName == identity)
                    return true;
            return false;
        }

        internal void ConfigureRuntimeTypeFacts(ISourceTypeMetadata definition, SceneEntityCatalog owner)
        {
            sourceMetadataOwner = owner;
            HasRuntimeTypeFacts = true;
            SelectedActualType = definition.RequireActualType();
            LogicalIdentity = definition.Identity;
            Assembly = definition.Assembly;
            ConfigureLogicalTypeName(definition.TypeName);
            ConfigureLogicalAssemblyIdentity(SelectedActualType.Assembly.FullName,
                SelectedActualType.Assembly.GetName().Name);
            LogicalIsAbstract = definition.IsAbstract;
            DeclaredTrackedInherited = definition.ReadDeclaredTrackedAttributes();
            declaredTrackedAliases = definition.ReadDeclaredTrackedAsAttributes();
            DeclaredPooledAttributeCount = definition.DeclaredPooledAttributeCount;
            HasPublicParameterlessConstructor = definition.HasPublicParameterlessConstructor;
            // Genuine external CLR identity; no imported PE token or Original member identity.
        }
    }
}
