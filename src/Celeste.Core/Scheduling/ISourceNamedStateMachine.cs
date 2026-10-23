using System;
using System.Collections;

namespace Celeste.Core.Scheduling
{
    public interface ISourceNamedStateMachine
    {
        int AddState(string name, Func<int> onUpdate, Func<IEnumerator> coroutine = null, Action begin = null,
            Action end = null);

        int AddState<E>(string name, Func<E, int> onUpdate, Func<E, IEnumerator> coroutine = null,
            Action<E> begin = null,
            Action<E> end = null) where E : class;

        string GetStateName(int state);
        void SetStateName(int state, string name);
        string GetCurrentStateName();
    }
}
