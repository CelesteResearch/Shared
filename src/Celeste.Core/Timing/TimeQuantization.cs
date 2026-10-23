using System;

namespace Celeste.Core.Timing
{
    // Quantizes seconds to whole milliseconds with .NET Framework TimeSpan rounding.
    public static class TimeQuantization
    {
        public static long SecondsToMillisecondTicks(float rawDeltaTime)
        {
            double seconds = rawDeltaTime;
            if (double.IsNaN(seconds)) throw new ArgumentException("TimeSpan does not accept NaN.");
            var milliseconds = seconds * 1000d + (seconds >= 0d ? .5d : -.5d);
            if (milliseconds > 922337203685477d || milliseconds < -922337203685477d)
                throw new OverflowException("TimeSpan is too long.");
            return (long)milliseconds * 10000;
        }
    }
}
