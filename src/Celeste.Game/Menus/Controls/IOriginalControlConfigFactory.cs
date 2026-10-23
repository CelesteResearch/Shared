using Celeste.Core.Scheduling;
using Celeste.Game.Menus.Options;
using Celeste.Simulation.UI.Menus.Text;

namespace Celeste.Game.Menus.Controls
{
    public interface IOriginalControlConfigFactory
    {
        TextMenuPresentation CreateKeyboard(ISourceEngineContext engine, MenuOptionsPresentation menuOptions);
        TextMenuPresentation CreateController(ISourceEngineContext engine, MenuOptionsPresentation menuOptions);
    }
}
