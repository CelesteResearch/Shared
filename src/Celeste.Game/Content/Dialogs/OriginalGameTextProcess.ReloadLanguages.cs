using System.Collections.Generic;
using System.IO;
using Celeste.Localization.Languages;

namespace Celeste.Game.Content.Dialogs
{
    public sealed partial class OriginalGameTextProcess
    {
        private IOriginalInstalledDialogPolicy InstalledDialogs =>
            ((IOriginalInstalledDialogEnvironment)sourceProcess).InstalledDialogs;

        public List<string> GetVanillaLanguageFileList(string root, string searchPattern, SearchOption searchOption)
        {
            return InstalledDialogs.GetVanillaLanguageFileList(root, searchPattern, searchOption);
        }

        public DialogLanguage LoadLanguage(string filename)
        {
            return InstalledDialogs.LoadLanguage(filename);
        }

        public void RefreshLanguages()
        {
            InstalledDialogs.RefreshLanguages();
        }
    }
}
