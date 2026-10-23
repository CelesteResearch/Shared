using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;

namespace Celeste.Game.Gameplay.Enemies.Seekers
{
    public interface IOriginalSeekerFactory
    {
        OriginalSeekerState Create(EntityData data, Vector2 offset, IOriginalSeekerProcess engine);
        OriginalSeekerState Create(Vector2 position, Vector2[] patrolPoints, IOriginalSeekerProcess engine);
        void AfterOriginalConstructor(OriginalSeekerState seeker, SimulationStateMachine machine);
    }
}
