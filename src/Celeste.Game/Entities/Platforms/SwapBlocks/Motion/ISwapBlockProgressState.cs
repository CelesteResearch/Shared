using Celeste.Core.Scheduling;

namespace Celeste.Game.Entities.Platforms.SwapBlocks.Motion
{
    public interface ISwapBlockProgressState
    {
        ISourceEngineContext Engine { get; }
        float MaxForwardSpeed { get; }
        float MaxBackwardSpeed { get; }
        ref int Target { get; }
        ref float Lerp { get; }
        ref float Speed { get; }
    }
}
