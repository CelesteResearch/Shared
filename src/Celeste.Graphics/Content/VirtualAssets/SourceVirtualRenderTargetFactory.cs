using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Graphics.Content.VirtualAssets
{
    public sealed class SourceVirtualRenderTargetFactory : ISourceVirtualRenderTargetFactory
    {
        private readonly ISourceGraphicsDeviceEnvironment graphics;

        public SourceVirtualRenderTargetFactory(ISourceGraphicsDeviceEnvironment graphics)
            => this.graphics = graphics;

        public SourceRenderTarget2DResource CreateRenderTarget(string name, int width, int height,
            int multiSampleCount, bool depth, bool preserve)
            => new SourceRenderTarget2DResource(graphics.GraphicsDevice, width, height, false,
                SourceSurfaceFormat.Color, depth ? SourceDepthFormat.Depth24Stencil8 : SourceDepthFormat.None,
                multiSampleCount,
                preserve ? SourceRenderTargetUsage.PreserveContents : SourceRenderTargetUsage.DiscardContents);
    }
}
