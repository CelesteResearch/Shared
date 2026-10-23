using System;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Physics.Collision;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Game.Execution.Levels;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Enemies.Seeker;

namespace Celeste.Game.Gameplay.Enemies.Seekers
{
    public partial class OriginalSeekerState
    {
        private void PatrolBegin()
        {
            State.State = ChoosePatrolTarget();
            patrolWaitTimer = 0f;
        }

        private int PatrolUpdate()
        {
            if (canSeePlayer)
            {
                return 2;
            }

            if (patrolWaitTimer > 0f)
            {
                patrolWaitTimer -= engine.DeltaTime;
                if (patrolWaitTimer <= 0f)
                {
                    return ChoosePatrolTarget();
                }
            }
            else if (engine.VectorArithmetic.DistanceSquared(base.Center, lastSpottedAt) < 144f)
            {
                patrolWaitTimer = 0.4f;
            }

            float speedMagnitude = GetSpeedMagnitude(25f);
            Speed = engine.VectorArithmetic.Approach(
                target: (!lastPathFound)
                    ? engine.VectorArithmetic.SafeNormalize(FollowTarget - base.Center, speedMagnitude)
                    : GetPathSpeed(speedMagnitude), value: Speed, maxMove: 600f * engine.DeltaTime);
            if (engine.VectorArithmetic.LengthSquared(Speed) > 100f)
            {
                TurnFacing(Speed.X);
            }

            if (spriteFacing == facing)
            {
                sprite.Play("search");
            }

            return 1;
        }

        private int ChoosePatrolTarget()
        {
            RoomPlayerSession entity = FirstPlayer();
            if (entity == null)
            {
                return 0;
            }

            SeekerPatrolPoint[] patrolChoices = engine.SeekerPatrolChoices;
            for (int i = 0; i < 3; i++)
            {
                patrolChoices[i].Distance = 0f;
            }

            int num = 0;
            Vector2[] array = patrolPoints;
            foreach (Vector2 vector in array)
            {
                if (engine.VectorArithmetic.DistanceSquared(base.Center, vector) < 576f)
                {
                    continue;
                }

                float num2 = engine.VectorArithmetic.DistanceSquared(vector, entity.Center);
                for (int k = 0; k < 3; k++)
                {
                    if (num2 < patrolChoices[k].Distance || patrolChoices[k].Distance <= 0f)
                    {
                        num++;
                        for (int num3 = 2; num3 > k; num3--)
                        {
                            patrolChoices[num3].Distance = patrolChoices[num3 - 1].Distance;
                            patrolChoices[num3].Point = patrolChoices[num3 - 1].Point;
                        }

                        patrolChoices[k].Distance = num2;
                        patrolChoices[k].Point = vector;
                        break;
                    }
                }
            }

            if (num <= 0)
            {
                return 0;
            }

            lastSpottedAt = patrolChoices[random.Next(Math.Min(3, num))].Point;
            lastPathTo = lastSpottedAt;
            pathIndex = 0;
            lastPathFound = ((OriginalLevelSceneRoot)Scene).Pathfinder.Find(ref path, base.Center, FollowTarget);
            return 1;
        }
    }
}
