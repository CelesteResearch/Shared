using Celeste.Physics.Collision;
using System;
using System.Numerics;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Player.Collision.Responses
{
    public sealed class PlayerCollisionResponse
    {
        private readonly RoomPlayerSession actualPlayer;
        public RoomPlayerSession Player => actualPlayer;
        private readonly global::Celeste.Simulation.Gameplay.Player.State.PlayerState data;
        private readonly global::Celeste.Core.Scheduling.SimulationStateMachine machine;
        private readonly global::Celeste.Simulation.Gameplay.Player.Collision.Responses.IPlayerCollisionWorld world;

        private readonly global::Celeste.Core.Mathematics.ISourceScalarArithmetic scalarArithmetic;

        public PlayerCollisionResponse(global::Celeste.Simulation.Gameplay.Player.State.PlayerState data,
            global::Celeste.Core.Scheduling.SimulationStateMachine machine,
            global::Celeste.Simulation.Gameplay.Player.Collision.Responses.IPlayerCollisionWorld world,
            RoomPlayerSession actualPlayer)
        {
            this.actualPlayer = actualPlayer;
            this.data = data;
            this.machine = machine;
            this.world = world;
            scalarArithmetic =
                ((global::Celeste.Core.Mathematics.ISourceScalarEnvironment)actualPlayer.World.EngineContext)
                .ScalarArithmetic;
        }

        private bool DashAttacking => actualPlayer.DashAttacking;

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        private bool HorizontalSolidAt(Vector2 offset)
            => world is IPlayerDirectionalCollisionWorld directional
                ? directional.HorizontalSolidAt(offset)
                : world.SolidAt(offset);

        private void EndDashAttack()
        {
            data.Motion.DashAttackTimer = 0f;
            data.Motion.GliderBoostTimer = 0f;
        }

        public void Horizontal(PixelCollision collision,
            global::Celeste.Simulation.Gameplay.Platforms.Foundation.SourcePlatformEntityState hit = null)
        {
            data.CanCurve = false;
            ref var speed = ref data.Motion.Normal.Speed;
            if (machine.State == 19)
            {
                if (data.StarFlyTimer < .2f)
                {
                    speed.X = 0f;
                    return;
                }

                world.Emit(global::Celeste.Simulation.Gameplay.Player.Collision.Responses.PlayerCollisionEffect
                    .FeatherBump);
                world.Emit(global::Celeste.Simulation.Gameplay.Player.Collision.Responses.PlayerCollisionEffect
                    .FeatherRumble);
                speed.X *= -.5f;
                return;
            }

            if (machine.State == 9) return;
            if (DashAttacking && hit?.OnDashCollide != null && collision.Direction.X == Math.Sign(data.Direction.X))
            {
                var result = hit.OnDashCollide(actualPlayer, collision.Direction);
                // Only the horizontal callback honors NormalOverride during red dash.
                if (result == global::Celeste.Simulation.Gameplay.Player.Collision.Surfaces.DashCollisionResult
                        .NormalOverride)
                    result = global::Celeste.Simulation.Gameplay.Player.Collision.Surfaces.DashCollisionResult
                        .NormalCollision;
                else if (machine.State == 5)
                    result = global::Celeste.Simulation.Gameplay.Player.Collision.Surfaces.DashCollisionResult.Ignore;
                switch (result)
                {
                    case global::Celeste.Simulation.Gameplay.Player.Collision.Surfaces.DashCollisionResult.Rebound:
                        Rebound(-Math.Sign(speed.X));
                        return;
                    case global::Celeste.Simulation.Gameplay.Player.Collision.Surfaces.DashCollisionResult.Bounce:
                        ReflectBounce(new Vector2(-Math.Sign(speed.X), 0));
                        return;
                    case global::Celeste.Simulation.Gameplay.Player.Collision.Surfaces.DashCollisionResult
                        .Ignore: return;
                }
            }

            if (machine.State == 2 || machine.State == 5)
            {
                if (data.OnGround && world.DuckFreeAt(Vector2.UnitX * Math.Sign(speed.X)))
                {
                    data.Motion.Ducking = true;
                    return;
                }

                if (speed.Y == 0f && speed.X != 0f)
                {
                    for (int distance = 1; distance <= 4; distance++)
                    for (int direction = 1; direction >= -1; direction -= 2)
                    {
                        var offset = new Vector2(Math.Sign(speed.X), distance * direction);
                        if (!HorizontalSolidAt(offset) && HorizontalSolidAt(offset - Vector2.UnitY * direction) &&
                            !world.DashCorrectBlocked(offset))
                        {
                            world.MoveVExact(distance * direction);
                            world.MoveHExact(Math.Sign(speed.X));
                            return;
                        }
                    }
                }
            }

            if (DreamDashCheck(Vector2.UnitX * Math.Sign(speed.X)))
            {
                machine.State = 9;
                EndDashAttack();
                return;
            }

            if (data.WallSpeedRetentionTimer <= 0f)
            {
                data.WallSpeedRetained = speed.X;
                data.WallSpeedRetentionTimer = .06f;
            }

            hit?.OnCollide?.Invoke(collision.Direction);
            speed.X = 0f;
            EndDashAttack();
            RedDashCollision();
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        public void Vertical(PixelCollision collision,
            global::Celeste.Simulation.Gameplay.Platforms.Foundation.SourcePlatformEntityState hit = null)
        {
            data.CanCurve = false;
            ref var speed = ref data.Motion.Normal.Speed;
            if (machine.State == 19)
            {
                if (data.StarFlyTimer < .2f)
                {
                    speed.Y = 0f;
                    return;
                }

                world.Emit(global::Celeste.Simulation.Gameplay.Player.Collision.Responses.PlayerCollisionEffect
                    .FeatherBump);
                world.Emit(global::Celeste.Simulation.Gameplay.Player.Collision.Responses.PlayerCollisionEffect
                    .FeatherRumble);
                speed.Y *= -.5f;
                return;
            }

            if (machine.State == 3)
            {
                speed.Y = 0f;
                return;
            }

            if (machine.State == 9) return;
            if (hit?.OnDashCollide != null)
            {
                if (DashAttacking && collision.Direction.Y == Math.Sign(data.Direction.Y))
                {
                    var result = hit.OnDashCollide(actualPlayer, collision.Direction);
                    if (machine.State == 5)
                        result = global::Celeste.Simulation.Gameplay.Player.Collision.Surfaces.DashCollisionResult
                            .Ignore;
                    switch (result)
                    {
                        case global::Celeste.Simulation.Gameplay.Player.Collision.Surfaces.DashCollisionResult.Rebound:
                            Rebound();
                            return;
                        case global::Celeste.Simulation.Gameplay.Player.Collision.Surfaces.DashCollisionResult.Bounce:
                            ReflectBounce(new Vector2(0, -Math.Sign(speed.Y)));
                            return;
                        case global::Celeste.Simulation.Gameplay.Player.Collision.Surfaces.DashCollisionResult
                            .Ignore: return;
                    }
                }
                else if (machine.State == 10)
                {
                    hit.OnDashCollide(actualPlayer, collision.Direction);
                    return;
                }
            }

            if (speed.Y > 0f)
            {
                if ((machine.State == 2 || machine.State == 5) && !data.StartedOnGround)
                {
                    if (speed.X <= .01f)
                        for (int x = -1; x >= -4; x--)
                            if (!world.GroundAt(new Vector2(x, 0)))
                            {
                                world.MoveHExact(x);
                                world.MoveVExact(1);
                                return;
                            }

                    if (speed.X >= -.01f)
                        for (int x = 1; x <= 4; x++)
                            if (!world.GroundAt(new Vector2(x, 0)))
                            {
                                world.MoveHExact(x);
                                world.MoveVExact(1);
                                return;
                            }
                }

                if (DreamDashCheck(Vector2.UnitY * Math.Sign(speed.Y)))
                {
                    machine.State = 9;
                    EndDashAttack();
                    return;
                }

                if (data.Direction.X != 0f && data.Direction.Y > 0f && speed.Y > 0f)
                {
                    data.Direction.X = Math.Sign(data.Direction.X);
                    data.Direction.Y = 0f;
                    speed.Y = 0f;
                    speed.X *= 1.2f;
                    data.Motion.Ducking = true;
                }

                if (machine.State != 1)
                {
                    float amount = Math.Min(speed.Y / 240f, 1f);
                    data.Motion.Normal.SpriteScaleX = scalarArithmetic.Lerp(1f, 1.6f, amount);
                    data.Motion.Normal.SpriteScaleY = scalarArithmetic.Lerp(1f, .4f, amount);
                    if (data.HighestAirY < world.Position.Y - 50f && speed.Y >= 160f && Math.Abs(speed.X) >= 90f)
                        world.Emit(global::Celeste.Simulation.Gameplay.Player.Collision.Responses.PlayerCollisionEffect
                            .RunStumble);
                    world.Emit(global::Celeste.Simulation.Gameplay.Player.Collision.Responses.PlayerCollisionEffect
                        .LandRumble);
                    var platform = world.LandingSurface();
                    int index = -1;
                    if (platform.HasValue)
                    {
                        index = platform.GetLandSoundIndex(actualPlayer);
                        if (index >= 0 && !data.MuffleLanding) world.PlayLanding(data.FootstepOnLandTimer > 0f, index);
                        if (platform.Platform is
                            global::Celeste.Simulation.Gameplay.Platforms.DreamBlock.ISourceDreamBlock
                            dreamBlock) dreamBlock.FootstepRipple(world.Position);
                        data.MuffleLanding = false;
                    }

                    if (speed.Y >= 80f) world.LandingDust(index);
                    data.FootstepOnLandTimer = 0f;
                }
            }
            else
            {
                if (speed.Y < 0f)
                {
                    int reach = DashAttacking && Math.Abs(speed.X) < .01f ? 5 : 4;
                    if (speed.X <= .01f)
                        for (int x = 1; x <= reach; x++)
                            if (!world.SolidAt(new Vector2(-x, -1)))
                            {
                                world.NudgePosition(new Vector2(-x, -1));
                                return;
                            }

                    if (speed.X >= -.01f)
                        for (int x = 1; x <= reach; x++)
                            if (!world.SolidAt(new Vector2(x, -1)))
                            {
                                world.NudgePosition(new Vector2(x, -1));
                                return;
                            }

                    if (data.Motion.Normal.VariableJumpTimer < .15f) data.Motion.Normal.VariableJumpTimer = 0f;
                }

                if (DreamDashCheck(Vector2.UnitY * Math.Sign(speed.Y)))
                {
                    machine.State = 9;
                    EndDashAttack();
                    return;
                }
            }

            hit?.OnCollide?.Invoke(collision.Direction);
            EndDashAttack();
            speed.Y = 0f;
            RedDashCollision();
        }

        private void RedDashCollision()
        {
            if (machine.State != 5) return;
            world.Emit(global::Celeste.Simulation.Gameplay.Player.Collision.Responses.PlayerCollisionEffect
                .RedDashRumble);
            world.Emit(
                global::Celeste.Simulation.Gameplay.Player.Collision.Responses.PlayerCollisionEffect.RedDashBurst);
            machine.State = 6;
        }

        public bool DreamDashCheck(Vector2 direction) => actualPlayer.DreamDashCheck(direction);

        public void Rebound(int direction = 0)
        {
            ref var motion = ref data.Motion;
            motion.Normal.Speed = new Vector2(direction * 120f, -120f);
            motion.Normal.VariableJumpSpeed = motion.Normal.Speed.Y;
            motion.Normal.VariableJumpTimer = .15f;
            motion.AutoJump = true;
            data.AutoJumpTimer = 0f;
            EndDashAttack();
            motion.WallSlideTimer = 1.2f;
            motion.WallBoostTimer = 0f;
            motion.Launched = false;
            motion.LowFrictionStopTimer = .15f;
            motion.ForceMoveXTimer = 0f;
            machine.State = 0;
        }

        public void ReflectBounce(Vector2 direction)
        {
            ref var motion = ref data.Motion;
            if (direction.X != 0f) motion.Normal.Speed.X = direction.X * 220f;
            if (direction.Y != 0f) motion.Normal.Speed.Y = direction.Y * 220f;
            data.AutoJumpTimer = 0f;
            EndDashAttack();
            motion.WallSlideTimer = 1.2f;
            motion.WallBoostTimer = 0f;
            motion.Launched = false;
            motion.ForceMoveXTimer = 0f;
            machine.State = 0;
        }
    }
}
