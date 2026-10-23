using Celeste.Core.Rendering;
using Celeste.Graphics.Content.VirtualAssets;

namespace Celeste.Simulation.Presentation.Scene.Transitions
{
    public interface ISourceScreenWipeGraphicsContext : ISourceGraphicsContext
    {
        VirtualRenderTarget WipeTarget { get; }
    }
}
