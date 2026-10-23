using System.IO;

namespace Celeste.Graphics.Content.Textures
{
    public interface ISourceTexturePngWriter
    {
        void SaveAsPng(ISourceDataTextureResource texture, Stream stream, int width, int height);
    }
}
