using System;
using Celeste.Core.Reflection.RuntimeShapes;
using Celeste.Scene.Collections;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities.Tracking.Metadata
{
    internal sealed class OriginalSceneCollectionMetadataScope : ISceneCollectionMetadataScope
    {
        private readonly SceneEntityCatalog _catalog;
        private readonly SourceRuntimeShapeCatalog _shapes;

        // ReSharper disable once ConvertToPrimaryConstructor
        public OriginalSceneCollectionMetadataScope(SceneEntityCatalog catalog, SourceRuntimeShapeCatalog shapes)
        {
            _catalog = catalog;
            _shapes = shapes;
        }

        public void RegisterEntities(object collection)
        {
            var type = _catalog.SourceTrackerInitialization.TypeUniverse.EntityType;
            _shapes.RegisterOriginalEnumerable(collection, type.Assembly.Identity, type.Identity);
        }

        public void RegisterTyped(object collection, Type elementType)
        {
            _shapes.RegisterOriginalEnumerable(collection, elementType);
        }

        public void RegisterComponents(object collection)
        {
            var type = _catalog.SourceTrackerInitialization.TypeUniverse.ComponentType;
            _shapes.RegisterOriginalEnumerable(collection, type.Assembly.Identity, type.Identity);
        }
    }
}
