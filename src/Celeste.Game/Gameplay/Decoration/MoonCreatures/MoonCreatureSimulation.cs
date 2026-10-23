using System;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Graphics.Rendering;
using Celeste.Scene.Entities;
using Celeste.Simulation;

namespace Celeste.Game.Gameplay.Decoration.MoonCreatures
{
    public static class MoonCreatureSimulation
    {
        public static void GetRandomTarget(IOriginalMoonCreatureProcess engine, Vector2 start, ref Vector2 target,
            float radius, float minimumDistance)
        {
            var vector = target;
            do
            {
                var length = SourceRandomMath.NextFloat(engine.Random, radius);
                var angleRadians = SourceRandomMath.NextFloat(engine.Random, (float)Math.PI * 2f);
                target = start + Vector2Geometry.AngleToVector(angleRadians, length);
            } while (engine.VectorArithmetic.Length(vector - target) < minimumDistance);
        }

        public static void GetFollowOffset(IOriginalMoonCreatureProcess engine, ref Vector2 followingOffset)
        {
            followingOffset = new(engine.Random.Choose(-1, 1) * SourceRandomMath.Range(engine.Random, 8, 16),
                SourceRandomMath.Range(engine.Random, -20f, 0f));
        }

        public static void OnPlayer(IOriginalMoonCreatureProcess engine, Vector2 position, Vector2 start,
            RoomPlayerSession player, in MoonCreatureMotionSettings settings, ref Vector2 bump,
            ref RoomPlayerSession following, ref float followingTime, ref Vector2 followingOffset)
        {
            var vector = engine.VectorArithmetic.SafeNormalize(position - player.Center,
                engine.VectorArithmetic.Length(player.Data.Motion.Normal.Speed) * 0.3f);
            if (engine.VectorArithmetic.LengthSquared(vector) > engine.VectorArithmetic.LengthSquared(bump))
            {
                bump = vector;
                if (engine.VectorArithmetic.Length(player.Center - start) < settings.MaxFollowDistance)
                {
                    following = player;
                    followingTime =
                        SourceRandomMath.Range(engine.Random, settings.MinFollowTime, settings.MaxFollowTime);
                    GetFollowOffset(engine, ref followingOffset);
                }
            }
        }

        public static void Update(IOriginalMoonCreatureProcess engine, SceneEntityState self, Vector2 start,
            ref Vector2 target, ref float targetTimer, ref Vector2 speed, ref Vector2 bump,
            ref RoomPlayerSession following, ref float followingTime, ref Vector2 followingOffset,
            in MoonCreatureMotionSettings settings)
        {
            if (following == null)
            {
                targetTimer -= engine.DeltaTime;
                if (targetTimer <= 0f)
                {
                    targetTimer = SourceRandomMath.Range(engine.Random, settings.MinTargetTime, settings.MaxTargetTime);
                    GetRandomTarget(engine, start, ref target, settings.TargetRangeRadius,
                        settings.TargetRangeRadius / 4f);
                }
            }
            else
            {
                followingTime -= engine.DeltaTime;
                targetTimer -= engine.DeltaTime;
                if (targetTimer <= 0f)
                {
                    targetTimer = SourceRandomMath.Range(engine.Random, settings.MinTargetTime,
                        settings.MaxFollowTargetTime);
                    GetFollowOffset(engine, ref followingOffset);
                }

                target = following.Center + followingOffset;
                if (engine.VectorArithmetic.Length(self.Position - start) > settings.MaxFollowDistance ||
                    followingTime <= 0f)
                {
                    following = null;
                    targetTimer = 0f;
                }
            }

            var vector = engine.VectorArithmetic.SafeNormalize(target - self.Position);
            speed += vector * (following == null ? settings.Acceleration : settings.FollowAcceleration) *
                     engine.DeltaTime;
            speed = engine.VectorArithmetic.SafeNormalize(speed) *
                    engine.ExtremaArithmetic.Min(engine.VectorArithmetic.Length(speed),
                        following == null ? settings.MaxSpeed : settings.MaxFollowSpeed);
            bump = engine.VectorArithmetic.SafeNormalize(bump) * ScalarMath.Approach(
                engine.VectorArithmetic.Length(bump),
                0f, engine.DeltaTime * 80f, engine.ExtremaArithmetic);
            self.Position += (speed + bump) * engine.DeltaTime;
        }

        public static void UpdateTrail<TTrail>(IOriginalMoonCreatureProcess engine, SceneEntityState self,
            TTrail[] trail, float gravity, float spacing, float catchupSpeed)
            where TTrail : struct, IMoonCreatureTrailNode
        {
            var position = self.Position;
            for (var i = 0; i < trail.Length; i++)
            {
                ref var node = ref trail[i];
                var vector2 = engine.VectorArithmetic.SafeNormalize(node.TrailPosition - position);
                if (vector2 == Vector2.Zero) vector2 = new(0f, 1f);

                vector2.Y += gravity;
                var vector3 = position + vector2 * spacing;
                node.TrailPosition =
                    engine.VectorArithmetic.Approach(node.TrailPosition, vector3, catchupSpeed * engine.DeltaTime);
                position = node.TrailPosition;
            }
        }

        public static void RenderTrail<TTrail>(ISourceRenderContext context, SceneEntityState self, TTrail[] trail,
            float baseSize) where TTrail : struct, IMoonCreatureTrailNode
        {
            for (var num = trail.Length - 1; num >= 0; num--)
            {
                var position2 = trail[num].TrailPosition;
                var num2 = ScalarMath.ClampedMap(num, 0f, trail.Length - 1, baseSize);
                SourcePrimitiveDrawing.Rect(context, self, position2.X - num2 / 2f, position2.Y - num2 / 2f, num2, num2,
                    trail[num].TrailColor);
            }
        }
    }
}
