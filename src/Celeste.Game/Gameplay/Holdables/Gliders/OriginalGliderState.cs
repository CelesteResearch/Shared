using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Controls.Source;
using Celeste.Game.Entities.Birds;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Gameplay.Mechanisms.DashSwitches;
using Celeste.Game.Profiles;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Rendering;
using Celeste.Input.Gameplay;
using Celeste.Input.Gameplay.Feedback;
using Celeste.Physics.Collision;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Components.Oscillation;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Gameplay.Actors.Foundation;
using Celeste.Simulation.Gameplay.Enemies.Seeker;
using Celeste.Simulation.Gameplay.Environment.Wind;
using Celeste.Simulation.Gameplay.Holdables;
using Celeste.Simulation.Gameplay.Interaction.Springs;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Presentation.Hud.Tutorials.Birds;

namespace Celeste.Game.Gameplay.Holdables.Gliders
{
    public class OriginalGliderState : SourceActorEntityState
    {
        private const float HighFrictionTime = 0.5f;

        public Vector2 Speed;

        public HoldableState Hold;

        private OriginalLevelSceneRoot level;
        private readonly ISourceEngineContext engine;

        private readonly SourceCollisionHandler onCollideH;

        private readonly SourceCollisionHandler onCollideV;

        private Vector2 prevLiftSpeed;

        private readonly Vector2 startPos;

        private float noGravityTimer;

        private float highFrictionTimer;

        private bool bubble;

        private bool tutorial;

        private bool destroyed;

        protected Sprite GliderSprite { get; }

        protected ref bool GliderDestroyed => ref destroyed;

        protected ref bool GliderBubble => ref bubble;

        private readonly WigglerComponent wiggler;

        private readonly SineWaveState platformSine;

        private readonly SoundSourceComponentState fallingSfx;

        private BirdTutorialGuiState tutorialGui;

        public OriginalGliderState(Vector2 position, bool bubble, bool tutorial, ISourceEngineContext engine)
            : base(new(null, position), engine,
                ((ISourcePlatformTargetMotionEnvironment)engine).TargetMotionPolicy)
        {
            this.engine = engine;
            this.bubble = bubble;
            this.tutorial = tutorial;
            startPos = Position;
            Collider = new HitboxColliderGeometry(8f, 10f, -4f, -10f);
            onCollideH = OnCollideH;
            onCollideV = OnCollideV;
            OwnedComponents.Add(GliderSprite =
                ((ISourceGameGraphicsEnvironment)engine).GameGraphics.SpriteFactory.Create("glider"));
            OwnedComponents.Add(wiggler = ((ISourceWigglerPoolScope)engine).WigglerPool.Create(0.25f, 4f));
            Depth = -5;
            OwnedComponents.Add(Hold = new(engine, 0.3f));
            Hold.PickupCollider = new HitboxColliderGeometry(20f, 22f, -10f, -16f);
            Hold.SlowFall = true;
            Hold.SlowRun = false;
            Hold.OnPickup = OnPickup;
            Hold.OnRelease = OnRelease;
            Hold.SpeedGetter = () => Speed;
            Hold.OnHitSpring = value => HitSpring((ISourceSpringEntity)value);
            platformSine = new(engine, 0.3f);
            OwnedComponents.Add(platformSine);
            fallingSfx = ((ISourceSoundSourceEnvironment)engine).SoundSources.Create();
            OwnedComponents.Add(fallingSfx);
            OwnedComponents.Add(new WindMoverState(WindMode));
            if (((IGameProfileEnvironment)engine).SourceProfile == GameProfile.InstalledEverest)
                Hold.SpeedSetter = speed => Speed = speed;
        }

