using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Scheduling;
using Celeste.Input.Gameplay;
using Celeste.Simulation.Gameplay.Player.Dash;
using Celeste.Simulation.Gameplay.Player.State;
using JetBrains.Annotations;

namespace Celeste.Simulation.Gameplay.Player.Movement
{
    public sealed class ClimbSequence
    {
        [UsedImplicitly(ImplicitUseKindFlags.Access)]
        private readonly PlayerState data;

        private readonly ISourceGameInput input;

        [UsedImplicitly(ImplicitUseKindFlags.Access)]
        private readonly ISourceEngineContext engine;

        public ISourceEngineContext EngineContext => engine;
        public PlayerState Data => data;
        public IClimbWorld World => world;

        private ISourceExtremaArithmetic Extrema =>
            ((ISourceExtremaEnvironment)engine).ExtremaArithmetic;

        private readonly DashSequence dash;

        [UsedImplicitly(ImplicitUseKindFlags.Access)]
        private readonly IClimbWorld world;

        public ClimbSequence(PlayerState data, ISourceGameInput input,
            SimulationStateMachine machine,
            DashSequence dash,
            IClimbWorld world,
            ISourceEngineContext engine)
        {
            this.engine = engine;
            this.data = data;
            this.input = input;
            this.dash = dash;
            this.world = world;
            machine.SetCallbacks(1, Update, begin: Begin, end: End);
        }

        public void Begin()
        {
            data.Motion.AutoJump = false;
            data.Motion.Normal.Speed.X = 0f;
            data.Motion.Normal.Speed.Y *= .2f;
            data.Motion.WallSlideTimer = 1.2f;
            data.ClimbNoMoveTimer = .1f;
            data.Motion.WallBoostTimer = 0f;
            data.LastClimbMove = 0;
            world.Emit(ClimbEffect.GrabRumble);
            for (var i = 0; i < 2; i++)
            {
                if (world.SolidAt(Vector2.UnitX * data.Facing)) break;
                world.NudgePosition(Vector2.UnitX * data.Facing);
            }

            world.Emit(ClimbEffect.GrabSurface);
        }

