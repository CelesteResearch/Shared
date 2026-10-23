using Celeste.Game.Controls.Source;
using Celeste.Input.Gameplay;

namespace Celeste.Game.Input.Gui
{
    public interface IOriginalInputGuiProcess : ISourceGameInputEnvironment
    {
        OriginalGameInputProcess InputGui { get; }
    }
}
