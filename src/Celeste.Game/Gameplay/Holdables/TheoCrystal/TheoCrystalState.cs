using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Entities.Platforms.SwapBlocks;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Gameplay.Doors.TempleGates;
using Celeste.Game.Gameplay.Effects.Slashes;
using Celeste.Game.Gameplay.Enemies.Seekers;
using Celeste.Game.Gameplay.Mechanisms.DashSwitches;
using Celeste.Game.Profiles;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Physics.Collision;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Actors.Foundation;
using Celeste.Simulation.Gameplay.Holdables;
using Celeste.Simulation.Gameplay.Holdables.TheoCrystal;
using Celeste.Simulation.Gameplay.Interaction.Springs;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Presentation.Effects.Mirrors;
using Celeste.Simulation.Presentation.Hud.Tutorials.Birds;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Simulation.Presentation.Particles.Definitions;
using Celeste.Simulation.Presentation.Player.Death;
using Celeste.Simulation.Presentation.PostProcessing.Bloom;

namespace Celeste.Game.Gameplay.Holdables.TheoCrystal
{
    public class TheoCrystalState : SourceActorEntityState
    {
        private ParticleTypePresentation P_Impact
            => ((IOriginalGameplayProcess)engine).ParticleTypes.TheoCrystal.P_Impact;

        public Vector2 Speed;

        public bool OnPedestal;

        public HoldableState Hold;

        private readonly Sprite sprite;

        private bool dead;

        private OriginalLevelSceneRoot Level;
        private readonly ISourceEngineContext engine;

        private readonly SourceCollisionHandler onCollideH;

        private readonly SourceCollisionHandler onCollideV;

        private float noGravityTimer;

        private Vector2 prevLiftSpeed;

        private Vector2 previousPosition;

        private HoldableColliderState hitSeeker;

        private float swatTimer;

        private bool shattering;

        private float hardVerticalHitSoundCooldown;

        private BirdTutorialGuiState tutorialGui;

        private float tutorialTimer;

        public TheoCrystalState(Vector2 position, ISourceEngineContext engine)
            : base(new(null, position), engine,
                ((ISourcePlatformTargetMotionEnvironment)engine).TargetMotionPolicy)
        {
            this.engine = engine;
            previousPosition = position;
            Depth = 100;
            Collider = new HitboxColliderGeometry(8f, 10f, -4f, -10f);
            OwnedComponents.Add(sprite =
                ((ISourceGameGraphicsEnvironment)engine).GameGraphics.SpriteFactory.Create("theo_crystal"));
            sprite.Scale.X = -1f;
            OwnedComponents.Add(Hold = new(engine));
            Hold.PickupCollider = new HitboxColliderGeometry(16f, 22f, -8f, -16f);
            Hold.SlowFall = false;
            Hold.SlowRun = true;
            Hold.OnPickup = OnPickup;
            Hold.OnRelease = OnRelease;
            Hold.DangerousCheck = value => Dangerous((HoldableColliderState)value);
            Hold.OnHitSeeker = value => HitSeeker((OriginalSeekerState)value);
            Hold.OnSwat = (value, dir) => Swat((HoldableColliderState)value, dir);
            Hold.OnHitSpring = value => HitSpring((ISourceSpringEntity)value);
            Hold.OnHitSpinner = value => HitSpinner((SceneEntityState)value);
            Hold.SpeedGetter = () => Speed;
            onCollideH = OnCollideH;
            onCollideV = OnCollideV;
            LiftSpeedGraceTime = 0.1f;
            OwnedComponents.Add(new VertexLightState(engine, Collider.Center, PackedColor.White, 1f, 32, 64));
            AddTag(((IOriginalGameTagsEnvironment)engine).Tags.TransitionUpdate.Value);
            OwnedComponents.Add(new MirrorReflectionState());
            if (((IGameProfileEnvironment)engine).SourceProfile == GameProfile.InstalledEverest)
                Hold.SpeedSetter = speed => Speed = speed;
        }

        public TheoCrystalState(EntityData e, Vector2 offset, ISourceEngineContext engine)
            : this(e.Position + offset, engine)
        {
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            Level = (OriginalLevelSceneRoot)Scene;
            foreach (var actual in Level.SourceScene.Entities.GetTrackedEntities("Celeste.TheoCrystal"))
            {
                var entity = (TheoCrystalState)actual;
                if (entity != this && entity.Hold.IsHeld) RemoveSelf();
            }

            if (Level.Session.Level == "e-00")
            {
                tutorialGui = new(engine, ((IOriginalGameTagsEnvironment)engine).Tags.HUD.Value,
                    (ITheoCrystalTutorialResources)engine, this, new(0f, -24f),
                    ((ITheoCrystalTutorialResources)engine).CleanDialog("tutorial_carry"),
                    ((ITheoCrystalTutorialResources)engine).CleanDialog("tutorial_hold"), BirdTutorialButton.Grab);
                tutorialGui.Open = false;
                ((ISourceScene)Scene).SourceScene.QueueSourceEntity(tutorialGui);
            }
        }

