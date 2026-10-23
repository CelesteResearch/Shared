using Celeste.Graphics.Content.Textures;
using Celeste.Core.IO.Content;

namespace Celeste.Graphics.Content.VirtualAssets
{
    public interface ISourceVirtualTextureEnvironment
    {
        string ContentDirectory { get; }
        IContentSource ContentFiles { get; }
        ISourceDataTextureFactory TextureFactory { get; }
    }
}
