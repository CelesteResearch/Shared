using System;
using Celeste.Scene.Tracking.Initialization;

namespace Celeste.Scene.Tracking
{
    public sealed partial class SceneEntityType
    {
        internal bool HasManagedTypeFacts { get; private set; }

        internal void ConfigureManagedTypeFacts(ManagedSceneTypeDefinition definition, SceneEntityCatalog owner)
        {
            if (sourceMetadataOwner != null)
                throw new InvalidOperationException("Type facts are already configured.");
            sourceMetadataOwner = owner ?? throw new ArgumentNullException(nameof(owner));
            HasManagedTypeFacts = true;
            SelectedActualType = definition.RequireActualType();
            LogicalIdentity = definition.Identity;
            Assembly = definition.Assembly;
            LogicalIsAbstract = definition.IsAbstract;
            DeclaredTrackedInherited = definition.ReadDeclaredTrackedAttributes();
            declaredTrackedAliases = definition.ReadDeclaredTrackedAsAttributes();
            DeclaredPooledAttributeCount = definition.DeclaredPooledAttributeCount;
            HasPublicParameterlessConstructor = definition.HasPublicParameterlessConstructor;
        }
    }
}
