using System;

namespace Celeste.Everest.Settings.Metadata
{
    /// <summary>
    ///     Whether the option should be disabled in-game or in the main menu.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public class SettingInGameDisableAttribute : Attribute
    {
        public bool InGame;

        // ReSharper disable once ConvertToPrimaryConstructor
        public SettingInGameDisableAttribute(bool inGame)
        {
            InGame = inGame;
        }
    }
}
