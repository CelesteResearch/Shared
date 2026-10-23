using Celeste.Game.Menus.Title;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IMainMenuAdditionalButtonEnvironment
    {
        public MainMenuAdditionalButton? MainMenuAdditionalButton => PhysicalIO.MainMenuAdditionalButton;
    }
}
