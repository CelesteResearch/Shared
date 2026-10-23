using Celeste.Core.Scheduling;
using Celeste.Simulation.UI.Menus.Text;
using Celeste.Game.Menus.Options;
using Celeste.Game.Menus.Controls;

namespace Celeste.Everest.UI.Controls
{
    public sealed class EverestControlConfigFactory : IOriginalControlConfigFactory
    {
        public TextMenuPresentation CreateKeyboard(ISourceEngineContext engine, MenuOptionsPresentation menuOptions) =>
            new EverestKeyboardConfigPresentation(engine, menuOptions);

        public TextMenuPresentation
            CreateController(ISourceEngineContext engine, MenuOptionsPresentation menuOptions) =>
            new EverestButtonConfigPresentation(engine, menuOptions);
    }
}
