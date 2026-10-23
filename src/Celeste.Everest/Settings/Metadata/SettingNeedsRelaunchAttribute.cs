using System;

namespace Celeste.Everest.Settings.Metadata
{
    /// <summary>
    ///       Any options with this attribute will notify the user that a restart is required to apply the changes.
    ///       </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class SettingNeedsRelaunchAttribute : Attribute
    {
    }
}
