using System.Collections;
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
        private void SpottedBegin()
        {
            aggroSfx.Play("event:/game/05_mirror_temple/seeker_aggro");
            RoomPlayerSession entity = FirstPlayer();
            if (entity != null)
            {
                TurnFacing(entity.X - base.X, "spot");
            }

            spottedLosePlayerTimer = 0.6f;
            spottedTurnDelay = 1f;
        }

        private int SpottedUpdate()
        {
            if (!canSeePlayer)
            {
                spottedLosePlayerTimer -= engine.DeltaTime;
                if (spottedLosePlayerTimer < 0f)
                {
                    return 0;
                }
            }
            else
            {
                spottedLosePlayerTimer = 0.6f;
            }

            float speedMagnitude = GetSpeedMagnitude(60f);
            Vector2 vector = ((!lastPathFound)
                ? engine.VectorArithmetic.SafeNormalize(FollowTarget - base.Center, speedMagnitude)
                : GetPathSpeed(speedMagnitude));
            if (engine.VectorArithmetic.DistanceSquared(base.Center, FollowTarget) < 2500f && base.Y < FollowTarget.Y)
            {
                float num = Vector2Geometry.Angle(vector);
                if (base.Y < FollowTarget.Y - 2f)
                {
                    num = ScalarMath.AngleLerp(num, (float)Math.PI / 2f, 0.5f);
                }
                else if (base.Y > FollowTarget.Y + 2f)
                {
                    num = ScalarMath.AngleLerp(num, -(float)Math.PI / 2f, 0.5f);
                }

                vector = Vector2Geometry.AngleToVector(num, 60f);
                Vector2 vector2 = Vector2.UnitX * Math.Sign(base.X - lastSpottedAt.X) * 48f;
                if (Math.Abs(base.X - lastSpottedAt.X) < 36f && !CollideCheck("Celeste.Solid", Position + vector2) &&
                    !CollideCheck("Celeste.Solid", lastSpottedAt + vector2))
                {
                    vector.X = Math.Sign(base.X - lastSpottedAt.X) * 60;
                }
            }

            Speed = engine.VectorArithmetic.Approach(Speed, vector, 600f * engine.DeltaTime);
            spottedTurnDelay -= engine.DeltaTime;
            if (spottedTurnDelay <= 0f)
            {
                TurnFacing(Speed.X, "spotted");
            }

            return 2;
        }

        private IEnumerator SpottedCoroutine()
        {
            yield return 0.2f;
            while (!CanAttack())
            {
                yield return null;
            }

            State.State = 3;
        }
    }
}
