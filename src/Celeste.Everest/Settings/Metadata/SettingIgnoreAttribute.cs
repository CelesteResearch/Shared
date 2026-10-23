using System;

namespace Celeste.Everest.Settings.Metadata
{
    /// <summary>
    ///     Ignore the setting in the default mod options menu handler.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class SettingIgnoreAttribute : Attribute;
}
