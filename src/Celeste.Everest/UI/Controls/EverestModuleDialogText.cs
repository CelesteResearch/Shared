using Celeste.Core.Scheduling;
using Celeste.Game.Content.Dialogs;

namespace Celeste.Everest.UI.Controls
{
    public static class EverestModuleDialogText
    {
        public static string CleanOrNull(ISourceEngineContext engine, string input)
        {
            return ((IOriginalGameTextEnvironment)engine).Text.Dialog.Has(input)
                ? ((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean(input)
                : null;
        }
    }
}
