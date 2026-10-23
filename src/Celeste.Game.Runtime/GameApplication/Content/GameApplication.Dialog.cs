using Celeste.Localization.Lookup;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ISourceDialogEnvironment
    {
        public DialogCatalog Dialog => Text.Dialog;
    }
}
