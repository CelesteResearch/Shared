using Celeste.Localization.Lookup;

namespace Celeste.Everest.UI.Text
{
    public static class SourceDialogTextLookup
    {
        public static string CleanOrNull(DialogCatalog dialog, string input)
        {
            return dialog.Has(input) ? dialog.Clean(input) : null;
        }
    }
}
