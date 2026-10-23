using System;
using System.Collections.Generic;
using Celeste.Scene.Collections;

namespace Celeste.Scene.Tracking
{
    public sealed partial class SceneEntityRegistry
    {
        private ISceneCollectionMetadataScope collectionMetadata;

        internal void BindCollectionMetadata(ISceneCollectionMetadataScope metadata)
        {
            collectionMetadata = metadata ?? throw new ArgumentNullException(nameof(metadata));
            RegisterSourceEntityEnumerable(this);
            RegisterSourceEntityEnumerable(entities);
            foreach (var list in tracker.Values) RegisterSourceEntityEnumerable(list);
        }

        internal void RegisterSourceEntityEnumerable(object actualCollection)
            => (collectionMetadata ??
                throw new InvalidOperationException("Bind the actual scene before exposing collections."))
                .RegisterEntities(actualCollection);

        private List<object> CopySourceEntityEnumerable(List<object> source)
        {
            var result = new List<object>(source);
            RegisterSourceEntityEnumerable(result);
            return result;
        }
    }
}
