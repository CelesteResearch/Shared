using Celeste.Core.Scheduling;

namespace Celeste.Simulation.Gameplay.Enemies.Seeker
{
    public interface ISourceSeekerBarrierBehavior
    {
        bool ReadMapStaticMovers { get; }
        bool IsVisible(ISourceEngineContext engine, SeekerBarrierState barrier);
    }
}
