using System;
using Celeste.Core.Pooling;
using Celeste.Core.Scheduling;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Everest.Runtime.Events.LevelLoading;
using Celeste.Formats.Save.Xml;
using Celeste.Game.Chapters.Flow;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.LevelLoader;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Threading;
using Celeste.Localization.Lookup;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Everest.Runtime.LevelLoading
{
    public sealed class EverestLevelLoaderPolicy : IInstalledLevelLoaderPolicy
    {
        private readonly EverestLevelLoaderConstructorPrefix prefix;
        private readonly EverestLevelLoaderFailureHandler failures;
        private readonly OriginalLevelLoaderProcessState process;
        private readonly SourceEntityPoolRegistry pools;
        private readonly LevelEnterStaticState errors;
        private readonly IOriginalAreaKeyPolicy areaKeys;
        private readonly ISourceDialogEnvironment dialogEnvironment;
        private readonly EverestLoggerProcess logger;
        private readonly SourceEngineSceneState scenes;
        private readonly ILevelEntrySceneFactory sourceScenes;

        public EverestLevelLoaderPolicy(EverestLevelLoaderConstructorPrefix prefix,
            EverestLevelLoaderFailureHandler failures, OriginalLevelLoaderProcessState process,
            SourceEntityPoolRegistry pools, LevelEnterStaticState errors, IOriginalAreaKeyPolicy areaKeys,
            ISourceDialogEnvironment dialogEnvironment, EverestLoggerProcess logger, SourceEngineSceneState scenes,
            ILevelEntrySceneFactory sourceScenes)
        {
            this.prefix = prefix ?? throw new ArgumentNullException(nameof(prefix));
            this.failures = failures ?? throw new ArgumentNullException(nameof(failures));
            this.process = process ?? throw new ArgumentNullException(nameof(process));
            this.pools = pools ?? throw new ArgumentNullException(nameof(pools));
            this.errors = errors ?? throw new ArgumentNullException(nameof(errors));
            this.areaKeys = areaKeys ?? throw new ArgumentNullException(nameof(areaKeys));
            this.dialogEnvironment = dialogEnvironment ?? throw new ArgumentNullException(nameof(dialogEnvironment));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.scenes = scenes ?? throw new ArgumentNullException(nameof(scenes));
            this.sourceScenes = sourceScenes ?? throw new ArgumentNullException(nameof(sourceScenes));
        }

        public bool HasPendingError => errors.ErrorMessage != null;

        public void BeforeOriginalConstructor(ChapterCompletionSession session)
        {
            prefix.BeforeOriginalConstructor(session);
        }

        public void AfterLoadingThreadStarted(OriginalGameThreadSession threads)
        {
            process.LastLoadingThread = threads.Current;
            pools.ClearAllQueues();
        }

        public void OnLoadingThread(OriginalLevelSceneRoot level)
        {
            EverestLevelLoaderSourceEvents.LoadingThread(level);
        }

        public void HandleLoadingFailure(ChapterCompletionSession session, Exception exception)
        {
            failures.Handle(session, exception);
        }

        public void HandleStartFailure(ChapterCompletionSession session, Exception exception)
        {
            var dialogs = dialogEnvironment.Dialog
                          ?? throw new InvalidOperationException("The actual Dialog catalog has not been loaded.");
            var sid = areaKeys.GetSID(areaKeys.GetSessionArea(session));
            var name = areaKeys.GetArea(areaKeys.GetSessionArea(session)).Name;
            var suffix = dialogs.Has(name)
                ? " [" + dialogs.Clean(name, dialogs.Languages["english"]) + "]"
                : null;
            if (session.Mode > 0) suffix += " [" + (AreaMode)session.Mode + "]";
            errors.ErrorMessage = dialogs.Get("postcard_levelloadfailed").Replace("((sid))", sid);
            logger.WarnLevelLoaderStart(session, sid, suffix);
            logger.LogDetailed(exception);
        }

        public void RouteError(ChapterCompletionSession session)
        {
            scenes.NextScene = sourceScenes.CreateLevelEnter(session, false);
        }
    }
}
