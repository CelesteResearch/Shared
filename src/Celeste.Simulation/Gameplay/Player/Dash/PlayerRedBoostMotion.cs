using System;
using Celeste.Input.Gameplay;
using Celeste.Simulation.Gameplay.Player.State;

namespace Celeste.Simulation.Gameplay.Player.Dash
{
    public static class PlayerRedBoostMotion
    {
        public static int Update(RoomPlayerSession player, ISourceGameInput input, IPlayerBoostWorld world,
            DashSequence dash, int returnState, bool hubTransition, Func<bool> canDashOut,
            Action beforeDash, Action correctJumpThrus)
        {
            PlayerState data = player.Data;
            data.StartedDashing = false;
            data.Motion.GliderBoostTimer = .05f;
            if (canDashOut())
            {
                beforeDash();
                return dash.Start();
            }

            return CheckJumpExit(data, input, world, hubTransition, returnState, correctJumpThrus);
        }

        internal static int CheckJumpExit(PlayerState data, ISourceGameInput input, IPlayerBoostWorld world,
            bool hubTransition, int returnState, Action correctJumpThrus)
        {
            if (data.Direction.Y == 0f)
            {
                correctJumpThrus();
                if (world.CanUnDuck && input.Jump.Pressed && data.Motion.JumpGraceTimer > 0f && !hubTransition)
                {
                    world.Jump(global::Celeste.Simulation.Gameplay.Player.Movement.PlayerJump.Super, data.Facing);
                    return 0;
                }
            }

            if (!hubTransition)
            {
                if (data.SuperWallJumpAngle)
                {
                    if (input.Jump.Pressed && world.CanUnDuck)
                    {
                        if (world.WallJumpCheck(1))
                        {
                            world.Jump(global::Celeste.Simulation.Gameplay.Player.Movement.PlayerJump.SuperWall, -1);
                            return 0;
                        }

                        if (world.WallJumpCheck(-1))
                        {
                            world.Jump(global::Celeste.Simulation.Gameplay.Player.Movement.PlayerJump.SuperWall, 1);
                            return 0;
                        }
                    }
                }
                else if (input.Jump.Pressed && world.CanUnDuck)
                {
                    for (int direction = 1; direction >= -1; direction -= 2)
                    {
                        if (!world.WallJumpCheck(direction)) continue;
                        if (data.Facing == direction && input.GrabCheck && data.Stamina > 0f && !data.Holding &&
                            !world.ClimbBlocked(direction * 3))
                            world.Jump(global::Celeste.Simulation.Gameplay.Player.Movement.PlayerJump.Climb, direction);
                        else
                            world.Jump(global::Celeste.Simulation.Gameplay.Player.Movement.PlayerJump.Wall, -direction);
                        return 0;
                    }
                }
            }

            return returnState;
        }
    }
}