        public OriginalGliderState(EntityData e, Vector2 offset, ISourceEngineContext engine)
            : this(e.Position + offset, EntityAttributeReader.Bool(e.Values, "bubble"),
                EntityAttributeReader.Bool(e.Values, "tutorial"), engine)
        {
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            level = (OriginalLevelSceneRoot)Scene;
            if (tutorial)
            {
                tutorialGui = new(engine, ((IOriginalGameTagsEnvironment)engine).Tags.HUD.Value,
                    ((IOriginalBirdProcess)engine).BirdTutorialResources, this, new(0f, -24f),
                    ((IOriginalFancyTextProcess)engine).Text.Dialog.Clean("tutorial_carry"),
                    ((IOriginalFancyTextProcess)engine).Text.Dialog.Clean("tutorial_hold"), BirdTutorialButton.Grab);
                tutorialGui.Open = true;
                ((ISourceScene)Scene).SourceScene.QueueSourceEntity(tutorialGui);
            }
        }

        public override void Update()
        {
            if (((ISourceScene)Scene).SourceScene.Clock.OnInterval(0.05f, engine))
                level.Particles.Emit(((IOriginalGameplayProcess)engine).ParticleTypes.Glider.P_Glow, 1,
                    Center + Vector2.UnitY * -9f, new(10f, 4f));

            var target = !Hold.IsHeld
                ? 0f
                : !Hold.Holder.OnGround()
                    ? ScalarMath.ClampedMap(Hold.Holder.Speed.X, -300f, 300f, (float)Math.PI / 3f, -(float)Math.PI / 3f)
                    : ScalarMath.ClampedMap(Hold.Holder.Speed.X, -300f, 300f, 0.6981317f, -0.6981317f);
            GliderSprite.Rotation = ScalarMath.Approach(GliderSprite.Rotation, target,
                (float)Math.PI * engine.DeltaTime,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            if (Hold.IsHeld && !Hold.Holder.OnGround() &&
                (GliderSprite.CurrentAnimationID == "fall" || GliderSprite.CurrentAnimationID == "fallLoop"))
            {
                if (!fallingSfx.Playing)
                {
                    PlaySound("event:/new_content/game/10_farewell/glider_engage", Position);
                    fallingSfx.Play("event:/new_content/game/10_farewell/glider_movement");
                }

                var speed = Hold.Holder.Speed;
                var vector = new Vector2(speed.X * 0.5f, speed.Y < 0f ? speed.Y * 2f : speed.Y);
                var value = ScalarMath.Map(((ISourceVectorEnvironment)engine).VectorArithmetic.Length(vector), 0f,
                    120f,
                    0f, 0.7f);
                fallingSfx.Param("glider_speed", value);
            }
            else
            {
                fallingSfx.Stop();
            }

            base.Update();
            if (!destroyed)
            {
                // ReSharper disable once ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator
                foreach (var actual in ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities(
                             "Celeste.SeekerBarrier"))
                {
                    var entity = (SeekerBarrierState)actual;
                    entity.Collidable = entity.CollidesWithGlider(true);
                    var num = SourceEntityCollision.Check(this, entity);
                    entity.Collidable = false;
                    if (num)
                    {
                        destroyed = true;
                        Collidable = false;
                        if (Hold.IsHeld)
                        {
                            var speed2 = Hold.Holder.Speed;
                            Hold.Holder.Drop();
                            Speed = speed2 * 0.333f;
                            ((ISourceRumbleEnvironment)engine).RumbleSession.Rumble((int)RumbleStrength.Medium,
                                (int)RumbleLength.Medium);
                        }

                        OwnedComponents.Add(new SimulationCoroutine(engine, DestroyAnimationRoutine()));
                        return;
                    }
                }

                if (Hold.IsHeld)
                {
                    prevLiftSpeed = Vector2.Zero;
                }
                else if (!bubble)
                {
                    if (highFrictionTimer > 0f) highFrictionTimer -= engine.DeltaTime;

                    GliderMotion.AdvanceSpeed(this, engine, Hold, ref Speed, ref prevLiftSpeed, ref noGravityTimer,
                        highFrictionTimer, ref level.Wind);

                    MoveH(Speed.X * engine.DeltaTime, onCollideH);
                    MoveV(Speed.Y * engine.DeltaTime, onCollideV);
                    if (Left < level.Bounds.Left)
                    {
                        Left = level.Bounds.Left;
                        OnCollideH(new(-Vector2.UnitX, Vector2.Zero, Vector2.Zero));
                    }
                    else if (Right > level.Bounds.Right)
                    {
                        Right = level.Bounds.Right;
                        OnCollideH(new(Vector2.UnitX, Vector2.Zero, Vector2.Zero));
                    }

                    if (Top < level.Bounds.Top)
                    {
                        Top = level.Bounds.Top;
                        OnCollideV(new(-Vector2.UnitY, Vector2.Zero, Vector2.Zero));
                    }
                    else if (Top > level.Bounds.Bottom + 16)
                    {
                        RemoveSelf();
                        return;
                    }

                    Hold.CheckAgainstColliders();
                }
                else
                {
                    Position = startPos + Vector2.UnitY * platformSine.Value * 1f;
                }

                var one = Vector2.One;
                if (!Hold.IsHeld)
                {
                    if (level.Wind.Y < 0f)
                        PlayOpen();
                    else
                        GliderSprite.Play("idle");
                }
                else if (Hold.Holder.Speed.Y > 20f || level.Wind.Y < 0f)
                {
                    if (level.SourceScene.Clock.OnInterval(0.04f, engine))
                    {
                        if (level.Wind.Y < 0f)
                            level.ParticlesBG.Emit(((IOriginalGameplayProcess)engine).ParticleTypes.Glider.P_GlideUp, 1,
                                Position - Vector2.UnitY * 20f, new(6f, 4f));
                        else
                            level.ParticlesBG.Emit(((IOriginalGameplayProcess)engine).ParticleTypes.Glider.P_Glide, 1,
                                Position - Vector2.UnitY * 10f, new(6f, 4f));
                    }

                    PlayOpen();
                    if (((ISourceGameInputEnvironment)engine).Input.GliderMoveY.Value > 0)
                    {
                        one.X = 0.7f;
                        one.Y = 1.4f;
                    }
                    else if (((ISourceGameInputEnvironment)engine).Input.GliderMoveY.Value < 0)
                    {
                        one.X = 1.2f;
                        one.Y = 0.8f;
                    }

                    ((ISourceRumbleEnvironment)engine).RumbleSession.Rumble((int)RumbleStrength.Climb,
                        (int)RumbleLength.Short);
                }
                else
                {
                    GliderSprite.Play("held");
                }

                GliderSprite.Scale.Y = ScalarMath.Approach(GliderSprite.Scale.Y, one.Y, engine.DeltaTime * 2f,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                GliderSprite.Scale.X = ScalarMath.Approach(GliderSprite.Scale.X,
                    Math.Sign(GliderSprite.Scale.X) * one.X,
                    engine.DeltaTime * 2f, ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                if (tutorialGui != null) tutorialGui.Open = tutorial && !Hold.IsHeld && (OnGround(4) || bubble);
            }
            else
            {
                Position += Speed * engine.DeltaTime;
            }
        }

        private void PlayOpen()
        {
            if (GliderSprite.CurrentAnimationID != "fall" && GliderSprite.CurrentAnimationID != "fallLoop")
            {
                GliderSprite.Play("fall");
                GliderSprite.Scale = new(1.5f, 0.6f);
                level.Particles.Emit(((IOriginalGameplayProcess)engine).ParticleTypes.Glider.P_Expand, 16,
                    Center +
                    ((ISourceVectorEnvironment)engine).VectorArithmetic.Rotate(Vector2.UnitY * -12f,
                        GliderSprite.Rotation),
                    new(8f, 3f), -(float)Math.PI / 2f + GliderSprite.Rotation);
                if (Hold.IsHeld)
                    ((ISourceRumbleEnvironment)engine).RumbleSession.Rumble((int)RumbleStrength.Medium,
                        (int)RumbleLength.Short);
            }
        }

        public override void Render(ISourceRenderContext context)
        {
            if (!destroyed) GliderSprite.DrawSimpleOutline(context);

            base.Render(context);
            if (bubble)
                for (var i = 0; i < 24; i++)
                    SourcePrimitiveDrawing.Point(context, this, Position + PlatformAdd(i), PlatformColor(i));
        }

        private void WindMode(Vector2 wind)
        {
            if (!Hold.IsHeld)
            {
                if (wind.X != 0f) MoveH(wind.X * 0.5f);

                if (wind.Y != 0f) MoveV(wind.Y);
            }
        }

        private Vector2 PlatformAdd(int num)
        {
            return new(-12 + num,
                -5 + (int)Math.Round(Math.Sin(((ISourceScene)Scene).SourceScene.Clock.TimeActive + num * 0.2f) *
                                     1.7999999523162842));
        }

        private PackedColor PlatformColor(int num)
        {
            if (num <= 1 || num >= 22) return PackedColor.White * 0.4f;

            return PackedColor.White * 0.8f;
        }

        private void OnCollideH(PixelCollision data)
        {
            if (data.Hit is OriginalDashSwitchState)
                (data.Hit as OriginalDashSwitchState).OnDashCollide(null, Vector2.UnitX * Math.Sign(Speed.X));

            if (Speed.X < 0f)
                PlaySound("event:/new_content/game/10_farewell/glider_wallbounce_left", Position);
            else
                PlaySound("event:/new_content/game/10_farewell/glider_wallbounce_right", Position);

            Speed.X *= -1f;
            GliderSprite.Scale = new(0.8f, 1.2f);
        }

        private void OnCollideV(PixelCollision data)
        {
            if (Math.Abs(Speed.Y) > 8f)
            {
                GliderSprite.Scale = new(1.2f, 0.8f);
                PlaySound("event:/new_content/game/10_farewell/glider_land", Position);
            }

            if (Speed.Y < 0f)
                Speed.Y *= -0.5f;
            else
                Speed.Y = 0f;
        }

        private void OnPickup()
        {
            if (bubble)
                for (var i = 0; i < 24; i++)
                    level.Particles.Emit(((IOriginalGameplayProcess)engine).ParticleTypes.Glider.P_Platform,
                        Position + PlatformAdd(i), PlatformColor(i));

            AllowPushing = false;
            Speed = Vector2.Zero;
            AddTag(((IOriginalGameTagsEnvironment)engine).Tags.Persistent.Value);
            highFrictionTimer = 0.5f;
            bubble = false;
            wiggler.Start();
            tutorial = false;
        }

        private void OnRelease(Vector2 force)
        {
            if (force.X == 0f) PlaySound("event:/new_content/char/madeline/glider_drop", Position);

            AllowPushing = true;
            RemoveTag(((IOriginalGameTagsEnvironment)engine).Tags.Persistent.Value);
            force.Y *= 0.5f;
            if (force.X != 0f && force.Y == 0f) force.Y = -0.4f;

            Speed = force * 100f;
            wiggler.Start();
        }

        protected override void OnSquish(PixelCollision data)
        {
            if (!TrySquishWiggle(data)) RemoveSelf();
        }

        public bool HitSpring(ISourceSpringEntity spring)
        {
            if (!Hold.IsHeld)
            {
                if (spring.Orientation == SpringOrientation.Floor && Speed.Y >= 0f)
                {
                    Speed.X *= 0.5f;
                    Speed.Y = -160f;
                    noGravityTimer = 0.15f;
                    wiggler.Start();
                    return true;
                }

                if (spring.Orientation == SpringOrientation.WallLeft && Speed.X <= 0f)
                {
                    MoveTowardsY(spring.Center.Y + 5f, 4f);
                    Speed.X = 160f;
                    Speed.Y = -80f;
                    noGravityTimer = 0.1f;
                    wiggler.Start();
                    return true;
                }

                if (spring.Orientation == SpringOrientation.WallRight && Speed.X >= 0f)
                {
                    MoveTowardsY(spring.Center.Y + 5f, 4f);
                    Speed.X = -160f;
                    Speed.Y = -80f;
                    noGravityTimer = 0.1f;
                    wiggler.Start();
                    return true;
                }
            }

            return false;
        }

        private IEnumerator DestroyAnimationRoutine()
        {
            PlaySound("event:/new_content/game/10_farewell/glider_emancipate", Position);
            GliderSprite.Play("death");
            yield return 1f;
            RemoveSelf();
        }

        private void PlaySound(string path, Vector2 position)
        {
            var process = (IOriginalGameplayProcess)engine;
            process.AudioSession.Play(path, position, process.SaveContext);
        }
    }
}
