using System;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities.Tracking.Metadata
{
    public sealed class OriginalSceneCatalogMetadata : ISourceSceneCatalogMetadata
    {
        public void Configure(SceneEntityCatalog catalog)
        {
            OriginalSceneDefinitionMembership.ConfigureOriginal(catalog);
            Celeste.Game.Entities.Tracking.Metadata.OriginalSceneTypeNameMetadata.ConfigureOriginal(catalog);
            catalog.SetTrackingMetadata("Monocle.Sprite", false, Array.Empty<string>());
            catalog.ClassifySourceTrackerTypes(typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName,
                "Monocle.Component");
        }
    }
}
