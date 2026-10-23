using System.Collections.Generic;
using Celeste.Scene.Collections;

namespace Celeste.Scene.Tracking.Initialization
{
    public static class ManagedSceneTypeCatalog
    {
        public static SceneEntityCatalog Create(IEnumerable<ManagedSceneTypeDefinition> definitions)
        {
            var universe = new ManagedSceneTypeUniverse(definitions);
            var catalog = new SceneEntityCatalog(new ManagedSceneCollectionMetadata());
            foreach (ManagedSceneTypeDefinition type in universe.GetTypes())
            {
                var definition = new SceneEntityType(type.Identity, type.BaseTypeNames(), System.Array.Empty<string>());
                definition.ConfigureLogicalTypeName(type.TypeName);
                definition.ConfigureLogicalAssemblyIdentity(type.Assembly.Identity,
                    type.RequireActualType().Assembly.GetName().Name);
                definition.ConfigureManagedTypeFacts(type, catalog);
                catalog.Register(definition);
                catalog.RegisterRuntimeType(type.RequireActualType(), type.Identity);
            }

            catalog.InitializeSourceTracker(new SourceTrackerInitialization(universe));
            return catalog;
        }
    }
}
