using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Celeste.Simulation;

namespace Celeste.Game.Content.Dialogs
{
    public static class OriginalDialogLoader
    {
        public static global::Celeste.Localization.Lookup.DialogCatalog Load(string dialogDirectory,
            string requestedLanguage, global::Celeste.Localization.Lookup.DialogLookupPolicy lookupPolicy,
            IOriginalLanguageTextureFactory textures)
        {
            var catalog = new global::Celeste.Localization.Lookup.DialogCatalog(lookupPolicy);
            LoadInto(catalog, dialogDirectory, requestedLanguage, textures, OriginalDialogLoadingPolicy.Shared);
            return catalog;
        }

        public static void LoadInto(global::Celeste.Localization.Lookup.DialogCatalog catalog,
            string dialogDirectory, string requestedLanguage, IOriginalLanguageTextureFactory textures,
            IOriginalDialogLoadingPolicy loadingPolicy)
        {
            foreach (string path in loadingPolicy.GetLanguageFiles(dialogDirectory))
                loadingPolicy.LoadLanguage(catalog, path, textures);
            if (requestedLanguage != null && catalog.Languages.ContainsKey(requestedLanguage))
                catalog.Language = catalog.Languages[requestedLanguage];
            else if (catalog.Languages.ContainsKey("english")) catalog.Language = catalog.Languages["english"];
            else
            {
                if (catalog.Languages.Count <= 0) throw new Exception("Missing Language Files");
                catalog.Language = catalog.Languages.ElementAt(0).Value;
            }

            catalog.OrderedLanguages =
                new List<global::Celeste.Localization.Languages.DialogLanguage>(catalog.Languages.Values);
            catalog.OrderedLanguages.Sort((a, b) => a.Order != b.Order ? a.Order - b.Order : a.Id.CompareTo(b.Id));
            catalog.FallbackLanguage = catalog.Languages.TryGetValue("english", out var fallback) ? fallback : null;
            loadingPolicy.PostLoad(catalog);
        }

        public static global::Celeste.Localization.Languages.DialogLanguage LoadLanguage(
            global::Celeste.Localization.Lookup.DialogCatalog catalog, string filename,
            IOriginalLanguageTextureFactory textures,
            global::Celeste.Core.IO.Content.IContentSource files = null)
        {
            global::Celeste.Localization.Languages.DialogLanguage language;
            if (files == null)
                language = File.Exists(filename + ".export")
                    ? OriginalDialogLanguageCodec.FromExport(filename + ".export", textures)
                    : OriginalDialogLanguageCodec.FromTxt(filename, textures);
            else if (files.FileExists(filename + ".export"))
                language = OriginalDialogLanguageCodec.FromExport(files.OpenTitleStream(filename + ".export"),
                    textures);
            else
                language = OriginalDialogLanguageCodec.FromTxt(files.OpenTitleStream(filename), filename, textures);
            if (language != null && string.IsNullOrEmpty(language.SourceName))
                language.SourceName = Path.GetFileName(filename);
            if (language != null)
            {
                catalog.Languages[language.Id] = language;
                if (language.Id == "english") catalog.FallbackLanguage = language;
            }

            return language;
        }
    }
}
