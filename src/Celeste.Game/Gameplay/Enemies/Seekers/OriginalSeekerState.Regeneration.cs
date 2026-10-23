using System;
using System.Collections;
using Celeste.Core.Mathematics;
using Celeste.Core.Randomness;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Gameplay.Holdables.TheoCrystal;
using Celeste.Game.Gameplay.Mechanisms.Switches;
using Celeste.Game.Gameplay.Walls.Breakable;
using Celeste.Physics.Collision;
using Celeste.Scene.Entities;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Enemies.Seeker;

namespace Celeste.Game.Gameplay.Enemies.Seekers
{
    public partial class OriginalSeekerState
    {
        private IEnumerator RegenerateCoroutine()
        {
            yield return 1f;
            shaker.On = true;
            yield return 0.2f;
            sprite.Play("pulse");
            yield return 0.5f;
            sprite.Play("recover");
            SeekerRecoverBlastState.Spawn(engine, Position);
            yield return 0.15f;
            Collider = pushRadius;
            var player =
                CollideFirst<RoomPlayerSession>(typeof(RoomPlayerSession).FullName);

            if (player != null && SourceSceneCollision.FirstLine<ISourceEntityCollider>(
                    ((OriginalLevelSceneRoot)Scene).Scheduler.Entities, "Celeste.Solid", Position, player.Center) ==
                null)
                player.ExplodeLaunch(Position);

            var theoCrystal = CollideFirst<TheoCrystalState>("Celeste.TheoCrystal");
            if (theoCrystal != null && SourceSceneCollision.FirstLine<ISourceEntityCollider>(
                    ((OriginalLevelSceneRoot)Scene).Scheduler.Entities, "Celeste.Solid", Position,
                    theoCrystal.Center) ==
                null)
                theoCrystal.ExplodeLaunch(Position);

            foreach (OriginalTempleCrackedBlockState entity in
                     ((OriginalLevelSceneRoot)Scene).Scheduler.Entities
                     .GetTrackedEntities("Celeste.TempleCrackedBlock"))
                if (SourceEntityCollision.Check(this, entity))
                    entity.Break(Position);

            foreach (OriginalTouchSwitchState entity2 in ((OriginalLevelSceneRoot)Scene).Scheduler.Entities
                     .GetTrackedEntities("Celeste.TouchSwitch"))
                if (SourceEntityCollision.Check(this, entity2))
                    entity2.TurnOn();

            Collider = physicsHitbox;
            var level = (OriginalLevelSceneRoot)Scene;
            level.Displacement.AddBurst(Position, 0.4f, 12f, 36f, 0.5f);
            level.Displacement.AddBurst(Position, 0.4f, 24f, 48f, 0.5f);
            level.Displacement.AddBurst(Position, 0.4f, 36f, 60f, 0.5f);
            for (var num = 0f; num < (float)Math.PI * 2f; num += 0.17453292f)
            {
                var position = Center + Vector2Geometry.AngleToVector(
                    num + SourceRandomMath.Range(engine.Random, -(float)Math.PI / 90f, (float)Math.PI / 90f),
                    SourceRandomMath.Range(engine.Random, 12, 18));
                level.Particles.Emit(engine.SeekerParticles.P_Regen, position, num);
            }

            shaker.On = false;
            CurrentStateMachine.Locked = false;
            CurrentStateMachine.State = 7;
        }
    }
}
