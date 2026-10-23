using System;
using Celeste.Game.Presentation.Environment;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Vignettes;
using Celeste.Formats.Graphics.Atlas;
using Celeste.Simulation.Runtime.Session;
using Celeste.Core.Scheduling;

namespace Celeste.Game.Chapters.Flow
{
    public sealed class OriginalLevelEntrySceneFactory : ILevelEntrySceneFactory
    {
        private readonly IOriginalLevelEnterProcess process;
        private readonly OriginalGameGraphicsResources graphics;
        private readonly ISourceAtlasLoaderEnvironment atlasEnvironment;

        public OriginalLevelEntrySceneFactory(IOriginalLevelEnterProcess actualProcess,
            OriginalGameGraphicsResources actualGraphics, ISourceAtlasLoaderEnvironment actualAtlasEnvironment)
        {
            process = actualProcess ?? throw new ArgumentNullException(nameof(actualProcess));
            graphics = actualGraphics ?? throw new ArgumentNullException(nameof(actualGraphics));
            atlasEnvironment = actualAtlasEnvironment ??
                               throw new ArgumentNullException(nameof(actualAtlasEnvironment));
        }

        public ISourceSceneExecution CreateIntroVignette(ChapterCompletionSession session, HiresSnowState snow)
            => ((IOriginalStartupSceneEnvironment)process).StartupScenes.CreateIntroVignette(session, snow);

        public ISourceSceneExecution CreateSummitVignette(ChapterCompletionSession session)
            => new SummitVignetteScene(session, process);

        public ISourceSceneExecution CreateCoreVignette(ChapterCompletionSession session, HiresSnowState snow)
            => new CoreVignetteSequence(session, process, snow);

        public ISourceSceneExecution CreateLevelEnter(ChapterCompletionSession session, bool fromSaveData)
            => new LevelEnterSequence(session, fromSaveData, process);

        public void RequirePreparedEntry(ChapterCompletionSession session)
        {
            if (process is global::Celeste.Game.Content.Loading.IOriginalChapterPreparationEnvironment environment)
                environment.ChapterPreparation?.RequirePreparedEntry(session);
        }
    }
}
