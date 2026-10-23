using System;
using System.Numerics;
using Celeste.Input.Gameplay;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Player.Movement
{
    public sealed class NormalSequence
    {
        private readonly global::Celeste.Simulation.Gameplay.Player.State.PlayerState data;
        private readonly global::Celeste.Simulation.Gameplay.Player.Configuration.IPlayerAssistSettings settings;
        private readonly ISourceGameInput input;
        private readonly global::Celeste.Core.Scheduling.ISourceEngineContext engine;

        public global::Celeste.Core.Scheduling.ISourceEngineContext EngineContext => engine;
        public global::Celeste.Simulation.Gameplay.Player.State.PlayerState Data => data;
        public INormalWorld World => world;

        private global::Celeste.Core.Mathematics.Extrema.ISourceExtremaArithmetic Extrema =>
            ((global::Celeste.Core.Mathematics.Extrema.ISourceExtremaEnvironment)engine).ExtremaArithmetic;

        private readonly global::Celeste.Core.Mathematics.ISourceScalarArithmetic scalarArithmetic;
        private readonly global::Celeste.Simulation.Gameplay.Player.Dash.DashSequence dash;
        private readonly global::Celeste.Simulation.Gameplay.Player.Movement.INormalWorld world;

        public NormalSequence(global::Celeste.Simulation.Gameplay.Player.State.PlayerState data,
            global::Celeste.Simulation.Gameplay.Player.Configuration.IPlayerAssistSettings settings,
            ISourceGameInput input,
            global::Celeste.Core.Scheduling.SimulationStateMachine machine,
            global::Celeste.Simulation.Gameplay.Player.Dash.DashSequence dash,
            global::Celeste.Simulation.Gameplay.Player.Movement.INormalWorld world,
            global::Celeste.Core.Scheduling.ISourceEngineContext engine)
        {
            this.engine = engine;
            scalarArithmetic = ((global::Celeste.Core.Mathematics.ISourceScalarEnvironment)engine).ScalarArithmetic;
            this.data = data;
            this.settings = settings;
            this.input = input;
            this.dash = dash;
            this.world = world;
            machine.SetCallbacks(0, Update, begin: Begin, end: End);
        }

        public void Begin() => data.Motion.Normal.MaxFall = 160f;

        public void End()
        {
            data.Motion.WallBoostTimer = 0f;
            data.WallSpeedRetentionTimer = 0f;
            data.HopWaitX = 0;
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        public int Update()
        {
            int result = UpdateCore();
            return result;
        }

        private int UpdateCore()
        {
            float dt = input.DeltaTime;
            Vector2 lift = global::Celeste.Simulation.Gameplay.Player.Movement.JumpMotion.LiftBoost(world.LiftSpeed);
            if (lift.Y < 0f && data.WasOnGround && !data.OnGround && data.Motion.Normal.Speed.Y >= 0f)
                data.Motion.Normal.Speed.Y = lift.Y;
            if (!data.Holding)
            {
                if (input.GrabCheck && !data.IsTired && !data.Motion.Ducking)
                {
                    if (world.TryPickup()) return 8;
                    if (data.Motion.Normal.Speed.Y >= 0f && Math.Sign(data.Motion.Normal.Speed.X) != -data.Facing)
                    {
                        if (world.ClimbCheck(data.Facing))
                        {
                            data.Motion.Ducking = false;
                            if (!settings.NoGrabbing) return 1;
                            data.ClimbTriggerDirection = data.Facing;
                        }

                        if (!settings.NoGrabbing && input.MoveY.Value < 1 && world.WindY <= 0f)
                        {
                            for (int i = 1; i <= 2; i++)
                                if (!world.SolidAt(new Vector2(0, -i)) && world.ClimbCheck(data.Facing, -i))
                                {
                                    world.MoveVExact(-i);
                                    data.Motion.Ducking = false;
                                    return 1;
                                }
                        }
                    }
                }

                if (dash.CanDash)
                {
                    data.Motion.Normal.Speed +=
                        global::Celeste.Simulation.Gameplay.Player.Movement.JumpMotion.LiftBoost(world.LiftSpeed);
                    return dash.Start();
                }

                if (data.Motion.Ducking)
                {
                    if (data.OnGround && input.MoveY.Value != 1)
                    {
                        if (world.CanUnDuck)
                        {
                            data.Motion.Ducking = false;
                            data.Motion.Normal.SpriteScale = new Vector2(.8f, 1.2f);
                        }
                        else if (data.Motion.Normal.Speed.X == 0f)
                        {
                            for (int distance = 4; distance > 0; distance--)
                            {
                                if (world.CanUnDuckAt(new Vector2(distance, 0)))
                                {
                                    world.MoveH(50f * dt);
                                    break;
                                }

                                if (world.CanUnDuckAt(new Vector2(-distance, 0)))
                                {
                                    world.MoveH(-50f * dt);
                                    break;
                                }
                            }
                        }
                    }
                }
                else if (data.OnGround && input.MoveY.Value == 1 && data.Motion.Normal.Speed.Y >= 0f)
                {
                    data.Motion.Ducking = true;
                    data.Motion.Normal.SpriteScale = new Vector2(1.4f, .6f);
                }
            }
            else
            {
                if (!input.GrabCheck && data.MinHoldTimer <= 0f) world.Throw();
                if (!data.Motion.Ducking && data.OnGround && input.MoveY.Value == 1 &&
                    data.Motion.Normal.Speed.Y >= 0f && !data.Motion.Normal.HoldCannotDuck)
                {
                    world.Drop();
                    data.Motion.Ducking = true;
                    data.Motion.Normal.SpriteScale = new Vector2(1.4f, .6f);
                }
                else if (data.OnGround && data.Motion.Ducking && data.Motion.Normal.Speed.Y >= 0f)
                {
                    if (world.CanUnDuck) data.Motion.Ducking = false;
                    else world.Drop();
                }
                else if (data.OnGround && input.MoveY.Value != 1 && data.Motion.Normal.HoldCannotDuck)
                    data.Motion.Normal.HoldCannotDuck = false;
            }

            var context = new global::Celeste.Simulation.Gameplay.Player.Movement.NormalMotionContext
            {
                MoveX = data.MoveX, MoveY = input.MoveY.Value, GliderMoveY = input.GliderMoveY.Value,
                OnGround = data.OnGround, Ducking = data.Motion.Ducking, JumpHeld = input.Jump.Check,
                AutoJump = data.Motion.AutoJump,
                Cold = world.Cold, InSpace = world.InSpace, LowFriction = settings.LowFriction,
                HoldingSlowRun = data.Holding && world.HoldingSlowRun,
                HoldingSlowFall = data.Holding && world.HoldingSlowFall,
                WindMovedUp = data.WindMovedUp, LowFrictionStopTimer = data.Motion.LowFrictionStopTimer,
                ForceMoveXTimer = data.Motion.ForceMoveXTimer
            };
            global::Celeste.Simulation.Gameplay.Player.Movement.NormalMotion.UpdateHorizontal(ref data.Motion.Normal,
                context, dt, Extrema, scalarArithmetic);
            global::Celeste.Simulation.Gameplay.Player.Movement.NormalMotion.UpdateFallLimit(ref data.Motion.Normal,
                context, dt, Extrema, scalarArithmetic);
            if (!data.OnGround && (data.MoveX == data.Facing || (data.MoveX == 0 && input.GrabCheck)) &&
                input.MoveY.Value != 1)
            {
                // DIAGNOSTIC SEAM. The conjuncts of the wall-slide contact test, evaluated for
                // observation WITHOUT changing the test below. `reach` here is 1, not the 3 that
                // `WallJumpCheck` uses; reporting them separately is the point. All three probes are
                // pure reads, and `PlayerNormalStateObservations` is null in shipping, so this is one
                // value-type construction and one null test. See that file's header.
                if (global::Celeste.Simulation.Gameplay.Player.Diagnostics.PlayerNormalStateObservations
                        .WallSlideContactObserved != null)
                {
                    bool probeClimbBounds = world.ClimbBoundsCheck(data.Facing);
                    bool probeSolid = world.SolidAt(Vector2.UnitX * data.Facing);
                    bool probeEdge = world.ClimbEdgeBlocked(data.Facing);
                    bool probeCanUnDuck = world.CanUnDuck;
                    global::Celeste.Simulation.Gameplay.Player.Diagnostics.PlayerNormalStateObservations.Observed(
                        new global::Celeste.Simulation.Gameplay.Player.Diagnostics.PlayerNormalStateObservations.
                            WallSlideContact(
                                data.OnGround,
                                data.MoveX == data.Facing || (data.MoveX == 0 && input.GrabCheck),
                                input.MoveY.Value != 1,
                                data.Motion.Normal.Speed.Y >= 0f,
                                data.Motion.WallSlideTimer > 0f,
                                !data.Holding,
                                probeClimbBounds, probeSolid, !probeEdge, probeCanUnDuck,
                                data.Motion.Normal.Speed.Y, data.Motion.WallSlideTimer,
                                data.MoveX, data.Facing, data.WallSlideDirection,
                                input.GrabCheck,
                                probeClimbBounds && probeSolid && !probeEdge && probeCanUnDuck
                                && data.Motion.Normal.Speed.Y >= 0f && data.Motion.WallSlideTimer > 0f && !data.Holding,
                                data.Motion.Normal.VariableJumpTimer, data.Motion.Normal.VariableJumpSpeed,
                                context.JumpHeld));
                }

                if (data.Motion.Normal.Speed.Y >= 0f && data.Motion.WallSlideTimer > 0f && !data.Holding &&
                    world.ClimbBoundsCheck(data.Facing) && world.SolidAt(Vector2.UnitX * data.Facing) &&
                    !world.ClimbEdgeBlocked(data.Facing) && world.CanUnDuck)
                {
                    data.Motion.Ducking = false;
                    data.WallSlideDirection = data.Facing;
                }

                if (data.WallSlideDirection != 0)
                {
                    if (input.GrabCheck) data.ClimbTriggerDirection = data.WallSlideDirection;
                    if (data.Motion.WallSlideTimer > .6f && world.ClimbBlocked(data.WallSlideDirection))
                        data.Motion.WallSlideTimer = .6f;
                    context.WallSliding = true;
                    context.WallSlideTimer = data.Motion.WallSlideTimer;
                    if (data.Motion.WallSlideTimer / 1.2f > .65f) world.WallSlideParticles(data.WallSlideDirection);
                }
            }

            global::Celeste.Simulation.Gameplay.Player.Movement.NormalMotion.UpdateGravityAndJump(
                ref data.Motion.Normal, context, dt, Extrema, scalarArithmetic);
            // DIAGNOSTIC SEAM, evaluated EVERY FRAME regardless of input. The reference's HUD asks
            // `WallJumpCheck(1)` once per frame; the port asks it only inside the jump-press branch
            // below, so on frames with no jump press it never asks. These three reads per direction are
            // pure collision queries, reported after the fact and never read back — no branch depends
            // on them. See PlayerNormalStateObservations for why reach is 3 here and 1 in the
            // wall-slide test above.
            if (global::Celeste.Simulation.Gameplay.Player.Diagnostics.PlayerNormalStateObservations
                    .WallJumpContactObserved != null)
            {
                bool probeWjClimbR = world.ClimbBoundsCheck(1);
                bool probeWjEdgeR = !world.ClimbEdgeBlocked(3);
                bool probeWjSolidR = world.SolidAt(Vector2.UnitX * 3);
                bool probeWjClimbL = world.ClimbBoundsCheck(-1);
                bool probeWjEdgeL = !world.ClimbEdgeBlocked(-3);
                bool probeWjSolidL = world.SolidAt(Vector2.UnitX * -3);
                global::Celeste.Simulation.Gameplay.Player.Diagnostics.PlayerNormalStateObservations.Observed(
                    new global::Celeste.Simulation.Gameplay.Player.Diagnostics.PlayerNormalStateObservations.
                        WallJumpContact(
                            data.Facing, probeWjClimbR, probeWjEdgeR, probeWjSolidR,
                            probeWjClimbL, probeWjEdgeL, probeWjSolidL,
                            data.Motion.Normal.Speed.X, data.Motion.Normal.Speed.Y, data.MoveX,
                            data.OnGround, input.Jump.Pressed));
            }

            if (input.Jump.Pressed && (!world.PlayerOverTalk || !input[GameAction.Talk].Pressed))
            {
                if (data.Motion.JumpGraceTimer > 0f)
                    world.Jump(global::Celeste.Simulation.Gameplay.Player.Movement.PlayerJump.Standard, data.Facing);
                else if (world.CanUnDuck)
                {
                    bool canUnDuck = world.CanUnDuck;
                    bool wallRight = canUnDuck && world.WallJumpCheck(1);
                    bool wallLeft = !wallRight && canUnDuck && world.WallJumpCheck(-1);
                    int wall = wallRight ? 1 : wallLeft ? -1 : 0;
                    // DIAGNOSTIC SEAM. The direction-change decision at this frame, reported after it
                    // is computed and never read back; `PlayerNormalStateObservations` is null in
                    // shipping, so this is one value-type construction and one null test. See that
                    // file's header for why it exists and what it is not.
                    global::Celeste.Simulation.Gameplay.Player.Diagnostics.PlayerNormalStateObservations.Observed(
                        new global::Celeste.Simulation.Gameplay.Player.Diagnostics.PlayerNormalStateObservations.
                            ReversalDecision(
                                data.MoveX, data.Facing, data.Dashes,
                                data.Motion.Normal.Speed.X, data.Motion.Normal.Speed.Y,
                                data.Motion.WallSlideTimer, data.Motion.JumpGraceTimer,
                                input.GrabCheck, canUnDuck,
                                wall, wallRight ? 1 : 0, wallLeft ? 1 : 0,
                                input.Jump.Pressed, (wallRight ? 1 : wallLeft ? -1 : 0) != 0 && -wall != data.Facing));
                    if (wall != 0)
                    {
                        if (data.Facing == wall && input.GrabCheck && !settings.NoGrabbing && data.Stamina > 0f &&
                            !data.Holding && !world.ClimbBlocked(wall * 3))
                            world.Jump(global::Celeste.Simulation.Gameplay.Player.Movement.PlayerJump.Climb, wall);
                        else if (world.DashAttacking && data.SuperWallJumpAngle)
                            world.Jump(global::Celeste.Simulation.Gameplay.Player.Movement.PlayerJump.SuperWall, -wall);
                        else world.Jump(global::Celeste.Simulation.Gameplay.Player.Movement.PlayerJump.Wall, -wall);
                    }
                    else world.JumpFromWater();
                }
            }

            return 0;
        }
    }
}
