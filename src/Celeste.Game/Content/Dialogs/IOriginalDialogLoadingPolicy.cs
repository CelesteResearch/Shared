using System.Collections.Generic;
using Celeste.Localization.Lookup;

namespace Celeste.Game.Content.Dialogs
{
    public interface IOriginalDialogLoadingPolicy
    {
        IEnumerable<string> GetLanguageFiles(string dialogDirectory);
        void LoadLanguage(DialogCatalog catalog, string filename, IOriginalLanguageTextureFactory textures);
        void PostLoad(DialogCatalog catalog);
    }
}
