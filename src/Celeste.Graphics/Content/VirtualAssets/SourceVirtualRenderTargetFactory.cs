using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Graphics.Content.VirtualAssets
{
    public sealed class SourceVirtualRenderTargetFactory(ISourceGraphicsDeviceEnvironment graphics)
        : ISourceVirtualRenderTargetFactory
    {
        private readonly ISourceGraphicsDeviceEnvironment graphics = graphics;

        public SourceRenderTarget2DResource CreateRenderTarget(string name, int width, int height, int multiSampleCount,
            bool depth, bool preserve)
        {
            return new(graphics.GraphicsDevice, width, height, false, SourceSurfaceFormat.Color,
                depth ? SourceDepthFormat.Depth24Stencil8 : SourceDepthFormat.None, multiSampleCount,
                preserve ? SourceRenderTargetUsage.PreserveContents : SourceRenderTargetUsage.DiscardContents);
        }
    }
}
