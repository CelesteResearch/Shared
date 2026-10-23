using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Scheduling;
using Celeste.Input.Gameplay;
using Celeste.Simulation.Gameplay.Player.Configuration;
using Celeste.Simulation.Gameplay.Player.Diagnostics;
using Celeste.Simulation.Gameplay.Player.Movement;
using Celeste.Simulation.Gameplay.Player.State;
using JetBrains.Annotations;

namespace Celeste.Simulation.Gameplay.Player.Dash
{
    // Player's standard dash callbacks, registered in the shared player state machine.
    // Player.Update still owns contact refresh, timer decrements and movement/collision phases;
    // the engine owns freeze frames and must not step this state machine during a freeze.
    public sealed class DashSequence
    {
        public readonly PlayerState Data;
        public readonly IPlayerAssistSettings Settings;
        private readonly ISourceGameInput input;
        private readonly ISourceVectorArithmetic vectorArithmetic;

        public ISourceEngineContext EngineContext { get; }

        public IDashWorld World => world;

        private ISourceExtremaArithmetic Extrema =>
            ((ISourceExtremaEnvironment)EngineContext).ExtremaArithmetic;

        private readonly SimulationStateMachine machine;

        [UsedImplicitly(ImplicitUseKindFlags.Access)]
        private readonly IDashWorld world;

        public DashSequence(PlayerState data,
            IPlayerAssistSettings settings,
            ISourceGameInput input, SimulationStateMachine machine,
            IDashWorld world,
            ISourceEngineContext engine)
        {
            EngineContext = engine;
            vectorArithmetic = ((ISourceVectorEnvironment)engine).VectorArithmetic;
            Data = data;
            Settings = settings;
            this.input = input;
            this.machine = machine;
            this.world = world;
            machine.SetCallbacks(2, Update, Coroutine, Begin, End);
        }

        public bool CanDash => (input.CrouchDashPressed || input.DashPressed) && Data.CooldownTimer <= 0f &&
                               Data.Dashes > 0 &&
                               (!world.PlayerOverTalk || !input[GameAction.Talk].Pressed) && !world.Chapter9BoosterBusy;

        public int Start()
        {
            Data.WasDashB = Data.Dashes == 2;
            Data.Dashes = Math.Max(0, Data.Dashes - 1);
            Data.DemoDashed = input.CrouchDashPressed;
            input.Dash.ConsumeBuffer();
            input.CrouchDash.ConsumeBuffer();
            return 2;
        }

        public void Begin()
        {
            Data.CalledEvents = false;
            Data.StartedOnGround = Data.OnGround;
            Data.Motion.Launched = false;
            Data.CanCurve = true;
            if (EngineContext.Effects.TimeRate > .25f) world.Freeze(.05f);
            Data.CooldownTimer = .2f;
            Data.RefillCooldownTimer = .1f;
            Data.StartedDashing = true;
            Data.Motion.WallSlideTimer = 1.2f;
            Data.TrailTimer = 0f;
            Data.TrailCounter = 0;
            if (!Settings.DashAssist) world.Emit(DashEffect.Rumble);
            Data.Motion.DashAttackTimer = .3f;
            Data.Motion.GliderBoostTimer = .55f;
            if (Settings.SuperDashing) Data.Motion.DashAttackTimer += .15f;
            Data.BeforeDashSpeed = Data.Motion.Normal.Speed;
            Data.Motion.Normal.Speed = Vector2.Zero;
            Data.Direction = Vector2.Zero;
            if (!Data.OnGround && Data.Motion.Ducking && world.CanUnDuck) Data.Motion.Ducking = false;
            else if (!Data.Motion.Ducking && (Data.DemoDashed || input.MoveY.Value == 1)) Data.Motion.Ducking = true;
            if (Settings.DashAssist && !Data.DemoDashed)
            {
                input.LastAim = Vector2.UnitX * Data.Facing;
                input.GetAimVector(Data.Facing);
                world.Emit(DashEffect.AssistInit);
            }
        }

