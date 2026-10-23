namespace Celeste.Core.Timing
{
    // Monocle.Scene.OnRawInterval uses the scene's raw clock, regardless of TimeRate.
    public static class IntervalQueries
    {
        public static bool BetweenInterval(float value, float interval)
            => value % (interval * 2f) > interval;

        public static bool OnInterval(float value, float previousValue, float interval)
            => (int)(previousValue / interval) != (int)(value / interval);

        public static bool OnRawInterval(float rawTimeActive, float rawDeltaTime, float interval)
            => (int)((rawTimeActive - rawDeltaTime) / interval) <
               (int)(rawTimeActive / interval);
    }
}
