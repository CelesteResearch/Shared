using Celeste.Game.Settings;

namespace Celeste.Game.Content.Dialogs
{
    public sealed partial class OriginalGameTextProcess
    {
        public void ApplyLanguage(SettingsState settings)
        {
            if (!Dialog.Languages.ContainsKey(settings.LanguageId))
                settings.LanguageId = "english";
            Dialog.Language = Dialog.Languages[settings.LanguageId];
            Fonts.Load(Dialog.Languages[settings.LanguageId].FontFace);
        }
    }
}
