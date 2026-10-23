using System;
using Celeste.Simulation.Gameplay.Mechanisms.Switches;
using Celeste.Simulation.Gameplay.Walls.Breakable;
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
        private void SlammedIntoWall(PixelCollision data)
        {
            float direction;
            float x;
            if (data.Direction.X > 0f)
            {
                direction = (float)Math.PI;
                x = base.Right;
            }
            else
            {
                direction = 0f;
                x = base.Left;
            }

            ((OriginalLevelSceneRoot)Scene).Particles.Emit(engine.SeekerParticles.P_HitWall, 12, new Vector2(x, base.Y),
                Vector2.UnitY * 4f, direction);
            if (data.Hit is ISourceDashSwitch)
            {
                ((ISourceDashSwitch)data.Hit).OnDashCollide(null, Vector2.UnitX * Math.Sign(Speed.X));
            }

            base.Collider = breakWallsHitbox;
            foreach (global::Celeste.Game.Gameplay.Walls.Breakable.OriginalTempleCrackedBlockState entity in
                     ((OriginalLevelSceneRoot)Scene).Scheduler.Entities
                     .GetTrackedEntities("Celeste.TempleCrackedBlock"))
            {
                if (SourceEntityCollision.CheckAt(this, entity, Position + Vector2.UnitX * Math.Sign(Speed.X)))
                {
                    entity.Break(base.Center);
                }
            }

            base.Collider = physicsHitbox;
            ((OriginalLevelSceneRoot)Scene).DirectionalShake(Vector2.UnitX * Math.Sign(Speed.X));
            engine.RumbleSession.Rumble(1, 1);
            Speed.X = (float)Math.Sign(Speed.X) * -100f;
            Speed.Y *= 0.4f;
            sprite.Scale.X = 0.6f;
            sprite.Scale.Y = 1.4f;
            shaker.ShakeFor(0.5f, removeOnFinish: false);
            scaleWiggler.Start();
            State.State = 4;
            if (data.Hit is SeekerBarrierState)
            {
                ((SeekerBarrierState)data.Hit).OnReflectSeeker();
                engine.SpatialAudio.Play("event:/game/05_mirror_temple/seeker_hit_lightwall", Position);
            }
            else
            {
                engine.SpatialAudio.Play("event:/game/05_mirror_temple/seeker_hit_normal", Position);
            }
        }
    }
}
