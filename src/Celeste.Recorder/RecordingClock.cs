using System;

namespace Celeste.Recorder
{
    public sealed class RecordingClock
    {
        private long elapsed;

        public void Reset()
        {
            elapsed = 0;
        }

        public int TakeFrameTicks(int framesPerSecond, float speed = 1f)
        {
            if (framesPerSecond < 1) throw new ArgumentOutOfRangeException(nameof(framesPerSecond));
            var duration = framesPerSecond == 60 ? 166667
                : framesPerSecond == 30 ? 333334
                : framesPerSecond == 24 ? 416667
                : (long)((double)(1f / framesPerSecond) * TimeSpan.TicksPerSecond);
            // Installed TAS Recorder targets modern .NET TimeSpan multiplication. Spell out its
            // ticks arithmetic so Unity's older TimeSpan.FromSeconds millisecond rounding cannot
            // change the same portable assembly's sequence of 60 Hz engine updates.
            elapsed += checked((long)Math.Round(duration * (double)speed));
            var count = checked((int)(elapsed / 166667));
            elapsed %= 166667;
            return count;
        }
    }
}
