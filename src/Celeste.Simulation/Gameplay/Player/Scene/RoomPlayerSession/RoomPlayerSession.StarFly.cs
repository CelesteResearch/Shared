using System;
using System.Collections;
using System.Linq;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Gameplay.Player.Movement;
using Celeste.Simulation.Gameplay.Player.Presentation.Hair;
using Celeste.Simulation.Gameplay.Player.Runtime;
using Celeste.Simulation.Gameplay.Player.Scene.Particles;
using Celeste.Simulation.Presentation.PostProcessing.Bloom;
using Celeste.Simulation.Presentation.ScreenEffects;

// ReSharper disable once CheckNamespace
namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        private readonly PackedColor starFlyColor = new(255, 214, 92, 255);

        public float StarFlyTimer => Data.StarFlyTimer;
        public bool StarFlyTransforming { get; private set; }
        public float StarFlySpeedLerp { get; private set; }
        public Vector2 StarFlyLastDirection { get; private set; }

        public BloomPointState StarFlyBloom { get; private set; }

        public bool StarFlyBloomAttached => StarFlyBloom != null && Components.Contains(StarFlyBloom);
        public SoundSourceComponentState StarFlyLoopSound { get; private set; }

        public SoundSourceComponentState StarFlyWarningSound { get; private set; }


        private Vector2 StarFlyCenter => Center;

        private void BindStarFly()
        {
            Machine.SetCallbacks(19, UpdateStarFly, StarFlyCoroutine, BeginStarFly, EndStarFly);
        }

        public bool StartStarFly()
        {
            RefillStamina();
            if (Machine.State == 18) return false;
            if (Machine.State == 19)
            {
                Data.StarFlyTimer = 2;
                Sprite.Color = starFlyColor;
                ReportRumble(1, 1, "MediumMedium", Body.Position);
            }
            else
            {
                Machine.State = 19;
            }

            return true;
        }

        public void PointBounce(Vector2 from)
        {
            if (Machine.State == 2) Machine.State = 0;
            if (Machine.State == 4 && CurrentBooster != null) CurrentBooster.PlayerReleased();
            World.RefillDash();
            RefillStamina();
            var direction = VectorArithmetic.SafeNormalize(StarFlyCenter - from);
            if (direction.Y > -.2f && direction.Y <= .4f) direction.Y = -.2f;
            Data.Motion.Normal.Speed = direction * 220;
            Data.Motion.Normal.Speed.X *= 1.5f;
            if (Math.Abs(Data.Motion.Normal.Speed.X) < 100)
                Data.Motion.Normal.Speed.X = Data.Motion.Normal.Speed.X == 0
                    ? -Data.Facing * 100
                    : Math.Sign(Data.Motion.Normal.Speed.X) * 100;
        }

        private void BeginStarFly()
        {
            Sprite.Play("startStarFly");
            StarFlyTransforming = true;
            Data.StarFlyTimer = 2;
            StarFlySpeedLerp = 0;
            Data.Motion.JumpGraceTimer = 0;
            if (StarFlyBloom == null)
            {
                StarFlyBloom = new() { Position = new(0, -6), Alpha = 0, Radius = 16 };
                Components.Add(StarFlyBloom);
            }

            StarFlyBloom.Visible = true;
            StarFlyBloom.Alpha = 0;
            World.Contacts.SetCollider(World.Contacts.FeatherHitbox);
            World.Contacts.Hurtbox = World.Contacts.FeatherHurtbox;
            if (StarFlyLoopSound == null)
            {
                var sounds = ((ISourceSoundSourceEnvironment)EngineContext)
                    .SoundSources;
                StarFlyLoopSound = sounds.Create();
                Components.Add(StarFlyLoopSound);
                StarFlyLoopSound.DisposeOnTransition = false;
                StarFlyWarningSound = sounds.Create();
                Components.Add(StarFlyWarningSound);
                StarFlyWarningSound.DisposeOnTransition = false;
            }

            StarFlyLoopSound.Play("event:/game/06_reflection/feather_state_loop", "feather_speed", 1);
            StarFlyWarningSound.Stop();
        }

        private void EndStarFly()
        {
            Play("event:/game/06_reflection/feather_state_end");
            StarFlyWarningSound.Stop();
            StarFlyLoopSound.Stop();
            Hair.DrawPlayerSpriteOutline = false;
            Sprite.Color = PackedColor.White;
            StarFlyDisplacement();
            StarFlyBloom.Visible = false;
            Sprite.HairCount = Appearance.StartHairCount;
            StarFlyReturnToNormalHitbox();
            if (Machine.State != 2)
                ((ISourcePlayerStarFlyScene)Level)
                    .EmitStarFlyParticles(true, 12, StarFlyCenter, Vector2.One * 4,
                        Vector2Geometry.Angle(-Data.Motion.Normal.Speed));
        }

        private void StarFlyReturnToNormalHitbox()
        {
            var contacts = World.Contacts;
            contacts.SetCollider(contacts.NormalHitbox);
            contacts.Hurtbox = contacts.NormalHurtbox;
            if (!Body.CollideSolidAt(Position)) return;
            var position = Position;
            Y -= contacts.NormalHitbox.Bottom - contacts.FeatherHitbox.Bottom;
            if (Body.CollideSolidAt(Position))
            {
                Position = position;
                Data.Motion.Ducking = true;
                Y -= contacts.DuckHitbox.Bottom - contacts.FeatherHitbox.Bottom;
                if (Body.CollideSolidAt(Position))
                {
                    Position = position;
                    ((ISourcePlayerStarFlyExitEnvironment)
                            EngineContext)
                        .StarFlyExitPolicy.OnFailure(this);
                }
            }
        }

        private IEnumerator StarFlyCoroutine()
        {
            while (Sprite.CurrentAnimationID == "startStarFly") yield return null;
            while (Data.Motion.Normal.Speed != Vector2.Zero) yield return null;
            yield return .1f;
            Sprite.Color = starFlyColor;
            Sprite.HairCount = 7;
            Hair.DrawPlayerSpriteOutline = true;
            StarFlyDisplacement();
            StarFlyTransforming = false;
            Data.StarFlyTimer = 2;
            World.RefillDash();
            RefillStamina();
            var direction = Input.Feather.Value;
            if (direction == Vector2.Zero) direction = Vector2.UnitX * Data.Facing;
            Data.Motion.Normal.Speed = direction * 250;
            StarFlyLastDirection = direction;
            ((ISourcePlayerStarFlyScene)Level)
                .EmitStarFlyParticles(true, 12, StarFlyCenter, Vector2.One * 4,
                    Vector2Geometry.Angle(-direction));
            ReportRumble(2, 1, "StrongMedium", Body.Position);
            ((ISourceLevelShakeScene)Level).DirectionalShake(
                StarFlyLastDirection);
            while (Data.StarFlyTimer > .5f) yield return null;
            StarFlyWarningSound.Play("event:/game/06_reflection/feather_state_warning");
        }

        private int UpdateStarFly()
        {
            StarFlyBloom.Alpha =
                ScalarMath.Approach(StarFlyBloom.Alpha, .7f,
                    EngineContext.DeltaTime * 2);
            ReportRumble(3, 0, "ClimbShort", Body.Position);
            if (StarFlyTransforming)
            {
                Data.Motion.Normal.Speed = VectorArithmetic.Approach(Data.Motion.Normal.Speed, Vector2.Zero,
                    1000 * EngineContext.DeltaTime);
            }
            else
            {
                var aim = Input.Feather.Value;
                var noInput = false;
                if (aim == Vector2.Zero)
                {
                    noInput = true;
                    aim = StarFlyLastDirection;
                }

                var direction = VectorArithmetic.SafeNormalize(Data.Motion.Normal.Speed);
                direction = StarFlyLastDirection = direction != Vector2.Zero
                    ? VectorArithmetic.RotateTowards(direction,
                        Vector2Geometry.Angle(aim),
                        5.5850534f * EngineContext.DeltaTime)
                    : aim;
                float target;
                if (noInput)
                {
                    StarFlySpeedLerp = 0;
                    target = 91;
                }
                else if (direction != Vector2.Zero && VectorArithmetic.Dot(direction, aim) >= .45f)
                {
                    StarFlySpeedLerp =
                        ScalarMath.Approach(StarFlySpeedLerp, 1,
                            EngineContext.DeltaTime / 1);
                    target = ((ISourceScalarEnvironment)EngineContext).ScalarArithmetic
                        .Lerp(140f, 190f, StarFlySpeedLerp);
                }
                else
                {
                    StarFlySpeedLerp = 0;
                    target = 140;
                }

                StarFlyLoopSound.Param("feather_speed", noInput ? 0 : 1);
                var speed = VectorArithmetic.Length(Data.Motion.Normal.Speed);
                speed = ScalarMath.Approach(speed, target,
                    1000 * EngineContext.DeltaTime);
                Data.Motion.Normal.Speed = direction * speed;
                if (((ISourceScene)Level).SourceScene.Clock.OnInterval(.02f,
                        EngineContext))
                    ((ISourcePlayerStarFlyScene)Level)
                        .EmitStarFlyParticles(false, 1, StarFlyCenter, Vector2.One * 2,
                            Vector2Geometry.Angle(-Data.Motion.Normal.Speed));
                if (Input.Jump.Pressed)
                {
                    if (StarFlyOnGround())
                    {
                        World.Jump();
                        return 0;
                    }

                    if (World.WallJumpCheck(-1))
                    {
                        World.Jump(PlayerJump.Wall, 1);
                        return 0;
                    }

                    if (World.WallJumpCheck(1))
                    {
                        World.Jump(PlayerJump.Wall, -1);
                        return 0;
                    }
                }

                if (Input.GrabCheck)
                {
                    var climb = false;
                    var directionX = 0;
                    if (Input.MoveX.Value != -1 && World.ClimbCheck(1))
                    {
                        Data.Facing = 1;
                        directionX = 1;
                        climb = true;
                    }
                    else if (Input.MoveX.Value != 1 && World.ClimbCheck(-1))
                    {
                        Data.Facing = -1;
                        directionX = -1;
                        climb = true;
                    }

                    if (climb)
                    {
                        if (Settings.NoGrabbing)
                        {
                            Data.Motion.Normal.Speed = Vector2.Zero;
                            ClimbTrigger(directionX);
                            return 0;
                        }

                        return 1;
                    }
                }

                if (Motor.Dash.CanDash) return Motor.Dash.Start();
                Data.StarFlyTimer -= EngineContext.DeltaTime;
                if (Data.StarFlyTimer <= 0)
                {
                    if (Input.MoveY.Value == -1) Data.Motion.Normal.Speed.Y = -100;
                    if (Input.MoveY.Value < 1)
                    {
                        Data.Motion.Normal.VariableJumpSpeed = Data.Motion.Normal.Speed.Y;
                        Data.Motion.AutoJump = true;
                        Data.AutoJumpTimer = 0;
                        Data.Motion.Normal.VariableJumpTimer = .2f;
                    }

                    if (Data.Motion.Normal.Speed.Y > 0) Data.Motion.Normal.Speed.Y = 0;
                    if (Math.Abs(Data.Motion.Normal.Speed.X) > 140)
                        Data.Motion.Normal.Speed.X = 140 * Math.Sign(Data.Motion.Normal.Speed.X);
                    ReportRumble(1, 1, "MediumMedium", Body.Position);
                    return 0;
                }

                if (Data.StarFlyTimer < .5f &&
                    ((ISourceScene)Scene).SourceScene.Clock.OnInterval(.05f,
                        EngineContext))
                    Sprite.Color = Sprite.Color == starFlyColor
                        ? PlayerHairAppearance
                            .NormalHairColor
                        : starFlyColor;
            }

            return 19;
        }

        private void StarFlyDisplacement()
        {
            ((ISourcePlayerStarFlyScene)Level)
                .AddStarFlyBurst(StarFlyCenter);
        }

        private bool StarFlyOnGround()
        {
            return OnGround(3);
        }
    }
}
