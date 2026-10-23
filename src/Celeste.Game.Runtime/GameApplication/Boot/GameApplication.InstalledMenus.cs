using Celeste.Game.Profiles;
using Celeste.Game.UI.Menus.Buttons;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalMenuHighlightEnvironment
    {
        public bool MenuHighlightAllowed => SourceProfile == GameProfile.Original
            ? !SettingsProcess.Instance.DisableFlashes
            : CurrentCoreSettings.AllowTextHighlight;
    }
}
