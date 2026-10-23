using System;
using System.Collections;
using Celeste.Core.Scheduling;

namespace Celeste.Core.Scheduling
{
    public class NamedSimulationStateMachine : SimulationStateMachine, ISourceNamedStateMachine
    {
        private string[] names;

        public NamedSimulationStateMachine(ISourceEngineContext engine, int maxStates = 10) : base(engine, maxStates)
        {
            names = new string[maxStates];
        }

        private int Expand()
        {
            int result = begins.Length;
            int newSize = begins.Length + 1;
            Array.Resize(ref begins, newSize);
            Array.Resize(ref updates, newSize);
            Array.Resize(ref ends, newSize);
            Array.Resize(ref coroutines, newSize);
            Array.Resize(ref names, newSize);
            return result;
        }

        public int AddState(string name, Func<int> onUpdate, Func<IEnumerator> coroutine = null,
            Action begin = null, Action end = null)
        {
            int index = Expand();
            SetCallbacks(index, onUpdate, coroutine, begin, end);
            names[index] = name;
            return index;
        }

        public int AddState<E>(string name, Func<E, int> onUpdate, Func<E, IEnumerator> coroutine = null,
            Action<E> begin = null, Action<E> end = null) where E : class
        {
            int index = Expand();
            SetCallbacks(index, () => onUpdate(Entity as E),
                coroutine == null ? null : () => coroutine(Entity as E),
                begin == null ? null : () => begin(Entity as E),
                end == null ? null : () => end(Entity as E));
            names[index] = name;
            return index;
        }

        private void CheckBounds(int state)
        {
            if (state >= begins.Length || state < 0)
                throw new IndexOutOfRangeException($"State {state} is out of range, maximum is {begins.Length}.");
        }

        public string GetStateName(int state)
        {
            CheckBounds(state);
            return (state < names.Length ? names[state] : null) ?? state.ToString();
        }

        public void SetStateName(int state, string name)
        {
            CheckBounds(state);
            if (state >= names.Length) Array.Resize(ref names, state + 1);
            names[state] = name;
        }

        public string GetCurrentStateName() => GetStateName(State);
    }
}
