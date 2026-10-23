using System;
using System.Collections;
using System.Reflection;
using Celeste.Core.Components;

namespace Celeste.Core.Scheduling
{
    public class SimulationStateMachine : SourceComponentState
    {
        private int state;

        protected Action[] begins;

        protected Func<int>[] updates;

        protected Action[] ends;

        protected Func<IEnumerator>[] coroutines;

        private SimulationCoroutine currentCoroutine;

        public bool ChangedStates;

        public bool Log;

        public bool Locked;

        public int PreviousState { get; private set; }

        public int State
        {
            get { return state; }
            set
            {
                if (Locked || state == value)
                {
                    return;
                }

                if (Log)
                {
                    SourceLog("Enter State " + value + " (leaving " + state + ")");
                }

                ChangedStates = true;
                PreviousState = state;
                state = value;
                if (PreviousState != -1 && ends[PreviousState] != null)
                {
                    if (Log)
                    {
                        SourceLog("Calling End " + PreviousState);
                    }

                    ends[PreviousState]();
                }

                if (begins[state] != null)
                {
                    if (Log)
                    {
                        SourceLog("Calling Begin " + state);
                    }

                    begins[state]();
                }

                if (coroutines[state] != null)
                {
                    if (Log)
                    {
                        SourceLog("Starting Coroutine " + state);
                    }

                    currentCoroutine.Replace(coroutines[state]());
                }
                else
                {
                    currentCoroutine.Cancel();
                }
            }
        }

        public SimulationStateMachine(ISourceEngineContext engine, int maxStates = 10)
            : base(active: true, visible: false)
        {
            PreviousState = (state = -1);
            begins = new Action[maxStates];
            updates = new Func<int>[maxStates];
            ends = new Action[maxStates];
            coroutines = new Func<IEnumerator>[maxStates];
            currentCoroutine = new SimulationCoroutine(engine);
            currentCoroutine.RemoveOnComplete = false;
        }

        public override void Added(object entity)
        {
            base.Added(entity);
            if (((ISourceEntityScene)Entity).Scene != null && state == -1)
            {
                State = 0;
            }
        }

        public override void EntityAdded(object scene)
        {
            base.EntityAdded(scene);
            if (state == -1)
            {
                State = 0;
            }
        }

        public void ForceState(int toState)
        {
            if (state != toState)
            {
                State = toState;
                return;
            }

            if (Log)
            {
                SourceLog("Enter State " + toState + " (leaving " + state + ")");
            }

            ChangedStates = true;
            PreviousState = state;
            state = toState;
            if (PreviousState != -1 && ends[PreviousState] != null)
            {
                if (Log)
                {
                    SourceLog("Calling End " + state);
                }

                ends[PreviousState]();
            }

            if (begins[state] != null)
            {
                if (Log)
                {
                    SourceLog("Calling Begin " + state);
                }

                begins[state]();
            }

            if (coroutines[state] != null)
            {
                if (Log)
                {
                    SourceLog("Starting Coroutine " + state);
                }

                currentCoroutine.Replace(coroutines[state]());
            }
            else
            {
                currentCoroutine.Cancel();
            }
        }

        public void SetCallbacks(int state, Func<int> onUpdate, Func<IEnumerator> coroutine = null, Action begin = null,
            Action end = null)
        {
            updates[state] = onUpdate;
            begins[state] = begin;
            ends[state] = end;
            coroutines[state] = coroutine;
        }

        public void ReflectState(object from, int index, string name)
        {
            updates[index] = (Func<int>)GetMethod<Func<int>>(from, name + "Update");
            begins[index] = (Action)GetMethod<Action>(from, name + "Begin");
            ends[index] = (Action)GetMethod<Action>(from, name + "End");
            coroutines[index] = (Func<IEnumerator>)GetMethod<Func<IEnumerator>>(from, name + "Coroutine");
        }

        public override void Update()
        {
            ChangedStates = false;
            if (updates[state] != null)
            {
                State = updates[state]();
            }

            if (currentCoroutine.Active)
            {
                currentCoroutine.Update();
                if (!ChangedStates && Log && currentCoroutine.Finished)
                {
                    SourceLog("Finished Coroutine " + state);
                }
            }
        }

        public static implicit operator int(SimulationStateMachine s)
        {
            return s.state;
        }

        public void LogAllStates()
        {
            for (int i = 0; i < updates.Length; i++)
            {
                LogState(i);
            }
        }

        public void LogState(int index)
        {
            SourceLog("State " + index + ": " + ((updates[index] != null) ? "U" : "") +
                      ((begins[index] != null) ? "B" : "") + ((ends[index] != null) ? "E" : "") +
                      ((coroutines[index] != null) ? "C" : ""));
        }

        private static Delegate GetMethod<T>(object obj, string method) where T : class
        {
            if (obj.GetType().GetMethod(method, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic) ==
                null)
                return null;
            return Delegate.CreateDelegate(typeof(T), obj, method);
        }

        private static void SourceLog(params object[] objects)
        {
            for (int i = 0; i < objects.Length; i++) _ = objects[i];
        }
    }
}
