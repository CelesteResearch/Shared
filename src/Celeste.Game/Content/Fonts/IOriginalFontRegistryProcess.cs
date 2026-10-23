using Celeste.Framework.Diagnostics.Commands;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Text.BitmapFonts;

namespace Celeste.Game.Content.Fonts
{
    public interface IOriginalFontRegistryProcess : ISourcePixelFontProcess
    {
        AtlasData GuiAtlas { get; }
        ISourcePixelFontFactory PixelFontFactory { get; }
        SourceCommands Commands { get; }
        IOriginalFontRegistryPolicy FontRegistryPolicy { get; }
        IOriginalFontRegistryContentPolicy FontRegistryContentPolicy { get; }
    }
}
