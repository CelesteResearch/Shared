using System;

namespace Celeste.Game.Content.Dialogs
{
    public sealed partial class OriginalGameTextProcess
    {
        public string Time(long ticks)
        {
            var timeSpan = TimeSpan.FromTicks(ticks);
            if ((int)timeSpan.TotalHours > 0) return (int)timeSpan.TotalHours + timeSpan.ToString("\\:mm\\:ss\\.fff");

            return timeSpan.Minutes + timeSpan.ToString("\\:ss\\.fff");
        }

        public string FileTime(long ticks)
        {
            var timeSpan = TimeSpan.FromTicks(ticks);
            if (timeSpan.TotalHours >= 1.0) return (int)timeSpan.TotalHours + timeSpan.ToString("\\:mm\\:ss\\.fff");

            return timeSpan.ToString("mm\\:ss\\.fff");
        }

        public string Deaths(int deaths)
        {
            if (deaths > 999999) return (deaths / 1000000f).ToString("0.00") + "m";

            if (deaths > 9999) return (deaths / 1000f).ToString("0.0") + "k";

            return deaths.ToString();
        }
    }
}
