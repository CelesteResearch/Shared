using System.Linq;
using Celeste.Localization.Lookup;

namespace Celeste.Game.Content.Dialogs
{
    public sealed class OriginalDialogLookupPolicy : DialogLookupPolicy
    {
        public static OriginalDialogLookupPolicy Shared { get; } = new();

        private OriginalDialogLookupPolicy()
        {
        }

        public override string NormalizeKey(string name)
        {
            return name.Replace('/', '_').Replace('-', '_').Replace('+', '_').Replace(' ', '_');
        }

        private static bool ValidId(string name)
        {
            return name.All(c => c <= 127 && (char.IsLetterOrDigit(c) || c == '_'));
        }

        public override string MissingText(string normalizedName, bool cleaned)
        {
            if (cleaned)
                return ValidId(normalizedName) ? "{" + normalizedName + "}" : "<INVALID> {" + normalizedName + "}";
            return ValidId(normalizedName) ? "[" + normalizedName + "]" : "<INVALID> [" + normalizedName + "]";
        }
    }
}
