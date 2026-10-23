using System;

namespace Celeste.Everest.Settings.Metadata
{
    /// <summary>
    ///       Shows a button that will open a number input screen. Supported on int and float properties.
    ///       </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class SettingNumberInputAttribute : Attribute
    {
        public int MaxLength;

        public bool AllowNegatives;

        public SettingNumberInputAttribute(bool allowNegatives = true, int maxLength = 6)
        {
            AllowNegatives = allowNegatives;
            MaxLength = maxLength;
        }
    }
}
