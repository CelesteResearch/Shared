using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Scheduling;

namespace Celeste.Game.Gameplay.Environment.Ridge
{
    public interface IOriginalFlaglineFactory
    {
        OriginalFlaglineState Create(ISourceEngineContext engine, Vector2 to, PackedColor lineColor,
            PackedColor pinColor, PackedColor[] colors, int minFlagHeight, int maxFlagHeight,
            int minFlagLength, int maxFlagLength, int minSpace, int maxSpace);
    }
}
