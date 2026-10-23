using Celeste.Core.Scheduling;
using Celeste.Game.Menus.Controls;
using Celeste.Game.Menus.Options;
using Celeste.Simulation.UI.Menus.Text;

namespace Celeste.Everest.UI.Controls
{
    public sealed class EverestControlConfigFactory : IOriginalControlConfigFactory
    {
        public TextMenuPresentation CreateKeyboard(ISourceEngineContext engine, MenuOptionsPresentation menuOptions)
        {
            return new EverestKeyboardConfigPresentation(engine, menuOptions);
        }

        public TextMenuPresentation
            CreateController(ISourceEngineContext engine, MenuOptionsPresentation menuOptions)
        {
            return new EverestButtonConfigPresentation(engine, menuOptions);
        }
    }
}
