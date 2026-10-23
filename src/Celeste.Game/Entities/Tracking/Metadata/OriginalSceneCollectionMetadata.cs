using System;
using Celeste.Core.Reflection.RuntimeShapes;
using Celeste.Core.Scheduling;
using Celeste.Scene.Collections;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities.Tracking.Metadata
{
    public sealed class OriginalSceneCollectionMetadata : ISceneCollectionMetadata
    {
        public ISceneCollectionMetadataScope BindScene(SceneEntityCatalog catalog, object scene)
        {
            var shapes = ((ISourceRuntimeShapeEnvironment)((ISourceEngineContextScene)scene).EngineContext)
                .SourceRuntimeShapes;
            return new OriginalSceneCollectionMetadataScope(catalog, shapes);
        }
    }
}
