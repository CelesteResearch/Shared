using Celeste.Physics.Collision;
using System;
using System.Collections;
using System.Numerics;
using Celeste.Input.Gameplay;
using Celeste.Simulation.Rendering;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Player.Collision
{
    public sealed class HitSquashSequence
    {
        private readonly global::Celeste.Simulation.Gameplay.Player.State.PlayerState data;
        private readonly global::Celeste.Simulation.Gameplay.Player.State.SpecialPlayerState special;
        private readonly ISourceGameInput input;
        private readonly global::Celeste.Core.Scheduling.ISourceEngineContext engine;
        private readonly global::Celeste.Simulation.Gameplay.Player.Dash.DashSequence dash;
        private readonly global::Celeste.Simulation.Gameplay.Player.Collision.IHitSquashWorld world;

        public HitSquashSequence(global::Celeste.Simulation.Gameplay.Player.State.PlayerState data,
            global::Celeste.Simulation.Gameplay.Player.State.SpecialPlayerState special, ISourceGameInput input,
            global::Celeste.Core.Scheduling.SimulationStateMachine machine,
            global::Celeste.Simulation.Gameplay.Player.Dash.DashSequence dash,
            global::Celeste.Simulation.Gameplay.Player.Collision.IHitSquashWorld world,
            global::Celeste.Core.Scheduling.ISourceEngineContext engine)
        {
            this.engine = engine;
            this.data = data;
            this.special = special;
            this.input = input;
            this.dash = dash;
            this.world = world;
            machine.SetCallbacks(6, Update, begin: Begin);
        }

        public void Begin() => special.HitSquashNoMoveTimer = .1f;

        public int Update()
        {
            ref var speed = ref data.Motion.Normal.Speed;
            speed.X = global::Celeste.Core.Mathematics.ScalarMath.Approach(speed.X, 0, 800 * input.DeltaTime,
                ((global::Celeste.Core.Mathematics.Extrema.ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            speed.Y = global::Celeste.Core.Mathematics.ScalarMath.Approach(speed.Y, 0, 800 * input.DeltaTime,
                ((global::Celeste.Core.Mathematics.Extrema.ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            if (input.Jump.Pressed)
            {
                if (data.OnGround)
                    world.Jump(global::Celeste.Simulation.Gameplay.Player.Movement.PlayerJump.Standard, 0);
                else if (world.WallJumpCheck(1))
                {
                    if (data.Facing == 1 && input.GrabCheck && data.Stamina > 0 && !data.Holding &&
                        !world.ClimbBlocked(3))
                        world.Jump(global::Celeste.Simulation.Gameplay.Player.Movement.PlayerJump.Climb, 0);
                    else world.Jump(global::Celeste.Simulation.Gameplay.Player.Movement.PlayerJump.Wall, -1);
                }
                else if (world.WallJumpCheck(-1))
                {
                    if (data.Facing == -1 && input.GrabCheck && data.Stamina > 0 && !data.Holding &&
                        !world.ClimbBlocked(-3))
                        world.Jump(global::Celeste.Simulation.Gameplay.Player.Movement.PlayerJump.Climb, 0);
                    else world.Jump(global::Celeste.Simulation.Gameplay.Player.Movement.PlayerJump.Wall, 1);
                }
                else input.Jump.ConsumeBuffer();

                return 0;
            }

            if (dash.CanDash) return dash.Start();
            if (input.GrabCheck && world.ClimbCheck(data.Facing)) return 1;
            if (special.HitSquashNoMoveTimer > 0)
            {
                special.HitSquashNoMoveTimer -= input.DeltaTime;
                return 6;
            }

            return 0;
        }
    }
}
