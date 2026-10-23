using System;
using Celeste.Core.Components;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Player.Presentation.Hair;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        public float WindSine;
        public float WindSineTimer;
        private bool updateHair = true;

        private void UpdateSourceGameplayTail()
        {
            HudRenderer.BackgroundFade = ScalarMath.Approach(HudRenderer.BackgroundFade,
                Paused ? 1f : 0f, 8f * EngineContext.RawDeltaTime,
                ((ISourceExtremaEnvironment)EngineContext).ExtremaArithmetic);
            if (!FrozenOrPaused)
            {
                WindSineTimer += EngineContext.DeltaTime;
                WindSine = (float)(Math.Sin(WindSineTimer) + 1.0) / 2f;
            }

            foreach (var entry in Scheduler.Components.GetTrackedComponents("Celeste.PostUpdateHook"))
            {
                var hook = (ScenePostUpdateHook)entry;
                if (((ISourceEntityUpdate)hook.Entity).Active)
                    hook.OnPostUpdate();
            }

            if (updateHair)
            {
                foreach (var entry in Scheduler.Components.GetTrackedComponents("Celeste.PlayerHair"))
                {
                    if (entry.Active && ((ISourceEntityUpdate)entry.Entity).Active)
                        (entry as PlayerHair).AfterUpdate();
                }

                if (FrozenOrPaused)
                    updateHair = false;
            }
            else if (!FrozenOrPaused)
                updateHair = true;

            UpdateSourceScreenEffects();
            ColorGrade.Update(EngineContext.DeltaTime);
        }
    }
}
