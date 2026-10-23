using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Game.Execution.Levels;
using Celeste.Simulation;

namespace Celeste.Game.Gameplay.Enemies.Seekers
{
    public partial class OriginalSeekerState
    {
        private int IdleUpdate()
        {
            if (canSeePlayer) return 2;

            var vector = Vector2.Zero;
            if (spotted && engine.VectorArithmetic.DistanceSquared(Center, FollowTarget) > 64f)
            {
                var speedMagnitude = GetSpeedMagnitude(50f);
                vector = !lastPathFound
                    ? engine.VectorArithmetic.SafeNormalize(FollowTarget - Center, speedMagnitude)
                    : GetPathSpeed(speedMagnitude);
            }

            if (vector == Vector2.Zero)
            {
                vector.X = idleSineX.Value * 6f;
                vector.Y = idleSineY.Value * 6f;
            }

            Speed = engine.VectorArithmetic.Approach(Speed, vector, 200f * engine.DeltaTime);
            if (engine.VectorArithmetic.LengthSquared(Speed) > 400f) TurnFacing(Speed.X);

            if (spriteFacing == facing) sprite.Play("idle");

            return 0;
        }

        private IEnumerator IdleCoroutine()
        {
            if (patrolPoints != null && patrolPoints.Length != 0 && spotted)
            {
                while (engine.VectorArithmetic.DistanceSquared(Center, FollowTarget) > 64f) yield return null;

                yield return 0.3f;
                CurrentStateMachine.State = 1;
            }
        }

        private Vector2 GetPathSpeed(float magnitude)
        {
            if (pathIndex >= path.Count) return Vector2.Zero;

            if (engine.VectorArithmetic.DistanceSquared(Center, path[pathIndex]) < 36f)
            {
                pathIndex++;
                return GetPathSpeed(magnitude);
            }

            return engine.VectorArithmetic.SafeNormalize(path[pathIndex] - Center, magnitude);
        }

        private float GetSpeedMagnitude(float baseMagnitude)
        {
            var entity = FirstPlayer();
            if (entity != null)
            {
                if (engine.VectorArithmetic.DistanceSquared(Center, entity.Center) > 12544f) return baseMagnitude * 3f;

                return baseMagnitude * 1.5f;
            }

            return baseMagnitude;
        }

        private int StunnedUpdate()
        {
            Speed = engine.VectorArithmetic.Approach(Speed, Vector2.Zero, 150f * engine.DeltaTime);
            return 4;
        }

        private IEnumerator StunnedCoroutine()
        {
            yield return 0.8f;
            CurrentStateMachine.State = 0;
        }

        private void SkiddingBegin()
        {
            engine.SpatialAudio.Play("event:/game/05_mirror_temple/seeker_dash_turn", Position);
            strongSkid = false;
            TurnFacing(-facing);
        }

        private int SkiddingUpdate()
        {
            Speed = engine.VectorArithmetic.Approach(Speed, Vector2.Zero,
                (strongSkid ? 400f : 200f) * engine.DeltaTime);
            if (engine.VectorArithmetic.LengthSquared(Speed) < 400f) return canSeePlayer ? 2 : 0;

            return 5;
        }

        private IEnumerator SkiddingCoroutine()
        {
            yield return 0.08f;
            strongSkid = true;
        }

        private void SkiddingEnd()
        {
            spriteFacing = facing;
        }

        private void RegenerateBegin()
        {
            engine.SpatialAudio.Play("event:/game/general/thing_booped", Position);
            boopedSfx.Play("event:/game/05_mirror_temple/seeker_booped");
            sprite.Play("takeHit");
            Collidable = false;
            CurrentStateMachine.Locked = true;
            Light.StartRadius = 16f;
            Light.EndRadius = 32f;
        }

        private void RegenerateEnd()
        {
            reviveSfx.Play("event:/game/05_mirror_temple/seeker_revive");
            Collidable = true;
            Light.StartRadius = 32f;
            Light.EndRadius = 64f;
        }

        private int RegenerateUpdate()
        {
            Speed.X = ScalarMath.Approach(Speed.X, 0f, 150f * engine.DeltaTime, engine.ExtremaArithmetic);
            Speed = engine.VectorArithmetic.Approach(Speed, Vector2.Zero, 150f * engine.DeltaTime);
            return 6;
        }

        private IEnumerator ReturnedCoroutine()
        {
            yield return 0.3f;
            CurrentStateMachine.State = 0;
        }

        private void TurnFacing(float dir, string gotoSprite = null)
        {
            if (dir != 0f) facing = Math.Sign(dir);

            if (spriteFacing != facing)
            {
                if (CurrentStateMachine.State == 5)
                    sprite.Play("skid");
                else if (CurrentStateMachine.State == 3 || CurrentStateMachine.State == 2)
                    sprite.Play("flipMouth");
                else
                    sprite.Play("flipEyes");

                nextSprite = gotoSprite;
            }
            else if (gotoSprite != null)
            {
                sprite.Play(gotoSprite);
            }
        }

        private void SnapFacing(float dir)
        {
            if (dir != 0f) spriteFacing = facing = Math.Sign(dir);
        }

        private RoomPlayerSession FirstPlayer()
        {
            var entities =
                ((OriginalLevelSceneRoot)Scene).Scheduler.Entities.GetTrackedEntities(
                    typeof(RoomPlayerSession).FullName);
            return entities.Count > 0 ? entities[0] as RoomPlayerSession : null;
        }
    }
}
