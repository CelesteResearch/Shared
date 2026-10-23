using System;

namespace Celeste.Core.Framework.Components
{
    public class SourceGameTime(TimeSpan totalGameTime, TimeSpan elapsedGameTime, bool isRunningSlowly)
    {
        public TimeSpan TotalGameTime { get; set; } = totalGameTime;
        public TimeSpan ElapsedGameTime { get; set; } = elapsedGameTime;
        public bool IsRunningSlowly { get; set; } = isRunningSlowly;

        public SourceGameTime() : this(TimeSpan.Zero, TimeSpan.Zero, false)
        {
        }

        public SourceGameTime(TimeSpan totalGameTime, TimeSpan elapsedGameTime) : this(totalGameTime, elapsedGameTime,
            false)
        {
        }
    }
}
