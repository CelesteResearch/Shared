using System.Linq;

namespace Celeste.Game.Content.Dialogs
{
    public sealed class OriginalDialogLookupPolicy : global::Celeste.Localization.Lookup.DialogLookupPolicy
    {
        public static OriginalDialogLookupPolicy Shared { get; } = new OriginalDialogLookupPolicy();

        private OriginalDialogLookupPolicy()
        {
        }

        public override string NormalizeKey(string name) =>
            name.Replace('/', '_').Replace('-', '_').Replace('+', '_').Replace(' ', '_');

        private static bool ValidId(string name) => name.All(c => c <= 127 && (char.IsLetterOrDigit(c) || c == '_'));

        public override string MissingText(string normalizedName, bool cleaned)
        {
            if (cleaned)
                return ValidId(normalizedName) ? "{" + normalizedName + "}" : "<INVALID> {" + normalizedName + "}";
            return ValidId(normalizedName) ? "[" + normalizedName + "]" : "<INVALID> [" + normalizedName + "]";
        }
    }
}
