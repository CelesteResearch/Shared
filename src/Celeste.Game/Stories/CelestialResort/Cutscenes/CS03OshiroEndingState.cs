using Celeste.Core.Display;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Components.Animation;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Core.Geometry;
using Celeste.Scene.Entities;
using Celeste.Physics.Collision.Shapes;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.UI.Dialogue.Textboxes;
using Celeste.Game.Entities.Npcs.Oshiro;
using Celeste.Game.Stories.CelestialResort.Cutscenes;
using Celeste.Formats.Map.Entities.Structure;

namespace Celeste.Game.Stories.CelestialResort.Cutscenes
{
    public class CS03OshiroEndingState : OriginalCutsceneEntityState
    {
        private class BgFlash : SceneEntityState
        {
            public float Alpha;

            public BgFlash(ISourceEngineContext engine) : base(((ISourceEntitySourceDataEnvironment)engine)
                .EntitySourceDataRegistration)
            {
                base.Depth = 10100;
            }

            public override void Render(ISourceRenderContext context)
            {
                var camera = ((OriginalLevelSceneRoot)Scene).Camera;
                SourcePrimitiveDrawing.Rect(context, this, camera.X - 10f, camera.Y - 10f, 340f, 200f,
                    PackedColor.Multiply(PackedColor.Black, Alpha));
            }
        }

        private readonly ISourceEngineContext engine;
        private ISourceExtremaArithmetic Extrema => ((ISourceExtremaEnvironment)engine).ExtremaArithmetic;
        private ISourceScalarArithmetic Scalar => ((ISourceScalarEnvironment)engine).ScalarArithmetic;
        private ISourceEasingArithmetic Ease => ((ISourceEasingEnvironment)engine).EasingArithmetic;

