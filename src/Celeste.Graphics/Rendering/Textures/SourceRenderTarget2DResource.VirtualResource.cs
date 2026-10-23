using Celeste.Graphics.Content.VirtualAssets;

namespace Celeste.Graphics.Rendering.Textures
{
    public partial class SourceRenderTarget2DResource : ISourceVirtualRenderTargetResource
    {
        bool ISourceVirtualRenderTargetResource.IsGraphicsDeviceDisposed => GraphicsDevice.IsDisposed;
        object ISourceVirtualRenderTargetResource.NativeTarget => this;
    }
}
