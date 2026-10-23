using Celeste.Core.Scheduling;
using Celeste.Input.Gameplay;
using Celeste.Game.Menus.Loading;
using Celeste.Game.Execution.Startup;

namespace Celeste.Everest.Runtime.Startup
{
    public sealed class EverestGameLoaderConstruction : IOriginalGameLoaderConstruction
    {
        public GameLoaderScene Create(ISourceEngineContext engine, ISourceGameInput input,
            IGameLoaderSourceResources resources)
            => new EverestGameLoaderScene(engine, input, resources);
    }
}
