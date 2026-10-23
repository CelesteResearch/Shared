using Celeste.Everest.Content.Registry;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Graphics.Text.BitmapFonts;

namespace Celeste.Everest.Text.BitmapFonts
{
    public interface IEverestPixelFontProcess : ISourcePixelFontProcess, IEverestLoggerProcessEnvironment
    {
        EverestContentRegistry SourceContentRegistry { get; }
    }
}
