using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Game.Gameplay.Enemies.Seekers;
using Celeste.Formats.Map.Entities.Structure;

namespace Celeste.Everest.Gameplay.Enemies.Seekers
{
    public sealed class EverestSeekerFactory : IOriginalSeekerFactory
    {
        private readonly EverestSeekerEvents events;

        public EverestSeekerFactory(EverestSeekerEvents events)
        {
            this.events = events;
        }

        public OriginalSeekerState Create(EntityData data, Vector2 offset, IOriginalSeekerProcess engine)
            => new EverestSeekerState(data, offset, engine);

        public OriginalSeekerState Create(Vector2 position, Vector2[] patrolPoints, IOriginalSeekerProcess engine)
            => new EverestSeekerState(position, patrolPoints, engine);

        public void AfterOriginalConstructor(OriginalSeekerState seeker, SimulationStateMachine machine)
        {
            var state = (ISourceNamedStateMachine)machine;
            state.SetStateName(0, "Idle");
            state.SetStateName(1, "Patrol");
            state.SetStateName(2, "Spotted");
            state.SetStateName(3, "Attack");
            state.SetStateName(4, "Stunned");
            state.SetStateName(5, "Skidding");
            state.SetStateName(6, "Regenerate");
            state.SetStateName(7, "Returned");
            events.RegisterStates((EverestSeekerState)seeker);
        }
    }
}
