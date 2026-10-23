using System;
using Celeste.Core.Scheduling;
using Celeste.Core.Mathematics.Intervals;

namespace Celeste.Scene.Scheduling
{
    // The source scene owns these exact public fields for its entire lifetime.
    public sealed class SceneClock
    {
        public float TimeActive;
        public float RawTimeActive;

        public void BeforeUpdate(float deltaTime, float rawDeltaTime, bool paused)
        {
            if (!paused) TimeActive += deltaTime;
            RawTimeActive += rawDeltaTime;
        }

        public bool BetweenInterval(float interval)
            => TimeActive % (interval * 2f) > interval;

        public bool BetweenRawInterval(float interval)
            => RawTimeActive % (interval * 2f) > interval;

        public bool OnInterval(float interval, ISourceEngineContext engine)
            => ((engine as ISourceIntervalEnvironment)?.IntervalArithmetic ?? SingleIntervalArithmetic.Shared)
                .OnInterval(TimeActive, engine.DeltaTime, interval);

        public bool OnInterval(float interval, float offset, ISourceEngineContext engine)
            => ((engine as ISourceIntervalEnvironment)?.IntervalArithmetic ?? SingleIntervalArithmetic.Shared)
                .OnInterval(TimeActive, engine.DeltaTime, interval, offset);

        public bool OnRawInterval(float interval, ISourceEngineContext engine)
            => (int)((RawTimeActive - engine.RawDeltaTime) / interval) < (int)(RawTimeActive / interval);

        public bool OnRawInterval(float interval, float offset, ISourceEngineContext engine)
            => Math.Floor((RawTimeActive - offset - engine.RawDeltaTime) / interval)
               < Math.Floor((RawTimeActive - offset) / interval);
    }
}
