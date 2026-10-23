using Celeste.Input.Bindings;
using Celeste.Game.Controls.Source;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Game.Input.Gui
{
    public sealed class OriginalInputGuiPolicy : IOriginalInputGuiPolicy
    {
        public string GuiInputPrefix(OriginalGameInputProcess input, OriginalGameInputProcess.PrefixMode mode) =>
            input.OriginalGuiInputPrefix(mode);

        public AtlasEntry GuiButton(OriginalGameInputProcess input, SourceVirtualButton button,
            OriginalGameInputProcess.PrefixMode mode, string fallback) =>
            input.OriginalGuiButton(button, mode, fallback);
    }
}
