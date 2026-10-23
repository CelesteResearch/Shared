using Celeste.Core.Display;
using SpeedrunTimerState = Celeste.Game.Presentation.Hud.Speedrun.SpeedrunTimerState;
using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Core.Rendering;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.Easing;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Input.Gameplay;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Player.Intro;
using Celeste.Simulation.Presentation.Hud.Speedrun;
using Celeste.Simulation.Presentation.Scene.Transitions;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Game.Settings;
using Celeste.Game.Controls.Source;
using Celeste.Graphics.Content;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Chapters.Flow;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Save.Runtime;
using Celeste.Game.Entities.Npcs;
using Celeste.Game.Entities.Npcs.Oshiro;
using Celeste.Game.Entities.BadelineDummy;
using Celeste.Game.Presentation.Hud.Counters;
using Celeste.Game.Presentation.Hud.Speedrun;
using Celeste.Game.UI.Dialogue.Textboxes;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Display;
using Celeste.Graphics.Display.Colors;
using global::Celeste.Game.Execution;

namespace Celeste.Game.Stories.Epilogue
{
    public class CS08EndingState : OriginalCutsceneEntityState
    {
        public class TimeDisplay : SourceComponentState
        {
            public Vector2 Position;

            public string Time;

            public Vector2 RenderPosition =>
                Vector2Geometry.Round(((Entity != null) ? ((ISourceEntityPosition)Entity).Position : Vector2.Zero) +
                                      Position);

            private readonly ISourceEngineContext engine;

            public TimeDisplay(ISourceEngineContext engine, string time)
                : base(active: true, visible: true)
            {
                this.engine = engine;
                Time = time;
            }

            public override void Render(ISourceRenderContext context)
                => SpeedrunTimerState.DrawTimeSource(engine, context, Entity, RenderPosition, Time);
        }

        private RoomPlayerSession player;

        private OriginalEpilogueGrannyState granny;

        private OriginalEpilogueTheoState theo;

        private BadelineDummyPresentation badeline;

        private SceneEntityState oshiro;

        private SpriteImage vignette;

        private SpriteImage vignettebg;

        private string endingDialog;

        private float fade;

        private bool showVersion;

        private float versionAlpha;

        private SimulationCoroutine cutscene;

        private readonly string version;
        private readonly ISourceEngineContext engine;
        private IOriginalGameplayProcess Process => (IOriginalGameplayProcess)engine;

        private OriginalAreaCompleteInfoState Info => ((IOriginalAreaCompleteInfoEnvironment)engine).AreaCompleteInfo;

        public CS08EndingState(ISourceEngineContext engine)
            : this(engine, global::Celeste.Game.Execution.GameRuntime.Instance.Version.ToString())
        {
        }

        private CS08EndingState(ISourceEngineContext engine, string version)
            : base(engine, fadeInOnSkip: false, endingChapterAfter: true)
        {
            this.engine = engine;
            this.version = version;
            Tags = ((IOriginalGameTagsEnvironment)engine).Tags.HUD.Value |
                   ((IOriginalGameTagsEnvironment)engine).Tags.PauseUpdate.Value;
            RemoveOnSkipped = false;
        }

        public override void OnBegin(OriginalLevelSceneRoot level)
        {
            level.SaveQuitDisabled = true;
            string text = "";
            int totalStrawberries =
                ((IOriginalSaveCollectibleTotalsEnvironment)engine).SaveCollectibleTotals.GetTotalStrawberriesSafe(
                    Process.SaveContext.CurrentSave);
            if (totalStrawberries < 20)
            {
                text = "final1";
                endingDialog = "EP_PIE_DISAPPOINTED";
            }
            else if (totalStrawberries < 50)
            {
                text = "final2";
                endingDialog = "EP_PIE_GROSSED_OUT";
            }
            else if (totalStrawberries < 90)
            {
                text = "final3";
                endingDialog = "EP_PIE_OKAY";
            }
            else if (totalStrawberries < 150)
            {
                text = "final4";
                endingDialog = "EP_PIE_REALLY_GOOD";
            }
            else
            {
                text = "final5";
                endingDialog = "EP_PIE_AMAZING";
            }

            OwnedComponents.Add(vignettebg =
                new SpriteImage(
                    ((Celeste.Game.Execution.Graphics.OriginalGameGraphicsResources)
                        ((ISourceGameGraphicsEnvironment)engine).GameGraphics).PortraitsAtlas["finalbg"]));
            vignettebg.Visible = false;
            OwnedComponents.Add(vignette =
                new SpriteImage(
                    ((Celeste.Game.Execution.Graphics.OriginalGameGraphicsResources)
                        ((ISourceGameGraphicsEnvironment)engine).GameGraphics).PortraitsAtlas[text]));
            vignette.Visible = false;
            vignette.CenterOrigin();
            vignette.Position = new Vector2(960f, 540f);
            OwnedComponents.Add(cutscene = new SimulationCoroutine(engine, Cutscene(level)));
        }

