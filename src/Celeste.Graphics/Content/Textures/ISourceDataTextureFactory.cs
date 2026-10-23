using Celeste.Core.Display;
using Celeste.Graphics.Rendering.Textures;
using System.IO;
using Celeste.Graphics.Display;

namespace Celeste.Graphics.Content.Textures
{
    public interface ISourceDataTextureFactory
    {
        SourceTexture2DResource CreateTexture(string name, int width, int height);
        SourceTexture2DResource CreateTexture(string name, int width, int height, PackedColor initialColor);
        SourceTexture2DResource FromStream(Stream stream);
        SourceTexture2DResource FromStream(Stream stream, bool premultiply);
        SourceTexture2DResource LoadContent(string assetName);
    }
}
