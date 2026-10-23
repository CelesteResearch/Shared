using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components.Animation;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using Celeste.Game.Entities.BadelineDummy;
using Celeste.Game.Entities.Gondolas;
using Celeste.Game.Entities.Npcs;
using Celeste.Game.Entities.ReflectionTentacles;
using Celeste.Game.Entities.StarJump;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Game.Execution.Processes;
using Celeste.Game.UI.Dialogue.Textboxes;
using Celeste.Graphics.Content;
using Celeste.Input.Gameplay.Feedback;
using Celeste.Scene.Entities;
using Celeste.Simulation;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Presentation.Backdrops.Parallax;
using Celeste.Simulation.Presentation.Backdrops.Weather.Snow;
using Celeste.Simulation.Presentation.Scene.Transitions;

namespace Celeste.Game.Stories.GoldenRidge
{
    public class OriginalGondolaCutsceneState : OriginalCutsceneEntityState
    {
        private readonly ISourceEngineContext engine;
        private IOriginalGameplayProcess Process => (IOriginalGameplayProcess)engine;
        private ISourceScalarArithmetic Scalar => ((ISourceScalarEnvironment)engine).ScalarArithmetic;
        private ISourceVectorArithmetic VectorArithmetic => ((ISourceVectorEnvironment)engine).VectorArithmetic;
        private ISourceExtremaArithmetic Extrema => ((ISourceExtremaEnvironment)engine).ExtremaArithmetic;
        private ISourceEasingArithmetic Easing => ((ISourceEasingEnvironment)engine).EasingArithmetic;
        private ISourceGameGraphicsResources Graphics => ((ISourceGameGraphicsEnvironment)engine).GameGraphics;
        private IRumbleSession Rumble => ((ISourceRumbleEnvironment)engine).RumbleSession;

        private float Approach(float value, float target, float amount)
        {
            return ScalarMath.Approach(value, target, amount, Extrema);
        }

        private void PlaySound(string name, Vector2 position)
        {
            Process.AudioSession.Play(name, position, Process.SaveContext);
        }

        private enum GondolaStates
        {
            Stopped,
            MovingToCenter,
            InCenter,
            Shaking,
            MovingToEnd,
        }

        private readonly OriginalNpcState theo;

        private readonly OriginalGondolaState gondola;

        private readonly RoomPlayerSession player;

        private BadelineDummyPresentation evil;

        private ParallaxBackdropPresentation loopingCloud;

        private ParallaxBackdropPresentation bottomCloud;

        private WindSnowBackdropPresentation windSnowFg;

        private float LoopCloudsAt;

        private readonly List<OriginalReflectionTentaclesState> tentacles = [];

        private SoundSourceComponentState moveLoopSfx;

        private SoundSourceComponentState haltLoopSfx;

        private float gondolaPercent;

        private bool AutoSnapCharacters;

        private float theoXOffset;

        private float playerXOffset;

        private float gondolaSpeed;

        private float shakeTimer;

        private const float gondolaMaxSpeed = 64f;

        private float anxiety;

        private float anxietyStutter;

#pragma warning disable CS0649 // Retain the original field and its original default state.
        private float anxietyRumble;
#pragma warning restore CS0649

        private OriginalBreathingRumblerState rumbler;

        private GondolaStates gondolaState;

        public OriginalGondolaCutsceneState(ISourceEngineContext engine, OriginalNpcState theo,
            OriginalGondolaState gondola, RoomPlayerSession player)
            : base(engine, false, true)
        {
            this.engine = engine;
            this.theo = theo;
            this.gondola = gondola;
            this.player = player;
        }

        public override void OnBegin(OriginalLevelSceneRoot level)
        {
            level.RegisterAreaComplete();
            foreach (var backdrop in level.Foreground.Backdrops)
                if (backdrop is WindSnowBackdropPresentation)
                    windSnowFg = backdrop as WindSnowBackdropPresentation;

            OwnedComponents.Add(moveLoopSfx = ((ISourceSoundSourceEnvironment)engine).SoundSources.Create());
            OwnedComponents.Add(haltLoopSfx = ((ISourceSoundSourceEnvironment)engine).SoundSources.Create());
            OwnedComponents.Add(new SimulationCoroutine(engine, Cutscene()));
        }

