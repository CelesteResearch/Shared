using System;
using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Engine.Timing;

namespace Celeste.Everest.Runtime.Engine.Timing
{
    public sealed class EverestEngineTimeRatePolicy : IOriginalEngineTimeRatePolicy
    {
        public static readonly EverestEngineTimeRatePolicy Instance = new();
        private const string ModifierSourceType = "Celeste.Mod.Entities.TimeRateModifier";

        private EverestEngineTimeRatePolicy()
        {
        }

        public OriginalEngineTimeSample Sample(float rawDeltaTime, SourceEngineEffectsState effects,
            ISourceSceneExecution currentScene)
        {
            if (effects == null) throw new ArgumentNullException(nameof(effects));
            var multiplier = 1f;
            if (currentScene != null)
            {
                var scene = currentScene as ISourceComponentIndexScene
                            ?? throw new InvalidOperationException(
                                "An actual source scene has no source component Tracker.");
                foreach (var identity in ((ISourceTrackedComponents)scene.ComponentIndex).GetTrackedComponents(
                             ModifierSourceType))
                {
                    var modifier = identity as ISourceTimeRateModifier
                                   ?? throw new InvalidOperationException(
                                       "A tracked time rate modifier has no actual source fields.");
                    if (modifier.Enabled) multiplier *= modifier.Multiplier;
                }
            }

            return OriginalEngineTimePolicy.Sample(rawDeltaTime, effects, multiplier);
        }
    }
}
