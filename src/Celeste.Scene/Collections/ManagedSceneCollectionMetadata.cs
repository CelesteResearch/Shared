using System;
using System.Collections.Generic;
using Celeste.Core.Components;
using Celeste.Scene.Tracking;

namespace Celeste.Scene.Collections
{
    // CLR collections carry their own element type; no imported type annotations are required.
    public sealed class ManagedSceneCollectionMetadata : ISceneCollectionMetadata, ISceneCollectionMetadataScope
    {
        public ISceneCollectionMetadataScope BindScene(SceneEntityCatalog catalog, object scene) => this;

        public void RegisterEntities(object collection)
        {
            if (!(collection is IEnumerable<object>))
                throw new ArgumentException("The entity collection must expose its CLR enumerable.",
                    nameof(collection));
        }

        public void RegisterTyped(object collection, Type elementType)
        {
            if (!typeof(IEnumerable<>).MakeGenericType(elementType).IsInstanceOfType(collection))
                throw new ArgumentException("The collection must expose its declared CLR element type.",
                    nameof(collection));
        }

        public void RegisterComponents(object collection)
        {
            if (!(collection is IEnumerable<SourceComponentState>))
                throw new ArgumentException("The component collection must expose its CLR enumerable.",
                    nameof(collection));
        }
    }
}
