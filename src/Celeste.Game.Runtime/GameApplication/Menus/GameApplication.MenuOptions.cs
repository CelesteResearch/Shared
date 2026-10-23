using Celeste.Everest.UI.Menus.Options;
using Celeste.Game.Menus.Options;
using Celeste.Game.Profiles;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalMenuOptionsEnvironment, IMenuOptionsExtensionEnvironment
    {
        private MenuOptionsPresentation menuOptions;

        public IMenuOptionsExtension? MenuOptionsExtension => PhysicalIO.MenuOptionsExtension;

        public MenuOptionsPresentation MenuOptions => menuOptions ??= SourceProfile == GameProfile.Original
            ? new MenuOptionsPresentation(this)
            : new EverestMenuOptionsPresentation(this);
    }
}
