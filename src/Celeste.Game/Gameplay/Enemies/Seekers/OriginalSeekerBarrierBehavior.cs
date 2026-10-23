using Celeste.Core.Scheduling;
using Celeste.Simulation.Gameplay.Enemies.Seeker;

namespace Celeste.Game.Gameplay.Enemies.Seekers
{
    public sealed class OriginalSeekerBarrierBehavior : ISourceSeekerBarrierBehavior
    {
        public bool ReadMapStaticMovers => false;
        public bool IsVisible(ISourceEngineContext engine, SeekerBarrierState barrier) => true;
    }
}
