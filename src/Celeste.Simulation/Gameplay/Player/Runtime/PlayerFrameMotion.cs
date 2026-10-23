using System;
using System.Numerics;
using Celeste.Input.Gameplay;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Player.Runtime
{
    // Movement bookkeeping in Player.Update before the state-machine component runs.
    // Input.Update runs first; presentation/variant hooks and the post-component movement
    // phase belong to the player host. This does not advance input, components, or lift grace.
    public sealed class PlayerFrameMotion
    {
        private readonly global::Celeste.Simulation.Gameplay.Player.State.PlayerState data;
        private readonly global::Celeste.Simulation.Gameplay.Player.Configuration.IPlayerAssistSettings settings;
        private readonly ISourceGameInput input;
        private readonly global::Celeste.Core.Scheduling.SimulationStateMachine machine;
        private readonly global::Celeste.Simulation.Gameplay.Player.Audio.Frame.IPlayerFrameWorld world;

        public PlayerFrameMotion(global::Celeste.Simulation.Gameplay.Player.State.PlayerState data,
            global::Celeste.Simulation.Gameplay.Player.Configuration.IPlayerAssistSettings settings,
            ISourceGameInput input,
            global::Celeste.Core.Scheduling.SimulationStateMachine machine,
            global::Celeste.Simulation.Gameplay.Player.Audio.Frame.IPlayerFrameWorld world)
        {
            this.data = data;
            this.settings = settings;
            this.input = input;
            this.machine = machine;
            this.world = world;
        }

        public static bool InControl(int state) => state < 11 || state > 17 && state != 23 && state != 25;

        public int MaxDashes =>
            settings.DashMode != global::Celeste.Simulation.Gameplay.Player.Configuration.DashMode.Normal &&
            !world.InCutscene
                ? 2
                : world.InventoryDashes;

        public bool RefillDash()
        {
            if (data.Dashes >= MaxDashes) return false;
            data.Dashes = MaxDashes;
            return true;
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        public void Update(float deltaTime)
        {
            ref var motion = ref data.Motion;
            ref var normal = ref motion.Normal;
            if (settings.InfiniteStamina) data.Stamina = 110f;
            data.PreviousPosition = world.Position;
            world.FlushSpriteReset();
            data.ClimbTriggerDirection = 0;
            world.UpdateHiccups(deltaTime);
            if (motion.GliderBoostTimer > 0f) motion.GliderBoostTimer -= deltaTime;
            if (motion.LowFrictionStopTimer > 0f) motion.LowFrictionStopTimer -= deltaTime;
            if (data.ExplodeLaunchBoostTimer > 0f)
            {
                if (input.MoveX.Value == Math.Sign(data.ExplodeLaunchBoostSpeed))
                {
                    normal.Speed.X = data.ExplodeLaunchBoostSpeed;
                    data.ExplodeLaunchBoostTimer = 0f;
                }
                else data.ExplodeLaunchBoostTimer -= deltaTime;
            }

            world.UpdateIdleBookkeeping(deltaTime);
            data.OnGround = data.OnSafeGround = false;
            if (machine.State != 9 && normal.Speed.Y >= 0f)
            {
                data.OnGround = world.GroundAtOnePixel(out bool safe);
                if (data.OnGround) data.OnSafeGround = safe;
            }

            if (machine.State == 3) data.OnSafeGround = true;
            if (data.OnSafeGround && world.SafeGroundBlocked()) data.OnSafeGround = false;
            data.FootstepOnLandTimer -= deltaTime;
            data.HighestAirY = data.OnGround ? world.Position.Y : Math.Min(world.Position.Y, data.HighestAirY);
            if (world.OnInterval(.05f)) world.ToggleFlash();
            if (data.WallSlideDirection != 0)
            {
                motion.WallSlideTimer = Math.Max(motion.WallSlideTimer - deltaTime, 0f);
                data.WallSlideDirection = 0;
            }

            if (motion.WallBoostTimer > 0f)
            {
                motion.WallBoostTimer -= deltaTime;
                // Native code reads the previous frame's moveX here.
                if (data.MoveX == data.WallBoostDirection)
                {
                    normal.Speed.X = 130f * data.MoveX;
                    data.Stamina += 27.5f;
                    motion.WallBoostTimer = 0f;
                    world.ResetSweat();
                }
            }

            if (data.OnGround && machine.State != 1)
            {
                motion.AutoJump = false;
                data.Stamina = 110f;
                motion.WallSlideTimer = 1.2f;
            }

            if (motion.DashAttackTimer > 0f) motion.DashAttackTimer -= deltaTime;
            if (data.OnGround)
            {
                data.DreamJump = false;
                motion.JumpGraceTimer = .1f;
            }
            else if (motion.JumpGraceTimer > 0f) motion.JumpGraceTimer -= deltaTime;

            if (data.CooldownTimer > 0f) data.CooldownTimer -= deltaTime;
            if (data.RefillCooldownTimer > 0f) data.RefillCooldownTimer -= deltaTime;
            else if (settings.DashMode == global::Celeste.Simulation.Gameplay.Player.Configuration.DashMode.Infinite &&
                     !world.InCutscene) RefillDash();
            else if (!world.NoRefills)
            {
                if (machine.State == 3) RefillDash();
                else if (data.OnGround && world.RefillGroundAtOnePixel() &&
                         (!world.TouchingSpikes() || settings.Invincible)) RefillDash();
            }

            if (normal.VariableJumpTimer > 0f) normal.VariableJumpTimer -= deltaTime;
            if (data.AutoJumpTimer > 0f)
            {
                if (motion.AutoJump)
                {
                    data.AutoJumpTimer -= deltaTime;
                    if (data.AutoJumpTimer <= 0f) motion.AutoJump = false;
                }
                else data.AutoJumpTimer = 0f;
            }

            if (motion.ForceMoveXTimer > 0f)
            {
                motion.ForceMoveXTimer -= deltaTime;
                data.MoveX = motion.ForceMoveX;
            }
            else
            {
                data.MoveX = input.MoveX.Value;
                data.ClimbHopSolid = null;
            }

            if (data.ClimbHopSolid != null && !data.ClimbHopSolid.Collidable) data.ClimbHopSolid = null;
            else if (data.ClimbHopSolid != null && data.ClimbHopSolid.Position != data.ClimbHopSolidPosition)
            {
                Vector2 movement = data.ClimbHopSolid.Position - data.ClimbHopSolidPosition;
                data.ClimbHopSolidPosition = data.ClimbHopSolid.Position;
                world.MoveHExact((int)movement.X);
                world.MoveVExact((int)movement.Y);
            }

            if (data.NoWindTimer > 0f) data.NoWindTimer -= deltaTime;
            if (data.MoveX != 0 && InControl(machine.State) && machine.State != 1 && machine.State != 8 &&
                machine.State != 5 && machine.State != 6)
            {
                if (data.MoveX != data.Facing && motion.Ducking) normal.SpriteScale = new Vector2(.8f, 1.2f);
                data.Facing = data.MoveX;
            }

            data.LastAim = input.GetAimVector(data.Facing);
            if (data.WallSpeedRetentionTimer > 0f)
            {
                if (Math.Sign(normal.Speed.X) == -Math.Sign(data.WallSpeedRetained)) data.WallSpeedRetentionTimer = 0f;
                else if (!world.SolidAt(Vector2.UnitX * Math.Sign(data.WallSpeedRetained)))
                {
                    normal.Speed.X = data.WallSpeedRetained;
                    data.WallSpeedRetentionTimer = 0f;
                }
                else data.WallSpeedRetentionTimer -= deltaTime;
            }

            if (data.HopWaitX != 0)
            {
                if (Math.Sign(normal.Speed.X) == -data.HopWaitX || normal.Speed.Y > 0f) data.HopWaitX = 0;
                else if (!world.SolidAt(Vector2.UnitX * data.HopWaitX))
                {
                    motion.LowFrictionStopTimer = .15f;
                    normal.Speed.X = data.HopWaitXSpeed;
                    data.HopWaitX = 0;
                }
            }

            if (data.MinHoldTimer > 0f) data.MinHoldTimer -= deltaTime;
            if (motion.Launched)
            {
                if (normal.Speed.LengthSquared() < 19600f) motion.Launched = false;
                else
                {
                    float previous = data.LaunchedTimer;
                    data.LaunchedTimer += deltaTime;
                    if (data.LaunchedTimer >= .5f)
                    {
                        motion.Launched = false;
                        data.LaunchedTimer = 0f;
                    }
                    else if ((int)(previous / .15f) != (int)(data.LaunchedTimer / .15f)) world.SpeedRing();
                }
            }
            else data.LaunchedTimer = 0f;

            // Player.orig_Update stores wasTired after launchedTimer and before
            // Actor.Update invokes components and the state machine.
            data.WasTired = data.IsTired;
        }
    }
}
