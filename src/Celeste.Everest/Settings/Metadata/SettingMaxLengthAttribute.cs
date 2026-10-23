using System;

namespace Celeste.Everest.Settings.Metadata
{
    /// <summary>
    ///     Allows to set the maximum length of string settings.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class SettingMaxLengthAttribute : Attribute
    {
        public int Max;

        // ReSharper disable once ConvertToPrimaryConstructor
        public SettingMaxLengthAttribute(int max)
        {
            Max = max;
        }
    }
}