        private IEnumerator Cutscene(OriginalLevelSceneRoot level)
        {
            level.ZoomSnap(new Vector2(164f, 120f), 2f);
            level.Wipe.Cancel();
            new FadeWipePresentation(level, wipeIn: true);
            while (player == null)
            {
                granny = level.Scheduler.Entities.FindFirst<OriginalEpilogueGrannyState>();
                theo = level.Scheduler.Entities.FindFirst<OriginalEpilogueTheoState>();
                player = level.Scheduler.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);
                yield return null;
            }

            player.Machine.State = 11;
            yield return 1f;
            yield return player.DummyWalkToExact((int)player.X + 16);
            yield return 0.25f;
            yield return TextboxState.Say("EP_CABIN", engine, BadelineEmerges, OshiroEnters, OshiroSettles, MaddyTurns);
            FadeWipePresentation fadeWipe = new FadeWipePresentation(Level, wipeIn: false);
            fadeWipe.Duration = 1.5f;
            yield return fadeWipe.Wait();
            fade = 1f;
            yield return TextboxState.Say("EP_PIE_START", engine);
            yield return 0.5f;
            vignettebg.Visible = true;
            vignette.Visible = true;
            vignettebg.Color = PackedColor.Black;
            vignette.Color = PackedColor.White * 0f;
            OwnedComponents.Add(vignette);
            float p;
            for (p = 0f; p < 1f; p += engine.DeltaTime)
            {
                vignette.Color = PackedColor.White * ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeIn(p);
                vignette.Scale = Vector2.One * (1f + 0.25f * (1f - p));
                vignette.Rotation = 0.05f * (1f - p);
                yield return null;
            }

            vignette.Color = PackedColor.White;
            vignettebg.Color = PackedColor.White;
            yield return 2f;
            p = 1f;
            float p2;
            for (p2 = 0f; p2 < 1f; p2 += engine.DeltaTime / p)
            {
                float num = ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeOut(p2);
                vignette.Position = Vector2Interpolation.Lerp(new Vector2(960f, 540f),
                    new Vector2(960f, 540f) + new Vector2(0f, 140f), num,
                    ((ISourceScalarEnvironment)engine).ScalarArithmetic);
                vignette.Scale = Vector2.One * (0.65f + 0.35f * (1f - num));
                vignette.Rotation = -0.025f * num;
                yield return null;
            }

            yield return TextboxState.Say(endingDialog, engine);
            yield return 0.25f;
            p = 2f;
            Vector2 posFrom = vignette.Position;
            p2 = vignette.Rotation;
            float scaleFrom = vignette.Scale.X;
            for (float p3 = 0f; p3 < 1f; p3 += engine.DeltaTime / p)
            {
                float amount = ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeOut(p3);
                vignette.Position = Vector2Interpolation.Lerp(posFrom, new Vector2(960f, 540f), amount,
                    ((ISourceScalarEnvironment)engine).ScalarArithmetic);
                vignette.Scale = Vector2.One *
                                 ScalarMath.Lerp(scaleFrom, 1f, amount,
                                     ((ISourceScalarEnvironment)engine).ScalarArithmetic);
                vignette.Rotation =
                    ScalarMath.Lerp(p2, 0f, amount, ((ISourceScalarEnvironment)engine).ScalarArithmetic);
                yield return null;
            }

            EndCutscene(level, removeSelf: false);
        }

        public override void OnEnd(OriginalLevelSceneRoot level)
        {
            vignette.Visible = true;
            vignette.Color = PackedColor.White;
            vignette.Position = new Vector2(960f, 540f);
            vignette.Scale = Vector2.One;
            vignette.Rotation = 0f;
            if (player != null)
            {
                player.Data.Motion.Normal.Speed = Vector2.Zero;
            }

            ((ISourceScene)Scene).SourceScene.Entities.FindFirst<TextboxState>()?.RemoveSelf();
            cutscene.RemoveSelf();
            OwnedComponents.Add(new SimulationCoroutine(engine, EndingRoutine()));
        }

        private IEnumerator EndingRoutine()
        {
            Info.InitializePie((Scene as OriginalLevelSceneRoot)?.Session);
            IEnumerator orig = OriginalEndingRoutine();
            while (orig.MoveNext()) yield return orig.Current;
            Info.DisposePie();
        }

