using Celeste.Core.Display;
using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.Easing;
using Celeste.Physics.Collision;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Graphics.Display;
using Celeste.Graphics.Animation;
using Celeste.Simulation.Gameplay.Actors.Foundation;
using Celeste.Simulation.Gameplay.Holdables;
using Celeste.Simulation.Gameplay.Holdables.TheoCrystal;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Player;
using Celeste.Simulation.Gameplay.Interaction.Springs;
using Celeste.Simulation.Presentation.Hud.Tutorials.Birds;
using Celeste.Simulation.Presentation.Player.Death;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Simulation.Presentation.PostProcessing.Bloom;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Audio.Runtime;
using Celeste.Game.Save.Runtime;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Game.Gameplay.Mechanisms.DashSwitches;
using Celeste.Game.Gameplay.Doors.TempleGates;
using Celeste.Game.Gameplay.Enemies.Seekers;
using Celeste.Game.Entities.Platforms.SwapBlocks;
using Celeste.Graphics.Content;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Profiles;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Gameplay.Effects.Slashes;

namespace Celeste.Game.Gameplay.Holdables.TheoCrystal
{
    public class TheoCrystalState : SourceActorEntityState
    {
        private global::Celeste.Simulation.Presentation.Particles.Definitions.ParticleTypePresentation P_Impact
            => ((IOriginalGameplayProcess)engine).ParticleTypes.TheoCrystal.P_Impact;

        public Vector2 Speed;

        public bool OnPedestal;

        public HoldableState Hold;

        private Sprite sprite;

        private bool dead;

        private OriginalLevelSceneRoot Level;
        private readonly ISourceEngineContext engine;

        private global::Celeste.Physics.Collision.SourceCollisionHandler onCollideH;

        private global::Celeste.Physics.Collision.SourceCollisionHandler onCollideV;

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
            : base(new PixelActor(null, position), engine,
                ((ISourcePlatformTargetMotionEnvironment)engine).TargetMotionPolicy)
        {
            this.engine = engine;
            previousPosition = position;
            base.Depth = 100;
            base.Collider = new HitboxColliderGeometry(8f, 10f, -4f, -10f);
            OwnedComponents.Add(sprite =
                ((ISourceGameGraphicsEnvironment)engine).GameGraphics.SpriteFactory.Create("theo_crystal"));
            sprite.Scale.X = -1f;
            OwnedComponents.Add(Hold = new HoldableState(engine));
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
            OwnedComponents.Add(new VertexLightState(engine, base.Collider.Center, PackedColor.White, 1f, 32, 64));
            AddTag(((IOriginalGameTagsEnvironment)engine).Tags.TransitionUpdate.Value);
            OwnedComponents.Add(new global::Celeste.Simulation.Presentation.Effects.Mirrors.MirrorReflectionState());
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
                if (entity != this && entity.Hold.IsHeld)
                {
                    RemoveSelf();
                }
            }

            if (Level.Session.Level == "e-00")
            {
                tutorialGui = new BirdTutorialGuiState(engine, ((IOriginalGameTagsEnvironment)engine).Tags.HUD.Value,
                    (ITheoCrystalTutorialResources)engine, this, new Vector2(0f, -24f),
                    ((ITheoCrystalTutorialResources)engine).CleanDialog("tutorial_carry"),
                    ((ITheoCrystalTutorialResources)engine).CleanDialog("tutorial_hold"), BirdTutorialButton.Grab);
                tutorialGui.Open = false;
                ((ISourceScene)Scene).SourceScene.QueueSourceEntity(tutorialGui);
            }
        }

