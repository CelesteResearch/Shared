namespace Celeste.Game.Settings
{
    /// <summary>
    ///     The settings half of <c>Celeste.Settings.Instance</c> that a cheat has to be able to write.
    ///     The original writes the global Settings singleton (UnlockEverythingThingy.cs:40-41); this
    ///     repo keeps those flags on the menu settings object that is serialized with the save directory
    ///     and handed to the overworld (Assets/Runtime/OverworldPresentation.FileSelect.cs:126-150).
    /// </summary>
    public interface IMenuSettingsFlags
    {
        /// <summary>Celeste/Settings.cs:56 <c>VariantsUnlocked</c>.</summary>
        bool VariantsUnlocked { get; set; }

        /// <summary>Celeste/Settings.cs:52 <c>Pico8OnMainMenu</c> - makes OuiMainMenu add menu_pico8 (OuiMainMenu.cs:51).</summary>
        bool Pico8OnMainMenu { get; set; }
    }
}
