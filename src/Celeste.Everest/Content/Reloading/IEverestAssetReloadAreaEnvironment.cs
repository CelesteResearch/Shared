using Celeste.Game.Execution.Areas;
using Celeste.Game.Save.Runtime;

namespace Celeste.Everest.Content.Reloading
{
    public interface IEverestAssetReloadAreaEnvironment : IOriginalSavePreparationEnvironment,
        IOriginalAreaRegistryLoadEnvironment
    {
        OriginalAreaRegistryProcess AreaRegistry { get; }
        IOriginalGameSaveContext SaveContext { get; }
    }
}
