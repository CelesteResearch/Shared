using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Audio;
using Celeste.Core.Components.Animation;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Controls.Source;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Gameplay.Collectibles.Strawberries;
using Celeste.Game.Gameplay.Walls.Breakable;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Physics.Collision;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Components.Shaking;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Actors.Foundation;
using Celeste.Simulation.Gameplay.Enemies.Seeker;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Gameplay.Player.Collision.Components;
using Celeste.Simulation.Gameplay.Player.Intro;
using Celeste.Simulation.Presentation.Effects.Mirrors;
using Celeste.Simulation.Presentation.Effects.Trails.Lifecycle;
using Celeste.Simulation.Presentation.Lighting;

namespace Celeste.Game.Gameplay.Player.Transformations.Seeker
{
    public class OriginalPlayerSeekerState : SourceActorEntityState
    {
        public Vector2 Speed => speed;

        // ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
        public float DashTimer => dashTimer;
        private int facing;

        private readonly ISourceEngineContext engine;

        private readonly Sprite sprite;

        private Vector2 speed;

        private bool enabled;

        private float dashTimer;

        private Vector2 dashDirection;

        private float trailTimerA;

        private float trailTimerB;

        private readonly ShakerComponentState shaker;

        public Vector2 CameraTarget
        {
            get
            {
                var bounds = (Scene as OriginalLevelSceneRoot).Bounds;
                return Vector2Clamping.Clamp(Position + new Vector2(-160f, -90f), bounds.Left, bounds.Top,
                    bounds.Right - 320, bounds.Bottom - 180);
            }
        }

        public OriginalPlayerSeekerState(EntityData data, Vector2 offset, ISourceEngineContext engine)
            : base(new(null, data.Position + offset), engine,
                ((ISourcePlatformTargetMotionEnvironment)engine).TargetMotionPolicy)
        {
            this.engine = engine;
            OwnedComponents.Add(sprite =
                ((ISourceGameGraphicsEnvironment)engine).GameGraphics.SpriteFactory.Create("seeker"));
            sprite.Play("statue");
            sprite.OnLastFrame = delegate(string a)
            {
                if (a == "flipMouth" || a == "flipEyes") facing = 0 - facing;
            };
            Collider = new HitboxColliderGeometry(10f, 10f, -5f, -5f);
            OwnedComponents.Add(new MirrorReflectionState());
            OwnedComponents.Add(new PlayerColliderComponentState(OnPlayer));
            OwnedComponents.Add(new VertexLightState(engine, PackedColor.White, 1f, 32, 64));
            facing = 1;
            OwnedComponents.Add(shaker = new(engine, false));
            OwnedComponents.Add(new SimulationCoroutine(engine, IntroSequence()));
        }

        public override void Awake(object scene)
        {
            base.Awake(scene);
            var obj = scene as OriginalLevelSceneRoot;
            obj.Session.ColorGrade = "templevoid";
            obj.ScreenPadding = 32f;
            obj.CanRetry = false;
        }

        private IEnumerator IntroSequence()
        {
            var level = Scene as OriginalLevelSceneRoot;
            yield return null;
            engine.Effects.Glitch = 0.05f;
            FirstPlayer(level)?.Dummy.StartTempleMirrorVoidSleep();
            yield return 3f;
            var from = level.Camera.Position;
            var tween = SourceTweenState.Create(engine.TweenPool, SourceTweenState.TweenMode.Oneshot,
                ((ISourceEasingEnvironment)engine).EasingArithmetic.SineInOut, 2f, true);
            tween.OnUpdate = delegate(SourceTweenState f)
            {
                var cameraTarget = CameraTarget;
                level.Camera.Position = from + (cameraTarget - from) * f.Eased;
            };
            OwnedComponents.Add(tween);
            yield return 2f;
            shaker.ShakeFor(0.5f, false);
            BreakOutParticles();
            ((IOriginalGameInputProcessEnvironment)engine).InputSource.Rumble(RumbleStrength.Light, RumbleLength.Long);
            yield return 1f;
            shaker.ShakeFor(0.5f, false);
            BreakOutParticles();
            ((IOriginalGameInputProcessEnvironment)engine).InputSource.Rumble(RumbleStrength.Medium, RumbleLength.Long);
            yield return 1f;
            BreakOutParticles();
            ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play(
                "event:/game/05_mirror_temple/seeker_statue_break",
                Position);
            shaker.ShakeFor(1f, false);
            sprite.Play("hatch");
            ((IOriginalGameInputProcessEnvironment)engine).InputSource.Rumble(RumbleStrength.Strong,
                RumbleLength.FullSecond);
            enabled = true;
            yield return 0.8f;
            BreakOutParticles();
            yield return 0.7f;
        }

