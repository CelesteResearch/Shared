using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Serialization.Xml;
using Celeste.Graphics.Content.VirtualAssets;

namespace Celeste.Graphics.Text.BitmapFonts
{
    public interface ISourcePixelFontProcess : ISourceExtremaEnvironment, ISourceXmlDocumentLoadingEnvironment
    {
        string ContentDirectory { get; }
        VirtualContent VirtualContent { get; }
    }
}
