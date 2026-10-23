using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Simulation.Rendering;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot : ISourceLightningBufferScene
    {
        public VirtualRenderTarget LightningBuffer => Buffers.Lightning;
    }
}
