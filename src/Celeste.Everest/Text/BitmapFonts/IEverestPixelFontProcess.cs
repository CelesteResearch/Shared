using Celeste.Graphics.Text.BitmapFonts;
using Celeste.Everest.Content.Registry;
using Celeste.Everest.Diagnostics.Logging;

namespace Celeste.Everest.Text.BitmapFonts
{
    public interface IEverestPixelFontProcess : ISourcePixelFontProcess, IEverestLoggerProcessEnvironment
    {
        EverestContentRegistry SourceContentRegistry { get; }
    }
}
