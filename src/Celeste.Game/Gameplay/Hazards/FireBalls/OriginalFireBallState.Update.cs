using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Game.Execution.Levels;
using Celeste.Scene.Tracking;
using Celeste.Simulation;

namespace Celeste.Game.Gameplay.Hazards.FireBalls
{
    public partial class OriginalFireBallState
    {
        public override void Update()
        {
            if ((Scene as OriginalLevelSceneRoot).Transitioning)
            {
                PositionTrackSfx();
                return;
            }

            base.Update();
            speedMult = ScalarMath.Approach(speedMult, iceMode ? 0.5f : 1f, 2f * engine.Frame.DeltaTime,
                engine.ExtremaArithmetic);
            percent += speed * speedMult * engine.Frame.DeltaTime;
            if (percent >= 1f)
            {
                percent %= 1f;
                if (broken && nodes[nodes.Length - 1] != nodes[0])
                {
                    broken = false;
                    Collidable = true;
                    sprite.Play(iceMode ? "ice" : "hot", false, true);
                }
            }

            Position = GetPercentPosition(percent);
            PositionTrackSfx();
            if (!broken && ((ISourceScene)Scene).SourceScene.Clock.OnInterval(iceMode ? 0.08f : 0.05f, engine))
                ((OriginalLevelSceneRoot)Scene).ParticlesBG.Emit(
                    iceMode ? engine.ParticleTypes.FireBall.P_IceTrail : FireTrailParticle, 1,
                    Center, Vector2.One * 4f);
        }

        public void PositionTrackSfx()
        {
            if (trackSfx == null) return;

            var entity =
                ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(RoomPlayerSession).FullName);

            if (entity == null) return;

            Vector2? vector = null;
            for (var i = 1; i < nodes.Length; i++)
            {
                var vector2 =
                    Vector2Geometry.ClosestPointOnLine(nodes[i - 1], nodes[i], entity.Center, engine.VectorArithmetic);
                if (!vector.HasValue || engine.VectorArithmetic.Length(vector2 - entity.Center) <
                    engine.VectorArithmetic.Length(vector.Value - entity.Center))
                    vector = vector2;
            }

            if (vector.HasValue)
            {
                trackSfx.Position = vector.Value - Position;
                trackSfx.UpdateSfxPosition();
            }
        }
    }
}
