using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;

namespace Celeste.Game.Gameplay.Enemies.Seekers
{
    public sealed class OriginalSeekerFactory : IOriginalSeekerFactory
    {
        public OriginalSeekerState Create(EntityData data, Vector2 offset, IOriginalSeekerProcess engine)
            => new OriginalSeekerState(data, offset, engine);

        public OriginalSeekerState Create(Vector2 position, Vector2[] patrolPoints, IOriginalSeekerProcess engine)
            => new OriginalSeekerState(position, patrolPoints, engine);

        public void AfterOriginalConstructor(OriginalSeekerState seeker, SimulationStateMachine machine)
        {
        }
    }
}
