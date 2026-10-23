using Celeste.Core.Mathematics;
using Celeste.Game.Execution.Levels;
using Celeste.Physics.Collision;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Enemies.Seeker;

namespace Celeste.Game.Gameplay.Enemies.Seekers
{
    public partial class OriginalSeekerState
    {
        private bool CanSeePlayer(RoomPlayerSession player)
        {
            if (player == null) return false;

            if (CurrentStateMachine.State != 2 && !((OriginalLevelSceneRoot)Scene).InsideCamera(Center) &&
                engine.VectorArithmetic.DistanceSquared(Center, player.Center) > 25600f)
                return false;

            var vector =
                engine.VectorArithmetic.SafeNormalize(Vector2Geometry.Perpendicular(player.Center - Center), 2f);
            if (SourceSceneCollision.FirstLine<ISourceEntityCollider>(
                    ((OriginalLevelSceneRoot)Scene).Scheduler.Entities,
                    "Celeste.Solid", Center + vector, player.Center + vector) == null)
                return SourceSceneCollision.FirstLine<ISourceEntityCollider>(
                    ((OriginalLevelSceneRoot)Scene).Scheduler.Entities, "Celeste.Solid", Center - vector,
                    player.Center - vector) == null;

            return false;
        }

        public override void Update()
        {
            Light.Alpha = ScalarMath.Approach(Light.Alpha, 1f, engine.DeltaTime * 2f, engine.ExtremaArithmetic);
            foreach (SeekerBarrierState entity2 in
                     ((OriginalLevelSceneRoot)Scene).Scheduler.Entities.GetTrackedEntities(
                         "Celeste.SeekerBarrier"))
                entity2.Collidable = entity2.CollidesWithSeeker(true);

            sprite.Scale.X = ScalarMath.Approach(sprite.Scale.X, 1f, 2f * engine.DeltaTime, engine.ExtremaArithmetic);
            sprite.Scale.Y = ScalarMath.Approach(sprite.Scale.Y, 1f, 2f * engine.DeltaTime, engine.ExtremaArithmetic);
            if (CurrentStateMachine.State == 6)
            {
                canSeePlayer = false;
            }
            else
            {
                var entity = FirstPlayer();
                canSeePlayer = CanSeePlayer(entity);
                if (canSeePlayer)
                {
                    spotted = true;
                    lastSpottedAt = entity.Center;
                }
            }

            if (lastPathTo != lastSpottedAt)
            {
                lastPathTo = lastSpottedAt;
                pathIndex = 0;
                lastPathFound = ((OriginalLevelSceneRoot)Scene).Pathfinder.Find(ref path, Center, FollowTarget);
            }

            base.Update();
            lastPosition = Position;
            MoveH(Speed.X * engine.DeltaTime, onCollideH);
            MoveV(Speed.Y * engine.DeltaTime, onCollideV);
            var level = (OriginalLevelSceneRoot)Scene;
            if (Left < level.Bounds.Left && Speed.X < 0f)
            {
                Left = level.Bounds.Left;
                onCollideH(default);
            }
            else if (Right > level.Bounds.Right && Speed.X > 0f)
            {
                Right = level.Bounds.Right;
                onCollideH(default);
            }

            if (Top < level.Bounds.Top + -8 && Speed.Y < 0f)
            {
                Top = level.Bounds.Top + -8;
                onCollideV(default);
            }
            else if (Bottom > level.Bounds.Bottom && Speed.Y > 0f)
            {
                Bottom = level.Bounds.Bottom;
                onCollideV(default);
            }

            foreach (SeekerColliderState component in ((ISourceScene)Scene).SourceScene.Components.GetTrackedComponents(
                         "Celeste.SeekerCollider"))
                component.Check(this);

            if (CurrentStateMachine.State == 3 && Speed.X > 0f)
            {
                BounceHitbox.Width = 16f;
                BounceHitbox.Position.X = -10f;
            }
            else if (CurrentStateMachine.State == 3 && Speed.Y < 0f)
            {
                BounceHitbox.Width = 16f;
                BounceHitbox.Position.X = -6f;
            }
            else
            {
                BounceHitbox.Width = 12f;
                BounceHitbox.Position.X = -6f;
            }

            foreach (SeekerBarrierState entity3 in
                     ((OriginalLevelSceneRoot)Scene).Scheduler.Entities.GetTrackedEntities(
                         "Celeste.SeekerBarrier"))
                entity3.Collidable = false;
        }
    }
}