        private IEnumerator OriginalEndingRoutine()
        {
            Level.InCutscene = true;
            Level.PauseLock = true;
            yield return 0.5f;
            TimeSpan timeSpan = TimeSpan.FromTicks(Process.SaveContext.CurrentSave.Time);
            string text = (int)timeSpan.TotalHours + timeSpan.ToString("\\:mm\\:ss\\.fff");
            StrawberriesCounterState strawbs = new StrawberriesCounterState(engine, centeredX: true,
                ((IOriginalSaveCollectibleTotalsEnvironment)engine).SaveCollectibleTotals.GetTotalStrawberriesSafe(
                    Process.SaveContext.CurrentSave), 175, showOutOf: true);
            DeathsCounterState deaths = new DeathsCounterState(engine, OriginalAreaMode.Normal, centeredX: true,
                Process.SaveContext.CurrentSave.TotalDeaths);
            TimeDisplay time = new TimeDisplay(engine, text);
            float timeWidth = SpeedrunTimerState.TimeWidth(SpeedrunTimerState.GetMetrics(engine), text);
            OwnedComponents.Add(strawbs);
            OwnedComponents.Add(deaths);
            OwnedComponents.Add(time);
            Vector2 from = new Vector2(960f, 1180f);
            Vector2 to = new Vector2(960f, 940f);
            for (float p = 0f; p < 1f; p += engine.DeltaTime / 0.5f)
            {
                Vector2 vector = Vector2Interpolation.Lerp(from, to,
                    ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeOut(p),
                    ((ISourceScalarEnvironment)engine).ScalarArithmetic);
                strawbs.Position = vector + new Vector2(-170f, 0f);
                deaths.Position = vector + new Vector2(170f, 0f);
                time.Position = vector + new Vector2((0f - timeWidth) / 2f, 100f);
                yield return null;
            }

            showVersion = true;
            yield return 0.25f;
            while (!((IOriginalGameInputProcessEnvironment)engine).InputSource.MenuConfirm.Pressed)
            {
                yield return null;
            }

            showVersion = false;
            yield return 0.25f;
            Level.CompleteArea(spotlightWipe: false);
        }

        private IEnumerator MaddyTurns()
        {
            yield return 0.1f;
            player.Data.Facing = 0 - player.Data.Facing;
            yield return 0.1f;
        }

        private IEnumerator BadelineEmerges()
        {
            Level.Displacement.AddBurst(player.Center, 0.5f, 8f, 32f, 0.5f);
            Level.Session.Inventory.Dashes = 1;
            player.Data.Dashes = 1;
            Level.Scheduler.QueueSourceEntity(badeline = BadelineDummyPresentation.Create(Level, player.Position));
            Process.AudioSession.Play("event:/char/badeline/maddy_split", player.Position, Process.SaveContext);
            badeline.Sprite.Scale.X = 1f;
            yield return badeline.FloatTo(player.Position + new Vector2(-12f, -16f), 1, faceDirection: false);
        }

        private IEnumerator OshiroEnters()
        {
            FadeWipePresentation fadeWipe = new FadeWipePresentation(Level, wipeIn: false);
            fadeWipe.Duration = 1.5f;
            yield return fadeWipe.Wait();
            fade = 1f;
            yield return 0.25f;
            float x = player.X;
            player.X = granny.X + 8f;
            badeline.X = player.X + 12f;
            player.Data.Facing = -1;
            badeline.Sprite.Scale.X = -1f;
            granny.X = x + 8f;
            theo.X += 16f;
            Level.Scheduler.QueueSourceEntity(oshiro = new SceneEntityState(
                ((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration,
                new Vector2(granny.X - 24f, granny.Y + 4f)));
            OshiroSpriteState component = new OshiroSpriteState(engine, 1);
            oshiro.OwnedComponents.Add(component);
            fade = 0f;
            fadeWipe = new FadeWipePresentation(Level, wipeIn: true);
            fadeWipe.Duration = 1f;
            yield return 0.25f;
            while (oshiro.Y > granny.Y - 4f)
            {
                oshiro.Y -= engine.DeltaTime * 32f;
                yield return null;
            }
        }

        private IEnumerator OshiroSettles()
        {
            Vector2 from = oshiro.Position;
            Vector2 to = oshiro.Position + new Vector2(40f, 8f);
            for (float p = 0f; p < 1f; p += engine.DeltaTime)
            {
                oshiro.Position =
                    Vector2Interpolation.Lerp(from, to, p, ((ISourceScalarEnvironment)engine).ScalarArithmetic);
                yield return null;
            }

            granny.Sprite.Scale.X = 1f;
            yield return null;
        }

        public override void Update()
        {
            versionAlpha = ScalarMath.Approach(versionAlpha, showVersion ? 1 : 0, engine.DeltaTime * 5f,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            base.Update();
        }

        public override void Render(ISourceRenderContext context)
        {
            if (fade > 0f)
            {
                SourcePrimitiveDrawing.Rect(context, this, -10f, -10f, 1940f, 1100f, PackedColor.Black * fade);
            }

            base.Render(context);
            if (((ISettingsContext)engine).Settings.SpeedrunClock != (int)SpeedrunClockMode.Off &&
                versionAlpha > 0f)
            {
                Info.VersionNumberAndVariants(context, this, version, versionAlpha, 1f);
            }

            global::Celeste.Core.Scheduling.SourceRuntimeExtensions
                .Get<IOriginalAreaCompleteInfoHooksEnvironment>(engine)
                ?.AfterSourceCS08EndingRendered(context, this, versionAlpha);
        }
    }
}
