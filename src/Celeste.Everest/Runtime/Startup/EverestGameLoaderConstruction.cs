using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Menus.Loading;
using Celeste.Input.Gameplay;

namespace Celeste.Everest.Runtime.Startup
{
    public sealed class EverestGameLoaderConstruction : IOriginalGameLoaderConstruction
    {
        public GameLoaderScene Create(ISourceEngineContext engine, ISourceGameInput input,
            IGameLoaderSourceResources resources)
        {
            return new EverestGameLoaderScene(engine, input, resources);
        }
    }
}
