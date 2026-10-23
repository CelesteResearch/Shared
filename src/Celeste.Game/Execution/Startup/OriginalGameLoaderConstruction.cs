using Celeste.Core.Scheduling;
using Celeste.Game.Menus.Loading;
using Celeste.Input.Gameplay;

namespace Celeste.Game.Execution.Startup
{
    public sealed class OriginalGameLoaderConstruction : IOriginalGameLoaderConstruction
    {
        public GameLoaderScene Create(ISourceEngineContext engine, ISourceGameInput input,
            IGameLoaderSourceResources resources)
        {
            return new(engine, input, resources);
        }
    }
}
