using Celeste.Core.Display;
using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Display;
using Celeste.Game.Gameplay.Environment.Ridge;

namespace Celeste.Game.Gameplay.Environment.Ridge
{
    public sealed class OriginalFlaglineFactory : IOriginalFlaglineFactory
    {
        public OriginalFlaglineState Create(ISourceEngineContext engine, Vector2 to, PackedColor lineColor,
            PackedColor pinColor, PackedColor[] colors, int minFlagHeight, int maxFlagHeight,
            int minFlagLength, int maxFlagLength, int minSpace, int maxSpace)
            => new OriginalFlaglineState(engine, to, lineColor, pinColor, colors,
                minFlagHeight, maxFlagHeight, minFlagLength, maxFlagLength, minSpace, maxSpace);
    }
}
