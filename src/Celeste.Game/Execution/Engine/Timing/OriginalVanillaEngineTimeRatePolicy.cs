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
            float deltaTime = rawDeltaTime * effects.TimeRate * effects.TimeRateB;
            float effective = effects.TimeRate * effects.TimeRateB;
            return new OriginalEngineTimeSample(rawDeltaTime, deltaTime, effective);
        }
    }
}
