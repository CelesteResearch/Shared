using System.Collections.Generic;
using System.IO;
using Celeste.Localization.Languages;

namespace Celeste.Game.Content.Dialogs
{
    public interface IOriginalInstalledDialogPolicy
    {
        List<string> GetVanillaLanguageFileList(string root, string searchPattern, SearchOption searchOption);
        DialogLanguage LoadLanguage(string filename);
        void RefreshLanguages();
    }
}
