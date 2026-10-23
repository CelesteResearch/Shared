using Celeste.Game.Controls.Source;

namespace Celeste.Game.Input.Gui
{
    public interface IOriginalInputGuiProcess : Celeste.Input.Gameplay.ISourceGameInputEnvironment
    {
        OriginalGameInputProcess InputGui { get; }
    }
}
