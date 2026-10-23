using System;
using System.Numerics;
using Celeste.Simulation.Gameplay.Player.Presentation.Sprites;
using Celeste.Simulation.Gameplay.Player.State;

namespace Celeste.Simulation.Gameplay.Player.Presentation.Animation
{
    public static class PlayerAnimation
    {
        public static void Update(PlayerState player, int state, PlayerSprite sprite, PlayerAnimationContext context,
            IPlayerAnimationWorld world, float deltaTime)
        {
            sprite.Scale.X = Approach(sprite.Scale.X, 1, 1.75f * deltaTime);
            sprite.Scale.Y = Approach(sprite.Scale.Y, 1, 1.75f * deltaTime);
            var speed = player.Motion.Normal.Speed;
            var ducking = player.Motion.Ducking;
            if (InControl(state) && sprite.CurrentAnimationID != "throw" && state != 20 && state != 18 && state != 19 &&
                state != 21)
            {
                if (state == 22)
                {
                    sprite.Play("fallFast");
                }
                else if (state == 10)
                {
                    sprite.Play("launch");
                }
                else if (state == 8)
                {
                    sprite.Play("pickup");
                }
                else if (state == 3)
                {
                    sprite.Play(context.InputMoveY > 0 ? "swimDown" : context.InputMoveY < 0 ? "swimUp" : "swimIdle");
                }
                else if (state == 9)
                {
                    if (sprite.CurrentAnimationID != "dreamDashIn" && sprite.CurrentAnimationID != "dreamDashLoop")
                        sprite.Play("dreamDashIn");
                }
                else if (sprite.DreamDashing && sprite.LastAnimationID != "dreamDashOut")
                {
                    sprite.Play("dreamDashOut");
                }
                else if (sprite.CurrentAnimationID != "dreamDashOut")
                {
                    if (world.DashAttacking)
                    {
                        if (player.OnGround && player.Direction.Y == 0 && !ducking && speed.X != 0 &&
                            player.MoveX == -Math.Sign(speed.X))
                        {
                            if (world.OnInterval(.02f))
                                world.SkidDust();
                            sprite.Play("skid");
                        }
                        else
                        {
                            sprite.Play(ducking ? "duck" : "dash");
                        }
                    }
                    else if (state == 1)
                    {
                        if (player.LastClimbMove < 0)
                        {
                            sprite.Play("climbUp");
                        }
                        else if (player.LastClimbMove > 0)
                        {
                            sprite.Play("wallslide");
                        }
                        else if (!world.SolidAt(new(player.Facing, 6)))
                        {
                            sprite.Play("dangling");
                        }
                        else if (context.InputMoveX == -player.Facing)
                        {
                            if (sprite.CurrentAnimationID != "climbLookBack")
                                sprite.Play("climbLookBackStart");
                        }
                        else
                        {
                            sprite.Play("wallslide");
                        }
                    }
                    else if (ducking && state == 0)
                    {
                        sprite.Play("duck");
                    }
                    else if (player.OnGround)
                    {
                        player.FastJump = false;
                        if (!player.Holding && player.MoveX != 0 && world.SolidAt(Vector2.UnitX * player.MoveX) &&
                            !world.ClimbEdgeBlocked(player.MoveX))
                        {
                            sprite.Play("push");
                        }
                        else if (Math.Abs(speed.X) <= 25 && player.MoveX == 0)
                        {
                            if (player.Holding)
                            {
                                sprite.Play("idle_carry");
                            }
                            else if (!world.SolidPointAt(new(player.Facing, 2)) &&
                                     !world.SolidPointAt(new(player.Facing * 4, 2)) &&
                                     !world.JumpThruAt(new(player.Facing * 4, 2)))
                            {
                                sprite.Play("edge");
                            }
                            else if (!world.SolidPointAt(new(-player.Facing, 2)) &&
                                     !world.SolidPointAt(new(-player.Facing * 4, 2)) &&
                                     !world.JumpThruAt(new(-player.Facing * 4, 2)))
                            {
                                sprite.Play("edgeBack");
                            }
                            else if (context.InputMoveY == -1)
                            {
                                if (sprite.LastAnimationID != "lookUp")
                                    sprite.Play("lookUp");
                            }
                            else if (sprite.CurrentAnimationID != null &&
                                     (!sprite.CurrentAnimationID.Contains("idle") ||
                                      (sprite.CurrentAnimationID == "idle_carry" && !player.Holding)))
                            {
                                sprite.Play("idle");
                            }
                        }
                        else if (player.Holding)
                        {
                            sprite.Play("runSlow_carry");
                        }
                        else if (Math.Sign(speed.X) == -player.MoveX && player.MoveX != 0)
                        {
                            if (Math.Abs(speed.X) > 90)
                                sprite.Play("skid");
                            else if (sprite.CurrentAnimationID != "skid")
                                sprite.Play("flip");
                        }
                        else if (context.WindDirection.X != 0 && context.WindTimeout > 0 &&
                                 player.Facing == -Math.Sign(context.WindDirection.X))
                        {
                            sprite.Play("runWind");
                        }
                        else if (!sprite.Running || sprite.CurrentAnimationID == "runWind" ||
                                 (sprite.CurrentAnimationID == "runSlow_carry" && !player.Holding))
                        {
                            sprite.Play(Math.Abs(speed.X) < 45 ? "runSlow" : "runFast");
                        }
                    }
                    else if (player.WallSlideDirection != 0 && !player.Holding)
                    {
                        sprite.Play("wallslide");
                    }
                    else if (speed.Y < 0)
                    {
                        if (player.Holding)
                        {
                            sprite.Play("jumpSlow_carry");
                        }
                        else if (player.FastJump || Math.Abs(speed.X) > 90)
                        {
                            player.FastJump = true;
                            sprite.Play("jumpFast");
                        }
                        else
                        {
                            sprite.Play("jumpSlow");
                        }
                    }
                    else if (player.Holding)
                    {
                        sprite.Play("fallSlow_carry");
                    }
                    else if (player.FastJump || speed.Y >= 160 || context.InSpace)
                    {
                        player.FastJump = true;
                        if (sprite.LastAnimationID != "fallFast")
                            sprite.Play("fallFast");
                    }
                    else
                    {
                        sprite.Play("fallSlow");
                    }
                }
            }

            if (state != 11)
                sprite.Rate = context.InSpace ? .5f : 1;
        }

        private static bool InControl(int state)
        {
            return state is not (>= 11 and <= 17 or 23 or 25);
        }

        private static float Approach(float value, float target, float amount)
        {
            return value > target ? Math.Max(value - amount, target) : Math.Min(value + amount, target);
        }
    }
}
