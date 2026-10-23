using Celeste.Core.Reflection.RuntimeShapes;
using Celeste.Scene.Collections;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities.Tracking.Metadata
{
    internal sealed class OriginalSceneCollectionMetadataScope : ISceneCollectionMetadataScope
    {
        private readonly SceneEntityCatalog catalog;
        private readonly SourceRuntimeShapeCatalog shapes;

        public OriginalSceneCollectionMetadataScope(SceneEntityCatalog catalog, SourceRuntimeShapeCatalog shapes)
        {
            this.catalog = catalog;
            this.shapes = shapes;
        }

        public void RegisterEntities(object collection)
        {
            var type = catalog.SourceTrackerInitialization.TypeUniverse.EntityType;
            shapes.RegisterOriginalEnumerable(collection, type.Assembly.Identity, type.Identity);
        }

        public void RegisterTyped(object collection, System.Type elementType)
            => shapes.RegisterOriginalEnumerable(collection, elementType);

        public void RegisterComponents(object collection)
        {
            var type = catalog.SourceTrackerInitialization.TypeUniverse.ComponentType;
            shapes.RegisterOriginalEnumerable(collection, type.Assembly.Identity, type.Identity);
        }
    }
}
