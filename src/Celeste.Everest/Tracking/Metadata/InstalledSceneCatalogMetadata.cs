using Celeste.Game.Entities.Tracking.Metadata;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;

namespace Celeste.Everest.Tracking.Metadata
{
    public sealed class InstalledSceneCatalogMetadata : ISourceSceneCatalogMetadata
    {
        public void Configure(SceneEntityCatalog catalog)
        {
            OriginalSceneTypeNameMetadata.ConfigureInstalled(catalog);
            catalog.SetTrackingMetadata("Monocle.Sprite", true, ["Monocle.Sprite"]);
            catalog.ClassifySourceTrackerTypes(typeof(SceneEntityState).FullName,
                "Monocle.Component");
        }
    }
}
