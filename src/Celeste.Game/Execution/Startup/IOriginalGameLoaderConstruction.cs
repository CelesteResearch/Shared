using Celeste.Core.Scheduling;
using Celeste.Input.Gameplay;
using Celeste.Game.Menus.Loading;

namespace Celeste.Game.Execution.Startup
{
    public interface IOriginalGameLoaderConstruction
    {
        GameLoaderScene Create(ISourceEngineContext engine, ISourceGameInput input,
            IGameLoaderSourceResources resources);
    }
}
