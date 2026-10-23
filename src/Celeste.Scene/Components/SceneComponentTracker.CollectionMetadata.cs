using System;
using System.Collections.Generic;
using Celeste.Core.Components;
using Celeste.Scene.Collections;

namespace Celeste.Scene.Components
{
    public partial class SceneComponentTracker
    {
        private ISceneCollectionMetadataScope collectionMetadata;

        internal void BindCollectionMetadata(ISceneCollectionMetadataScope metadata)
        {
            collectionMetadata = metadata ?? throw new ArgumentNullException(nameof(metadata));
            foreach (var list in tracker.Values) RegisterSourceComponentEnumerable(list);
        }

        internal void RegisterSourceComponentEnumerable(object actualCollection)
            => (collectionMetadata ??
                throw new InvalidOperationException("Bind the actual scene before exposing collections."))
                .RegisterComponents(actualCollection);

        internal List<SourceComponentState> CopySourceComponentEnumerable(List<SourceComponentState> source)
        {
            var result = new List<SourceComponentState>(source);
            RegisterSourceComponentEnumerable(result);
            return result;
        }
    }
}
