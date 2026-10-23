using System;

namespace Celeste.Everest.Settings.Metadata
{
    /// <summary>
    ///     The dialog key / name for the settings option.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public class SettingNameAttribute : Attribute
    {
        public string Name;

        // ReSharper disable once ConvertToPrimaryConstructor
        public SettingNameAttribute(string name)
        {
            Name = name;
        }
    }
}