        private IEnumerator Cutscene()
        {
            player.Machine.State = 11;
            yield return player.DummyWalkToExact((int)gondola.X + 16);
            while (!player.OnGround()) yield return null;

            Process.AudioSession.SetMusic("event:/music/lvl1/theo");
            yield return TextboxState.Say("CH4_GONDOLA", engine, EnterTheo, CheckOnTheo, GetUpTheo, LookAtLever,
                PullLever,
                WaitABit, WaitForCenter, SelfieThenStallsOut, MovePlayerLeft, SnapLeverOff, DarknessAppears,
                DarknessConsumes, CantBreath, StartBreathing, Ascend, WaitABit, TheoTakesOutPhone, FaceTheo);
            yield return ShowPhoto();
            EndCutscene(Level);
        }

        public override void OnEnd(OriginalLevelSceneRoot level)
        {
            if (rumbler != null)
            {
                rumbler.RemoveSelf();
                rumbler = null;
            }

            level.CompleteArea();
            if (!WasSkipped)
            {
                ((ISourceScreenWipeEnvironment)engine).ProcessWipe.SpotlightModifier = 120f;
                ((ISourceScreenWipeEnvironment)engine).ProcessWipe.SpotlightFocusPoint =
                    VectorArithmetic.Divide(new Vector2(320f, 180f), 2f);
            }
        }

        private IEnumerator EnterTheo()
        {
            player.Data.Facing = -1;
            yield return 0.2f;
            yield return PanCamera(new(Level.Bounds.Left, theo.Y - 90f), 1f);
            theo.Visible = true;
            var theoStartX = theo.X;
            yield return theo.MoveTo(new(theoStartX + 35f, theo.Y));
            yield return 0.6f;
            yield return theo.MoveTo(new(theoStartX + 60f, theo.Y));
            PlaySound("event:/game/04_cliffside/gondola_theo_fall", theo.Position);
            theo.Sprite.Play("idleEdge");
            yield return 1f;
            theo.Sprite.Play("falling");
            theo.X += 4f;
            theo.Depth = -10010;
            var speed = 80f;
            while (theo.Y < player.Y)
            {
                theo.Y += speed * engine.DeltaTime;
                speed += 120f * engine.DeltaTime;
                yield return null;
            }

            Level.DirectionalShake(new(0f, 1f));
            Rumble.Rumble(2, 1);
            theo.Y = player.Y;
            theo.Sprite.Play("hitGround");
            theo.Sprite.Rate = 0f;
            theo.Depth = 1000;
            theo.Sprite.Scale = new(1.3f, 0.8f);
            yield return 0.5f;
            var start = theo.Sprite.Scale;
            var tween = SourceTweenState.Create(engine.TweenPool, SourceTweenState.TweenMode.Oneshot, null,
                2f,
                true);
            tween.OnUpdate = delegate(SourceTweenState t)
            {
                theo.Sprite.Scale.X = Scalar.Lerp(start.X, 1f, t.Eased);
                theo.Sprite.Scale.Y = Scalar.Lerp(start.Y, 1f, t.Eased);
            };
            OwnedComponents.Add(tween);
            yield return PanCamera(new(Level.Bounds.Left, theo.Y - 120f), 1f);
            yield return 0.6f;
        }

        private IEnumerator CheckOnTheo()
        {
            yield return player.DummyWalkTo(gondola.X - 18f);
        }

        private IEnumerator GetUpTheo()
        {
            yield return 1.4f;
            PlaySound("event:/game/04_cliffside/gondola_theo_recover", theo.Position);
            theo.Sprite.Rate = 1f;
            theo.Sprite.Play("recoverGround");
            yield return 1.6f;
            yield return theo.MoveTo(new(gondola.X - 50f, player.Y));
            yield return 0.2f;
        }

        private IEnumerator LookAtLever()
        {
            yield return theo.MoveTo(new(gondola.X + 7f, theo.Y));
            player.Data.Facing = 1;
            theo.Sprite.Scale.X = -1f;
        }

