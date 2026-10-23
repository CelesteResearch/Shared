using Celeste.Core.IO.Content;
using Celeste.Graphics.Content.Textures;

namespace Celeste.Graphics.Content.VirtualAssets
{
    public interface ISourceVirtualTextureEnvironment
    {
        string ContentDirectory { get; }
        IContentSource ContentFiles { get; }
        ISourceDataTextureFactory TextureFactory { get; }
    }
}
