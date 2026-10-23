using Celeste.Core.Scheduling;
using Celeste.Game.Presentation.Effects.SpeedRings;

namespace Celeste.Game.Execution.Engine.Pooling
{
    public static class OriginalSpeedRingPoolRegistration
    {
        public static void Register(ISourceEngineContext engine)
        {
            engine.EntityPools.Register("Celeste.SpeedRing",
                () => new OriginalSpeedRingState(engine));
        }
    }
}
