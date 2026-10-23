using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Game.Execution.Levels;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Enemies.Seeker;
using Celeste.Simulation.Presentation.Effects.Trails.Lifecycle;

namespace Celeste.Game.Gameplay.Enemies.Seekers
{
    public partial class OriginalSeekerState
    {
        private bool CanAttack()
        {
            if (Math.Abs(Y - lastSpottedAt.Y) > 24f) return false;
            if (Math.Abs(X - lastSpottedAt.X) < 16f) return false;
            var value = engine.VectorArithmetic.SafeNormalize(FollowTarget - Center);
            if (engine.VectorArithmetic.Dot(-Vector2.UnitY, value) > .5f ||
                engine.VectorArithmetic.Dot(Vector2.UnitY, value) > .5f) return false;
            return CollideCheck("Celeste.Solid", Position + Vector2.UnitX * Math.Sign(lastSpottedAt.X - X) * 24f)
                ? false
                : true;
        }

        private void AttackBegin()
        {
            engine.SpatialAudio.Play("event:/game/05_mirror_temple/seeker_dash", Position);
            attackWindUp = true;
            attackSpeed = -60f;
            Speed = engine.VectorArithmetic.SafeNormalize(FollowTarget - Center, -60f);
        }

        private int AttackUpdate()
        {
            if (!attackWindUp)
            {
                var vector = engine.VectorArithmetic.SafeNormalize(FollowTarget - Center);
                if (engine.VectorArithmetic.Dot(engine.VectorArithmetic.SafeNormalize(Speed), vector) < .4f) return 5;
                attackSpeed = ScalarMath.Approach(attackSpeed, 260f, 300f * engine.DeltaTime, engine.ExtremaArithmetic);
                Speed = engine.VectorArithmetic.SafeNormalize(
                    engine.VectorArithmetic.RotateTowards(Speed, Vector2Geometry.Angle(vector),
                        .61086524f * engine.DeltaTime), attackSpeed);
                if (((ISourceScene)Scene).SourceScene.Clock.OnInterval(.04f, engine))
                {
                    var vector2 = engine.VectorArithmetic.SafeNormalize(-Speed);
                    ((OriginalLevelSceneRoot)Scene).Particles.Emit(engine.SeekerParticles.P_Attack,
                        2, Position + vector2 * 4f, Vector2.One * 4f, Vector2Geometry.Angle(vector2));
                }

                if (((ISourceScene)Scene).SourceScene.Clock.OnInterval(.06f, engine)) CreateTrail();
            }

            return 3;
        }

        private IEnumerator AttackCoroutine()
        {
            TurnFacing(lastSpottedAt.X - X, "windUp");
            yield return .3f;
            attackWindUp = false;
            attackSpeed = 180f;
            Speed = engine.VectorArithmetic.SafeNormalize(lastSpottedAt - Vector2.UnitY * 2f - Center, 180f);
            SnapFacing(Speed.X);
        }

        private void CreateTrail()
        {
            var scale = sprite.Scale;
            sprite.Scale *= 1f - .3f * scaleWiggler.Value;
            sprite.Scale.X *= spriteFacing;
            TrailManagerState.Add(engine, engine, this, SeekerAppearance.TrailColor, .5f);
            sprite.Scale = scale;
        }
    }
}
