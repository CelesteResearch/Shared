using System;
using Celeste.Core.Scheduling;

namespace Celeste.Game.Execution.Engine.Timing
{
    public static class OriginalEngineTimePolicy
    {
        public static OriginalEngineTimeSample Sample(float rawDeltaTime, SourceEngineEffectsState effects,
            float componentMultiplier)
        {
            if (effects == null) throw new ArgumentNullException(nameof(effects));
            var effective = effects.TimeRate * effects.TimeRateB * componentMultiplier;
            var deltaTime = rawDeltaTime * effects.TimeRate * effects.TimeRateB * componentMultiplier;
            return new(rawDeltaTime, deltaTime, effective);
        }
    }
}
