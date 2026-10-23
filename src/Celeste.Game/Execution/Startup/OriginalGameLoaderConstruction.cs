using Celeste.Core.Scheduling;
using Celeste.Input.Gameplay;
using Celeste.Game.Menus.Loading;

namespace Celeste.Game.Execution.Startup
{
    public sealed class OriginalGameLoaderConstruction : IOriginalGameLoaderConstruction
    {
        public GameLoaderScene Create(ISourceEngineContext engine, ISourceGameInput input,
            IGameLoaderSourceResources resources)
            => new GameLoaderScene(engine, input, resources);
    }
}