        public override void Update()
        {
            base.Update();
            if (shattering || dead) return;

            if (swatTimer > 0f) swatTimer -= engine.DeltaTime;

            hardVerticalHitSoundCooldown -= engine.DeltaTime;
            if (OnPedestal)
            {
                Depth = 8999;
                return;
            }

            Depth = 100;
            if (Hold.IsHeld)
            {
                prevLiftSpeed = Vector2.Zero;
            }
            else
            {
                CarryableActorMotion.AdvanceSpeed(this, engine, Hold, ref Speed, ref prevLiftSpeed, ref noGravityTimer);

                previousPosition = ExactPosition;
                MoveH(Speed.X * engine.DeltaTime, onCollideH);
                MoveV(Speed.Y * engine.DeltaTime, onCollideV);
                if (Center.X > Level.Bounds.Right)
                {
                    MoveH(32f * engine.DeltaTime);
                    if (Left - 8f > Level.Bounds.Right) RemoveSelf();
                }
                else if (Left < Level.Bounds.Left)
                {
                    Left = Level.Bounds.Left;
                    Speed.X *= -0.4f;
                }
                else if (Top < Level.Bounds.Top - 4)
                {
                    Top = Level.Bounds.Top + 4;
                    Speed.Y = 0f;
                }
                else if (Bottom > Level.Bounds.Bottom &&
                         ((IOriginalGameplayProcess)engine).SaveContext.CurrentSave.Assists.Invincible)
                {
                    Bottom = Level.Bounds.Bottom;
                    Speed.Y = -300f;
                    PlaySound("event:/game/general/assist_screenbottom", Position);
                }
                else if (Top > Level.Bounds.Bottom)
                {
                    Die();
                }

                if (X < Level.Bounds.Left + 10) MoveH(32f * engine.DeltaTime);

                var entity =
                    ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                        typeof(RoomPlayerSession).FullName);

                var templeGate = CollideFirst<OriginalTempleGateState>("Celeste.TempleGate");
                if (templeGate != null && entity != null)
                {
                    templeGate.Collidable = false;
                    MoveH(Math.Sign(entity.X - X) * 32 * engine.DeltaTime);
                    templeGate.Collidable = true;
                }
            }

            if (!dead) Hold.CheckAgainstColliders();

            if (hitSeeker != null && swatTimer <= 0f && !hitSeeker.Check(Hold)) hitSeeker = null;

            if (tutorialGui != null)
            {
                if (!OnPedestal && !Hold.IsHeld && OnGround() && Level.Session.GetFlag("foundTheoInCrystal"))
                    tutorialTimer += engine.DeltaTime;
                else
                    tutorialTimer = 0f;

                tutorialGui.Open = tutorialTimer > 0.25f;
            }
        }

        public IEnumerator Shatter()
        {
            shattering = true;
            var bloom = new BloomPointState(0f, 32f);
            var light = new VertexLightState(engine, new(240, 248, 255, 255), 0f, 64, 200);
            OwnedComponents.Add(bloom);
            OwnedComponents.Add(light);
            for (var p = 0f; p < 1f; p += engine.DeltaTime)
            {
                Position += Speed * (1f - p) * engine.DeltaTime;
                Level.ZoomFocusPoint = TopCenter - Level.Camera.Position;
                light.Alpha = p;
                bloom.Alpha = p;
                yield return null;
            }

            yield return 0.5f;
            Level.Shake();
            sprite.Play("shatter");
            yield return 1f;
            Level.Shake();
        }

        public void ExplodeLaunch(Vector2 from)
        {
            if (!Hold.IsHeld)
            {
                Speed = ((ISourceVectorEnvironment)engine).VectorArithmetic.SafeNormalize(Center - from, 120f);
                OriginalSlashFxState.Burst(engine, Center, Vector2Geometry.Angle(Speed));
            }
        }

        public void Swat(HoldableColliderState hc, int dir)
        {
            if (Hold.IsHeld && hitSeeker == null)
            {
                swatTimer = 0.1f;
                hitSeeker = hc;
                Hold.Holder.Swat(dir);
            }
        }

        public bool Dangerous(HoldableColliderState holdableCollider)
        {
            if (!Hold.IsHeld && Speed != Vector2.Zero) return hitSeeker != holdableCollider;

            return false;
        }

        public void HitSeeker(OriginalSeekerState seeker)
        {
            if (!Hold.IsHeld)
                Speed = ((ISourceVectorEnvironment)engine).VectorArithmetic.SafeNormalize(Center - seeker.Center,
                    120f);

            PlaySound("event:/game/05_mirror_temple/crystaltheo_hit_side", Position);
        }

        public void HitSpinner(SceneEntityState spinner)
        {
            if (!Hold.IsHeld && ((ISourceVectorEnvironment)engine).VectorArithmetic.Length(Speed) < 0.01f &&
                ((ISourceVectorEnvironment)engine).VectorArithmetic.Length(LiftSpeed) < 0.01f &&
                ((ISourceVectorEnvironment)engine).VectorArithmetic.Length(previousPosition - ExactPosition) <
                0.01f &&
                OnGround())
            {
                var num = Math.Sign(X - spinner.X);
                if (num == 0) num = 1;

                Speed.X = num * 120f;
                Speed.Y = -30f;
            }
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
                    return true;
                }

