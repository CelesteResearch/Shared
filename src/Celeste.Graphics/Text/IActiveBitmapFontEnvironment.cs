using Celeste.Graphics.Text.BitmapFonts;

namespace Celeste.Graphics.Text
{
    public interface IActiveBitmapFontEnvironment
    {
        SourcePixelFont Font { get; }
        float BaseSize { get; }
    }
}