        public void CallEvents()
        {
            if (Data.CalledEvents) return;
            Data.CalledEvents = true;
            world.Emit(DashEffect.DashStarted);
        }

        public void End()
        {
            CallEvents();
            Data.DemoDashed = false;
        }

        public int Update()
        {
            var deltaTime = input.DeltaTime;
            Data.StartedDashing = false;
            if (Data.TrailTimer > 0f)
            {
                Data.TrailTimer -= deltaTime;
                if (Data.TrailTimer <= 0f)
                {
                    world.Emit(DashEffect.Trail);
                    Data.TrailCounter--;
                    if (Data.TrailCounter > 0) Data.TrailTimer = .1f;
                }
            }

            if (Settings.SuperDashing && Data.CanCurve && input.Aim.Value != Vector2.Zero &&
                Data.Motion.Normal.Speed != Vector2.Zero)
            {
                // The native call uses default facing, rather than the player's current facing.
                var aim = CorrectPrecision(input.GetAimVector());
                var normalized = vectorArithmetic.SafeNormalize(Data.Motion.Normal.Speed);
                var dot = aim.X * normalized.X + aim.Y * normalized.Y;
                if (dot >= -.1f && dot < .99f)
                {
                    var speed = Data.Motion.Normal.Speed;
                    float angle = (float)Math.Atan2(speed.Y, speed.X), target = (float)Math.Atan2(aim.Y, aim.X);
                    var difference = target - angle;
                    while (difference > (float)Math.PI) difference -= (float)Math.PI * 2f;
                    while (difference <= -(float)Math.PI) difference += (float)Math.PI * 2f;
                    var step = 4.1887903f * deltaTime;
                    angle = Math.Abs(difference) < step
                        ? target
                        : angle + Extrema.Max(-step, Extrema.Min(step, difference));
                    var length = (float)Math.Sqrt(speed.X * speed.X + speed.Y * speed.Y);
                    Data.Motion.Normal.Speed =
                        new((float)Math.Cos(angle) * length, (float)Math.Sin(angle) * length);
                    Data.Direction = CorrectPrecision(vectorArithmetic.SafeNormalize(Data.Motion.Normal.Speed));
                }
            }

            if (Settings.SuperDashing && CanDash)
            {
                Start();
                machine.ForceState(2);
                return 2;
            }

            var tired = (Data.Motion.WallBoostTimer > 0f ? Data.Stamina + 27.5f : Data.Stamina) < 20f;
            if (!Data.Holding && Data.Direction != Vector2.Zero && input.GrabCheck && !tired && world.CanUnDuck &&
                world.TryPickup()) return 8;
            if (Math.Abs(Data.Direction.Y) < .1f)
            {
                world.CorrectJumpThrus();
                if (world.CanUnDuck && input.Jump.Pressed && Data.Motion.JumpGraceTimer > 0f)
                {
                    world.Jump(PlayerJump.Super, Data.Facing);
                    return 0;
                }
            }

            var superWall = Math.Abs(Data.Direction.X) <= .2f && Data.Direction.Y <= -.75f;
            if (input.Jump.Pressed && world.CanUnDuck)
                for (var direction = 1; direction >= -1; direction -= 2)
                {
                    if (!world.WallJumpCheck(direction)) continue;
                    if (superWall)
                        world.Jump(PlayerJump.SuperWall,
                            -direction);
                    else if (Data.Facing == direction && input.GrabCheck && Data.Stamina > 0f && !Data.Holding &&
                             !world.ClimbBlocked(direction * 3))
                        world.Jump(PlayerJump.Climb, direction);
                    else world.Jump(PlayerJump.Wall, -direction);
                    return 0;
                }

            if (Data.Motion.Normal.Speed != Vector2.Zero && world.ParticleInterval)
                world.Emit(DashEffect.Particle);
            return 2;
        }

