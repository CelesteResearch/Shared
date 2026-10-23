using Celeste.Input.Runtime;
using Celeste.Input.Devices.Keyboard;
using System;
using System.Numerics;
using System.Xml;
using Celeste.Core.Scheduling;
using Celeste.Core.Rendering;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Controls.Source;
using Celeste.Game.Credits;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Platform.Statistics;
using Celeste.Game.Presentation.Completion;
using Celeste.Game.Presentation.Environment;
using Celeste.Game.Execution.Engine.Update;
using Celeste.Game.Execution.LevelLoader;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Startup;
using Celeste.Scene.Scenes;
using Celeste.Scene.Scheduling;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Player.Intro;
using Celeste.Simulation.Presentation.Scene.Transitions;
using Celeste.Simulation.Runtime.Session;
using Celeste.Simulation.UI.Menus.Completion;
using Celeste.Graphics.Content.Atlas;
using global::Celeste.Game.Execution;

namespace Celeste.Game.Chapters.Flow
{
    public class AreaCompleteSequence : SourceSceneState, IOriginalEngineDashAssistScene
    {
        public ChapterCompletionSession Session;
        private bool finishedSlide;
        private bool canConfirm = true;
        private HiresSnowState snow;
        private float speedrunTimerDelay = 1.1f;
        private float speedrunTimerEase;
        private string speedrunTimerChapterString;
        private string speedrunTimerFileString;
        private string chapterSpeedrunText;
        private AreaCompleteTitlePresentation title;
        private CompleteRendererState complete;
        private string version;

        protected OriginalAreaCompleteInfoState Info =>
            ((IOriginalAreaCompleteInfoEnvironment)EngineContext).AreaCompleteInfo;

        protected OriginalGameInputProcess Input => ((IOriginalGameInputProcessEnvironment)EngineContext).InputSource;
        private OriginalGameTextProcess Text => ((IOriginalGameTextEnvironment)EngineContext).Text;

        public AreaCompleteSequence(ChapterCompletionSession session, XmlElement xml, AtlasData atlas,
            HiresSnowState snow, ISourceEngineContext engine, IInstalledAreaCompleteConstruction installed = null)
            : base(engine, ((ISourceSceneCatalogEnvironment)engine).SceneCatalog,
                ((ISourceSceneUpdatePolicyEnvironment)engine).PlainScenePolicy)
        {
            chapterSpeedrunText = Text.Dialog.Get("OPTIONS_SPEEDRUN_CHAPTER") + ":";
            Session = session;
            version = GameRuntime.Instance.Version.ToString();
            if (session.AreaID != 7)
            {
                string text = installed?.GetCustomCompleteScreenTitle(session);
                if (text == null)
                {
                    string mode = ((OriginalAreaMode)session.Mode).ToString();
                    text = Text.CleanDialog("areacomplete_" + mode + (session.FullClear ? "_fullclear" : ""));
                }

                Vector2 origin = new Vector2(960f, 200f);
                float scale = Math.Min(1600f / Text.ActiveFont.Measure(text).X, 3f);
                title = new AreaCompleteTitlePresentation(origin, text, scale, engine);
            }

            complete = installed == null
                ? new CompleteRendererState(engine, xml, atlas, 1f, () => finishedSlide = true)
                : installed.CreateCompleteRenderer(engine, xml, atlas, 1f, () => finishedSlide = true);
            Renderers.Add(complete);
            if (title != null) complete.RenderUI = (context, scroll) => title.DrawLineUI(context);
            complete.RenderPostUI = RenderUI;
            speedrunTimerChapterString =
                Celeste.Game.Presentation.Hud.Speedrun.SpeedrunTimerState.ShortGameplayFormat(session.Time);
            speedrunTimerFileString =
                Celeste.Game.Presentation.Formatting.OriginalStatsFormatter.FileTime(
                    ((IOriginalGameplayProcess)engine).SaveContext.CurrentSave.Time);
            Celeste.Game.Presentation.Hud.Speedrun.SpeedrunTimerState.CalculateBaseSizes(engine);
            Renderers.Add(this.snow = snow);
            Renderers.UpdateLists();
            if (session.Mode == 0)
            {
                var statistics = ((IOriginalPlatformStatisticsEnvironment)engine).Statistics;
                if (session.AreaID == 1) statistics.Achievements.Register(OriginalAchievement.CH1);
                else if (session.AreaID == 2) statistics.Achievements.Register(OriginalAchievement.CH2);
                else if (session.AreaID == 3) statistics.Achievements.Register(OriginalAchievement.CH3);
                else if (session.AreaID == 4) statistics.Achievements.Register(OriginalAchievement.CH4);
                else if (session.AreaID == 5) statistics.Achievements.Register(OriginalAchievement.CH5);
                else if (session.AreaID == 6) statistics.Achievements.Register(OriginalAchievement.CH6);
                else if (session.AreaID == 7) statistics.Achievements.Register(OriginalAchievement.CH7);
            }
        }

