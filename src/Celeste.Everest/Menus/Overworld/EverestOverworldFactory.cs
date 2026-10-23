using Celeste.Core.Scheduling;
using Celeste.Game.Menus.Overworld;

namespace Celeste.Everest.Menus.Overworld
{
    public sealed class EverestOverworldFactory : IOriginalOverworldFactory
    {
        private readonly ISourceEngineContext engine;

        public EverestOverworldFactory(ISourceEngineContext engine)
        {
            this.engine = engine;
        }

        public OverworldSequence CreateOverworld(OverworldLoaderSequence loader)
        {
            return new EverestOverworldSequence(engine, loader);
        }
    }
}
