using System;
using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Game.Content.Loading;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Engine.Update;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Construction;
using Celeste.Game.Execution.Threading;
using Celeste.Scene.Scenes;
using Celeste.Scene.Scheduling;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Player.Intro;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Game.Execution.LevelLoader
{
    public sealed class OriginalLevelLoaderScene : SourceSceneState, IOriginalEngineDashAssistScene
    {
        public ChapterCompletionSession Session { get; }

        private readonly Vector2? startPosition;
        private readonly OriginalLevelLoadingResources resources;
        private readonly IOriginalAreaDataResolver areas;
        private readonly IInstalledLevelLoaderPolicy installedPolicy;
        private bool started;

        public PlayerIntroType? PlayerIntroTypeOverride;
        public OriginalLevelSceneRoot Level { get; }
        public bool Loaded { get; private set; }

        public OriginalLevelLoaderScene(ISourceEngineContext engine, ChapterCompletionSession session,
            OriginalLevelSceneConstruction construction, OriginalLevelLoadingResources resources,
            IOriginalAreaDataResolver areas, OriginalGameThreadSession threads, Vector2? startPosition = null)
            : this(engine, session, construction, resources, areas, threads, null, startPosition)
        {
        }

        public OriginalLevelLoaderScene(ISourceEngineContext engine, ChapterCompletionSession session,
            OriginalLevelSceneConstruction construction, OriginalLevelLoadingResources resources,
            IOriginalAreaDataResolver areas, OriginalGameThreadSession threads,
            IInstalledLevelLoaderPolicy installedPolicy, Vector2? startPosition = null)
            : base(PrepareEngine(engine, session, threads, installedPolicy),
                ((ISourceSceneCatalogEnvironment)engine).SceneCatalog,
                ((ISourceSceneUpdatePolicyEnvironment)engine).PlainScenePolicy)
        {
            this.installedPolicy = installedPolicy;
            Session = session;
            this.startPosition = startPosition.HasValue ? startPosition : session.RespawnPoint;
            this.resources = resources;
            this.areas = areas;
            Level = construction.CreateLevel();
            if (installedPolicy == null)
            {
                var preparation =
                    (engine as IOriginalChapterPreparationEnvironment)
                    ?.ChapterPreparation;
                if (preparation == null)
                    threads.Start(LoadingThread, "LEVEL_LOADER");
                else
                    threads.Start(LoadingThread, preparation.CreateWorkInfo(session, "LEVEL_LOADER"));
            }
            else if (!installedPolicy.HasPendingError)
            {
                threads.Start(LoadingThreadSafe, "LEVEL_LOADER");
                installedPolicy.AfterLoadingThreadStarted(threads);
            }
            else
            {
                Loaded = true;
            }
        }

        private void LoadingThread()
        {
            var map = Session.MapData;
            var area = areas.Get(Session.AreaID);
            resources.Load(Level, Session, map, area, startPosition);
            installedPolicy?.OnLoadingThread(Level);
            Loaded = true;
        }

        private void LoadingThreadSafe()
        {
            try
            {
                LoadingThread();
            }
            catch (Exception exception)
            {
                installedPolicy.HandleLoadingFailure(Session, exception);
                Loaded = true;
            }
        }

        private void StartLevel()
        {
            started = true;
            var actualSession = Level.Session;
            var playerIntro = PlayerIntroTypeOverride ??
                              (!actualSession.FirstLevel || !actualSession.StartedFromBeginning ||
                               !actualSession.JustStarted
                                  ? PlayerIntroType.Respawn
                                  : actualSession.Mode != 2
                                      ? areas.Get(actualSession.AreaID).IntroType
                                      : PlayerIntroType.WalkInRight);
            Level.LoadLevel(playerIntro, true);
            Level.Session.JustStarted = false;
            if (ReferenceEquals(EngineContext.Frame.Scenes.CurrentScene, this))
                EngineContext.Frame.Scenes.NextScene = Level;
        }

        private static ISourceEngineContext PrepareEngine(ISourceEngineContext engine,
            ChapterCompletionSession session, OriginalGameThreadSession threads,
            IInstalledLevelLoaderPolicy installedPolicy)
        {
            if (engine == null) throw new ArgumentNullException(nameof(engine));
            if (threads.Profile == OriginalGameThreadProfile.Installed && installedPolicy == null)
                throw new ArgumentNullException(nameof(installedPolicy));
            if (threads.Profile == OriginalGameThreadProfile.Original && installedPolicy != null)
                throw new ArgumentException("Original process cannot use an installed loader policy.",
                    nameof(installedPolicy));
            installedPolicy?.BeforeOriginalConstructor(session);
            return engine;
        }

        public override void Update()
        {
            base.Update();
            if (Loaded && !started)
            {
                if (installedPolicy == null)
                    StartLevel();
                else if (!installedPolicy.HasPendingError)
                    try
                    {
                        StartLevel();
                    }
                    catch (Exception exception)
                    {
                        installedPolicy.HandleStartFailure(Session, exception);
                        installedPolicy.RouteError(Session);
                    }
                else
                    installedPolicy.RouteError(Session);
            }
        }

        public void UpdateFirstTrackedDashAssist()
        {
            OriginalEngineDashAssistSceneBody.UpdateFirstTrackedDashAssist(SourceScene, EngineContext);
        }

        public void CommitEntityLists()
        {
            OriginalEngineDashAssistSceneBody.CommitEntityLists(SourceScene);
        }
    }
}
