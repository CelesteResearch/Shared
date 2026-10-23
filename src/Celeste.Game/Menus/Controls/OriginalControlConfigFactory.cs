using Celeste.Core.Scheduling;
using Celeste.Simulation.UI.Menus.Text;
using Celeste.Game.Menus.Options;

namespace Celeste.Game.Menus.Controls
{
    public sealed class OriginalControlConfigFactory : IOriginalControlConfigFactory
    {
        public TextMenuPresentation CreateKeyboard(ISourceEngineContext engine, MenuOptionsPresentation menuOptions) =>
            new KeyboardConfigPresentation(engine, menuOptions);

        public TextMenuPresentation
            CreateController(ISourceEngineContext engine, MenuOptionsPresentation menuOptions) =>
            new ButtonConfigPresentation(engine, menuOptions);
    }
}
