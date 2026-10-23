using Celeste.Game.Controls.Source;
using Celeste.Graphics.Content.Atlas;
using Celeste.Input.Bindings;

namespace Celeste.Game.Input.Gui
{
    public sealed class OriginalInputGuiPolicy : IOriginalInputGuiPolicy
    {
        public string GuiInputPrefix(OriginalGameInputProcess input, OriginalGameInputProcess.PrefixMode mode)
        {
            return input.OriginalGuiInputPrefix(mode);
        }

        public AtlasEntry GuiButton(OriginalGameInputProcess input, SourceVirtualButton button,
            OriginalGameInputProcess.PrefixMode mode, string fallback)
        {
            return input.OriginalGuiButton(button, mode, fallback);
        }
    }
}
