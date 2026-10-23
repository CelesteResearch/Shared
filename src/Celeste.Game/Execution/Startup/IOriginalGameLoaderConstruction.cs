using Celeste.Core.Scheduling;
using Celeste.Game.Menus.Loading;
using Celeste.Input.Gameplay;

namespace Celeste.Game.Execution.Startup
{
    public interface IOriginalGameLoaderConstruction
    {
        GameLoaderScene Create(ISourceEngineContext engine, ISourceGameInput input,
            IGameLoaderSourceResources resources);
    }
}
