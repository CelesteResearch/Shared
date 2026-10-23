using Celeste.Core.Scheduling;

namespace Celeste.Game.Execution.Engine.Timing
{
    public interface IOriginalEngineTimeRatePolicy
    {
        OriginalEngineTimeSample Sample(float rawDeltaTime, SourceEngineEffectsState effects,
            ISourceSceneExecution currentScene);
    }
}
