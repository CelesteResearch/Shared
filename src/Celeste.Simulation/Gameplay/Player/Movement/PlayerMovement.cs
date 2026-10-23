using Celeste.Physics.Collision;
using System;
using System.Numerics;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Player.Movement
{
    // The host runs this after state/component updates and Actor.FinishComponentUpdate,
    // then updates animation, carried objects, triggers, player colliders and camera.
    public sealed class PlayerMovement
    {
        private readonly global::Celeste.Simulation.Gameplay.Player.State.PlayerState data;
        private readonly global::Celeste.Core.Scheduling.SimulationStateMachine machine;
        private readonly global::Celeste.Simulation.Gameplay.Player.Movement.IPlayerMovementWorld world;
        private readonly global::Celeste.Physics.Collision.SourceCollisionHandler horizontal, vertical;

        public PlayerMovement(global::Celeste.Simulation.Gameplay.Player.State.PlayerState data,
            global::Celeste.Core.Scheduling.SimulationStateMachine machine,
            global::Celeste.Simulation.Gameplay.Player.Movement.IPlayerMovementWorld world,
            global::Celeste.Simulation.Gameplay.Player.Collision.Responses.PlayerCollisionResponse collisions)
        {
            this.data = data;
            this.machine = machine;
            this.world = world;
            horizontal = c => collisions.Horizontal(c, world.CollisionSurface(c));
            vertical = c => collisions.Vertical(c, world.CollisionSurface(c));
        }

        public void Update(float deltaTime)
        {
            if (!data.OnGround && data.Motion.Normal.Speed.Y <= 0f &&
                (machine.State != 1 || data.LastClimbMove == -1) && world.JumpThruAt(Vector2.Zero) &&
                !world.JumpThruBoostBlocked())
                world.MoveV(-40f * deltaTime, null);
            if (!data.OnGround && world.DashAttacking && data.Direction.Y == 0f &&
                (world.SolidAt(Vector2.UnitY * 3f) || world.JumpThruOutsideAt(Vector2.UnitY * 3f)) &&
                !world.DashCorrectBlocked(Vector2.UnitY * 3f))
                world.MoveVExact(3);
            if (data.Motion.Normal.Speed.Y > 0f && world.CanUnDuck && !world.UsesFeatherCollider && !data.OnGround &&
                data.Motion.JumpGraceTimer <= 0f)
                data.Motion.Ducking = false;
            if (machine.State != 9 && machine.State != 22)
                world.MoveH(data.Motion.Normal.Speed.X * deltaTime, horizontal);
            // A horizontal hit may enter DreamDash; re-read the state before moving vertically.
            if (machine.State != 9 && machine.State != 22)
                world.MoveV(data.Motion.Normal.Speed.Y * deltaTime, vertical);
            if (machine.State == 3)
            {
                if (data.Motion.Normal.Speed.Y < 0f && data.Motion.Normal.Speed.Y >= -60f &&
                    (world is not IPlayerSwimSurfaceCorrectionWorld surface || surface.CanCorrectSwimSurface))
                    while (!world.SwimCheck())
                    {
                        data.Motion.Normal.Speed.Y = 0f;
                        if (world.MoveVExact(1)) break;
                    }
            }
            else if (machine.State == 0 && world.SwimCheck()) machine.State = 3;
            else if (machine.State == 1 && world.SwimCheck())
            {
                var water = world.FirstWaterAt(Vector2.Zero);
                if (water != null && world.PlayerCenterY < water.Center.Y)
                {
                    while (world.SwimCheck() && !world.MoveVExact(-1))
                    {
                    }

                    if (world.SwimCheck()) machine.State = 3;
                }
                else machine.State = 3;
            }
        }
    }
}
