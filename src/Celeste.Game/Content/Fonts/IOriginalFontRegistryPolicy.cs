using Celeste.Graphics.Text.BitmapFonts;

namespace Celeste.Game.Content.Fonts
{
    public interface IOriginalFontRegistryPolicy
    {
        SourcePixelFont Load(OriginalFontRegistry registry, string face);
        void Reload(OriginalFontRegistry registry);
    }
}
