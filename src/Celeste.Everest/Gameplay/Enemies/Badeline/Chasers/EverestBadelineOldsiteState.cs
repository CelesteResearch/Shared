using System.Collections;
using System.Numerics;
using Celeste.Core.Audio;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Gameplay.Enemies.Badeline.Chasers;

namespace Celeste.Everest.Gameplay.Enemies.Badeline.Chasers
{
    public class EverestBadelineOldsiteState : BadelineOldsiteState
    {
        private readonly bool canChangeMusic;

        public EverestBadelineOldsiteState(EntityData data, Vector2 offset, int index,
            ISourceEngineContext engine)
            : base(data, offset, index, engine)
        {
            canChangeMusic = EntityAttributeReader.Bool(data.Values, "canChangeMusic", true);
        }

        public override void Added(object scene)
        {
            var level = scene as OriginalLevelSceneRoot;
            if (level?.AreaData.LevelSet == "Celeste")
            {
                base.Added(scene);
                return;
            }

            AddedSourceEntityBase(scene);
            OwnedComponents.Add(new SimulationCoroutine(engine, StartChasingRoutine(level)));
        }

        public override bool IsChaseEnd(bool value)
        {
            var level = (OriginalLevelSceneRoot)Scene;
            if (level.AreaData.LevelSet == "Celeste") return value;
            return level.SourceScene.Entities.GetTrackedEntities("Celeste.Mod.Entities.BadelineOldsiteEnd").Count != 0;
        }

        public override bool CanChangeMusic(bool value)
        {
            return ((OriginalLevelSceneRoot)Scene).AreaData.LevelSet == "Celeste" ? value : canChangeMusic;
        }

        protected override IEnumerator StopChasing()
        {
            return ((OriginalLevelSceneRoot)Scene).AreaData.LevelSet == "Celeste"
                ? base.StopChasing()
                : CustomStopChasing();
        }

        private IEnumerator CustomStopChasing()
        {
            var level = (OriginalLevelSceneRoot)Scene;
            while (!CollideCheck("Celeste.Mod.Entities.BadelineOldsiteEnd")) yield return null;
            following = false;
            ignorePlayerAnim = true;
            Sprite.Play("laugh");
            Sprite.Scale.X = 1f;
            yield return 1f;
            ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play("event:/char/badeline/disappear", Position);
            level.Displacement.AddBurst(Center, .5f, 24f, 96f, .4f);
            level.Particles.Emit(((IOriginalGameplayProcess)engine).ParticleTypes.BadelineOldsite.P_Vanish, 12, Center,
                Vector2.One * 6f);
            RemoveSelf();
        }
    }
}
