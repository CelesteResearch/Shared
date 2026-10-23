using System;
using System.Collections;

namespace Celeste.Core.Scheduling
{
    public class NamedSimulationStateMachine : SimulationStateMachine, ISourceNamedStateMachine
    {
        private string[] _names;

        public NamedSimulationStateMachine(ISourceEngineContext engine, int maxStates = 10) : base(engine, maxStates)
        {
            _names = new string[maxStates];
        }

        private int Expand()
        {
            var result = begins.Length;
            var newSize = begins.Length + 1;
            Array.Resize(ref begins, newSize);
            Array.Resize(ref updates, newSize);
            Array.Resize(ref ends, newSize);
            Array.Resize(ref coroutines, newSize);
            Array.Resize(ref _names, newSize);
            return result;
        }

        public int AddState(string name, Func<int> onUpdate, Func<IEnumerator> coroutine = null, Action begin = null,
            Action end = null)
        {
            var index = Expand();
            SetCallbacks(index, onUpdate, coroutine, begin, end);
            _names[index] = name;
            return index;
        }

        public int AddState<E>(string name, Func<E, int> onUpdate, Func<E, IEnumerator> coroutine = null,
            Action<E> begin = null, Action<E> end = null)
            where E : class
        {
            var index = Expand();
            SetCallbacks(index, () => onUpdate(Entity as E), coroutine == null ? null : () => coroutine(Entity as E),
                begin == null ? null : () => begin(Entity as E), end == null ? null : () => end(Entity as E));
            _names[index] = name;
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
            return (state < _names.Length ? _names[state] : null) ?? state.ToString();
        }

        public void SetStateName(int state, string name)
        {
            CheckBounds(state);
            if (state >= _names.Length)
                Array.Resize(ref _names, state + 1);
            _names[state] = name;
        }

        public string GetCurrentStateName()
        {
            return GetStateName(State);
        }
    }
}
