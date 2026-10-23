using Celeste.Core.Scheduling;
using Celeste.Everest.Runtime.Events;
using Celeste.Game.Chapters.Flow;
using Celeste.Game.Presentation.Environment;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Session;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Everest.Chapters.Flow
{
    public sealed class EverestLevelExitFactory : IOriginalLevelExitFactory, IInstalledLevelExitConstructorPolicy
    {
        private readonly ISourceEngineContext engine;
        private readonly IOriginalAreaDataResolver areas;
        private readonly EverestGameEventsProcess events;

        public EverestLevelExitFactory(ISourceEngineContext engine, IOriginalAreaDataResolver areas,
            EverestGameEventsProcess events)
        {
            this.engine = engine;
            this.areas = areas;
            this.events = events;
        }

        public LevelExitSequence CreateLevelExit(LevelExitMode mode, ChapterCompletionSession session,
            HiresSnowState snow = null) => new LevelExitSequence(mode, session, engine, snow, this);

        public void BeforeConstructor(ChapterCompletionSession session)
            => ((IOriginalSessionAreaMetadata)areas.Get(session.AreaID)).RestoreASideAreaData();

        public void AfterConstructor(LevelExitSequence exit, LevelExitMode mode,
            ChapterCompletionSession session, HiresSnowState snow)
            => events.Exit(engine.Frame.Scenes.CurrentScene as OriginalLevelSceneRoot, exit, mode, session, snow);
    }
}
