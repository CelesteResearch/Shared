using System;

namespace Celeste.Everest.Settings.Metadata
{
    /// <summary>
    ///       Add a description shown when the setting is selected
    ///       </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class SettingSubTextAttribute : Attribute
    {
        public string Description;

        public SettingSubTextAttribute(string description)
        {
            Description = description;
        }
    }
}
