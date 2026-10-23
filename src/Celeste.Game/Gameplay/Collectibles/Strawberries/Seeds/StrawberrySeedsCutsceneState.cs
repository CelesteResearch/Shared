using System;
using System.Collections;
using System.Numerics;
using Celeste.Audio.Fmod.Events;
using Celeste.Core.Mathematics;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Game.Execution.Startup;
using Celeste.Graphics.Particles.Sources;
using Celeste.Simulation;
using Celeste.Simulation.Presentation.Particles;

namespace Celeste.Game.Gameplay.Collectibles.Strawberries.Seeds
{
    public sealed class StrawberrySeedsCutsceneState : OriginalCutsceneEntityState
    {
        private readonly OriginalStrawberryState strawberry;
        private Vector2 cameraStart;
        private ParticleSystemPresentation system;
        private FmodEventReference snapshot;
        private FmodEventReference sfx;
        private readonly IOriginalStrawberryProcess process;

        public StrawberrySeedsCutsceneState(OriginalStrawberryState strawberry,
            IOriginalStrawberryProcess process)
            : base(process)
        {
            this.strawberry = strawberry;
            this.process = process ?? throw new ArgumentNullException(nameof(process));
        }

        public override void OnBegin(OriginalLevelSceneRoot level)
        {
            cameraStart = level.Camera.Position;
            OwnedComponents.Add(new SimulationCoroutine(process, Cutscene(level)));
        }

        private IEnumerator Cutscene(OriginalLevelSceneRoot level)
        {
            sfx = process.AudioSession.Play("event:/game/general/seed_complete_main", Position, process.SaveContext);
            snapshot = process.AudioSession.CreateSnapshot("snapshot:/music_mains_mute");
            var players =
                level.Scheduler.Entities.GetTrackedEntities(typeof(RoomPlayerSession)
                    .FullName);
            var entity = players.Count == 0 ? null : (RoomPlayerSession)players[0];
            if (entity != null) cameraStart = entity.CameraTarget;
            foreach (var seed in strawberry.Seeds) seed.OnAllCollected();
            strawberry.Depth = -2000002;
            strawberry.Tags |= ((IOriginalGameTagsEnvironment)process).Tags.FrozenUpdate.Value;
            yield return .35f;
            Tags = ((IOriginalGameTagsEnvironment)process).Tags.FrozenUpdate.Value |
                   ((IOriginalGameTagsEnvironment)process).Tags.HUD.Value;
            level.Frozen = true;
            level.FormationBackdrop.Display = true;
            level.FormationBackdrop.Alpha = .5f;
            level.Displacement.Clear();
            level.Displacement.Enabled = false;
            PauseBuses(true);
            yield return .1f;
            system = new(-2000002, 50, process,
                (ISourceParticleTextureEnvironment)process);
            system.Tags = ((IOriginalGameTagsEnvironment)process).Tags.FrozenUpdate.Value;
            level.Scheduler.QueueSourceEntity(system);
            var angleStep = (float)Math.PI * 2f / strawberry.Seeds.Count;
            var angle = (float)Math.PI / 2f;
            var average = Vector2.Zero;
            foreach (var seed in strawberry.Seeds) average += seed.Position;
            average /= strawberry.Seeds.Count;
            foreach (var seed in strawberry.Seeds)
            {
                seed.StartSpinAnimation(average, strawberry.Position, angle, 4f);
                angle -= angleStep;
            }

            var target = strawberry.Position - new Vector2(160f, 90f);
            target = new(ScalarMath.Clamp(target.X, level.Bounds.Left, level.Bounds.Right - 320),
                ScalarMath.Clamp(target.Y, level.Bounds.Top, level.Bounds.Bottom - 180));
            OwnedComponents.Add(new SimulationCoroutine(process,
                CameraTo(process, target, 3.5f, process.EasingArithmetic.CubeInOut)));
            yield return 4f;
            process.RumbleSession.Rumble(0, 2);
            process.AudioSession.Play("event:/game/general/seed_complete_berry", strawberry.Position,
                process.SaveContext);
            foreach (var seed in strawberry.Seeds) seed.StartCombineAnimation(strawberry.Position, .6f, system);
            yield return .6f;
            process.RumbleSession.Rumble(1, 1);
            foreach (var seed in strawberry.Seeds) seed.RemoveSelf();
            strawberry.CollectedSeeds();
            yield return .5f;
            var distance = process.VectorArithmetic.Length(level.Camera.Position - cameraStart);
            yield return CameraTo(process, cameraStart, distance / 180f);
            if (distance > 80f) yield return .25f;
            level.CutscenePolicy.EndCutscene();
            OnEnd(level);
        }

        public override void OnEnd(OriginalLevelSceneRoot level)
        {
            if (WasSkipped) process.AudioSession.Stop(sfx);
            level.Scheduler.OnEndOfFrame += () =>
            {
                if (WasSkipped)
                {
                    foreach (var seed in strawberry.Seeds) seed.RemoveSelf();
                    strawberry.CollectedSeeds();
                    level.Camera.Position = cameraStart;
                }

                strawberry.Depth = -100;
                strawberry.Tags &= ~((IOriginalGameTagsEnvironment)process).Tags.FrozenUpdate.Value;
                level.Frozen = false;
                level.FormationBackdrop.Display = false;
                level.Displacement.Enabled = true;
            };
            RemoveSelf();
        }

        private void PauseBuses(bool paused)
        {
            process.AudioSession.BusPaused("bus:/gameplay_sfx/ambience", paused);
            process.AudioSession.BusPaused("bus:/gameplay_sfx/char", paused);
            process.AudioSession.BusPaused("bus:/gameplay_sfx/game/general/yes_pause", paused);
            process.AudioSession.BusPaused("bus:/gameplay_sfx/game/chapters", paused);
        }

        private void EndSfx()
        {
            PauseBuses(false);
            process.AudioSession.ReleaseSnapshot(snapshot);
        }

        public override void Removed(object scene)
        {
            EndSfx();
            base.Removed(scene);
        }

        public override void SceneEnd(object scene)
        {
            EndSfx();
            base.SceneEnd(scene);
        }
    }
}
