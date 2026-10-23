using Celeste.Game.Audio;
using System.Collections;
using System.Numerics;
using System.Xml;
using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Game.Chapters.Flow.Restarts;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Platform.Statistics;
using Celeste.Game.Presentation.Environment;
using Celeste.Game.Presentation.Hud;
using Celeste.Game.Execution.Engine.Update;
using Celeste.Game.Execution.LevelLoader;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Threading;
using Celeste.Game.Save.Runtime;
using Celeste.Scene.Entities;
using Celeste.Scene.Scenes;
using Celeste.Scene.Scheduling;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Player.Intro;
using Celeste.Simulation.Presentation.Hud.Saving;
using Celeste.Simulation.Presentation.Scene.Transitions;
using Celeste.Simulation.Runtime.Session;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Game.Chapters.Flow
{
    public class LevelExitSequence : SourceSceneState, IOriginalEngineDashAssistScene
    {
        public readonly LevelExitMode Mode;
        public readonly ChapterCompletionSession Session;
        private float timer;
        public XmlElement CompleteXml;
        public AtlasData CompleteAtlas;
        private bool completeLoaded;
        public bool IsCompleteLoaded => completeLoaded;
        public HiresSnowState Snow;
        protected OverworldLoaderSequence overworldLoader;
        public string GoldenStrawberryEntryLevel;
        private const float MinTimeForCompleteScreen = 3.3f;
        public object CompleteMetadata;

        public LevelExitSequence(LevelExitMode mode, ChapterCompletionSession session,
            ISourceEngineContext engine, HiresSnowState snow = null,
            IInstalledLevelExitConstructorPolicy installedConstructor = null)
            : base(PrepareEngine(engine, session, installedConstructor),
                ((ISourceSceneCatalogEnvironment)engine).SceneCatalog,
                ((ISourceSceneUpdatePolicyEnvironment)engine).PlainScenePolicy)
        {
            Renderers.Add(new HudRendererState());
            Session = session;
            Mode = mode;
            Snow = snow;
            installedConstructor?.AfterConstructor(this, mode, session, snow);
        }

        private static ISourceEngineContext PrepareEngine(ISourceEngineContext engine,
            ChapterCompletionSession session, IInstalledLevelExitConstructorPolicy installedConstructor)
        {
            installedConstructor?.BeforeConstructor(session);
            return engine;
        }

        public override void Begin()
        {
            base.Begin();
            if (Mode != LevelExitMode.GoldenBerryRestart)
                ((ISaveLoadIconEnvironment)EngineContext).SaveLoadIconProcess.Show(this);
            bool flag = Snow == null;
            if (flag)
                Snow = new HiresSnowState(EngineContext);
            if (Mode == LevelExitMode.Completed)
            {
                Snow.Direction = new Vector2(0f, 16f);
                if (flag)
                    Snow.Reset();
                var preparation =
                    (EngineContext as global::Celeste.Game.Content.Loading.IOriginalChapterPreparationEnvironment)
                    ?.ChapterPreparation;
                if (preparation == null)
                    ((IOriginalThreadEnvironment)EngineContext).Threads.Start(LoadCompleteThread, "COMPLETE_LEVEL");
                else
                    ((IOriginalThreadEnvironment)EngineContext).Threads.Start(LoadCompleteThread,
                        preparation.CreateWorkInfo(Session, "COMPLETE_LEVEL"));
                ((IOriginalLevelExitCompletionEnvironment)EngineContext).LevelExitCompletionPolicy.PlayMusic(this);
                ((IOriginalGameplayProcess)EngineContext).AudioSession.ChannelOutput.SetAmbience(null);
            }

            if (Mode == LevelExitMode.GiveUp)
                overworldLoader =
                    ((IOriginalOverworldLoaderEnvironment)EngineContext).OverworldLoaders.CreateOverworldLoader(
                        OverworldStartMode.AreaQuit, Snow);
            else if (Mode == LevelExitMode.SaveAndQuit)
                overworldLoader =
                    ((IOriginalOverworldLoaderEnvironment)EngineContext).OverworldLoaders.CreateOverworldLoader(
                        OverworldStartMode.MainMenu, Snow);
            else if (Mode == LevelExitMode.CompletedInterlude)
                overworldLoader =
                    ((IOriginalOverworldLoaderEnvironment)EngineContext).OverworldLoaders.CreateOverworldLoader(
                        OverworldStartMode.AreaComplete, Snow);
            var entity =
                new SceneEntityState(((ISourceEntitySourceDataEnvironment)EngineContext).EntitySourceDataRegistration);
            SourceScene.QueueSourceEntity(entity);
            entity.OwnedComponents.Add(new SimulationCoroutine(EngineContext, Routine()));
            if (Mode != LevelExitMode.Restart && Mode != LevelExitMode.GoldenBerryRestart)
            {
                Renderers.Add(Snow);
                if (flag)
                    new FadeWipePresentation(this, true);
            }

            ((IOriginalPlatformStatisticsEnvironment)EngineContext).Statistics.Store();
            Renderers.UpdateLists();
        }

        private void LoadCompleteThread()
        {
            ((IOriginalLevelExitCompletionEnvironment)EngineContext).LevelExitCompletionPolicy.Load(this);
            completeLoaded = true;
        }

        private IEnumerator Routine()
        {
            if (Mode != LevelExitMode.GoldenBerryRestart)
            {
                var userIO = ((IOriginalUserIOEnvironment)EngineContext).UserIO;
                userIO.SaveHandler(true, true);
                while (userIO.Saving)
                    yield return null;
                if (Mode == LevelExitMode.Completed)
                    while (!completeLoaded)
                        yield return null;
                while (((ISaveLoadIconEnvironment)EngineContext).SaveLoadIconProcess.OnScreen)
                    yield return null;
            }

            if (Mode == LevelExitMode.Completed)
            {
                while (timer < MinTimeForCompleteScreen)
                    yield return null;
                ((IOriginalGameplayProcess)EngineContext).AudioSession.SetMusicParam("end", 1f);
                EngineContext.Frame.Scenes.NextScene = ((IOriginalLevelExitCompletionEnvironment)EngineContext)
                    .LevelExitCompletionPolicy.CreateAreaComplete(this);
            }
            else if (Mode == LevelExitMode.GiveUp || Mode == LevelExitMode.SaveAndQuit ||
                     Mode == LevelExitMode.CompletedInterlude)
                EngineContext.Frame.Scenes.NextScene = overworldLoader;
            else
            {
                if (Mode != LevelExitMode.Restart && Mode != LevelExitMode.GoldenBerryRestart)
                    yield break;
                ChapterCompletionSession session;
                if (Mode == LevelExitMode.GoldenBerryRestart)
                {
                    if ((Session.Audio.Music.Event == "event:/music/lvl7/main" ||
                         Session.Audio.Music.Event == "event:/music/lvl7/final_ascent") &&
                        Session.Audio.Music.GetProgress() > 0)
                        ((IOriginalGameplayProcess)EngineContext).AudioSession.ChannelOutput.SetMusic(null);
                    session = ((IOriginalLevelRestartEnvironment)EngineContext).LevelRestartPolicy.Restart(Session,
                        GoldenStrawberryEntryLevel, true);
                }
                else
                    session = ((IOriginalLevelRestartEnvironment)EngineContext).LevelRestartPolicy.Restart(Session,
                        null,
                        false);

                var levelLoader =
                    ((IOriginalLevelLoaderEnvironment)EngineContext).LevelLoaders.CreateLevelLoader(session);
                if (Mode == LevelExitMode.GoldenBerryRestart)
                    levelLoader.PlayerIntroTypeOverride = PlayerIntroType.Respawn;
                EngineContext.Frame.Scenes.NextScene = levelLoader;
            }
        }

        public override void Update()
        {
            timer += EngineContext.DeltaTime;
            base.Update();
        }

        public void UpdateFirstTrackedDashAssist()
            => OriginalEngineDashAssistSceneBody.UpdateFirstTrackedDashAssist(SourceScene, EngineContext);

        public void CommitEntityLists()
            => OriginalEngineDashAssistSceneBody.CommitEntityLists(SourceScene);
    }
}
