using System;

namespace Celeste.Core.Framework.Time
{
    public interface ISourceTimeSpanPolicy
    {
        TimeSpan FromMilliseconds(double value);
        TimeSpan FromSeconds(double value);
        TimeSpan FromMinutes(double value);
        TimeSpan FromHours(double value);
        TimeSpan FromDays(double value);
    }
}
