namespace Celeste.Graphics.Text.BitmapFonts
{
    public sealed class SourcePixelFontFactory : ISourcePixelFontFactory
    {
        public SourcePixelFont Create(string face, ISourcePixelFontProcess engine)
        {
            return new(face, engine);
        }
    }
}
