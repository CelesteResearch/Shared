using System;
using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Levels;
using Celeste.Simulation.Runtime.Session;
using Celeste.Simulation.Runtime.Session.Maps;

namespace Celeste.Game.Execution.LevelLoader
{
    public sealed class OriginalLevelLoadingResources
    {
        private readonly ISourceEngineContext engine;

        public OriginalLevelLoadingResources(ISourceEngineContext engine)
            => this.engine = engine ?? throw new ArgumentNullException(nameof(engine));

        internal void Load(OriginalLevelSceneRoot level, ChapterCompletionSession session,
            IChapterSessionMapData map, IOriginalAreaData area, Vector2? startPosition)
        {
            if (!ReferenceEquals(level.EngineContext, engine))
                throw new InvalidOperationException("Level loading must borrow the same actual Engine process.");
            level.LoadSourceLevelContent(session, map, area, startPosition);
        }
    }
}
