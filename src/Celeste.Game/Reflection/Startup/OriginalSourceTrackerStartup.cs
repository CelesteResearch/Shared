using Celeste.Scene.Tracking;
using Celeste.Scene.Tracking.Initialization;

namespace Celeste.Game.Reflection.Startup
{
    public static class OriginalSourceTrackerStartup
    {
        public static SourceTrackerInitialization Create(SceneEntityCatalog catalog)
        {
            const string identity = "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
            var assembly = new SourceCatalogAssemblyMetadata(catalog, identity);
            OriginalLogicalTypeFacts.Register(catalog, identity, assembly);
            OriginalTrackerFrameworkTypeBindings.Register(catalog);
            OriginalBuiltInEntityActualTypeBindings.RegisterConfigurationUi(catalog);
            OriginalTrackedComponentActualTypeBindings.Register(catalog);
            OriginalOwnActorActualTypeBindings.Register(catalog);
            OriginalScreenWipeActualTypeBindings.Register(catalog);
            OriginalPooledActualTypeBindings.Register(catalog);
            return new(new OriginalCatalogTrackerTypeUniverse(catalog, identity));
        }
    }
}
