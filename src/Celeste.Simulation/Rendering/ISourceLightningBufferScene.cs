using Celeste.Graphics.Content.VirtualAssets;

namespace Celeste.Simulation.Rendering
{
    public interface ISourceLightningBufferScene
    {
        VirtualRenderTarget LightningBuffer { get; }
    }
}
