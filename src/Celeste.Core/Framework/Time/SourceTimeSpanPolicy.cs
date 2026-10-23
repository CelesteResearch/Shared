using System;

namespace Celeste.Core.Framework.Time
{
    public abstract class SourceTimeSpanPolicy : ISourceTimeSpanPolicy
    {
        protected abstract string CannotBeNaNMessage { get; }
        protected abstract string OverflowMessage { get; }

        private TimeSpan Interval(double value, int scale)
        {
            if (double.IsNaN(value)) throw new ArgumentException(CannotBeNaNMessage);
            double product = value * (double)scale;
            double rounded = product + (value >= 0.0 ? 0.5 : -0.5);
            if (rounded > 922337203685477.0 || rounded < -922337203685477.0)
                throw new OverflowException(OverflowMessage);
            return new TimeSpan(unchecked((long)rounded * 10000));
        }

        public TimeSpan FromMilliseconds(double value) => Interval(value, 1);
        public TimeSpan FromSeconds(double value) => Interval(value, 1000);
        public TimeSpan FromMinutes(double value) => Interval(value, 60000);
        public TimeSpan FromHours(double value) => Interval(value, 3600000);
        public TimeSpan FromDays(double value) => Interval(value, 86400000);
    }
}