        private static OriginalGameGraphicsResources Graphics(ISourceEngineContext engine) =>
            (OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics;

        private IOriginalGameplayProcess Process => (IOriginalGameplayProcess)engine;
        private global::Celeste.Game.Audio.Runtime.OriginalGameAudioSession Audio => Process.AudioSession;
        public const string Flag = "oshiroEnding";

        private OriginalResortRoofEndingState roof;

        private global::Celeste.Game.Gameplay.Enemies.AngryOshiro.OriginalAngryOshiroState angryOshiro;

        private RoomPlayerSession player;

        private SceneEntityState oshiro;

        private Sprite oshiroSprite;

        private global::Celeste.Audio.Fmod.Events.FmodEventReference smashSfx;

        private bool smashRumble;

        public CS03OshiroEndingState(ISourceEngineContext engine, OriginalResortRoofEndingState roof,
            RoomPlayerSession player)
            : base(engine, false, true)
        {
            this.engine = engine;
            this.roof = roof;
            this.player = player;
            base.Depth = -1000000;
        }

        public override void OnBegin(OriginalLevelSceneRoot level)
        {
            level.RegisterAreaComplete();
            OwnedComponents.Add(new SimulationCoroutine(engine, Cutscene(level)));
        }

        public override void Update()
        {
            base.Update();
            if (smashRumble)
            {
                ((global::Celeste.Input.Gameplay.Feedback.ISourceRumbleEnvironment)engine).RumbleSession.Rumble(0, 0);
            }
        }

        private IEnumerator Cutscene(OriginalLevelSceneRoot level)
        {
            player.Machine.State = 11;
            player.Machine.Locked = true;
            player.ForceCameraUpdate = false;
            OwnedComponents.Add(new SimulationCoroutine(engine,
                player.Dummy.RunTo(roof.X + roof.Width - 32f, fastAnimation: true)));
            yield return null;
            player.Dummy.AutoAnimate = false;
            yield return 0.5f;
            angryOshiro = Level.SourceScene.Entities
                .FindFirst<global::Celeste.Game.Gameplay.Enemies.AngryOshiro.OriginalAngryOshiroState>();
            OwnedComponents.Add(new SimulationCoroutine(engine, MoveGhostTo(new Vector2(roof.X + 40f, roof.Y - 12f))));
            yield return 1f;
            player.Dummy.AutoAnimate = true;
            yield return level.ZoomTo(new Vector2(130f, 60f), 2f, 0.5f);
            player.Data.Facing = -1;
            yield return 0.5f;
            yield return TextboxState.Say("CH3_OSHIRO_CHASE_END", engine, GhostSmash);
            yield return GhostSmash(0.5f, final: true);
            Audio.SetMusic(null);
            oshiroSprite = null;
            BgFlash bgFlash = new BgFlash(engine)
            {
                Alpha = 1f
            };
            level.Scheduler.QueueSourceEntity(bgFlash);
            engine.Effects.GameRate = 0f;
            Sprite sprite = Graphics(engine).SpriteFactory.Create("oshiro_boss_lightning");
            sprite.Position = angryOshiro.Position + new Vector2(140f, -100f);
            sprite.Rotation = Vector2Geometry.Angle(sprite.Position, angryOshiro.Position + new Vector2(0f, 10f));
            sprite.Play("once");
            OwnedComponents.Add(sprite);
            yield return null;
            global::Celeste.Game.Execution.Engine.Actions.OriginalCelesteFreeze.Freeze(engine, 0.3f);
            yield return null;
            level.Shake();
            ((global::Celeste.Input.Gameplay.Feedback.ISourceRumbleEnvironment)engine).RumbleSession.Rumble(2, 2);
            smashRumble = false;
            yield return 0.2f;
            engine.Effects.GameRate = 1f;
            level.Flash(PackedColor.White);
            player.Dummy.Gravity = false;
            angryOshiro.Sprite.Play("transformBack");
            player.Sprite.Play("fall");
            roof.BeginFalling = true;
            yield return null;
            engine.Effects.TimeRate = 0.01f;
            player.Sprite.Play("fallFast");
            player.Dummy.Gravity = true;
            player.Data.Motion.Normal.Speed.Y = -200f;
            player.Data.Motion.Normal.Speed.X = 300f;
            Vector2 oshiroFallSpeed = new Vector2(-100f, -250f);
            SourceTweenState tween = SourceTweenState.Create(engine.TweenPool, SourceTweenState.TweenMode.Oneshot,
                Ease.SineInOut, 1.5f, start: true);
            tween.OnUpdate = delegate(SourceTweenState tween2)
            {
                angryOshiro.Sprite.Rotation = tween2.Eased * -100f * ((float)Math.PI / 180f);
            };
            OwnedComponents.Add(tween);
            float t;
            for (t = 0f; t < 2f; t += engine.DeltaTime)
            {
                oshiroFallSpeed.X = ScalarMath.Approach(oshiroFallSpeed.X, 0f, engine.DeltaTime * 400f, Extrema);
                oshiroFallSpeed.Y += engine.DeltaTime * 800f;
                angryOshiro.Position += oshiroFallSpeed * engine.DeltaTime;
                bgFlash.Alpha = ScalarMath.Approach(bgFlash.Alpha, 0f, engine.RawDeltaTime, Extrema);
                engine.Effects.TimeRate =
                    ScalarMath.Approach(engine.Effects.TimeRate, 1f, engine.RawDeltaTime * .6f, Extrema);
                yield return null;
            }

            level.DirectionalShake(new Vector2(0f, -1f), 0.5f);
            ((global::Celeste.Input.Gameplay.Feedback.ISourceRumbleEnvironment)engine).RumbleSession.Rumble(1, 2);
            yield return 1f;
            while (!player.OnGround())
            {
                player.MoveV(1f);
            }

            player.Dummy.AutoAnimate = false;
            player.Sprite.Play("tired");
            angryOshiro.RemoveSelf();
            level.Scheduler.QueueSourceEntity(oshiro = new SceneEntityState(
                ((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration,
                new Vector2(level.Bounds.Left + 110, player.Y)));
            oshiro.OwnedComponents.Add(oshiroSprite = Graphics(engine).SpriteFactory.Create("oshiro"));
            oshiroSprite.Play("fall");
            oshiroSprite.Scale.X = 1f;
            oshiro.Collider = new HitboxColliderGeometry(8f, 8f, -4f, -8f);
            oshiro.OwnedComponents.Add(
                new global::Celeste.Simulation.Presentation.Lighting.VertexLightState(engine, new Vector2(0f, -8f),
                    PackedColor.White, 1f, 16, 32));
            yield return OriginalCutsceneEntityState.CameraTo(engine, player.CameraTarget + new Vector2(0f, 40f), 1f,
                Ease.CubeOut);
            yield return 1.5f;
            Audio.SetMusic("event:/music/lvl3/intro");
            yield return 3f;
            Audio.Play("event:/char/oshiro/chat_get_up", oshiro.Position, Process.SaveContext);
            oshiroSprite.Play("recover");
            float target = oshiro.Y + 4f;
            while (oshiro.Y != target)
            {
                oshiro.Y = ScalarMath.Approach(oshiro.Y, target, 6f * engine.DeltaTime, Extrema);
                yield return null;
            }

            yield return 0.6f;
            yield return TextboxState.Say("CH3_ENDING", engine, OshiroTurns);
            OwnedComponents.Add(new SimulationCoroutine(engine,
                OriginalCutsceneEntityState.CameraTo(engine, level.Camera.Position + new Vector2(-80f, 0f), 3f)));
            yield return 0.5f;
            oshiroSprite.Scale.X = -1f;
            yield return 0.2f;
            t = 0f;
            oshiro.OwnedComponents.Add(((global::Celeste.Simulation.Audio.Sources.ISourceSoundSourceEnvironment)engine)
                .SoundSources.Create().Play("event:/char/oshiro/move_08_roof07_exit"));
            while (oshiro.X > (float)(level.Bounds.Left - 16))
            {
                oshiro.X -= 40f * engine.DeltaTime;
                Sprite sprite2 = oshiroSprite;
                float num;
                t = (num = t + engine.DeltaTime * 2f);
                sprite2.Y = (float)Math.Sin(num) * 2f;
                oshiro.CollideFirst<global::Celeste.Game.Entities.Npcs.Oshiro.OriginalDoorState>("Celeste.Door")
                    ?.Open(oshiro.X);
                yield return null;
            }

            OwnedComponents.Add(new SimulationCoroutine(engine,
                OriginalCutsceneEntityState.CameraTo(engine, level.Camera.Position + new Vector2(80f, 0f), 2f)));
            yield return 1.2f;
            player.Dummy.AutoAnimate = true;
            yield return player.DummyWalkTo(player.X - 16f);
            yield return 2f;
            player.Data.Facing = 1;
            yield return 1f;
            player.ForceCameraUpdate = false;
            player.OwnedComponents.Add(new SimulationCoroutine(engine, RunPlayerRight()));
            EndCutscene(level);
        }

        private IEnumerator OshiroTurns()
        {
            yield return 1f;
            oshiroSprite.Scale.X = -1f;
            yield return 0.2f;
        }

        private IEnumerator MoveGhostTo(Vector2 target)
        {
            if (angryOshiro != null)
            {
                target.Y -= angryOshiro.Height / 2f;
                angryOshiro.EnterDummyMode();
                angryOshiro.Collidable = false;
                while (angryOshiro.Position != target)
                {
                    angryOshiro.Position =
                        ((ISourceVectorEnvironment)engine).VectorArithmetic.Approach(angryOshiro.Position, target,
                            64f * engine.DeltaTime);
                    yield return null;
                }
            }
        }

        private IEnumerator GhostSmash()
        {
            yield return GhostSmash(0f, final: false);
        }

        private IEnumerator GhostSmash(float topDelay, bool final)
        {
            if (angryOshiro == null)
            {
                yield break;
            }

            if (final)
            {
                smashSfx = Audio.Play("event:/char/oshiro/boss_slam_final", angryOshiro.Position, Process.SaveContext);
            }
            else
            {
                smashSfx = Audio.Play("event:/char/oshiro/boss_slam_first", angryOshiro.Position, Process.SaveContext);
            }

            float from = angryOshiro.Y;
            float to = angryOshiro.Y - 32f;
            for (float p = 0f; p < 1f; p += engine.DeltaTime * 2f)
            {
                angryOshiro.Y = ScalarMath.Lerp(from, to, Ease.CubeOut(p), Scalar);
                yield return null;
            }

            yield return topDelay;
            float ground = from + 20f;
            for (float p = 0f; p < 1f; p += engine.DeltaTime * 8f)
            {
                angryOshiro.Y = ScalarMath.Lerp(to, ground, Ease.CubeOut(p), Scalar);
                yield return null;
            }

            angryOshiro.Squish();
            Level.Shake(0.5f);
            ((global::Celeste.Input.Gameplay.Feedback.ISourceRumbleEnvironment)engine).RumbleSession.Rumble(2, 1);
            smashRumble = true;
            roof.StartShaking(0.5f);
            if (!final)
            {
                for (float p = 0f; p < 1f; p += engine.DeltaTime * 16f)
                {
                    angryOshiro.Y = ScalarMath.Lerp(ground, from, Ease.CubeOut(p), Scalar);
                    yield return null;
                }
            }
            else
            {
                angryOshiro.Y = (ground + from) / 2f;
            }

            if (angryOshiro != null)
            {
                player.Dummy.AutoAnimate = false;
                player.Sprite.Play("shaking");
                roof.Wobble(angryOshiro, final);
                if (!final)
                {
                    yield return 0.5f;
                }
            }
        }

        private IEnumerator RunPlayerRight()
        {
            yield return 0.75f;
            yield return player.Dummy.RunTo(player.X + 128f);
        }

        public override void OnEnd(OriginalLevelSceneRoot level)
        {
            Audio.SetMusic("event:/music/lvl3/intro");
            Audio.Stop(smashSfx);
            level.CompleteArea();
            ((global::Celeste.Simulation.Presentation.Scene.Transitions.ISourceScreenWipeEnvironment)engine).ProcessWipe
                .SpotlightFocusPoint = new Vector2(192f, 120f);
        }
    }
}
