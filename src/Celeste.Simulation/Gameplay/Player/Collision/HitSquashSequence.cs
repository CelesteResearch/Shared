using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Scheduling;
using Celeste.Input.Gameplay;
using Celeste.Simulation.Gameplay.Player.Dash;
using Celeste.Simulation.Gameplay.Player.Movement;
using Celeste.Simulation.Gameplay.Player.State;

namespace Celeste.Simulation.Gameplay.Player.Collision
{
    public sealed class HitSquashSequence
    {
        private readonly PlayerState data;
        private readonly SpecialPlayerState special;
        private readonly ISourceGameInput input;
        private readonly ISourceEngineContext engine;
        private readonly DashSequence dash;
        private readonly IHitSquashWorld world;

        public HitSquashSequence(PlayerState data,
            SpecialPlayerState special, ISourceGameInput input,
            SimulationStateMachine machine,
            DashSequence dash,
            IHitSquashWorld world,
            ISourceEngineContext engine)
        {
            this.engine = engine;
            this.data = data;
            this.special = special;
            this.input = input;
            this.dash = dash;
            this.world = world;
            machine.SetCallbacks(6, Update, begin: Begin);
        }

        public void Begin()
        {
            special.HitSquashNoMoveTimer = .1f;
        }

        public int Update()
        {
            ref var speed = ref data.Motion.Normal.Speed;
            speed.X = ScalarMath.Approach(speed.X, 0, 800 * input.DeltaTime,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            speed.Y = ScalarMath.Approach(speed.Y, 0, 800 * input.DeltaTime,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            if (input.Jump.Pressed)
            {
                if (data.OnGround)
                {
                    world.Jump(PlayerJump.Standard, 0);
                }
                else if (world.WallJumpCheck(1))
                {
                    if (data.Facing == 1 && input.GrabCheck && data.Stamina > 0 && !data.Holding &&
                        !world.ClimbBlocked(3))
                        world.Jump(PlayerJump.Climb, 0);
                    else world.Jump(PlayerJump.Wall, -1);
                }
                else if (world.WallJumpCheck(-1))
                {
                    if (data.Facing == -1 && input.GrabCheck && data.Stamina > 0 && !data.Holding &&
                        !world.ClimbBlocked(-3))
                        world.Jump(PlayerJump.Climb, 0);
                    else world.Jump(PlayerJump.Wall, 1);
                }
                else
                {
                    input.Jump.ConsumeBuffer();
                }

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
