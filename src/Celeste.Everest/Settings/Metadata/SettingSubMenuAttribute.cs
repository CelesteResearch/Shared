using System;

namespace Celeste.Everest.Settings.Metadata
{
    /// <summary>
    ///       When used as a <see cref="T:Celeste.Mod.EverestModuleSettings" /> property type, create a submenu based on this type.
    ///       </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class SettingSubMenuAttribute : Attribute
    {
    }
}