        public override void Update()
        {
            base.Update();
            if (shattering || dead)
            {
                return;
            }

            if (swatTimer > 0f)
            {
                swatTimer -= engine.DeltaTime;
            }

            hardVerticalHitSoundCooldown -= engine.DeltaTime;
            if (OnPedestal)
            {
                base.Depth = 8999;
                return;
            }

            base.Depth = 100;
            if (Hold.IsHeld)
            {
                prevLiftSpeed = Vector2.Zero;
            }
            else
            {
                CarryableActorMotion.AdvanceSpeed(this, engine, Hold, ref Speed, ref prevLiftSpeed, ref noGravityTimer);

                previousPosition = base.ExactPosition;
                MoveH(Speed.X * engine.DeltaTime, onCollideH);
                MoveV(Speed.Y * engine.DeltaTime, onCollideV);
                if (base.Center.X > (float)Level.Bounds.Right)
                {
                    MoveH(32f * engine.DeltaTime);
                    if (base.Left - 8f > (float)Level.Bounds.Right)
                    {
                        RemoveSelf();
                    }
                }
                else if (base.Left < (float)Level.Bounds.Left)
                {
                    base.Left = Level.Bounds.Left;
                    Speed.X *= -0.4f;
                }
                else if (base.Top < (float)(Level.Bounds.Top - 4))
                {
                    base.Top = Level.Bounds.Top + 4;
                    Speed.Y = 0f;
                }
                else if (base.Bottom > (float)Level.Bounds.Bottom &&
                         ((IOriginalGameplayProcess)engine).SaveContext.CurrentSave.Assists.Invincible)
                {
                    base.Bottom = Level.Bounds.Bottom;
                    Speed.Y = -300f;
                    PlaySound("event:/game/general/assist_screenbottom", Position);
                }
                else if (base.Top > (float)Level.Bounds.Bottom)
                {
                    Die();
                }

                if (base.X < (float)(Level.Bounds.Left + 10))
                {
                    MoveH(32f * engine.DeltaTime);
                }

                RoomPlayerSession entity =
                    ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                        typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);

                OriginalTempleGateState templeGate = CollideFirst<OriginalTempleGateState>("Celeste.TempleGate");
                if (templeGate != null && entity != null)
                {
                    templeGate.Collidable = false;
                    MoveH((float)(Math.Sign(entity.X - base.X) * 32) * engine.DeltaTime);
                    templeGate.Collidable = true;
                }
            }

            if (!dead)
            {
                Hold.CheckAgainstColliders();
            }

            if (hitSeeker != null && swatTimer <= 0f && !hitSeeker.Check(Hold))
            {
                hitSeeker = null;
            }

