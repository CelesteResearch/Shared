using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Mathematics;

namespace Celeste.Game.Gameplay.Enemies.Seekers
{
    public partial class OriginalSeekerState
    {
        private void SpottedBegin()
        {
            aggroSfx.Play("event:/game/05_mirror_temple/seeker_aggro");
            var entity = FirstPlayer();
            if (entity != null) TurnFacing(entity.X - X, "spot");

            spottedLosePlayerTimer = 0.6f;
            spottedTurnDelay = 1f;
        }

        private int SpottedUpdate()
        {
            if (!canSeePlayer)
            {
                spottedLosePlayerTimer -= engine.DeltaTime;
                if (spottedLosePlayerTimer < 0f) return 0;
            }
            else
            {
                spottedLosePlayerTimer = 0.6f;
            }

            var speedMagnitude = GetSpeedMagnitude(60f);
            var vector = !lastPathFound
                ? engine.VectorArithmetic.SafeNormalize(FollowTarget - Center, speedMagnitude)
                : GetPathSpeed(speedMagnitude);
            if (engine.VectorArithmetic.DistanceSquared(Center, FollowTarget) < 2500f && Y < FollowTarget.Y)
            {
                var num = Vector2Geometry.Angle(vector);
                if (Y < FollowTarget.Y - 2f)
                    num = ScalarMath.AngleLerp(num, (float)Math.PI / 2f, 0.5f);
                else if (Y > FollowTarget.Y + 2f) num = ScalarMath.AngleLerp(num, -(float)Math.PI / 2f, 0.5f);

                vector = Vector2Geometry.AngleToVector(num, 60f);
                var vector2 = Vector2.UnitX * Math.Sign(X - lastSpottedAt.X) * 48f;
                if (Math.Abs(X - lastSpottedAt.X) < 36f && !CollideCheck("Celeste.Solid", Position + vector2) &&
                    !CollideCheck("Celeste.Solid", lastSpottedAt + vector2))
                    vector.X = Math.Sign(X - lastSpottedAt.X) * 60;
            }

            Speed = engine.VectorArithmetic.Approach(Speed, vector, 600f * engine.DeltaTime);
            spottedTurnDelay -= engine.DeltaTime;
            if (spottedTurnDelay <= 0f) TurnFacing(Speed.X, "spotted");

            return 2;
        }

        private IEnumerator SpottedCoroutine()
        {
            yield return 0.2f;
            while (!CanAttack()) yield return null;

            CurrentStateMachine.State = 3;
        }
    }
}
