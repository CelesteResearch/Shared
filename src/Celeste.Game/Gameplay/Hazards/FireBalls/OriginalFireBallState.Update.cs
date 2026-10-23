using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Rendering;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Scene.Components.Oscillation;
using Celeste.Game.Execution.Levels;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Environment.Core;
using Celeste.Simulation.Gameplay.Player.Collision.Components;
using Celeste.Simulation.Audio.Sources;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Display;

namespace Celeste.Game.Gameplay.Hazards.FireBalls
{
    public partial class OriginalFireBallState
    {
        public override void Update()
        {
            if ((base.Scene as OriginalLevelSceneRoot).Transitioning)
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
                    sprite.Play(iceMode ? "ice" : "hot", restart: false, randomizeFrame: true);
                }
            }

            Position = GetPercentPosition(percent);
            PositionTrackSfx();
            if (!broken && ((ISourceScene)Scene).SourceScene.Clock.OnInterval(iceMode ? 0.08f : 0.05f, engine))
            {
                ((OriginalLevelSceneRoot)Scene).ParticlesBG.Emit(
                    iceMode ? engine.ParticleTypes.FireBall.P_IceTrail : FireTrailParticle, 1,
                    base.Center, Vector2.One * 4f);
            }
        }

        public void PositionTrackSfx()
        {
            if (trackSfx == null)
            {
                return;
            }

            RoomPlayerSession entity =
                ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);

            if (entity == null)
            {
                return;
            }

            Vector2? vector = null;
            for (int i = 1; i < nodes.Length; i++)
            {
                Vector2 vector2 =
                    Vector2Geometry.ClosestPointOnLine(nodes[i - 1], nodes[i], entity.Center, engine.VectorArithmetic);
                if (!vector.HasValue || engine.VectorArithmetic.Length(vector2 - entity.Center) <
                    engine.VectorArithmetic.Length(vector.Value - entity.Center))
                {
                    vector = vector2;
                }
            }

            if (vector.HasValue)
            {
                trackSfx.Position = vector.Value - Position;
                trackSfx.UpdateSfxPosition();
            }
        }
    }
}