        private IEnumerator PullLever()
        {
            OwnedComponents.Add(new SimulationCoroutine(engine, player.DummyWalkToExact((int)gondola.X - 7)));
            theo.Sprite.Scale.X = -1f;
            yield return 0.2f;
            PlaySound("event:/game/04_cliffside/gondola_theo_lever_start", theo.Position);
            theo.Sprite.Play("pullVent");
            yield return 1f;
            Rumble.Rumble(1, 1);
            gondola.Lever.Play("pulled");
            theo.Sprite.Play("fallVent");
            yield return 0.6f;
            Level.Shake();
            Rumble.Rumble(2, 2);
            yield return 0.5f;
            yield return PanCamera(gondola.Position + new Vector2(-160f, -120f), 1f);
            yield return 0.5f;
            Level.Background.Backdrops.Add(loopingCloud =
                new(Graphics.GameAtlas.Entries["bgs/04/bgCloudLoop"]));
            Level.Background.Backdrops.Add(bottomCloud =
                new(Graphics.GameAtlas.Entries["bgs/04/bgCloud"]));
            var parallax = loopingCloud;
            var parallax2 = bottomCloud;
            var loopX = true;
            parallax2.LoopX = true;
            parallax.LoopX = loopX;
            var parallax3 = loopingCloud;
            var parallax4 = bottomCloud;
            loopX = false;
            parallax4.LoopY = false;
            parallax3.LoopY = loopX;
            loopingCloud.Position.Y = Level.Camera.Top - loopingCloud.Texture.FrameHeight -
                                      bottomCloud.Texture.FrameHeight;
            bottomCloud.Position.Y = Level.Camera.Top - bottomCloud.Texture.FrameHeight;
            LoopCloudsAt = bottomCloud.Position.Y;
            AutoSnapCharacters = true;
            theoXOffset = theo.X - gondola.X;
            playerXOffset = player.X - gondola.X;
            player.Machine.State = 17;
            var tween = SourceTweenState.Create(engine.TweenPool, SourceTweenState.TweenMode.Oneshot, null,
                16f, true);
            tween.OnUpdate = delegate(SourceTweenState t)
            {
                if (Process.AudioSession.CurrentMusic == "event:/music/lvl1/theo")
                    Process.AudioSession.SetMusicParam("fade", 1f - t.Eased);
            };
            OwnedComponents.Add(tween);
            var soundSource = ((ISourceSoundSourceEnvironment)engine).SoundSources.Create();
            soundSource.Position = gondola.LeftCliffside.Position;
            soundSource.Play("event:/game/04_cliffside/gondola_cliffmechanism_start");
            OwnedComponents.Add(soundSource);
            moveLoopSfx.Play("event:/game/04_cliffside/gondola_movement_loop");
            Level.Shake();
            Rumble.Rumble(2, 3);
            gondolaSpeed = 32f;
            gondola.RotationSpeed = 1f;
            gondolaState = GondolaStates.MovingToCenter;
            yield return 1f;
            yield return MoveTheoOnGondola(12f, false);
            yield return 0.2f;
            theo.Sprite.Scale.X = -1f;
        }

        private IEnumerator WaitABit()
        {
            yield return 1f;
        }

        private IEnumerator WaitForCenter()
        {
            while (gondolaState != GondolaStates.InCenter) yield return null;

            theo.Sprite.Scale.X = 1f;
            yield return 1f;
            yield return MovePlayerOnGondola(-20f);
            yield return 0.5f;
        }