        public IEnumerator Coroutine()
        {
            yield return null;
            if (Settings.DashAssist) world.Emit(DashEffect.Rumble);
            world.Emit(DashEffect.Displacement);
            var direction = CorrectPrecision(Data.OverrideDirection ?? Data.LastAim);
            var speed = direction * 240f;
            if (Math.Sign(Data.BeforeDashSpeed.X) == Math.Sign(speed.X) &&
                Math.Abs(Data.BeforeDashSpeed.X) > Math.Abs(speed.X)) speed.X = Data.BeforeDashSpeed.X;
            // DIAGNOSTIC SEAM. The dash DIRECTION decision, reported after it is computed and never
            // read back; `PlayerNormalStateObservations` is null in shipping, so this is one
            // value-type construction and one null test. See that file's header. Recorded here
            // because this is where `Data.Direction` is first resolved from the aim, which is the
            // decision the `1A` route diverges on.
            PlayerNormalStateObservations.Observed(
                new PlayerNormalStateObservations.DashDecision(
                    input.MoveX.Value, input.MoveY.Value, Data.LastAim.X, Data.LastAim.Y,
                    Data.BeforeDashSpeed.X, Data.BeforeDashSpeed.Y, speed.X, speed.Y,
                    Data.Dashes, Data.Facing, input.Dash.Pressed || input.CrouchDashPressed,
                    Data.OnGround, Data.Motion.Ducking));
            Data.Motion.Normal.Speed = speed;
            if (world.InWater) Data.Motion.Normal.Speed *= .75f;
            Data.Motion.GliderBoostDirection = Data.Direction = direction;
            world.Emit(DashEffect.DirectionalShake);
            if (Data.Direction.X != 0f) Data.Facing = Math.Sign(Data.Direction.X);
            CallEvents();
            if (machine.PreviousState == 19)
                world.Emit(DashEffect.FeatherBoost);
            if (Data.OnGround && Data.Direction.X != 0f && Data.Direction.Y > 0f && Data.Motion.Normal.Speed.Y > 0f &&
                !world.DreamDashIntoBlock)
            {
                Data.Direction.X = Math.Sign(Data.Direction.X);
                Data.Direction.Y = 0f;
                Data.Motion.Normal.Speed.Y = 0f;
                Data.Motion.Normal.Speed.X *= 1.2f;
                Data.Motion.Ducking = true;
            }

            world.Emit(DashEffect.Slash);
            world.Emit(DashEffect.Trail);
            Data.TrailTimer = Settings.SuperDashing ? .1f : .08f;
            Data.TrailCounter = Settings.SuperDashing ? 2 : 1;
            if (Data.Direction.X != 0f && input.GrabCheck && world.MatchingSwapBlockAhead(Math.Sign(Data.Direction.X)))
            {
                machine.State = 1;
                Data.Motion.Normal.Speed = Vector2.Zero;
                yield break;
            }

            var swapCancel = world.SwapCancel(Data.Direction);
            if (swapCancel.X == 0f) Data.Motion.Normal.Speed.X = 0f;
            if (swapCancel.Y == 0f) Data.Motion.Normal.Speed.Y = 0f;
            if (Settings.SuperDashing) yield return .3f;
            else yield return .15f;
            world.Emit(DashEffect.Trail);
            Data.Motion.AutoJump = true;
            Data.AutoJumpTimer = 0f;
            if (Data.Direction.Y <= 0f)
            {
                Data.Motion.Normal.Speed = Data.Direction * 160f;
                Data.Motion.Normal.Speed.X *= swapCancel.X;
                Data.Motion.Normal.Speed.Y *= swapCancel.Y;
            }

            if (Data.Motion.Normal.Speed.Y < 0f) Data.Motion.Normal.Speed.Y *= .75f;
            machine.State = 0;
        }

        public static Vector2 CorrectPrecision(Vector2 direction)
        {
            if (direction.X != 0f && Math.Abs(direction.X) < .001f)
            {
                direction.X = 0f;
                direction.Y = Math.Sign(direction.Y);
            }
            else if (direction.Y != 0f && Math.Abs(direction.Y) < .001f)
            {
                direction.Y = 0f;
                direction.X = Math.Sign(direction.X);
            }

            return direction;
        }
    }
}
