using Celeste.Core.Mathematics.Extrema;

namespace Celeste.Game.Gameplay.Collectibles.Refills
{
    public interface IRefillPresentationContext
    {
        float DeltaTime { get; }
        ISourceExtremaArithmetic ExtremaArithmetic { get; }
        bool OnInterval(object scene, float interval);
    }
}
