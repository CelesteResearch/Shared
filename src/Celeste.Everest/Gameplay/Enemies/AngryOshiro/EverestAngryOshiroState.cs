using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Game.Gameplay.Enemies.AngryOshiro;

namespace Celeste.Everest.Gameplay.Enemies.AngryOshiro
{
    public sealed class EverestAngryOshiroState : OriginalAngryOshiroState
    {
        public EverestAngryOshiroState(Vector2 position, bool fromCutscene, IOriginalAngryOshiroProcess process)
            : base(position, fromCutscene, process)
        {
            var state = (ISourceNamedStateMachine)StateMachine;
            state.SetStateName(0, "Chase");
            state.SetStateName(1, "ChargeUp");
            state.SetStateName(2, "Attack");
            state.SetStateName(3, "Dummy");
            state.SetStateName(4, "Waiting");
            state.SetStateName(5, "Hurt");
            ((IOriginalAngryOshiroStateEventsEnvironment)process).AngryOshiroStateEvents.RegisterStates(this);
        }

        public int AddState(string name, Func<EverestAngryOshiroState, int> onUpdate,
            Func<EverestAngryOshiroState, IEnumerator> coroutine = null,
            Action<EverestAngryOshiroState> begin = null, Action<EverestAngryOshiroState> end = null)
            => ((ISourceNamedStateMachine)StateMachine).AddState(name, onUpdate, coroutine, begin, end);
    }
}
