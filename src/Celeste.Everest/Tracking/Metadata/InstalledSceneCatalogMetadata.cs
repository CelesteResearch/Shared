using Celeste.Scene.Tracking;

namespace Celeste.Everest.Tracking.Metadata
{
    public sealed class InstalledSceneCatalogMetadata : ISourceSceneCatalogMetadata
    {
        public void Configure(SceneEntityCatalog catalog)
        {
            Celeste.Game.Entities.Tracking.Metadata.OriginalSceneTypeNameMetadata.ConfigureInstalled(catalog);
            catalog.SetTrackingMetadata("Monocle.Sprite", true, new[] { "Monocle.Sprite" });
            catalog.ClassifySourceTrackerTypes(typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName,
                "Monocle.Component");
        }
    }
}
