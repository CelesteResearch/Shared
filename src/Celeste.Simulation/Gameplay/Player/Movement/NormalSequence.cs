using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Scheduling;
using Celeste.Input.Gameplay;
using Celeste.Simulation.Gameplay.Player.Configuration;
using Celeste.Simulation.Gameplay.Player.Dash;
using Celeste.Simulation.Gameplay.Player.Diagnostics;
using Celeste.Simulation.Gameplay.Player.State;
using JetBrains.Annotations;

namespace Celeste.Simulation.Gameplay.Player.Movement
{
    public sealed class NormalSequence
    {
        [UsedImplicitly(ImplicitUseKindFlags.Access)]
        private readonly PlayerState data;

        private readonly IPlayerAssistSettings settings;
        private readonly ISourceGameInput input;

        [UsedImplicitly(ImplicitUseKindFlags.Access)]
        private readonly ISourceEngineContext engine;

        public ISourceEngineContext EngineContext => engine;
        public PlayerState Data => data;
        public INormalWorld World { get; }

        private ISourceExtremaArithmetic Extrema =>
            ((ISourceExtremaEnvironment)engine).ExtremaArithmetic;

        private readonly ISourceScalarArithmetic scalarArithmetic;
        private readonly DashSequence dash;

        public NormalSequence(PlayerState data,
            IPlayerAssistSettings settings,
            ISourceGameInput input,
            SimulationStateMachine machine,
            DashSequence dash,
            INormalWorld world,
            ISourceEngineContext engine)
        {
            this.engine = engine;
            scalarArithmetic = ((ISourceScalarEnvironment)engine).ScalarArithmetic;
            this.data = data;
            this.settings = settings;
            this.input = input;
            this.dash = dash;
            World = world;
            machine.SetCallbacks(0, Update, begin: Begin, end: End);
        }

        public void Begin()
        {
            data.Motion.Normal.MaxFall = 160f;
        }

