using System.Collections.Generic;
using System.IO;
using Celeste.Localization.Languages;

namespace Celeste.Game.Content.Dialogs
{
    public interface IOriginalInstalledDialogEnvironment
    {
        IOriginalInstalledDialogPolicy InstalledDialogs { get; }
    }
}
