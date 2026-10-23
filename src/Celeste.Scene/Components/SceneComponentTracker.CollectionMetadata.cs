using System;
using System.Collections.Generic;
using Celeste.Core.Components;
using Celeste.Scene.Collections;

namespace Celeste.Scene.Components
{
    public partial class SceneComponentTracker
    {
        private ISceneCollectionMetadataScope _collectionMetadata;

        internal void BindCollectionMetadata(ISceneCollectionMetadataScope metadata)
        {
            _collectionMetadata = metadata ?? throw new ArgumentNullException(nameof(metadata));
            foreach (var list in Components.Values) RegisterSourceComponentEnumerable(list);
        }

        internal void RegisterSourceComponentEnumerable(object actualCollection)
        {
            (_collectionMetadata ??
             throw new InvalidOperationException("Bind the actual scene before exposing collections."))
                .RegisterComponents(actualCollection);
        }

        internal List<SourceComponentState> CopySourceComponentEnumerable(List<SourceComponentState> source)
        {
            var result = new List<SourceComponentState>(source);
            RegisterSourceComponentEnumerable(result);
            return result;
        }
    }
}
