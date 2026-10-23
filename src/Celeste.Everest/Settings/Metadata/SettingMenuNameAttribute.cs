using System;

namespace Celeste.Everest.Settings.Metadata
{
    /// <summary>
    ///     The type name used to form default mod menu dialog keys, independently of CLR identity.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum, Inherited = false)]
    public sealed class SettingMenuNameAttribute : Attribute
    {
        public string Name { get; }

        // ReSharper disable once ConvertToPrimaryConstructor
        public SettingMenuNameAttribute(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}
