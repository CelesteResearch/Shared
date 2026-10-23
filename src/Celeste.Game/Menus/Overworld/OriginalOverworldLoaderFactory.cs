using Celeste.Core.Scheduling;
using Celeste.Game.Presentation.Environment;

namespace Celeste.Game.Menus.Overworld
{
    public sealed class OriginalOverworldLoaderFactory : IOriginalOverworldLoaderFactory
    {
        private readonly ISourceEngineContext engine;

        public OriginalOverworldLoaderFactory(ISourceEngineContext engine)
        {
            this.engine = engine;
        }

        public OverworldLoaderSequence CreateOverworldLoader(OverworldStartMode startMode, HiresSnowState snow = null)
            => new OverworldLoaderSequence(engine, startMode, snow);
    }
}
