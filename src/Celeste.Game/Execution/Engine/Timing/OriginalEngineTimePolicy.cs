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
            float effective = effects.TimeRate * effects.TimeRateB * componentMultiplier;
            float deltaTime = rawDeltaTime * effects.TimeRate * effects.TimeRateB * componentMultiplier;
            return new OriginalEngineTimeSample(rawDeltaTime, deltaTime, effective);
        }
    }
}
