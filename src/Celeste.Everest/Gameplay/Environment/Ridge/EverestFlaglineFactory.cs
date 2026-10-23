using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Scheduling;
using Celeste.Game.Gameplay.Environment.Ridge;

namespace Celeste.Everest.Gameplay.Environment.Ridge
{
    public sealed class EverestFlaglineFactory : IOriginalFlaglineFactory
    {
        public OriginalFlaglineState Create(ISourceEngineContext engine, Vector2 to, PackedColor lineColor,
            PackedColor pinColor, PackedColor[] colors, int minFlagHeight, int maxFlagHeight,
            int minFlagLength, int maxFlagLength, int minSpace, int maxSpace)
        {
            return new EverestFlaglineState(engine, to, lineColor, pinColor, colors,
                minFlagHeight, maxFlagHeight, minFlagLength, maxFlagLength, minSpace, maxSpace);
        }
    }
}
