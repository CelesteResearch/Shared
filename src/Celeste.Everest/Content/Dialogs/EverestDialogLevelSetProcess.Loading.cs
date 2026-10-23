using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Celeste.Everest.Content.Types.Dialogs;
using Celeste.Game.Content.Dialogs;
using Celeste.Localization.Lookup;

namespace Celeste.Everest.Content.Dialogs
{
    public sealed partial class EverestDialogLevelSetProcess : IOriginalDialogLoadingPolicy
    {
        public IEnumerable<string> GetLanguageFiles(string dialogDirectory)
        {
            var files = GetVanillaLanguageFileList(dialogDirectory, "*.txt", SearchOption.AllDirectories);
            List<string> modFiles;
            lock (Content.Map)
            {
                modFiles =
                [
                    .. Content.Map.Values
                        .Where(asset =>
                            asset.Type == typeof(AssetTypeDialog) || asset.Type == typeof(AssetTypeDialogExport))
                        .Select(asset => Path.ChangeExtension(asset.PathVirtual, "txt")),
                ];
            }

            foreach (var modFile in modFiles)
                if (files.All(file => !file.Equals(modFile, StringComparison.InvariantCultureIgnoreCase)))
                    files.Add(modFile);

            return (string[])
            [
                .. files.Select(file => Path.Combine(Content.PathContentOrig,
                    file.Replace('/', Path.DirectorySeparatorChar))),
            ];
        }

        void IOriginalDialogLoadingPolicy.LoadLanguage(DialogCatalog catalog, string filename,
            IOriginalLanguageTextureFactory textures)
        {
            LoadLanguage(filename);
        }

        void IOriginalDialogLoadingPolicy.PostLoad(DialogCatalog catalog)
        {
            PostLanguageLoad();
        }
    }
}
