using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Scheduling;
using Celeste.Game.Controls.Source;
using Celeste.Game.Entities.Birds;
using Celeste.Game.Entities.Bridges;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Presentation.Hud.Speedrun;
using Celeste.Game.Presentation.Particles;
using Celeste.Input.Runtime;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Presentation.Backdrops.Weather.Snow;

namespace Celeste.Game.Stories.Prologue.Ending
{
    public class CS00EndingState : OriginalCutsceneEntityState
    {
        private class EndingCutsceneDelay : SceneEntityState
        {
            public EndingCutsceneDelay(ISourceEngineContext engine)
                : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
            {
                OwnedComponents.Add(new SimulationCoroutine(engine, Routine()));
            }

            private IEnumerator Routine()
            {
                yield return 3f;
                (Scene as OriginalLevelSceneRoot).CompleteArea(false);
            }
        }

        private readonly ISourceEngineContext engine;
        private IOriginalGameplayProcess Process => (IOriginalGameplayProcess)engine;
        private OriginalGameInputProcess Input => ((IOriginalGameInputProcessEnvironment)engine).InputSource;
        private ISourceEasingArithmetic Ease => ((ISourceEasingEnvironment)engine).EasingArithmetic;
        private ISourceExtremaArithmetic Extrema => ((ISourceExtremaEnvironment)engine).ExtremaArithmetic;
        private readonly RoomPlayerSession player;

        private readonly BirdNpcState bird;

        private readonly OriginalBridgeState bridge;

        private bool keyOffed;

        private PrologueEndingTextPresentation endingText;

        public CS00EndingState(ISourceEngineContext engine, RoomPlayerSession player, BirdNpcState bird,
            OriginalBridgeState bridge)
            : base(engine, false, true)
        {
            this.engine = engine;
            this.player = player;
            this.bird = bird;
            this.bridge = bridge;
        }

        public override void OnBegin(OriginalLevelSceneRoot level)
        {
            OwnedComponents.Add(new SimulationCoroutine(engine, Cutscene(level)));
        }

        private IEnumerator Cutscene(OriginalLevelSceneRoot level)
        {
            while (engine.Effects.TimeRate > 0f)
            {
                yield return null;
                if (engine.Effects.TimeRate < 0.5f && bridge != null) bridge.StopCollapseLoop();

                level.StopShake();
                ((ISourceMInputEnvironment)engine).MInput.GamePads[Input.Gamepad].StopRumble();
                engine.Effects.TimeRate -= engine.Frame.RawDeltaTime * 2f;
            }

            engine.Effects.TimeRate = 0f;
            player.Machine.State = 11;
            player.Data.Facing = 1;
            yield return WaitFor(1f);
            var instance = Process.AudioSession.Play("event:/game/general/bird_in", bird.Position, Process.SaveContext);
            bird.Facing = -1;
            bird.Sprite.Play("fall");
            var percent = 0f;
            var from = bird.Position;
            var to = bird.StartPosition;
            while (percent < 1f)
            {
                bird.Position = from + (to - from) * Ease.QuadOut(percent);
                Process.AudioSession.Position(instance, bird.Position, Process.SaveContext);
                if (percent > 0.5f) bird.Sprite.Play("fly");

                percent += engine.Frame.RawDeltaTime * 0.5f;
                yield return null;
            }

            bird.Position = to;
            Process.AudioSession.Play("event:/game/general/bird_land_dirt", bird.Position, Process.SaveContext);
            OriginalDustBurstSource.Burst(engine, bird.Position, -(float)Math.PI / 2f, 12);
            bird.Sprite.Play("idle");
            yield return WaitFor(0.5f);
            bird.Sprite.Play("peck");
            yield return WaitFor(1.1f);
            yield return bird.ShowDashTutorial();
            while (true)
            {
                var aimVector = Input.GetAimVector();
                if (aimVector.X > 0f && aimVector.Y < 0f && Input.Dash.Pressed) break;

                yield return null;
            }

            player.Machine.State = 16;
            player.Data.Dashes = 0;
            level.Session.Inventory.Dashes = 1;
            engine.Effects.TimeRate = 1f;
            keyOffed = true;
            Process.AudioSession.CurrentMusicEventInstance.TriggerCue();
            bird.OwnedComponents.Add(new SimulationCoroutine(engine, bird.HideTutorial()));
            yield return 0.25f;
            bird.OwnedComponents.Add(new SimulationCoroutine(engine, bird.StartleAndFlyAway()));
            while (!player.Dead && !player.OnGround()) yield return null;

            yield return 2f;
            Process.AudioSession.ChannelOutput.SetMusic("event:/music/lvl0/title_ping");
            yield return 2f;
            endingText = new(engine, false);
            ((ISourceScene)Scene).SourceScene.QueueSourceEntity(endingText);
            var bgSnowBackdropPresentation = level.Background.Get<SnowBackdropPresentation>();
            var fgSnowBackdropPresentation = level.Foreground.Get<SnowBackdropPresentation>();
            level.Renderers.Add(level.HiresSnow = new(engine));
            level.HiresSnow.Alpha = 0f;
            var ease = 0f;
            while (ease < 1f)
            {
                ease += engine.Frame.DeltaTime * 0.25f;
                var num = Ease.CubeInOut(ease);
                if (fgSnowBackdropPresentation != null)
                    fgSnowBackdropPresentation.Alpha -= engine.Frame.DeltaTime * 0.5f;

                if (bgSnowBackdropPresentation != null)
                    bgSnowBackdropPresentation.Alpha -= engine.Frame.DeltaTime * 0.5f;

                level.HiresSnow.Alpha =
                    ScalarMath.Approach(level.HiresSnow.Alpha, 1f, engine.Frame.DeltaTime * 0.5f, Extrema);
                endingText.Position = new(960f, 540f - 1080f * (1f - num));
                level.Camera.Y = level.Bounds.Top - 3900f * num;
                yield return null;
            }

            EndCutscene(level);
        }

        private IEnumerator WaitFor(float time)
        {
            for (var t = 0f; t < time; t += engine.Frame.RawDeltaTime) yield return null;
        }

        public override void OnEnd(OriginalLevelSceneRoot level)
        {
            if (WasSkipped)
            {
                if (bird != null) bird.Visible = false;

                if (player != null)
                {
                    player.Position = new(2120f, 40f);
                    player.Machine.State = 11;
                    player.Dummy.AutoAnimate = false;
                    player.Sprite.Play("tired");
                    player.Data.Motion.Normal.Speed = Vector2.Zero;
                }

                if (!keyOffed) Process.AudioSession.CurrentMusicEventInstance.TriggerCue();

                if (level.HiresSnow == null) level.Renderers.Add(level.HiresSnow = new(engine));

                level.HiresSnow.Alpha = 1f;
                var snow = level.Background.Get<SnowBackdropPresentation>();
                if (snow != null) snow.Alpha = 0f;

                var snow2 = level.Foreground.Get<SnowBackdropPresentation>();
                if (snow2 != null) snow2.Alpha = 0f;

                if (endingText != null) level.Scheduler.RemoveEntity(endingText);

                level.Scheduler.QueueSourceEntity(
                    endingText = new(engine, true));
                endingText.Position = new(960f, 540f);
                level.Camera.Y = level.Bounds.Top - 3900;
            }

            engine.Effects.TimeRate = 1f;
            level.PauseLock = true;
            level.Scheduler.Entities.FindFirst<SpeedrunTimerState>().CompleteTimer = 10f;
            level.Scheduler.QueueSourceEntity(new EndingCutsceneDelay(engine));
        }
    }
}
