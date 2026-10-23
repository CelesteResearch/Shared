using Celeste.Core.Scheduling;
using Celeste.Simulation.UI.Menus.Text;
using Celeste.Game.Menus.Options;

namespace Celeste.Game.Menus.Controls
{
    public interface IOriginalControlConfigEnvironment
    {
        IOriginalControlConfigFactory ControlConfigs { get; }
    }
}