        public void End()
        {
            if (world.ConveyorLoopActive)
                world.Emit(ClimbEffect.ConveyorStop);
            data.WallSpeedRetentionTimer = 0f;
            if (world.SweatAnimation != null && world.SweatAnimation != "jump") world.PlaySweat("idle");
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public int Update()
        {
            var dt = input.DeltaTime;
            data.ClimbNoMoveTimer -= dt;
            if (data.OnGround) data.Stamina = 110f;
            if (input.Jump.Pressed && (!data.Motion.Ducking || world.CanUnDuck))
            {
                if (data.MoveX == -data.Facing)
                    world.Jump(PlayerJump.Wall, -data.Facing);
                else world.Jump(PlayerJump.Climb, data.Facing);
                return 0;
            }

            if (dash.CanDash)
            {
                data.Motion.Normal.Speed +=
                    JumpMotion.LiftBoost(world.LiftSpeed);
                return dash.Start();
            }

            if (!input.GrabCheck)
            {
                data.Motion.Normal.Speed +=
                    JumpMotion.LiftBoost(world.LiftSpeed);
                world.Emit(ClimbEffect.LetGo);
                return 0;
            }

            if (!world.SolidAt(Vector2.UnitX * data.Facing))
            {
                if (data.Motion.Normal.Speed.Y < 0f)
                {
                    if (data.WallBoosting)
                    {
                        data.Motion.Normal.Speed +=
                            JumpMotion.LiftBoost(world.LiftSpeed);
                        world.Emit(ClimbEffect.LetGo);
                    }
                    else
                    {
                        Hop();
                    }
                }

                return 0;
            }

            var booster = world.WallBoosterCheck();
            if (data.ClimbNoMoveTimer <= 0f && booster)
            {
                data.WallBoosting = true;
                if (!world.ConveyorLoopActive)
                    world.Emit(ClimbEffect.ConveyorStart);
                world.Emit(ClimbEffect.ConveyorPosition);
                data.Motion.Normal.Speed.Y =
                    ScalarMath.Approach(data.Motion.Normal.Speed.Y, -160f, 600f * dt,
                        Extrema);
                world.LiftSpeed = Vector2.UnitY * Extrema.Max(data.Motion.Normal.Speed.Y, -80f);
                world.Emit(ClimbEffect.BoosterRumble);
            }
            else
            {
                data.WallBoosting = false;
                if (world.ConveyorLoopActive)
                    world.Emit(ClimbEffect.ConveyorStop);
                var target = 0f;
                var slip = false;
                if (data.ClimbNoMoveTimer <= 0f)
                {
                    if (world.ClimbBlocked(data.Facing))
                    {
                        slip = true;
                    }
                    else if (input.MoveY.Value == -1)
                    {
                        target = -45f;
                        if (world.SolidAt(-Vector2.UnitY) || (world.ClimbHopBlockedCheck() && world.SlipCheck(-1f)))
                        {
                            if (data.Motion.Normal.Speed.Y < 0f) data.Motion.Normal.Speed.Y = 0f;
                            target = 0f;
                            slip = true;
                        }
                        else if (world.SlipCheck())
                        {
                            Hop();
                            return 0;
                        }
                    }
                    else if (input.MoveY.Value == 1)
                    {
                        target = 80f;
                        if (data.OnGround)
                        {
                            if (data.Motion.Normal.Speed.Y > 0f) data.Motion.Normal.Speed.Y = 0f;
                            target = 0f;
                        }
                        else
                        {
                            world.WallSlideParticles(data.Facing);
                        }
                    }
                    else
                    {
                        slip = true;
                    }
                }
                else
                {
                    slip = true;
                }

                data.LastClimbMove = Math.Sign(target);
                if (slip && world.SlipCheck()) target = 30f;
                data.Motion.Normal.Speed.Y =
                    ScalarMath.Approach(data.Motion.Normal.Speed.Y, target, 900f * dt,
                        Extrema);
            }

            if (input.MoveY.Value != 1 && data.Motion.Normal.Speed.Y > 0f &&
                !world.SolidAt(new(data.Facing, 1f))) data.Motion.Normal.Speed.Y = 0f;
            if (data.ClimbNoMoveTimer <= 0f)
            {
                if (data.LastClimbMove == -1)
                {
                    data.Stamina -= 45.454544f * dt;
                    if (data.Stamina <= 20f) world.PlaySweat("danger");
                    else if (world.SweatAnimation != "climbLoop") world.PlaySweat("climb");
                    if (world.OnInterval(.2f))
                        world.Emit(ClimbEffect.ClimbRumble);
                }
                else
                {
                    if (data.LastClimbMove == 0) data.Stamina -= 10f * dt;
                    if (!data.OnGround)
                    {
                        Sweat("still");
                        if (world.OnInterval(.8f))
                            world.Emit(ClimbEffect.ClimbRumble);
                    }
                    else
                    {
                        Sweat("idle");
                    }
                }
            }
            else
            {
                Sweat("idle");
            }

            if (data.Stamina <= 0f)
            {
                data.Motion.Normal.Speed +=
                    JumpMotion.LiftBoost(world.LiftSpeed);
                return 0;
            }

            return 1;
        }

        private void Sweat(string animation)
        {
            world.PlaySweat(data.Stamina <= 20f ? "danger" : animation);
        }

        public void Hop()
        {
            data.ClimbHopSolid = world.FirstSolidAt(Vector2.UnitX * data.Facing);
            data.FootstepOnLandTimer = .5f;
            if (data.ClimbHopSolid != null)
            {
                data.ClimbHopSolidPosition = data.ClimbHopSolid.Position;
                data.HopWaitX = data.Facing;
                data.HopWaitXSpeed = data.Facing * 100f;
            }
            else
            {
                data.HopWaitX = 0;
                data.Motion.Normal.Speed.X = data.Facing * 100f;
            }

            data.Motion.LowFrictionStopTimer = .15f;
            data.Motion.Normal.Speed.Y = Extrema.Min(data.Motion.Normal.Speed.Y, -120f);
            data.Motion.ForceMoveX = 0;
            data.Motion.ForceMoveXTimer = .2f;
            data.FastJump = false;
            data.NoWindTimer = .3f;
            world.Emit(ClimbEffect.LedgeHop);
        }
    }
}
