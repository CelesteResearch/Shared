using Celeste.Core.Scheduling;
using Celeste.Simulation.Gameplay.Enemies.Seeker;
using Celeste.Everest.Gameplay.Visibility;

namespace Celeste.Everest.Gameplay.Enemies.Seekers
{
    public sealed class EverestSeekerBarrierBehavior : ISourceSeekerBarrierBehavior
    {
        public bool ReadMapStaticMovers => true;

        public bool IsVisible(ISourceEngineContext engine, SeekerBarrierState barrier)
            => EverestCullHelper.IsRectangleVisible(engine, barrier.Position.X, barrier.Position.Y, barrier.Width,
                barrier.Height);
    }
}
