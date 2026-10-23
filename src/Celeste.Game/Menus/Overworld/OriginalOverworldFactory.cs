using Celeste.Core.Scheduling;

namespace Celeste.Game.Menus.Overworld
{
    public sealed class OriginalOverworldFactory : IOriginalOverworldFactory
    {
        private readonly ISourceEngineContext engine;
        public OriginalOverworldFactory(ISourceEngineContext engine) => this.engine = engine;

        public OverworldSequence CreateOverworld(OverworldLoaderSequence loader)
            => new OverworldSequence(engine, loader);
    }
}
