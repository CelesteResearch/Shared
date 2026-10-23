using Celeste.Game.Presentation.Effects.SpeedRings;
using Celeste.Graphics.Effects.SpeedRings;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ISourceSpeedRingEnvironment
    {
        ISourceSpeedRing ISourceSpeedRingEnvironment.CreateSpeedRing()
            => OriginalSpeedRingState.Create(this);
    }
}
