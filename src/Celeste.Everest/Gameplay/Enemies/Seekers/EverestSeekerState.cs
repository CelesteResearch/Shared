using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Gameplay.Enemies.Seekers;

namespace Celeste.Everest.Gameplay.Enemies.Seekers
{
    public class EverestSeekerState : OriginalSeekerState
    {
        public EverestSeekerState(EntityData data, Vector2 offset, IOriginalSeekerProcess engine)
            : base(data, offset, engine)
        {
        }

        public EverestSeekerState(Vector2 position, Vector2[] patrolPoints, IOriginalSeekerProcess engine)
            : base(position, patrolPoints, engine)
        {
        }

        public int AddState(string name, Func<EverestSeekerState, int> onUpdate,
            Func<EverestSeekerState, IEnumerator> coroutine = null,
            Action<EverestSeekerState> begin = null, Action<EverestSeekerState> end = null)
        {
            return ((ISourceNamedStateMachine)CurrentStateMachine).AddState(name, onUpdate, coroutine, begin, end);
        }
    }
}