                if (spring.Orientation == SpringOrientation.WallLeft && Speed.X <= 0f)
                {
                    MoveTowardsY(spring.CenterY + 5f, 4f);
                    Speed.X = 220f;
                    Speed.Y = -80f;
                    noGravityTimer = 0.1f;
                    return true;
                }

                if (spring.Orientation == SpringOrientation.WallRight && Speed.X >= 0f)
                {
                    MoveTowardsY(spring.CenterY + 5f, 4f);
                    Speed.X = -220f;
                    Speed.Y = -80f;
                    noGravityTimer = 0.1f;
                    return true;
                }
            }

            return false;
        }

        private void OnCollideH(PixelCollision data)
        {
            if (data.Hit is OriginalDashSwitchState)
                (data.Hit as OriginalDashSwitchState).OnDashCollide(null, Vector2.UnitX * Math.Sign(Speed.X));

            PlaySound("event:/game/05_mirror_temple/crystaltheo_hit_side", Position);
            if (Math.Abs(Speed.X) > 100f) ImpactParticles(data.Direction);

            Speed.X *= -0.4f;
        }

        private void OnCollideV(PixelCollision data)
        {
            if (data.Hit is OriginalDashSwitchState)
                (data.Hit as OriginalDashSwitchState).OnDashCollide(null, Vector2.UnitY * Math.Sign(Speed.Y));

            if (Speed.Y > 0f)
            {
                if (hardVerticalHitSoundCooldown <= 0f)
                {
                    PlaySound("event:/game/05_mirror_temple/crystaltheo_hit_ground", Position, "crystal_velocity",
                        ScalarMath.ClampedMap(Speed.Y, 0f, 200f));
                    hardVerticalHitSoundCooldown = 0.5f;
                }
                else
                {
                    PlaySound("event:/game/05_mirror_temple/crystaltheo_hit_ground", Position, "crystal_velocity");
                }
            }

            if (Speed.Y > 160f) ImpactParticles(data.Direction);

            if (Speed.Y > 140f && !(data.Hit is OriginalSwapBlockState) && !(data.Hit is OriginalDashSwitchState))
                Speed.Y *= -0.6f;
            else
                Speed.Y = 0f;
        }

        private void ImpactParticles(Vector2 dir)
        {
            float direction;
            Vector2 position;
            Vector2 positionRange;
            if (dir.X > 0f)
            {
                direction = (float)Math.PI;
                position = new(Right, Y - 4f);
                positionRange = Vector2.UnitY * 6f;
            }
            else if (dir.X < 0f)
            {
                direction = 0f;
                position = new(Left, Y - 4f);
                positionRange = Vector2.UnitY * 6f;
            }
            else if (dir.Y > 0f)
            {
                direction = -(float)Math.PI / 2f;
                position = new(X, Bottom);
                positionRange = Vector2.UnitX * 6f;
            }
            else
            {
                direction = (float)Math.PI / 2f;
                position = new(X, Top);
                positionRange = Vector2.UnitX * 6f;
            }

            Level.Particles.Emit(P_Impact, 12, position, positionRange, direction);
        }

        public override bool IsRiding(ISourceEntityCollider solid)
        {
            return Speed.Y == 0f ? base.IsRiding(solid) : false;
        }

        protected override void OnSquish(PixelCollision data)
        {
            if (!TrySquishWiggle(data) &&
                !((IOriginalGameplayProcess)engine).SaveContext.CurrentSave.Assists.Invincible)
                Die();
        }

        private void OnPickup()
        {
            Speed = Vector2.Zero;
            AddTag(((IOriginalGameTagsEnvironment)engine).Tags.Persistent.Value);
        }

        private void OnRelease(Vector2 force)
        {
            RemoveTag(((IOriginalGameTagsEnvironment)engine).Tags.Persistent.Value);
            if (force.X != 0f && force.Y == 0f) force.Y = -0.4f;

            Speed = force * 200f;
            if (Speed != Vector2.Zero) noGravityTimer = 0.1f;
        }

        public void Die()
        {
            if (!dead)
            {
                dead = true;
                var entity =
                    Level.SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                        typeof(RoomPlayerSession).FullName);

                entity?.Die(-Vector2.UnitX * entity.Facing);
                PlaySound("event:/char/madeline/death", Position);
                OwnedComponents.Add(new DeathEffect(new(34, 139, 34, 255), engine, Center - Position));
                sprite.Visible = false;
                Depth = -1000000;
                AllowPushing = false;
            }
        }

        private void PlaySound(string path, Vector2 position, string parameter = null, float value = 0f)
        {
            var process = (IOriginalGameplayProcess)engine;
            if (parameter == null) process.AudioSession.Play(path, position, process.SaveContext);
            else process.AudioSession.Play(path, position, process.SaveContext, parameter, value);
        }
    }
}