        public void End()
        {
            data.Motion.WallBoostTimer = 0f;
            data.WallSpeedRetentionTimer = 0f;
            data.HopWaitX = 0;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public int Update()
        {
            var result = UpdateCore();
            return result;
        }

        private int UpdateCore()
        {
            var dt = input.DeltaTime;
            var lift = JumpMotion.LiftBoost(World.LiftSpeed);
            if (lift.Y < 0f && data.WasOnGround && !data.OnGround && data.Motion.Normal.Speed.Y >= 0f)
                data.Motion.Normal.Speed.Y = lift.Y;
            if (!data.Holding)
            {
                if (input.GrabCheck && !data.IsTired && !data.Motion.Ducking)
                {
                    if (World.TryPickup()) return 8;
                    if (data.Motion.Normal.Speed.Y >= 0f && Math.Sign(data.Motion.Normal.Speed.X) != -data.Facing)
                    {
                        if (World.ClimbCheck(data.Facing))
                        {
                            data.Motion.Ducking = false;
                            if (!settings.NoGrabbing) return 1;
                            data.ClimbTriggerDirection = data.Facing;
                        }

                        if (!settings.NoGrabbing && input.MoveY.Value < 1 && World.WindY <= 0f)
                            for (var i = 1; i <= 2; i++)
                                if (!World.SolidAt(new(0, -i)) && World.ClimbCheck(data.Facing, -i))
                                {
                                    World.MoveVExact(-i);
                                    data.Motion.Ducking = false;
                                    return 1;
                                }
                    }
                }

                if (dash.CanDash)
                {
                    data.Motion.Normal.Speed +=
                        JumpMotion.LiftBoost(World.LiftSpeed);
                    return dash.Start();
                }

                if (data.Motion.Ducking)
                {
                    if (data.OnGround && input.MoveY.Value != 1)
                    {
                        if (World.CanUnDuck)
                        {
                            data.Motion.Ducking = false;
                            data.Motion.Normal.SpriteScale = new(.8f, 1.2f);
                        }
                        else if (data.Motion.Normal.Speed.X == 0f)
                        {
                            for (var distance = 4; distance > 0; distance--)
                            {
                                if (World.CanUnDuckAt(new(distance, 0)))
                                {
                                    World.MoveH(50f * dt);
                                    break;
                                }

                                if (World.CanUnDuckAt(new(-distance, 0)))
                                {
                                    World.MoveH(-50f * dt);
                                    break;
                                }
                            }
                        }
                    }
                }
                else if (data.OnGround && input.MoveY.Value == 1 && data.Motion.Normal.Speed.Y >= 0f)
                {
                    data.Motion.Ducking = true;
                    data.Motion.Normal.SpriteScale = new(1.4f, .6f);
                }
            }
            else
            {
                if (!input.GrabCheck && data.MinHoldTimer <= 0f) World.Throw();
                if (!data.Motion.Ducking && data.OnGround && input.MoveY.Value == 1 &&
                    data.Motion.Normal.Speed.Y >= 0f && !data.Motion.Normal.HoldCannotDuck)
                {
                    World.Drop();
                    data.Motion.Ducking = true;
                    data.Motion.Normal.SpriteScale = new(1.4f, .6f);
                }
                else if (data.OnGround && data.Motion.Ducking && data.Motion.Normal.Speed.Y >= 0f)
                {
                    if (World.CanUnDuck) data.Motion.Ducking = false;
                    else World.Drop();
                }
                else if (data.OnGround && input.MoveY.Value != 1 && data.Motion.Normal.HoldCannotDuck)
                {
                    data.Motion.Normal.HoldCannotDuck = false;
                }
            }

            var context = new NormalMotionContext
            {
                MoveX = data.MoveX, MoveY = input.MoveY.Value, GliderMoveY = input.GliderMoveY.Value,
                OnGround = data.OnGround, Ducking = data.Motion.Ducking, JumpHeld = input.Jump.Check,
                AutoJump = data.Motion.AutoJump,
                Cold = World.Cold, InSpace = World.InSpace, LowFriction = settings.LowFriction,
                HoldingSlowRun = data.Holding && World.HoldingSlowRun,
                HoldingSlowFall = data.Holding && World.HoldingSlowFall,
                WindMovedUp = data.WindMovedUp, LowFrictionStopTimer = data.Motion.LowFrictionStopTimer,
                ForceMoveXTimer = data.Motion.ForceMoveXTimer,
            };
            NormalMotion.UpdateHorizontal(ref data.Motion.Normal,
                context, dt, Extrema, scalarArithmetic);
            NormalMotion.UpdateFallLimit(ref data.Motion.Normal,
                context, dt, Extrema, scalarArithmetic);
            if (!data.OnGround && (data.MoveX == data.Facing || (data.MoveX == 0 && input.GrabCheck)) &&
                input.MoveY.Value != 1)
            {
                // DIAGNOSTIC SEAM. The conjuncts of the wall-slide contact test, evaluated for
                // observation WITHOUT changing the test below. `reach` here is 1, not the 3 that
                // `WallJumpCheck` uses; reporting them separately is the point. All three probes are
                // pure reads, and `PlayerNormalStateObservations` is null in shipping, so this is one
                // value-type construction and one null test. See that file's header.
                if (PlayerNormalStateObservations
                        .WallSlideContactObserved != null)
                {
                    var probeClimbBounds = World.ClimbBoundsCheck(data.Facing);
                    var probeSolid = World.SolidAt(Vector2.UnitX * data.Facing);
                    var probeEdge = World.ClimbEdgeBlocked(data.Facing);
                    var probeCanUnDuck = World.CanUnDuck;
                    PlayerNormalStateObservations.Observed(
                        new PlayerNormalStateObservations.WallSlideContact(
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
                    World.ClimbBoundsCheck(data.Facing) && World.SolidAt(Vector2.UnitX * data.Facing) &&
                    !World.ClimbEdgeBlocked(data.Facing) && World.CanUnDuck)
                {
                    data.Motion.Ducking = false;
                    data.WallSlideDirection = data.Facing;
                }

                if (data.WallSlideDirection != 0)
                {
                    if (input.GrabCheck) data.ClimbTriggerDirection = data.WallSlideDirection;
                    if (data.Motion.WallSlideTimer > .6f && World.ClimbBlocked(data.WallSlideDirection))
                        data.Motion.WallSlideTimer = .6f;
                    context.WallSliding = true;
                    context.WallSlideTimer = data.Motion.WallSlideTimer;
                    if (data.Motion.WallSlideTimer / 1.2f > .65f) World.WallSlideParticles(data.WallSlideDirection);
                }
            }

            NormalMotion.UpdateGravityAndJump(
                ref data.Motion.Normal, context, dt, Extrema, scalarArithmetic);
            // DIAGNOSTIC SEAM, evaluated EVERY FRAME regardless of input. The reference's HUD asks
            // `WallJumpCheck(1)` once per frame; the port asks it only inside the jump-press branch
            // below, so on frames with no jump press it never asks. These three reads per direction are
            // pure collision queries, reported after the fact and never read back — no branch depends
            // on them. See PlayerNormalStateObservations for why reach is 3 here and 1 in the
            // wall-slide test above.
            if (PlayerNormalStateObservations
                    .WallJumpContactObserved != null)
            {
                var probeWjClimbR = World.ClimbBoundsCheck(1);
                var probeWjEdgeR = !World.ClimbEdgeBlocked(3);
                var probeWjSolidR = World.SolidAt(Vector2.UnitX * 3);
                var probeWjClimbL = World.ClimbBoundsCheck(-1);
                var probeWjEdgeL = !World.ClimbEdgeBlocked(-3);
                var probeWjSolidL = World.SolidAt(Vector2.UnitX * -3);
                PlayerNormalStateObservations.Observed(
                    new PlayerNormalStateObservations.WallJumpContact(
                        data.Facing, probeWjClimbR, probeWjEdgeR, probeWjSolidR,
                        probeWjClimbL, probeWjEdgeL, probeWjSolidL,
                        data.Motion.Normal.Speed.X, data.Motion.Normal.Speed.Y, data.MoveX,
                        data.OnGround, input.Jump.Pressed));
            }

            if (input.Jump.Pressed && (!World.PlayerOverTalk || !input[GameAction.Talk].Pressed))
            {
                if (data.Motion.JumpGraceTimer > 0f)
                {
                    World.Jump(PlayerJump.Standard, data.Facing);
                }
                else if (World.CanUnDuck)
                {
                    var canUnDuck = World.CanUnDuck;
                    var wallRight = canUnDuck && World.WallJumpCheck(1);
                    var wallLeft = !wallRight && canUnDuck && World.WallJumpCheck(-1);
                    var wall = wallRight ? 1 : wallLeft ? -1 : 0;
                    // DIAGNOSTIC SEAM. The direction-change decision at this frame, reported after it
                    // is computed and never read back; `PlayerNormalStateObservations` is null in
                    // shipping, so this is one value-type construction and one null test. See that
                    // file's header for why it exists and what it is not.
                    PlayerNormalStateObservations.Observed(
                        new PlayerNormalStateObservations.ReversalDecision(
                            data.MoveX, data.Facing, data.Dashes,
                            data.Motion.Normal.Speed.X, data.Motion.Normal.Speed.Y,
                            data.Motion.WallSlideTimer, data.Motion.JumpGraceTimer,
                            input.GrabCheck, canUnDuck,
                            wall, wallRight ? 1 : 0, wallLeft ? 1 : 0,
                            input.Jump.Pressed, (wallRight ? 1 : wallLeft ? -1 : 0) != 0 && -wall != data.Facing));
                    if (wall != 0)
                    {
                        if (data.Facing == wall && input.GrabCheck && !settings.NoGrabbing && data.Stamina > 0f &&
                            !data.Holding && !World.ClimbBlocked(wall * 3))
                            World.Jump(PlayerJump.Climb, wall);
                        else if (World.DashAttacking && data.SuperWallJumpAngle)
                            World.Jump(PlayerJump.SuperWall, -wall);
                        else World.Jump(PlayerJump.Wall, -wall);
                    }
                    else
                    {
                        World.JumpFromWater();
                    }
                }
            }

            return 0;
        }
    }
}
