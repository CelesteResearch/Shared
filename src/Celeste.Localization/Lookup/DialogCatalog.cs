using System;
using System.Collections.Generic;

namespace Celeste.Localization.Lookup
{
    // Independent catalogs replace the original process-wide Dialog globals so a
    // preview can use another language without changing the running room's choice.
    public sealed class DialogCatalog
    {
        public global::Celeste.Localization.Lookup.DialogLookupPolicy LookupPolicy { get; }
        public global::Celeste.Localization.Languages.DialogLanguage FallbackLanguage;
        public global::Celeste.Localization.Languages.DialogLanguage Language;

        public DialogCatalog(global::Celeste.Localization.Lookup.DialogLookupPolicy lookupPolicy)
        {
            LookupPolicy = lookupPolicy ?? throw new ArgumentNullException(nameof(lookupPolicy));
        }

        public Dictionary<string, global::Celeste.Localization.Languages.DialogLanguage> Languages =
            new Dictionary<string, global::Celeste.Localization.Languages.DialogLanguage>();

        public List<global::Celeste.Localization.Languages.DialogLanguage> OrderedLanguages;

        public void Unload()
        {
            Languages.Clear();
            Language = null;
            FallbackLanguage = null;
            OrderedLanguages.Clear();
            OrderedLanguages = null;
        }

        public bool Has(string name, global::Celeste.Localization.Languages.DialogLanguage language = null)
        {
            if (string.IsNullOrEmpty(name)) return false;
            name = LookupPolicy.NormalizeKey(name);
            return (language ?? Language).Dialog.ContainsKey(name) ||
                   FallbackLanguage != null && FallbackLanguage.Dialog.ContainsKey(name);
        }

        public string Get(string name, global::Celeste.Localization.Languages.DialogLanguage language = null)
        {
            if (string.IsNullOrEmpty(name)) return "";
            name = LookupPolicy.NormalizeKey(name);
            if ((language ?? Language).Dialog.TryGetValue(name, out var value)) return value;
            return FallbackLanguage != null && FallbackLanguage.Dialog.TryGetValue(name, out value)
                ? value
                : LookupPolicy.MissingText(name, false);
        }

        public string Clean(string name, global::Celeste.Localization.Languages.DialogLanguage language = null)
        {
            if (string.IsNullOrEmpty(name)) return "";
            name = LookupPolicy.NormalizeKey(name);
            if ((language ?? Language).Cleaned.TryGetValue(name, out var value)) return value;
            return FallbackLanguage != null && FallbackLanguage.Cleaned.TryGetValue(name, out value)
                ? value
                : LookupPolicy.MissingText(name, true);
        }
    }
}