        public override void End()
        {
            base.End();
            complete.Dispose();
        }

        public override void Update()
        {
            base.Update();
            if (Input.MenuConfirm.Pressed && finishedSlide && canConfirm)
            {
                canConfirm = false;
                if (Session.AreaID == 7 && Session.Mode == 0)
                {
                    new FadeWipePresentation(this, false, () =>
                    {
                        Session.RespawnPoint = null;
                        Session.FirstLevel = false;
                        Session.Level = "credits-summit";
                        Session.Audio.Music.Event = "event:/music/lvl8/main";
                        var process = (IOriginalGameplayProcess)EngineContext;
                        Celeste.Game.Audio.OriginalAudioSession.Apply(Session.Audio,
                            process.AudioSession.ChannelOutput, process.AudioApplyPolicy);
                        var loader =
                            ((IOriginalLevelLoaderEnvironment)EngineContext).LevelLoaders.CreateLevelLoader(Session);
                        loader.PlayerIntroTypeOverride = PlayerIntroType.None;
                        loader.Level.SourceScene.QueueSourceEntity(new CreditsChapterSequence(EngineContext));
                        EngineContext.Frame.Scenes.NextScene = loader;
                    });
                }
                else
                {
                    HiresSnowState outSnow = new HiresSnowState(EngineContext);
                    outSnow.Alpha = 0f;
                    outSnow.AttachAlphaTo = new FadeWipePresentation(this, false, () =>
                        EngineContext.Frame.Scenes.NextScene = ((IOriginalOverworldLoaderEnvironment)EngineContext)
                            .OverworldLoaders.CreateOverworldLoader(OverworldStartMode.AreaComplete, outSnow));
                    Renderers.Add(outSnow);
                }
            }

            snow.Alpha = Approach(snow.Alpha, 0f, EngineContext.DeltaTime * 0.5f);
            snow.Direction.Y = Approach(snow.Direction.Y, 1f, EngineContext.DeltaTime * 24f);
            speedrunTimerDelay -= EngineContext.DeltaTime;
            if (speedrunTimerDelay <= 0f)
                speedrunTimerEase = Approach(speedrunTimerEase, 1f, EngineContext.DeltaTime * 2f);
            if (title != null) title.Update();
            if (GameRuntime.PlayMode == GameRuntime.PlayModes.Debug)
            {
                var keyboard = ((ISourceMInputEnvironment)EngineContext).MInput.Keyboard;
                if (keyboard.Pressed(SourceKeys.F2))
                {
                    GameRuntime.ReloadAssets(false, true, false);
                    EngineContext.Frame.Scenes.NextScene =
                        ((IOriginalLevelExitEnvironment)EngineContext).LevelExits.CreateLevelExit(
                            LevelExitMode.Completed,
                            Session);
                }
                else if (keyboard.Pressed(SourceKeys.F3))
                {
                    GameRuntime.ReloadAssets(false, true, true);
                    EngineContext.Frame.Scenes.NextScene =
                        ((IOriginalLevelExitEnvironment)EngineContext).LevelExits.CreateLevelExit(
                            LevelExitMode.Completed,
                            Session);
                }
            }
        }

        private float Approach(float value, float target, float amount)
            => ScalarMath.Approach(value, target, amount, ((ISourceExtremaEnvironment)EngineContext).ExtremaArithmetic);

        protected virtual void RenderUI(ISourceRenderContext context)
        {
            SourceScene.Entities.Render(context);
            Info.Info(context, this, speedrunTimerEase, speedrunTimerChapterString, speedrunTimerFileString,
                chapterSpeedrunText, version);
            if (complete.HasUI && title != null) title.Render(context);
        }

        public void UpdateFirstTrackedDashAssist() =>
            OriginalEngineDashAssistSceneBody.UpdateFirstTrackedDashAssist(SourceScene, EngineContext);

        public void CommitEntityLists() => OriginalEngineDashAssistSceneBody.CommitEntityLists(SourceScene);
    }
}
