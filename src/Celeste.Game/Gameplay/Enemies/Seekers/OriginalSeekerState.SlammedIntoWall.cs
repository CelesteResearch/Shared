using System;
using System.Numerics;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Gameplay.Walls.Breakable;
using Celeste.Physics.Collision;
using Celeste.Simulation.Gameplay.Enemies.Seeker;
using Celeste.Simulation.Gameplay.Mechanisms.Switches;

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
                x = Right;
            }
            else
            {
                direction = 0f;
                x = Left;
            }

            ((OriginalLevelSceneRoot)Scene).Particles.Emit(engine.SeekerParticles.P_HitWall, 12, new(x, Y),
                Vector2.UnitY * 4f, direction);
            if (data.Hit is ISourceDashSwitch)
                ((ISourceDashSwitch)data.Hit).OnDashCollide(null, Vector2.UnitX * Math.Sign(Speed.X));

            Collider = breakWallsHitbox;
            foreach (OriginalTempleCrackedBlockState entity in
                     ((OriginalLevelSceneRoot)Scene).Scheduler.Entities
                     .GetTrackedEntities("Celeste.TempleCrackedBlock"))
                if (SourceEntityCollision.CheckAt(this, entity, Position + Vector2.UnitX * Math.Sign(Speed.X)))
                    entity.Break(Center);

            Collider = physicsHitbox;
            ((OriginalLevelSceneRoot)Scene).DirectionalShake(Vector2.UnitX * Math.Sign(Speed.X));
            engine.RumbleSession.Rumble(1, 1);
            Speed.X = Math.Sign(Speed.X) * -100f;
            Speed.Y *= 0.4f;
            sprite.Scale.X = 0.6f;
            sprite.Scale.Y = 1.4f;
            shaker.ShakeFor(0.5f, false);
            scaleWiggler.Start();
            CurrentStateMachine.State = 4;
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