        private IEnumerator SelfieThenStallsOut()
        {
            Process.AudioSession.SetMusic("event:/music/lvl4/minigame");
            OwnedComponents.Add(new SimulationCoroutine(engine, Level.ZoomTo(new(160f, 110f), 2f, 0.5f)));
            yield return 0.3f;
            theo.Sprite.Scale.X = 1f;
            yield return 0.2f;
            OwnedComponents.Add(new SimulationCoroutine(engine, MovePlayerOnGondola(theoXOffset - 8f)));
            yield return 0.4f;
            PlaySound("event:/game/04_cliffside/gondola_theoselfie_halt", theo.Position);
            theo.Sprite.Play("holdOutPhone");
            yield return 1.5f;
            theoXOffset += 4f;
            playerXOffset += 4f;
            gondola.RotationSpeed = -1f;
            gondolaState = GondolaStates.Stopped;
            Rumble.Rumble(2, 2);
            theo.Sprite.Play("takeSelfieImmediate");
            OwnedComponents.Add(new SimulationCoroutine(engine,
                PanCamera(
                    gondola.Position + VectorArithmetic.SafeNormalize(gondola.Destination - gondola.Position) * 32f +
                    new Vector2(-160f, -120f), 0.3f, Easing.CubeOut)));
            yield return 0.5f;
            Level.Flash(PackedColor.White);
            Level.Scheduler.QueueSourceEntity(evil = BadelineDummyPresentation.Create(Level, Vector2.Zero));
            evil.Appear(Level);
            evil.Floatness = 0f;
            evil.Depth = -1000000;
            moveLoopSfx.Stop();
            haltLoopSfx.Play("event:/game/04_cliffside/gondola_halted_loop");
            gondolaState = GondolaStates.Shaking;
            yield return PanCamera(gondola.Position + new Vector2(-160f, -120f), 1f);
            yield return 1f;
        }

        private IEnumerator MovePlayerLeft()
        {
            yield return MovePlayerOnGondola(-20f);
            theo.Sprite.Scale.X = -1f;
            yield return 0.5f;
            yield return MovePlayerOnGondola(20f);
            yield return 0.5f;
            yield return MovePlayerOnGondola(-10f);
            yield return 0.5f;
            player.Data.Facing = 1;
        }

        private IEnumerator SnapLeverOff()
        {
            yield return MoveTheoOnGondola(7f);
            PlaySound("event:/game/04_cliffside/gondola_theo_lever_fail", theo.Position);
            theo.Sprite.Play("pullVent");
            yield return 1f;
            theo.Sprite.Play("fallVent");
            yield return 1f;
            gondola.BreakLever();
            Rumble.Rumble(1, 1);
            Level.Shake();
            yield return 2.5f;
        }

        private IEnumerator DarknessAppears()
        {
            Process.AudioSession.SetMusicParam("calm", 0f);
            yield return 0.25f;
            player.Sprite.Play("tired");
            yield return 0.25f;
            evil.Vanish();
            evil = null;
            yield return 0.3f;
            Level.NextColorGrade("panicattack");
            Level.Shake();
            Rumble.Rumble(0, 1);
            BurstTentacles(3, 90f);
            PlaySound("event:/game/04_cliffside/gondola_scaryhair_01", gondola.Position);
            for (var p = 0f; p < 1f; p += engine.DeltaTime / 2f)
            {
                yield return null;
                Level.Background.Fade = p;
                anxiety = p;
                if (windSnowFg != null) windSnowFg.Alpha = 1f - p;
            }

            yield return 0.25f;
        }

        private IEnumerator DarknessConsumes()
        {
            Level.Shake();
            Rumble.Rumble(1, 1);
            PlaySound("event:/game/04_cliffside/gondola_scaryhair_02", gondola.Position);
            BurstTentacles(2, 60f);
            yield return MoveTheoOnGondola(0f);
            theo.Sprite.Play("comfortStart");
        }

        private IEnumerator CantBreath()
        {
            Level.Shake();
            Rumble.Rumble(2, 1);
            PlaySound("event:/game/04_cliffside/gondola_scaryhair_03", gondola.Position);
            BurstTentacles(1, 30f);
            BurstTentacles(0, 0f, 100f);
            rumbler = new(engine);
            ((OriginalLevelSceneRoot)Scene).Scheduler.QueueSourceEntity(rumbler);
            yield return null;
        }

        private IEnumerator StartBreathing()
        {
            var breathing =
                new OriginalBreathingMinigameState(engine, true, rumbler);
            ((OriginalLevelSceneRoot)Scene).Scheduler.QueueSourceEntity(breathing);
            while (!breathing.Completed) yield return null;

            foreach (var tentacle in tentacles) tentacle.RemoveSelf();

            anxiety = 0f;
            Level.Background.Fade = 0f;
            Level.SnapColorGrade(null);
            gondola.CancelPullSides();
            Level.ResetZoom();
            yield return 0.5f;
            PlaySound("event:/game/04_cliffside/gondola_restart", gondola.Position);
            yield return 1f;
            moveLoopSfx.Play("event:/game/04_cliffside/gondola_movement_loop");
            haltLoopSfx.Stop();
            Level.Shake();
            Rumble.Rumble(2, 2);
            gondolaState = GondolaStates.InCenter;
            gondola.RotationSpeed = 0.5f;
            yield return 1.2f;
        }

