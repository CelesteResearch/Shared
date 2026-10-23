using System.Collections.Generic;
using System.IO;
using Celeste.Core.IO.Content;
using Celeste.Localization.Lookup;

namespace Celeste.Game.Content.Dialogs
{
    public sealed class OriginalDialogLoadingPolicy : IOriginalDialogLoadingPolicy
    {
        public static OriginalDialogLoadingPolicy Shared { get; } = new();

        private readonly IContentSource files;

        public OriginalDialogLoadingPolicy(IContentSource files = null)
        {
            this.files = files;
        }

        public IEnumerable<string> GetLanguageFiles(string dialogDirectory)
        {
            if (files == null) return Directory.GetFiles(dialogDirectory, "*.txt", SearchOption.AllDirectories);
            var selected = new List<string>();
            foreach (var path in files.GetFiles(dialogDirectory, SearchOption.AllDirectories))
                if (Path.GetExtension(path) == ".txt")
                    selected.Add(path);
            return selected;
        }

        public void LoadLanguage(DialogCatalog catalog, string filename, IOriginalLanguageTextureFactory textures)
        {
            OriginalDialogLoader.LoadLanguage(catalog, filename, textures, files);
        }

        public void PostLoad(DialogCatalog catalog)
        {
        }
    }
}
