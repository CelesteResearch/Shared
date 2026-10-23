using System;
using Celeste.Game.Gameplay.Collectibles.Strawberries;
using Celeste.Scene.Entities;
using System.Collections;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Mathematics;
using Celeste.Core.Scheduling;
using Celeste.Audio.Fmod.Events;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Simulation;
using Celeste.Simulation.Presentation.Particles;
using Celeste.Graphics.Particles.Sources;

namespace Celeste.Everest.Gameplay.Collectibles.Strawberries.Seeds
{
    [Celeste.Core.Reflection.Runtime.RuntimeTypeAlias("Celeste.Mod.Entities.CSGEN_GenericStrawberrySeeds")]
    public class GenericStrawberrySeedsCutsceneState : OriginalCutsceneEntityState
    {
        private IStrawberrySeeded strawberry;
        private Vector2 cameraStart;
        private ParticleSystemPresentation system;
        private FmodEventReference snapshot;
        private FmodEventReference sfx;
        private readonly IOriginalStrawberryProcess process;

        public GenericStrawberrySeedsCutsceneState(IStrawberrySeeded strawberry,
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
                level.Scheduler.Entities.GetTrackedEntities(typeof(global::Celeste.Simulation.RoomPlayerSession)
                    .FullName);
            RoomPlayerSession player = players.Count == 0 ? null : (RoomPlayerSession)players[0];
            if (player != null) cameraStart = player.CameraTarget;
            var seeds = strawberry.Seeds;
            var entity = (SceneEntityState)strawberry;
            foreach (var seed in seeds) seed.OnAllCollected();
            entity.Depth = -2000002;
            entity.Tags |= ((IOriginalGameTagsEnvironment)process).Tags.FrozenUpdate.Value;
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
            system = new ParticleSystemPresentation(-2000002, 50, process,
                (ISourceParticleTextureEnvironment)process);
            system.Tags = ((IOriginalGameTagsEnvironment)process).Tags.FrozenUpdate.Value;
            level.Scheduler.QueueSourceEntity(system);
            float angleStep = (float)Math.PI * 2f / seeds.Count;
            float angle = (float)Math.PI / 2f;
            Vector2 average = Vector2.Zero;
            foreach (var seed in seeds) average += seed.Position;
            average /= seeds.Count;
            foreach (var seed in seeds)
            {
                seed.StartSpinAnimation(average, entity.Position, angle, 4f);
                angle -= angleStep;
            }

            Vector2 target = entity.Position - new Vector2(160f, 90f);
            target = new Vector2(ScalarMath.Clamp(target.X, level.Bounds.Left, level.Bounds.Right - 320),
                ScalarMath.Clamp(target.Y, level.Bounds.Top, level.Bounds.Bottom - 180));
            OwnedComponents.Add(new SimulationCoroutine(process,
                CameraTo(process, target, 3.5f, process.EasingArithmetic.CubeInOut)));
            yield return 4f;
            process.RumbleSession.Rumble(0, 2);
            process.AudioSession.Play("event:/game/general/seed_complete_berry", entity.Position,
                process.SaveContext);
            foreach (var seed in seeds) seed.StartCombineAnimation(entity.Position, .6f, system);
            yield return .6f;
            process.RumbleSession.Rumble(1, 1);
            foreach (var seed in seeds) seed.RemoveSelf();
            strawberry.CollectedSeeds();
            yield return .5f;
            float distance = process.VectorArithmetic.Length(level.Camera.Position - cameraStart);
            yield return CameraTo(process, cameraStart, distance / 180f);
            if (distance > 80f) yield return .25f;
            level.EndCutscene();
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

                ((SceneEntityState)strawberry).Depth = -100;
                ((SceneEntityState)strawberry).Tags &= ~((IOriginalGameTagsEnvironment)process).Tags.FrozenUpdate.Value;
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