        private IEnumerator Ascend()
        {
            gondolaState = GondolaStates.MovingToEnd;
            while (gondolaState != GondolaStates.Stopped) yield return null;

            Level.Shake();
            Rumble.Rumble(2, 2);
            moveLoopSfx.Stop();
            PlaySound("event:/game/04_cliffside/gondola_finish", gondola.Position);
            gondola.RotationSpeed = 0.5f;
            yield return 0.1f;
            while (gondola.Rotation > 0f) yield return null;

            gondola.Rotation = gondola.RotationSpeed = 0f;
            Level.Shake();
            AutoSnapCharacters = false;
            player.Machine.State = 11;
            player.Position = Vector2Geometry.Floor(player.Position);
            while (SourceTrackedEntityCollision.Check(((OriginalLevelSceneRoot)player.Scene).Scheduler.Entities,
                       "Celeste.Solid", player))
                player.Y--;

            theo.Y = player.Position.Y;
            theo.Sprite.Play("comfortRecover");
            theo.Sprite.Scale.X = 1f;
            yield return player.DummyWalkTo(gondola.X + 80f);
            player.Dummy.AutoAnimate = false;
            player.Sprite.Play("tired");
            yield return theo.MoveTo(new(gondola.X + 64f, theo.Y));
            yield return 0.5f;
        }

        private IEnumerator TheoTakesOutPhone()
        {
            player.Data.Facing = 1;
            yield return 0.25f;
            theo.Sprite.Play("usePhone");
            yield return 2f;
        }

        private IEnumerator FaceTheo()
        {
            player.Dummy.AutoAnimate = true;
            yield return 0.2f;
            player.Data.Facing = -1;
            yield return 0.2f;
        }

        private IEnumerator ShowPhoto()
        {
            theo.Sprite.Scale.X = -1f;
            yield return 0.25f;
            yield return player.DummyWalkTo(theo.X + 5f);
            yield return 1f;
            var selfie = new OriginalSelfieState(Scene as OriginalLevelSceneRoot);
            ((OriginalLevelSceneRoot)Scene).Scheduler.QueueSourceEntity(selfie);
            yield return selfie.OpenRoutine("selfieGondola");
            yield return selfie.WaitForInput();
        }

        public override void Update()
        {
            base.Update();
            if (anxietyRumble > 0f) Rumble.RumbleSpecific(anxietyRumble, 0.1f);

            if (((OriginalLevelSceneRoot)Scene).Clock.OnInterval(0.05f, engine))
                anxietyStutter = SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random, 0.1f);

            engine.Effects.AnxietyOrigin = new(0.5f, 0.5f);
            engine.Effects.Anxiety = anxiety * 0.2f + anxietyStutter * anxiety;
            if (moveLoopSfx != null && gondola != null) moveLoopSfx.Position = gondola.Position;

            if (haltLoopSfx != null && gondola != null) haltLoopSfx.Position = gondola.Position;

            if (gondolaState == GondolaStates.MovingToCenter)
            {
                MoveGondolaTowards(0.5f);
                if (gondolaPercent >= 0.5f) gondolaState = GondolaStates.InCenter;
            }
            else if (gondolaState == GondolaStates.InCenter)
            {
                var vector = VectorArithmetic.SafeNormalize(gondola.Destination - gondola.Position) * gondolaSpeed;
                loopingCloud.CameraOffset.X += vector.X * engine.DeltaTime;
                loopingCloud.CameraOffset.Y += vector.Y * engine.DeltaTime;
                windSnowFg.CameraOffset = loopingCloud.CameraOffset;
                loopingCloud.LoopY = true;
            }
            else if (gondolaState != GondolaStates.Stopped)
            {
                if (gondolaState == GondolaStates.Shaking)
                {
                    Level.Wind.X = -400f;
                    if (shakeTimer <= 0f && (gondola.Rotation == 0f || gondola.Rotation < -0.25f))
                    {
                        shakeTimer = 1f;
                        gondola.RotationSpeed = 0.5f;
                    }

                    shakeTimer -= engine.DeltaTime;
                }
                else if (gondolaState == GondolaStates.MovingToEnd)
                {
                    MoveGondolaTowards(1f);
                    if (gondolaPercent >= 1f) gondolaState = GondolaStates.Stopped;
                }
            }

