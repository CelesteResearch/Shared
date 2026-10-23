using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Rendering;
using Celeste.Input.Gameplay;
using Celeste.Input.Gameplay.Feedback;
using Celeste.Scene.Lifecycle;
using Celeste.Scene.Tracking;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Audio;
using Celeste.Game.Entities.Birds;
using Celeste.Game.Entities.Platforms.Barriers;
using Celeste.Game.Entities.Effects.AbsorbOrbs;
using Celeste.Game.Gameplay.Collectibles.Strawberries;
using Celeste.Game.Presentation.Hud.Poems;
using Celeste.Game.Execution.Engine.Actions;
using Celeste.Game.Save.Runtime;
using Celeste.Game.Platform.Statistics;
using Celeste.Simulation;
using Celeste.Simulation.Audio.Emitters;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Simulation.Presentation.PostProcessing.Bloom;
using Celeste.Simulation.Presentation.Scene.Transitions;
using Celeste.Simulation.Presentation.Effects.Trails.Lifecycle;
using Celeste.Game.Entities.Triggers.Camera;
using Celeste.Graphics.Content;
using Celeste.Graphics.Display;
using Celeste.Graphics.Display.Colors;

namespace Celeste.Game.Entities.Collectibles.Hearts
{
    public partial class OriginalHeartGemState
    {
        private IOriginalGameplayProcess Process => (IOriginalGameplayProcess)engine;
        private ISourceExtremaArithmetic Extrema => ((ISourceExtremaEnvironment)engine).ExtremaArithmetic;
        private ISourceEasingArithmetic Easing => ((ISourceEasingEnvironment)engine).EasingArithmetic;
        private IOriginalHeartGemRuntimePolicy HeartPolicy => ((IOriginalHeartGemEnvironment)engine).HeartGemPolicy;

        private OriginalAreaKey GetArea(OriginalLevelSceneRoot level) =>
            ((IOriginalAreaKeyEnvironment)engine).AreaKeys.GetSessionArea(level.Session);

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
            int unlockedModes =
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
                if (global::Celeste.Physics.Collision.SourceEntityCollision.Check(this, trigger))
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
            bool collided = false;
            foreach (var item in ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities("Celeste.Solid"))
                if (global::Celeste.Physics.Collision.SourceEntityCollision.Check(player,
                        (global::Celeste.Physics.Collision.ISourceEntityCollider)item))
                {
                    collided = true;
                    break;
                }

            player.Position = previous;
            return collided;
        }
    }
}
