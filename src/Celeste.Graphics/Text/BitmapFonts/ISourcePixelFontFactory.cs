namespace Celeste.Graphics.Text.BitmapFonts
{
    public interface ISourcePixelFontFactory
    {
        SourcePixelFont Create(string face, ISourcePixelFontProcess engine);
    }
}
