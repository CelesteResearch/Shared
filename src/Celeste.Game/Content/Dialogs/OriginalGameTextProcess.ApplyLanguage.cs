using Celeste.Game.Settings;

namespace Celeste.Game.Content.Dialogs
{
    public sealed partial class OriginalGameTextProcess
    {
        public void ApplyLanguage(SettingsState settings)
        {
            if (!dialog.Languages.ContainsKey(settings.LanguageId))
                settings.LanguageId = "english";
            dialog.Language = dialog.Languages[settings.LanguageId];
            Fonts.Load(dialog.Languages[settings.LanguageId].FontFace);
        }
    }
}
