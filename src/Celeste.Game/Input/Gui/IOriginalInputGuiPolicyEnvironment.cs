using Celeste.Input.Bindings;
using Celeste.Game.Controls.Source;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Game.Input.Gui
{
    public interface IOriginalInputGuiPolicyEnvironment
    {
        IOriginalInputGuiPolicy InputGuiPolicy { get; }
    }
}
