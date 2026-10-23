using System;

namespace Celeste.Game.Presentation.Formatting
{
    public static class OriginalStatsFormatter
    {
        public static string Time(long ticks)
        {
            var span = TimeSpan.FromTicks(ticks);
            return (int)span.TotalHours > 0
                ? (int)span.TotalHours + span.ToString("\\:mm\\:ss\\.fff")
                : span.Minutes + span.ToString("\\:ss\\.fff");
        }

        public static string FileTime(long ticks)
        {
            var span = TimeSpan.FromTicks(ticks);
            return span.TotalHours >= 1
                ? (int)span.TotalHours + span.ToString("\\:mm\\:ss\\.fff")
                : span.ToString("mm\\:ss\\.fff");
        }

        public static string Deaths(int deaths)
        {
            if (deaths > 999999) return ((float)deaths / 1000000f).ToString("0.00") + "m";
            if (deaths > 9999) return ((float)deaths / 1000f).ToString("0.0") + "k";
            return deaths.ToString();
        }
    }
}
