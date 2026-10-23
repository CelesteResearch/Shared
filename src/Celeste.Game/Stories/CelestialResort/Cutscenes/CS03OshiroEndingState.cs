using System;
using System.Collections;
using System.Numerics;
using Celeste.Audio.Fmod.Events;
using Celeste.Core.Components;
using Celeste.Core.Components.Animation;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Game.Audio.Runtime;
using Celeste.Game.Entities.Npcs.Oshiro;
using Celeste.Game.Execution.Engine.Actions;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Gameplay.Enemies.AngryOshiro;
using Celeste.Game.UI.Dialogue.Textboxes;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Rendering;
using Celeste.Input.Gameplay.Feedback;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Entities;
using Celeste.Simulation;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Simulation.Presentation.Scene.Transitions;

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
                Depth = 10100;
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

        private static OriginalGameGraphicsResources Graphics(ISourceEngineContext engine)
        {
            return (OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics;
        }

        private IOriginalGameplayProcess Process => (IOriginalGameplayProcess)engine;
        private OriginalGameAudioSession Audio => Process.AudioSession;
        public const string Flag = "oshiroEnding";

        private readonly OriginalResortRoofEndingState roof;

        private OriginalAngryOshiroState angryOshiro;

        private readonly RoomPlayerSession player;

        private SceneEntityState oshiro;

        private Sprite oshiroSprite;

        private FmodEventReference smashSfx;

        private bool smashRumble;

        public CS03OshiroEndingState(ISourceEngineContext engine, OriginalResortRoofEndingState roof,
            RoomPlayerSession player)
            : base(engine, false, true)
        {
            this.engine = engine;
            this.roof = roof;
            this.player = player;
            Depth = -1000000;
        }

        public override void OnBegin(OriginalLevelSceneRoot level)
        {
            level.RegisterAreaComplete();
            OwnedComponents.Add(new SimulationCoroutine(engine, Cutscene(level)));
        }

        public override void Update()
        {
            base.Update();
            if (smashRumble) ((ISourceRumbleEnvironment)engine).RumbleSession.Rumble(0, 0);
        }

        private IEnumerator Cutscene(OriginalLevelSceneRoot level)
        {
            player.Machine.State = 11;
            player.Machine.Locked = true;
            player.ForceCameraUpdate = false;
            OwnedComponents.Add(new SimulationCoroutine(engine,
                player.Dummy.RunTo(roof.X + roof.Width - 32f, true)));
            yield return null;
            player.Dummy.AutoAnimate = false;
            yield return 0.5f;
            angryOshiro = Level.SourceScene.Entities
                .FindFirst<OriginalAngryOshiroState>();
            OwnedComponents.Add(new SimulationCoroutine(engine, MoveGhostTo(new(roof.X + 40f, roof.Y - 12f))));
            yield return 1f;
            player.Dummy.AutoAnimate = true;
            yield return level.ZoomTo(new(130f, 60f), 2f, 0.5f);
            player.Data.Facing = -1;
            yield return 0.5f;
            yield return TextboxState.Say("CH3_OSHIRO_CHASE_END", engine, GhostSmash);
            yield return GhostSmash(0.5f, true);
            Audio.SetMusic(null);
            oshiroSprite = null;
            var bgFlash = new BgFlash(engine)
            {
                Alpha = 1f,
            };
            level.Scheduler.QueueSourceEntity(bgFlash);
            engine.Effects.GameRate = 0f;
            var sprite = Graphics(engine).SpriteFactory.Create("oshiro_boss_lightning");
            sprite.Position = angryOshiro.Position + new Vector2(140f, -100f);
            sprite.Rotation = Vector2Geometry.Angle(sprite.Position, angryOshiro.Position + new Vector2(0f, 10f));
            sprite.Play("once");
            OwnedComponents.Add(sprite);
            yield return null;
            OriginalCelesteFreeze.Freeze(engine, 0.3f);
            yield return null;
            level.Shake();
            ((ISourceRumbleEnvironment)engine).RumbleSession.Rumble(2, 2);
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
            var oshiroFallSpeed = new Vector2(-100f, -250f);
            var tween = SourceTweenState.Create(engine.TweenPool, SourceTweenState.TweenMode.Oneshot,
                Ease.SineInOut, 1.5f, true);
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

            level.DirectionalShake(new(0f, -1f), 0.5f);
            ((ISourceRumbleEnvironment)engine).RumbleSession.Rumble(1, 2);
            yield return 1f;
            while (!player.OnGround()) player.MoveV(1f);

            player.Dummy.AutoAnimate = false;
            player.Sprite.Play("tired");
            angryOshiro.RemoveSelf();
            level.Scheduler.QueueSourceEntity(oshiro = new(
                ((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration,
                new(level.Bounds.Left + 110, player.Y)));
            oshiro.OwnedComponents.Add(oshiroSprite = Graphics(engine).SpriteFactory.Create("oshiro"));
            oshiroSprite.Play("fall");
            oshiroSprite.Scale.X = 1f;
            oshiro.Collider = new HitboxColliderGeometry(8f, 8f, -4f, -8f);
            oshiro.OwnedComponents.Add(
                new VertexLightState(engine, new(0f, -8f),
                    PackedColor.White, 1f, 16, 32));
            yield return CameraTo(engine, player.CameraTarget + new Vector2(0f, 40f), 1f,
                Ease.CubeOut);
            yield return 1.5f;
            Audio.SetMusic("event:/music/lvl3/intro");
            yield return 3f;
            Audio.Play("event:/char/oshiro/chat_get_up", oshiro.Position, Process.SaveContext);
            oshiroSprite.Play("recover");
            var target = oshiro.Y + 4f;
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            while (oshiro.Y != target)
            {
                oshiro.Y = ScalarMath.Approach(oshiro.Y, target, 6f * engine.DeltaTime, Extrema);
                yield return null;
            }

            yield return 0.6f;
            yield return TextboxState.Say("CH3_ENDING", engine, OshiroTurns);
            OwnedComponents.Add(new SimulationCoroutine(engine,
                CameraTo(engine, level.Camera.Position + new Vector2(-80f, 0f), 3f)));
            yield return 0.5f;
            oshiroSprite.Scale.X = -1f;
            yield return 0.2f;
            t = 0f;
            oshiro.OwnedComponents.Add(((ISourceSoundSourceEnvironment)engine)
                .SoundSources.Create().Play("event:/char/oshiro/move_08_roof07_exit"));
            while (oshiro.X > level.Bounds.Left - 16)
            {
                oshiro.X -= 40f * engine.DeltaTime;
                var sprite2 = oshiroSprite;
                float num;
                t = num = t + engine.DeltaTime * 2f;
                sprite2.Y = (float)Math.Sin(num) * 2f;
                oshiro.CollideFirst<OriginalDoorState>("Celeste.Door")
                    ?.Open(oshiro.X);
                yield return null;
            }

            OwnedComponents.Add(new SimulationCoroutine(engine,
                CameraTo(engine, level.Camera.Position + new Vector2(80f, 0f), 2f)));
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
            yield return GhostSmash(0f, false);
        }

        private IEnumerator GhostSmash(float topDelay, bool final)
        {
            if (angryOshiro == null) yield break;

            if (final)
                smashSfx = Audio.Play("event:/char/oshiro/boss_slam_final", angryOshiro.Position, Process.SaveContext);
            else
                smashSfx = Audio.Play("event:/char/oshiro/boss_slam_first", angryOshiro.Position, Process.SaveContext);

            var from = angryOshiro.Y;
            var to = angryOshiro.Y - 32f;
            for (var p = 0f; p < 1f; p += engine.DeltaTime * 2f)
            {
                angryOshiro.Y = ScalarMath.Lerp(from, to, Ease.CubeOut(p), Scalar);
                yield return null;
            }

            yield return topDelay;
            var ground = from + 20f;
            for (var p = 0f; p < 1f; p += engine.DeltaTime * 8f)
            {
                angryOshiro.Y = ScalarMath.Lerp(to, ground, Ease.CubeOut(p), Scalar);
                yield return null;
            }

            angryOshiro.Squish();
            Level.Shake(0.5f);
            ((ISourceRumbleEnvironment)engine).RumbleSession.Rumble(2, 1);
            smashRumble = true;
            roof.StartShaking(0.5f);
            if (!final)
                for (var p = 0f; p < 1f; p += engine.DeltaTime * 16f)
                {
                    angryOshiro.Y = ScalarMath.Lerp(ground, from, Ease.CubeOut(p), Scalar);
                    yield return null;
                }
            else
                angryOshiro.Y = (ground + from) / 2f;

            if (angryOshiro != null)
            {
                player.Dummy.AutoAnimate = false;
                player.Sprite.Play("shaking");
                roof.Wobble(angryOshiro, final);
                if (!final) yield return 0.5f;
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
            ((ISourceScreenWipeEnvironment)engine).ProcessWipe
                .SpotlightFocusPoint = new(192f, 120f);
        }
    }
}
