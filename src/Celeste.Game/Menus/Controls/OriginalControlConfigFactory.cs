using Celeste.Core.Scheduling;
using Celeste.Game.Menus.Options;
using Celeste.Simulation.UI.Menus.Text;

namespace Celeste.Game.Menus.Controls
{
    public sealed class OriginalControlConfigFactory : IOriginalControlConfigFactory
    {
        public TextMenuPresentation CreateKeyboard(ISourceEngineContext engine, MenuOptionsPresentation menuOptions)
        {
            return new KeyboardConfigPresentation(engine, menuOptions);
        }

        public TextMenuPresentation
            CreateController(ISourceEngineContext engine, MenuOptionsPresentation menuOptions)
        {
            return new ButtonConfigPresentation(engine, menuOptions);
        }
    }
}
