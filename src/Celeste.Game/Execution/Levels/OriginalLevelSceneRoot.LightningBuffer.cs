using Celeste.Simulation.Rendering;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot : ISourceLightningBufferScene
    {
        public global::Celeste.Graphics.Content.VirtualAssets.VirtualRenderTarget LightningBuffer => Buffers.Lightning;
    }
}
