using System;

namespace Celeste.Everest.Settings.Metadata
{
    /// <summary>
    ///       Insert a subheader before the setting.
    ///       </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class SettingSubHeaderAttribute : Attribute
    {
        public string SubHeader;

        public SettingSubHeaderAttribute(string subheader)
        {
            SubHeader = subheader;
        }
    }
}
