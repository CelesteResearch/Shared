using System;

namespace Celeste.Everest.Settings.Metadata
{
    /// <summary>
    ///       Whether the option should be shown in-game or in the main menu only.
    ///       </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public class SettingInGameAttribute : Attribute
    {
        public bool InGame;

        public SettingInGameAttribute(bool inGame)
        {
            InGame = inGame;
        }
    }
}
