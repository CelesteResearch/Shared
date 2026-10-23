using System;

namespace Celeste.Core.Scheduling
{
    public sealed class SourceEngineTimingState
    {
        private TimeSpan targetElapsedTime;
        private TimeSpan inactiveSleepTime;
        public bool IsFixedTimeStep { get; set; }

        public TimeSpan TargetElapsedTime
        {
            get => targetElapsedTime;
            set
            {
                if (value <= TimeSpan.Zero)
                    throw new ArgumentOutOfRangeException("The time must be positive and non-zero.", (Exception)null);
                targetElapsedTime = value;
            }
        }

        public TimeSpan InactiveSleepTime
        {
            get => inactiveSleepTime;
            set
            {
                if (value < TimeSpan.Zero)
                    throw new ArgumentOutOfRangeException("The time must be positive.", (Exception)null);
                if (inactiveSleepTime != value) inactiveSleepTime = value;
            }
        }

        private SourceEngineTimingState()
        {
        }

        public static SourceEngineTimingState CreateUninitialized() => new SourceEngineTimingState();

        public SourceEngineTimingState(TimeSpan targetElapsedTime)
        {
            inactiveSleepTime = TimeSpan.FromTicks(200000);
            IsFixedTimeStep = true;
            TargetElapsedTime = targetElapsedTime;
        }
    }
}
