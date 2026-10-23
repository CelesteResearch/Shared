using System;

namespace Celeste.Everest.Settings.Metadata
{
    /// <summary>
    ///     Allows setting the minimum length of a string setting.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class SettingMinLengthAttribute : Attribute
    {
        public int Min;

        // ReSharper disable once ConvertToPrimaryConstructor
        public SettingMinLengthAttribute(int min)
        {
            Min = min;
        }
    }
}
