using Celeste.Core.Scheduling;
using Celeste.Game.Presentation.Environment;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Game.Chapters.Flow
{
    public sealed class OriginalLevelExitFactory : IOriginalLevelExitFactory
    {
        private readonly ISourceEngineContext engine;
        public OriginalLevelExitFactory(ISourceEngineContext engine) => this.engine = engine;

        public LevelExitSequence CreateLevelExit(LevelExitMode mode, ChapterCompletionSession session,
            HiresSnowState snow = null) => new LevelExitSequence(mode, session, engine, snow);
    }
}
