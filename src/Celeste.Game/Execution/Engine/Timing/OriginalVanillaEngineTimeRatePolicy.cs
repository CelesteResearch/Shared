using System;
using Celeste.Core.Scheduling;

namespace Celeste.Game.Execution.Engine.Timing
{
    public sealed class OriginalVanillaEngineTimeRatePolicy : IOriginalEngineTimeRatePolicy
    {
        public static readonly OriginalVanillaEngineTimeRatePolicy Instance = new();

        private OriginalVanillaEngineTimeRatePolicy()
        {
        }

        public OriginalEngineTimeSample Sample(float rawDeltaTime, SourceEngineEffectsState effects,
            ISourceSceneExecution currentScene)
        {
            if (effects == null) throw new ArgumentNullException(nameof(effects));
            var deltaTime = rawDeltaTime * effects.TimeRate * effects.TimeRateB;
            var effective = effects.TimeRate * effects.TimeRateB;
            return new(rawDeltaTime, deltaTime, effective);
        }
    }
}
