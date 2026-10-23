using Celeste.Everest.Content.Extensions.Entities.Registry;
using Celeste.Everest.Content.Reloading;
using Celeste.Game.Controls.Source;

namespace Celeste.Everest.Modules.Runtime
{
    public interface IEverestModuleLifecycleEnvironment
    {
        OriginalGameInputProcess ActualInput { get; }
        EverestEntityRegistryProcess EntityRegistry { get; }
        EverestAssetReloadProcess AssetReload { get; }
    }
}
