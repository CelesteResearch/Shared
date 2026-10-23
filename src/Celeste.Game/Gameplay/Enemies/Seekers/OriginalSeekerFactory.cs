using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;

namespace Celeste.Game.Gameplay.Enemies.Seekers
{
    public sealed class OriginalSeekerFactory : IOriginalSeekerFactory
    {
        public OriginalSeekerState Create(EntityData data, Vector2 offset, IOriginalSeekerProcess engine)
        {
            return new(data, offset, engine);
        }

        public OriginalSeekerState Create(Vector2 position, Vector2[] patrolPoints, IOriginalSeekerProcess engine)
        {
            return new(position, patrolPoints, engine);
        }

        public void AfterOriginalConstructor(OriginalSeekerState seeker, SimulationStateMachine machine)
        {
        }
    }
}
