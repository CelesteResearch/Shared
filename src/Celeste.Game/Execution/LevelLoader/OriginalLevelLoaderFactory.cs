using System;
using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Levels.Construction;
using Celeste.Game.Execution.Threading;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Game.Execution.LevelLoader
{
    public sealed class OriginalLevelLoaderFactory : IOriginalLevelLoaderFactory
    {
        private readonly ISourceEngineContext engine;
        private readonly OriginalLevelSceneConstruction construction;
        private readonly OriginalLevelLoadingResources resources;
        private readonly IOriginalAreaDataResolver areas;
        private readonly OriginalGameThreadSession threads;
        private readonly IInstalledLevelLoaderPolicy installedPolicy;

        public OriginalLevelLoaderFactory(ISourceEngineContext engine,
            OriginalLevelSceneConstruction construction, OriginalLevelLoadingResources resources,
            IOriginalAreaDataResolver areas, OriginalGameThreadSession threads,
            IInstalledLevelLoaderPolicy installedPolicy)
        {
            this.engine = engine ?? throw new ArgumentNullException(nameof(engine));
            this.construction = construction ?? throw new ArgumentNullException(nameof(construction));
            this.resources = resources ?? throw new ArgumentNullException(nameof(resources));
            this.areas = areas ?? throw new ArgumentNullException(nameof(areas));
            this.threads = threads ?? throw new ArgumentNullException(nameof(threads));
            if (threads.Profile == OriginalGameThreadProfile.Installed && installedPolicy == null)
                throw new ArgumentNullException(nameof(installedPolicy));
            if (threads.Profile == OriginalGameThreadProfile.Original && installedPolicy != null)
                throw new ArgumentException("Original process cannot use an installed loader policy.",
                    nameof(installedPolicy));
            this.installedPolicy = installedPolicy;
        }

        public OriginalLevelLoaderScene CreateLevelLoader(ChapterCompletionSession session,
            Vector2? startPosition = null)
        {
            return new(engine, session, construction, resources,
                areas, threads, installedPolicy, startPosition);
        }
    }
}
