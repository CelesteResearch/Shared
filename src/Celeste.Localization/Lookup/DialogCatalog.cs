using System;
using System.Collections.Generic;
using Celeste.Localization.Languages;

namespace Celeste.Localization.Lookup
{
    // Independent catalogs replace the original process-wide Dialog globals so a
    // preview can use another language without changing the running room's choice.
    public sealed class DialogCatalog
    {
        public DialogLookupPolicy LookupPolicy { get; }
        public DialogLanguage FallbackLanguage;
        public DialogLanguage Language;

        public DialogCatalog(DialogLookupPolicy lookupPolicy)
        {
            LookupPolicy = lookupPolicy ?? throw new ArgumentNullException(nameof(lookupPolicy));
        }

        public Dictionary<string, DialogLanguage> Languages = new();

        public List<DialogLanguage> OrderedLanguages;

        public void Unload()
        {
            Languages.Clear();
            Language = null;
            FallbackLanguage = null;
            OrderedLanguages.Clear();
            OrderedLanguages = null;
        }

        public bool Has(string name, DialogLanguage language = null)
        {
            if (string.IsNullOrEmpty(name)) return false;
            name = LookupPolicy.NormalizeKey(name);
            return (language ?? Language).Dialog.ContainsKey(name) ||
                   (FallbackLanguage != null && FallbackLanguage.Dialog.ContainsKey(name));
        }

        public string Get(string name, DialogLanguage language = null)
        {
            if (string.IsNullOrEmpty(name)) return "";
            name = LookupPolicy.NormalizeKey(name);
            if ((language ?? Language).Dialog.TryGetValue(name, out var value)) return value;
            return FallbackLanguage != null && FallbackLanguage.Dialog.TryGetValue(name, out value)
                ? value
                : LookupPolicy.MissingText(name, false);
        }

        public string Clean(string name, DialogLanguage language = null)
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
