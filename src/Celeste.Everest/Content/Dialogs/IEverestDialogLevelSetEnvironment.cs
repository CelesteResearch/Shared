using System;
using System.Collections.Generic;
using System.Text;
using Celeste.Core.Scheduling;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Localization.Languages;
using Celeste.Game.Content.Dialogs;

namespace Celeste.Everest.Content.Dialogs
{
    public interface IEverestDialogLevelSetEnvironment
    {
        EverestDialogLevelSetProcess DialogLevelSets { get; }
    }
}
