using Celeste.Localization.Lookup;
using Celeste.Game.Content.Dialogs;

namespace Celeste.Everest.UI.Text
{
    public static class SourceDialogTextLookup
    {
        public static string CleanOrNull(DialogCatalog dialog, string input)
        {
            if (dialog.Has(input)) return dialog.Clean(input);
            return null;
        }
    }
}
