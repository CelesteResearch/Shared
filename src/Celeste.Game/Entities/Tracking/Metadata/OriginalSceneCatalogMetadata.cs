using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities.Tracking.Metadata
{
    public sealed class OriginalSceneCatalogMetadata : ISourceSceneCatalogMetadata
    {
        public void Configure(SceneEntityCatalog catalog)
        {
            OriginalSceneDefinitionMembership.ConfigureOriginal(catalog);
            OriginalSceneTypeNameMetadata.ConfigureOriginal(catalog);
            catalog.SetTrackingMetadata("Monocle.Sprite", false, (string[])[]);
            catalog.ClassifySourceTrackerTypes(typeof(SceneEntityState).FullName,
                "Monocle.Component");
        }
    }
}
