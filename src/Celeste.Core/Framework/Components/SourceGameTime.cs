using System;

namespace Celeste.Core.Framework.Components
{
    public class SourceGameTime
    {
        public TimeSpan TotalGameTime { get; set; }
        public TimeSpan ElapsedGameTime { get; set; }
        public bool IsRunningSlowly { get; set; }

        public SourceGameTime() : this(TimeSpan.Zero, TimeSpan.Zero, false)
        {
        }

        public SourceGameTime(TimeSpan totalGameTime, TimeSpan elapsedGameTime)
            : this(totalGameTime, elapsedGameTime, false)
        {
        }

        public SourceGameTime(TimeSpan totalGameTime, TimeSpan elapsedGameTime, bool isRunningSlowly)
        {
            TotalGameTime = totalGameTime;
            ElapsedGameTime = elapsedGameTime;
            IsRunningSlowly = isRunningSlowly;
        }
    }
}