        private void BreakOutParticles()
        {
            var level = (OriginalLevelSceneRoot)Scene;
            for (var num = 0f; num < (float)Math.PI * 2f; num += 0.17453292f)
            {
                var position = Center + Vector2Geometry.AngleToVector(
                    num + SourceRandomMath.Range(((ISourceRandomEnvironment)engine).Random, -(float)Math.PI / 90f,
                        (float)Math.PI / 90f),
                    SourceRandomMath.Range(((ISourceRandomEnvironment)engine).Random, 12, 20));
                level.Particles.Emit(((IOriginalGameplayProcess)engine).ParticleTypes.Seeker.P_BreakOut, position, num);
            }
        }

        private void OnPlayer(RoomPlayerSession player)
        {
            if (!player.Dead)
            {
                OriginalStrawberryTransfer.StoreStrawberries(player.Leader);
                var playerDeadBody =
                    player.Die(
                        ((ISourceVectorEnvironment)engine).VectorArithmetic.SafeNormalize(player.Position - Position),
                        true, false);
                playerDeadBody.DeathAction = End;
                playerDeadBody.ActionDelay = 0.3f;
                engine.Effects.TimeRate = 0.25f;
            }
        }

        private void End()
        {
            var level = Scene as OriginalLevelSceneRoot;
            level.OnEndOfFrame += delegate
            {
                engine.Effects.Glitch = 0f;
                engine.Effects.Anxiety = 0f;
                engine.Effects.TimeRate = 1f;
                level.Session.ColorGrade = null;
                level.UnloadLevel();
                level.CanRetry = true;
                level.Session.Level = "c-00";
                level.Session.RespawnPoint = level.GetSpawnPoint(new(level.Bounds.Left, level.Bounds.Top));
                level.LoadLevel(PlayerIntroType.WakeUp);
                OriginalStrawberryTransfer.RestoreStrawberries(FirstPlayer(level).Leader);
            };
        }

