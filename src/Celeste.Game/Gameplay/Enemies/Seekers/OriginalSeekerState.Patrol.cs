using System;
using Celeste.Game.Execution.Levels;

namespace Celeste.Game.Gameplay.Enemies.Seekers
{
    public partial class OriginalSeekerState
    {
        private void PatrolBegin()
        {
            CurrentStateMachine.State = ChoosePatrolTarget();
            patrolWaitTimer = 0f;
        }

        private int PatrolUpdate()
        {
            if (canSeePlayer) return 2;

            if (patrolWaitTimer > 0f)
            {
                patrolWaitTimer -= engine.DeltaTime;
                if (patrolWaitTimer <= 0f) return ChoosePatrolTarget();
            }
            else if (engine.VectorArithmetic.DistanceSquared(Center, lastSpottedAt) < 144f)
            {
                patrolWaitTimer = 0.4f;
            }

            var speedMagnitude = GetSpeedMagnitude(25f);
            Speed = engine.VectorArithmetic.Approach(
                target: !lastPathFound
                    ? engine.VectorArithmetic.SafeNormalize(FollowTarget - Center, speedMagnitude)
                    : GetPathSpeed(speedMagnitude), value: Speed, maxMove: 600f * engine.DeltaTime);
            if (engine.VectorArithmetic.LengthSquared(Speed) > 100f) TurnFacing(Speed.X);

            if (spriteFacing == facing) sprite.Play("search");

            return 1;
        }

        private int ChoosePatrolTarget()
        {
            var entity = FirstPlayer();
            if (entity == null) return 0;

            var patrolChoices = engine.SeekerPatrolChoices;
            for (var i = 0; i < 3; i++) patrolChoices[i].Distance = 0f;

            var num = 0;
            var array = patrolPoints;
            foreach (var vector in array)
            {
                if (engine.VectorArithmetic.DistanceSquared(Center, vector) < 576f) continue;

                var num2 = engine.VectorArithmetic.DistanceSquared(vector, entity.Center);
                for (var k = 0; k < 3; k++)
                    if (num2 < patrolChoices[k].Distance || patrolChoices[k].Distance <= 0f)
                    {
                        num++;
                        for (var num3 = 2; num3 > k; num3--)
                        {
                            patrolChoices[num3].Distance = patrolChoices[num3 - 1].Distance;
                            patrolChoices[num3].Point = patrolChoices[num3 - 1].Point;
                        }

                        patrolChoices[k].Distance = num2;
                        patrolChoices[k].Point = vector;
                        break;
                    }
            }

            if (num <= 0) return 0;

            lastSpottedAt = patrolChoices[random.Next(Math.Min(3, num))].Point;
            lastPathTo = lastSpottedAt;
            pathIndex = 0;
            lastPathFound = ((OriginalLevelSceneRoot)Scene).Pathfinder.Find(ref path, Center, FollowTarget);
            return 1;
        }
    }
}
