using Celeste.Input.Bindings;
using Celeste.Game.Controls.Source;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Game.Input.Gui
{
    public interface IOriginalInputGuiPolicy
    {
        string GuiInputPrefix(OriginalGameInputProcess input, OriginalGameInputProcess.PrefixMode mode);

        AtlasEntry GuiButton(OriginalGameInputProcess input, SourceVirtualButton button,
            OriginalGameInputProcess.PrefixMode mode, string fallback);
    }
}
