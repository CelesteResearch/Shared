using System.Collections;
using System.Numerics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Game.Entities.Triggers.Camera;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Platform.Statistics;
using Celeste.Game.Save.Runtime;
using Celeste.Physics.Collision;
using Celeste.Scene.Tracking;
using Celeste.Simulation;

namespace Celeste.Game.Entities.Collectibles.Hearts
{
    public partial class OriginalHeartGemState
    {
        private IOriginalGameplayProcess Process => (IOriginalGameplayProcess)engine;
        private ISourceExtremaArithmetic Extrema => ((ISourceExtremaEnvironment)engine).ExtremaArithmetic;
        private ISourceEasingArithmetic Easing => ((ISourceEasingEnvironment)engine).EasingArithmetic;
        private IOriginalHeartGemRuntimePolicy HeartPolicy => ((IOriginalHeartGemEnvironment)engine).HeartGemPolicy;

        private OriginalAreaKey GetArea(OriginalLevelSceneRoot level)
        {
            return ((IOriginalAreaKeyEnvironment)engine).AreaKeys.GetSessionArea(level.Session);
        }

        // Wrapper is intentionally not an iterator: installed registered-berry collection
        // happens immediately before the original iterator is constructed.
        private IEnumerator CollectRoutine(RoomPlayerSession player)
        {
            HeartPolicy.BeforeCollectRoutine(Scene as OriginalLevelSceneRoot, player, IsFake);
            return OriginalCollectRoutine(player);
        }

        private void RegisterAsCollected(OriginalLevelSceneRoot level, string poemID)
        {
            level.Session.HeartGem = true;
            level.Session.UpdateLevelStartDashes();
            var unlockedModes =
                ((IOriginalSaveProgressionEnvironment)engine).SaveProgression.GetUnlockedModes(Process.SaveContext
                    .CurrentSave);
            ((IOriginalSaveHeartEnvironment)engine).SaveHearts.RegisterHeartGem(Process.SaveContext.CurrentSave,
                GetArea(level));
            if (!string.IsNullOrEmpty(poemID))
                ((IOriginalSavePoemEnvironment)engine).SavePoem.RegisterPoemEntry(Process.SaveContext.CurrentSave,
                    poemID);
            if (unlockedModes < 3 &&
                ((IOriginalSaveProgressionEnvironment)engine).SaveProgression.GetUnlockedModes(Process.SaveContext
                    .CurrentSave) >= 3)
                level.Session.UnlockedCSide = true;
            if (HeartPolicy.TotalHeartsForAchievement(engine, Process.SaveContext.CurrentSave) >= 24)
                ((IOriginalPlatformStatisticsEnvironment)engine).Statistics.Achievements.Register(
                    OriginalAchievement.CSIDES);
        }

        private void RemoveSourceCameraOffsetTriggers()
        {
            foreach (var item in ((ISourceScene)Scene).SourceScene.Entities.FindAll<OriginalCameraOffsetTriggerState>())
                item.RemoveSelf();
        }

        private void FakeRemoveCameraTrigger()
        {
            var list = ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities("Celeste.CameraTargetTrigger");
            foreach (var item in list)
            {
                var trigger = (OriginalCameraTargetTriggerState)item;
                if (SourceEntityCollision.Check(this, trigger))
                {
                    trigger.LerpStrength = 0f;
                    break;
                }
            }
        }

        private bool PlayerCollidesSolidAt(RoomPlayerSession player, Vector2 at)
        {
            var previous = player.Position;
            player.Position = at;
            var collided = false;
            foreach (var item in ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities("Celeste.Solid"))
                if (SourceEntityCollision.Check(player,
                        (ISourceEntityCollider)item))
                {
                    collided = true;
                    break;
                }

            player.Position = previous;
            return collided;
        }
    }
}
