using Celeste.Graphics.Text.BitmapFonts;

namespace Celeste.Everest.Text.BitmapFonts
{
    public sealed class SourceEverestPixelFontFactory : ISourcePixelFontFactory
    {
        public SourcePixelFont Create(string face, ISourcePixelFontProcess engine) =>
            new SourceEverestPixelFont(face, (IEverestPixelFontProcess)engine);
    }
}
