using System.Xml;

namespace Celeste.Graphics.Text.BitmapFonts
{
    public interface ISourcePixelFontSizeObservationEnvironment
    {
        void AfterSourceFontSizeAdded(SourcePixelFontSize size, XmlElement data);
    }
}
