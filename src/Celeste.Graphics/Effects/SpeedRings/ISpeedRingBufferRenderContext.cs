using Celeste.Core.Rendering;

namespace Celeste.Graphics.Effects.SpeedRings
{
    public interface ISpeedRingBufferRenderContext : ISourceRenderContext
    {
        object SpeedRingsTarget { get; }
    }
}
