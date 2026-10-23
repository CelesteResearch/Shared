using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Graphics.Content.VirtualAssets
{
    public interface ISourceVirtualRenderTargetFactory
    {
        SourceRenderTarget2DResource CreateRenderTarget(string name, int width, int height,
            int multiSampleCount, bool depth, bool preserve);
    }
}
