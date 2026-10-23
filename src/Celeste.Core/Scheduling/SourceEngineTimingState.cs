using System;

namespace Celeste.Core.Scheduling
{
    public sealed class SourceEngineTimingState
    {
        private TimeSpan _targetElapsedTime;
        private TimeSpan _inactiveSleepTime;
        public bool IsFixedTimeStep { get; set; }

        public TimeSpan TargetElapsedTime
        {
            get => _targetElapsedTime;
            set
            {
                if (value <= TimeSpan.Zero)
                    throw new ArgumentOutOfRangeException("The time must be positive and non-zero.", (Exception)null);
                _targetElapsedTime = value;
            }
        }

        public TimeSpan InactiveSleepTime
        {
            get => _inactiveSleepTime;
            set
            {
                if (value < TimeSpan.Zero)
                    throw new ArgumentOutOfRangeException("The time must be positive.", (Exception)null);
                if (_inactiveSleepTime != value) _inactiveSleepTime = value;
            }
        }

        private SourceEngineTimingState()
        {
        }

        public static SourceEngineTimingState CreateUninitialized()
        {
            return new();
        }

        public SourceEngineTimingState(TimeSpan targetElapsedTime)
        {
            _inactiveSleepTime = TimeSpan.FromTicks(200000);
            IsFixedTimeStep = true;
            TargetElapsedTime = targetElapsedTime;
        }
    }
}
