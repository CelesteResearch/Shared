using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Effects.SpeedRings;

namespace Celeste.Game.Execution.Graphics
{
    public sealed partial class OriginalGameGraphicsResources : ISourceSpeedRingBufferResources
    {
        VirtualRenderTarget ISourceSpeedRingBufferResources.SpeedRings => Buffers.SpeedRings;
    }
}