            if (tutorialGui != null)
            {
                if (!OnPedestal && !Hold.IsHeld && OnGround() && Level.Session.GetFlag("foundTheoInCrystal"))
                {
                    tutorialTimer += engine.DeltaTime;
                }
                else
                {
                    tutorialTimer = 0f;
                }

                tutorialGui.Open = tutorialTimer > 0.25f;
            }
        }

        public IEnumerator Shatter()
        {
            shattering = true;
            BloomPointState bloom = new BloomPointState(0f, 32f);
            VertexLightState light = new VertexLightState(engine, new PackedColor(240, 248, 255, 255), 0f, 64, 200);
            OwnedComponents.Add(bloom);
            OwnedComponents.Add(light);
            for (float p = 0f; p < 1f; p += engine.DeltaTime)
            {
                Position += Speed * (1f - p) * engine.DeltaTime;
                Level.ZoomFocusPoint = base.TopCenter - Level.Camera.Position;
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
                Speed = ((ISourceVectorEnvironment)engine).VectorArithmetic.SafeNormalize(base.Center - from, 120f);
                OriginalSlashFxState.Burst(engine, base.Center, Vector2Geometry.Angle(Speed));
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
            if (!Hold.IsHeld && Speed != Vector2.Zero)
            {
                return hitSeeker != holdableCollider;
            }

            return false;
        }

        public void HitSeeker(OriginalSeekerState seeker)
        {
            if (!Hold.IsHeld)
            {
                Speed = ((ISourceVectorEnvironment)engine).VectorArithmetic.SafeNormalize(base.Center - seeker.Center,
                    120f);
            }

            PlaySound("event:/game/05_mirror_temple/crystaltheo_hit_side", Position);
        }

        public void HitSpinner(SceneEntityState spinner)
        {
            if (!Hold.IsHeld && ((ISourceVectorEnvironment)engine).VectorArithmetic.Length(Speed) < 0.01f &&
                ((ISourceVectorEnvironment)engine).VectorArithmetic.Length(base.LiftSpeed) < 0.01f &&
                ((ISourceVectorEnvironment)engine).VectorArithmetic.Length(previousPosition - base.ExactPosition) <
                0.01f &&
                OnGround())
            {
                int num = Math.Sign(base.X - spinner.X);
                if (num == 0)
                {
                    num = 1;
                }

                Speed.X = (float)num * 120f;
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
            {
                (data.Hit as OriginalDashSwitchState).OnDashCollide(null, Vector2.UnitX * Math.Sign(Speed.X));
            }

            PlaySound("event:/game/05_mirror_temple/crystaltheo_hit_side", Position);
            if (Math.Abs(Speed.X) > 100f)
            {
                ImpactParticles(data.Direction);
            }

            Speed.X *= -0.4f;
        }

        private void OnCollideV(PixelCollision data)
        {
            if (data.Hit is OriginalDashSwitchState)
            {
                (data.Hit as OriginalDashSwitchState).OnDashCollide(null, Vector2.UnitY * Math.Sign(Speed.Y));
            }

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
                    PlaySound("event:/game/05_mirror_temple/crystaltheo_hit_ground", Position, "crystal_velocity", 0f);
                }
            }

            if (Speed.Y > 160f)
            {
                ImpactParticles(data.Direction);
            }

            if (Speed.Y > 140f && !(data.Hit is OriginalSwapBlockState) && !(data.Hit is OriginalDashSwitchState))
            {
                Speed.Y *= -0.6f;
            }
            else
            {
                Speed.Y = 0f;
            }
        }

        private void ImpactParticles(Vector2 dir)
        {
            float direction;
            Vector2 position;
            Vector2 positionRange;
            if (dir.X > 0f)
            {
                direction = (float)Math.PI;
                position = new Vector2(base.Right, base.Y - 4f);
                positionRange = Vector2.UnitY * 6f;
            }
            else if (dir.X < 0f)
            {
                direction = 0f;
                position = new Vector2(base.Left, base.Y - 4f);
                positionRange = Vector2.UnitY * 6f;
            }
            else if (dir.Y > 0f)
            {
                direction = -(float)Math.PI / 2f;
                position = new Vector2(base.X, base.Bottom);
                positionRange = Vector2.UnitX * 6f;
            }
            else
            {
                direction = (float)Math.PI / 2f;
                position = new Vector2(base.X, base.Top);
                positionRange = Vector2.UnitX * 6f;
            }

            Level.Particles.Emit(P_Impact, 12, position, positionRange, direction);
        }

        public override bool IsRiding(ISourceEntityCollider solid)
        {
            if (Speed.Y == 0f)
            {
                return base.IsRiding(solid);
            }

            return false;
        }

        protected override void OnSquish(PixelCollision data)
        {
            if (!TrySquishWiggle(data) &&
                !((IOriginalGameplayProcess)engine).SaveContext.CurrentSave.Assists.Invincible)
            {
                Die();
            }
        }

        private void OnPickup()
        {
            Speed = Vector2.Zero;
            AddTag(((IOriginalGameTagsEnvironment)engine).Tags.Persistent.Value);
        }

        private void OnRelease(Vector2 force)
        {
            RemoveTag(((IOriginalGameTagsEnvironment)engine).Tags.Persistent.Value);
            if (force.X != 0f && force.Y == 0f)
            {
                force.Y = -0.4f;
            }

            Speed = force * 200f;
            if (Speed != Vector2.Zero)
            {
                noGravityTimer = 0.1f;
            }
        }

        public void Die()
        {
            if (!dead)
            {
                dead = true;
                RoomPlayerSession entity =
                    Level.SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                        typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);

                entity?.Die(-Vector2.UnitX * (float)entity.Facing);
                PlaySound("event:/char/madeline/death", Position);
                OwnedComponents.Add(new DeathEffect(new PackedColor(34, 139, 34, 255), engine, base.Center - Position));
                sprite.Visible = false;
                base.Depth = -1000000;
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