            if (loopingCloud != null && !loopingCloud.LoopY && Level.Camera.Bottom < LoopCloudsAt)
                loopingCloud.LoopY = true;

            if (AutoSnapCharacters)
            {
                theo.Position = gondola.GetRotatedFloorPositionAt(theoXOffset);
                player.Position = gondola.GetRotatedFloorPositionAt(playerXOffset);
                if (evil != null) evil.Position = gondola.GetRotatedFloorPositionAt(-24f, 20f);
            }
        }

        private void MoveGondolaTowards(float percent)
        {
            var num = VectorArithmetic.Length(gondola.Start - gondola.Destination);
            gondolaSpeed = Approach(gondolaSpeed, 64f, 120f * engine.DeltaTime);
            gondolaPercent = Approach(gondolaPercent, percent, gondolaSpeed / num * engine.DeltaTime);
            gondola.Position =
                Vector2Geometry.Floor(gondola.Start + (gondola.Destination - gondola.Start) * gondolaPercent);
            Level.Camera.Position = gondola.Position + new Vector2(-160f, -120f);
        }

        private IEnumerator PanCamera(Vector2 to, float duration, Func<float, float> ease = null)
        {
            if (ease == null) ease = Easing.CubeInOut;

            var from = Level.Camera.Position;
            for (var t = 0f; t < 1f; t += engine.DeltaTime / duration)
            {
                yield return null;
                Level.Camera.Position = from + (to - from) * ease(Extrema.Min(t, 1f));
            }
        }

        private IEnumerator MovePlayerOnGondola(float x)
        {
            player.Sprite.Play("walk");
            player.Data.Facing = Math.Sign(x - playerXOffset);
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            while (playerXOffset != x)
            {
                playerXOffset = Approach(playerXOffset, x, 48f * engine.DeltaTime);
                yield return null;
            }

            player.Sprite.Play("idle");
        }

        private IEnumerator MoveTheoOnGondola(float x, bool changeFacing = true)
        {
            theo.Sprite.Play("walk");
            if (changeFacing) theo.Sprite.Scale.X = Math.Sign(x - theoXOffset);

            // ReSharper disable once CompareOfFloatsByEqualityOperator
            while (theoXOffset != x)
            {
                theoXOffset = Approach(theoXOffset, x, 48f * engine.DeltaTime);
                yield return null;
            }

            theo.Sprite.Play("idle");
        }

        private void BurstTentacles(int layer, float dist, float from = 200f)
        {
            var vector = Level.Camera.Position + new Vector2(160f, 90f);
            var reflectionTentacles = new OriginalReflectionTentaclesState(engine);
            reflectionTentacles.Create(0f, 0, layer, [
                vector + new Vector2(0f - from, 0f),
                vector + new Vector2(-800f, 0f),
            ]);
            reflectionTentacles.SnapTentacles();
            reflectionTentacles.Nodes[0] = vector + new Vector2(0f - dist, 0f);
            var reflectionTentacles2 = new OriginalReflectionTentaclesState(engine);
            reflectionTentacles2.Create(0f, 0, layer, [
                vector + new Vector2(from, 0f),
                vector + new Vector2(800f, 0f),
            ]);
            reflectionTentacles2.SnapTentacles();
            reflectionTentacles2.Nodes[0] = vector + new Vector2(dist, 0f);
            tentacles.Add(reflectionTentacles);
            tentacles.Add(reflectionTentacles2);
            Level.Scheduler.QueueSourceEntity(reflectionTentacles);
            Level.Scheduler.QueueSourceEntity(reflectionTentacles2);
        }
    }
}
