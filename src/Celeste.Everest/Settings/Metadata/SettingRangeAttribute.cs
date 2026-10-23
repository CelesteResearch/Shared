using System;

namespace Celeste.Everest.Settings.Metadata
{
    /// <summary>
    ///       The integer option range.
    ///       If largeRange is set to true, a slider optimized for large integer ranges (going through values at an increasing speed) will be used.
    ///       </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class SettingRangeAttribute : Attribute
    {
        public int Min;

        public int Max;

        public bool LargeRange;

        public SettingRangeAttribute(int min, int max)
        {
            Min = min;
            Max = max;
            LargeRange = false;
        }

        public SettingRangeAttribute(int min, int max, bool largeRange)
            : this(min, max)
        {
            LargeRange = largeRange;
        }
    }
}