        public override void Update()
        {
            foreach (SceneEntityState entity2 in ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities(
                         "Celeste.SeekerBarrier"))
                entity2.Collidable = true;

            var level = Scene as OriginalLevelSceneRoot;
            base.Update();
            sprite.Scale.X = ScalarMath.Approach(sprite.Scale.X, 1f, 2f * engine.DeltaTime,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            sprite.Scale.Y = ScalarMath.Approach(sprite.Scale.Y, 1f, 2f * engine.DeltaTime,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            if (enabled && sprite.CurrentAnimationID != "hatch")
            {
                if (DashTimer > 0f)
                {
                    speed = ((ISourceVectorEnvironment)engine).VectorArithmetic.Approach(speed, Vector2.Zero,
                        800f * engine.DeltaTime);
                    dashTimer -= engine.DeltaTime;
                    if (DashTimer <= 0f) sprite.Play("spotted");

                    if (trailTimerA > 0f)
                    {
                        trailTimerA -= engine.DeltaTime;
                        if (trailTimerA <= 0f) CreateTrail();
                    }

                    if (trailTimerB > 0f)
                    {
                        trailTimerB -= engine.DeltaTime;
                        if (trailTimerB <= 0f) CreateTrail();
                    }

                    if (((ISourceScene)Scene).SourceScene.Clock.OnInterval(0.04f, engine))
                    {
                        var vector = ((ISourceVectorEnvironment)engine).VectorArithmetic.SafeNormalize(speed);
                        ((OriginalLevelSceneRoot)Scene).Particles.Emit(
                            ((IOriginalGameplayProcess)engine).ParticleTypes.Seeker.P_Attack, 2, Position + vector * 4f,
                            Vector2.One * 4f, Vector2Geometry.Angle(vector));
                    }
                }
                else
                {
                    var vector2 =
                        ((ISourceVectorEnvironment)engine).VectorArithmetic.SafeNormalize(
                            ((IOriginalGameInputProcessEnvironment)engine).InputSource.Aim.Value);
                    speed += vector2 * 600f * engine.DeltaTime;
                    var num = ((ISourceVectorEnvironment)engine).VectorArithmetic.Length(speed);
                    if (num > 120f)
                    {
                        num = ScalarMath.Approach(num, 120f, engine.DeltaTime * 700f,
                            ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                        speed = ((ISourceVectorEnvironment)engine).VectorArithmetic.SafeNormalize(speed, num);
                    }

                    if (vector2.Y == 0f)
                        speed.Y = ScalarMath.Approach(speed.Y, 0f, 400f * engine.DeltaTime,
                            ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);

                    if (vector2.X == 0f)
                        speed.X = ScalarMath.Approach(speed.X, 0f, 400f * engine.DeltaTime,
                            ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);

                    if (((ISourceVectorEnvironment)engine).VectorArithmetic.Length(vector2) > 0f &&
                        sprite.CurrentAnimationID == "idle")
                    {
                        level.Displacement.AddBurst(Position, 0.5f, 8f, 32f);
                        sprite.Play("spotted");
                        ((ISourceAudioEnvironment)engine).SourceAudio.Play(
                            "event:/game/05_mirror_temple/seeker_playercontrolstart");
                    }

                    var num2 = Math.Sign(facing);
                    var num3 = Math.Sign(speed.X);
                    if (num3 != 0 && num2 != num3 &&
                        Math.Sign(((IOriginalGameInputProcessEnvironment)engine).InputSource.Aim.Value.X) ==
                        Math.Sign(speed.X) && Math.Abs(speed.X) > 20f && sprite.CurrentAnimationID != "flipMouth" &&
                        sprite.CurrentAnimationID != "flipEyes")
                        sprite.Play("flipMouth");

                    if (((IOriginalGameInputProcessEnvironment)engine).InputSource.Dash.Pressed)
                        Dash(Vector2Geometry.EightWayNormal(((IOriginalGameInputProcessEnvironment)engine).InputSource
                            .Aim
                            .Value));
                }

                MoveH(speed.X * engine.DeltaTime, OnCollide);
                MoveV(speed.Y * engine.DeltaTime, OnCollide);
                Position = Vector2Clamping.Clamp(Position, level.Bounds.X, level.Bounds.Y, level.Bounds.Right,
                    level.Bounds.Bottom);
                var entity = FirstPlayer((OriginalLevelSceneRoot)Scene);
                if (entity != null)
                {
                    var num4 = ((ISourceVectorEnvironment)engine).VectorArithmetic.Length(Position - entity.Position);
                    if (num4 < 200f && entity.Sprite.CurrentAnimationID == "asleep")
                    {
                        entity.Sprite.Rate = 2f;
                        entity.Sprite.Play("wakeUp");
                    }
                    else if (num4 < 100f && entity.Sprite.CurrentAnimationID != "wakeUp")
                    {
                        entity.Sprite.Rate = 1f;
                        entity.Sprite.Play("runFast");
                        entity.Data.Facing = !(X > entity.X) ? 1 : -1;
                    }

                    if (num4 < 50f && DashTimer <= 0f)
                        Dash(((ISourceVectorEnvironment)engine).VectorArithmetic.SafeNormalize(
                            entity.Center - Center));

                    engine.Effects.TimeRate = ScalarMath.ClampedMap(num4, 60f, 220f, 0.5f);
                    var camera = level.Camera;
                    var cameraTarget = CameraTarget;
                    camera.Position += (cameraTarget - camera.Position) *
                                       (1f - (float)Math.Pow(0.009999999776482582, engine.DeltaTime));
                    engine.Effects.Anxiety = ScalarMath.ClampedMap(num4, 0f, 200f, 0.25f, 0f) +
                                             SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random,
                                                 0.05f);
                    engine.Effects.AnxietyOrigin = (new Vector2(entity.X, level.Camera.Top) - level.Camera.Position) /
                                                   new Vector2(320f, 180f);
                }
                else
                {
                    engine.Effects.TimeRate = ScalarMath.Approach(engine.Effects.TimeRate, 1f, 1f * engine.DeltaTime,
                        ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                }
            }

            foreach (SceneEntityState entity3 in ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities(
                         "Celeste.SeekerBarrier"))
                entity3.Collidable = false;
        }

        private void CreateTrail()
        {
            var scale = sprite.Scale;
            sprite.Scale.X *= facing;
            TrailManagerState.Add(engine, (ISourceRenderEnvironment)engine, this, SeekerAppearance.TrailColor);
            sprite.Scale = scale;
        }

        private void OnCollide(PixelCollision data)
        {
            if (DashTimer <= 0f)
            {
                if (data.Direction.X != 0f) speed.X = 0f;

                if (data.Direction.Y != 0f) speed.Y = 0f;

                return;
            }

            float direction;
            Vector2 position;
            Vector2 positionRange;
            if (data.Direction.X > 0f)
            {
                direction = (float)Math.PI;
                position = new(Right, Y);
                positionRange = Vector2.UnitY * 4f;
            }
            else if (data.Direction.X < 0f)
            {
                direction = 0f;
                position = new(Left, Y);
                positionRange = Vector2.UnitY * 4f;
            }
            else if (data.Direction.Y > 0f)
            {
                direction = -(float)Math.PI / 2f;
                position = new(X, Bottom);
                positionRange = Vector2.UnitX * 4f;
            }
            else
            {
                direction = (float)Math.PI / 2f;
                position = new(X, Top);
                positionRange = Vector2.UnitX * 4f;
            }

            ((OriginalLevelSceneRoot)Scene).Particles.Emit(
                ((IOriginalGameplayProcess)engine).ParticleTypes.Seeker.P_HitWall, 12, position, positionRange,
                direction);
            if (data.Hit is SeekerBarrierState)
            {
                (data.Hit as SeekerBarrierState).OnReflectSeeker();
                ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play(
                    "event:/game/05_mirror_temple/seeker_hit_lightwall", Position);
            }
            else
            {
                ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play(
                    "event:/game/05_mirror_temple/seeker_hit_normal",
                    Position);
            }

            if (data.Direction.X != 0f)
            {
                speed.X *= -0.8f;
                sprite.Scale = new(0.6f, 1.4f);
            }
            else if (data.Direction.Y != 0f)
            {
                speed.Y *= -0.8f;
                sprite.Scale = new(1.4f, 0.6f);
            }

            if (data.Hit is OriginalTempleCrackedBlockState)
            {
                ((ISourceFreezeEnvironment)engine).Freeze(0.15f);
                ((IOriginalGameInputProcessEnvironment)engine).InputSource.Rumble(RumbleStrength.Strong,
                    RumbleLength.Long);
                (data.Hit as OriginalTempleCrackedBlockState).Break(Position);
            }
        }

        private void Dash(Vector2 dir)
        {
            if (DashTimer <= 0f)
            {
                CreateTrail();
                trailTimerA = 0.1f;
                trailTimerB = 0.25f;
            }

            dashTimer = 0.3f;
            dashDirection = dir;
            if (dashDirection == Vector2.Zero) dashDirection.X = Math.Sign(facing);

            if (dashDirection.X != 0f) facing = Math.Sign(dashDirection.X);

            speed = dashDirection * 400f;
            sprite.Play("attacking");
            ((OriginalLevelSceneRoot)Scene).DirectionalShake(dashDirection);
            ((IOriginalGameInputProcessEnvironment)engine).InputSource.Rumble(RumbleStrength.Strong,
                RumbleLength.Medium);
            ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play("event:/game/05_mirror_temple/seeker_dash",
                Position);
            if (dashDirection.X == 0f)
                sprite.Scale = new(0.6f, 1.4f);
            else
                sprite.Scale = new(1.4f, 0.6f);
        }

        public override void Render(ISourceRenderContext context)
        {
            if (!((IOriginalGameplayProcess)engine).SaveContext.CurrentSave.Assists.InvisibleMotion || !enabled ||
                !(((ISourceVectorEnvironment)engine).VectorArithmetic.LengthSquared(speed) > 100f))
            {
                var position = Position;
                Position += shaker.Value;
                var scale = sprite.Scale;
                sprite.Scale.X *= facing;
                base.Render(context);
                Position = position;
                sprite.Scale = scale;
            }
        }

        private static RoomPlayerSession FirstPlayer(OriginalLevelSceneRoot level)
        {
            var tracked =
                level.SourceScene.Entities.GetTrackedEntities(typeof(RoomPlayerSession)
                    .FullName);

            return tracked.Count > 0 ? tracked[0] as RoomPlayerSession : null;
        }
    }
}
