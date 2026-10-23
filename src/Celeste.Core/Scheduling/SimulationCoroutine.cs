using Celeste.Core.Components;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Celeste.Core.Scheduling
{
    public class SimulationCoroutine : SourceComponentState
    {
        private readonly ISourceEngineContext engine;
        public bool RemoveOnComplete = true;

        public bool UseRawDeltaTime;

        private Stack<IEnumerator> enumerators;

        private float waitTimer;

        private bool ended;

        public bool Finished { get; private set; }

        public SimulationCoroutine(ISourceEngineContext engine, IEnumerator functionCall, bool removeOnComplete = true)
            : base(true, false)
        {
            this.engine = engine;
            enumerators = new Stack<IEnumerator>();
            enumerators.Push(functionCall);
            RemoveOnComplete = removeOnComplete;
        }

        public SimulationCoroutine(ISourceEngineContext engine, bool removeOnComplete = true)
            : base(false, false)
        {
            RemoveOnComplete = removeOnComplete;
            this.engine = engine;
            enumerators = new Stack<IEnumerator>();
        }

        public IEnumerator Current => enumerators.Count <= 0 ? null : enumerators.Peek();

        public void Jump()
        {
            waitTimer = 0f;
        }

        public override void Update()
        {
            if (!((ISourceCoroutineUpdateEnvironment)engine).SourceUsesInstalledCoroutine)
            {
                OriginalUpdate();
                return;
            }

            while (true)
            {
                IEnumerator current = Current;
                if (current != null && !(current is SourceSwapImmediatelyExtension.Flattened))
                {
                    enumerators.Pop();
                    enumerators.Push(current.SafeEnumerate());
                }

                OriginalUpdate();
                if (Current?.Current is Action<SimulationCoroutine> action)
                {
                    action(this);
                    continue;
                }

                break;
            }
        }

        private void OriginalUpdate()
        {
            ended = false;
            if (waitTimer > 0f)
            {
                waitTimer -= (UseRawDeltaTime ? engine.RawDeltaTime : engine.DeltaTime);
            }
            else
            {
                if (enumerators.Count <= 0)
                {
                    return;
                }

                IEnumerator enumerator = enumerators.Peek();
                if (enumerator.MoveNext() && !ended)
                {
                    if (enumerator.Current is int)
                    {
                        waitTimer = (int)enumerator.Current;
                    }

                    if (enumerator.Current is float)
                    {
                        waitTimer = (float)enumerator.Current;
                    }
                    else if (enumerator.Current is IEnumerator)
                    {
                        enumerators.Push(enumerator.Current as IEnumerator);
                    }
                }
                else
                {
                    if (ended)
                    {
                        return;
                    }

                    enumerators.Pop();
                    if (enumerators.Count == 0)
                    {
                        Finished = true;
                        Active = false;
                        if (RemoveOnComplete)
                        {
                            RemoveSelf();
                        }
                    }
                }
            }
        }

        public void Cancel()
        {
            Active = false;
            Finished = true;
            waitTimer = 0f;
            enumerators.Clear();
            ended = true;
        }

        public void Replace(IEnumerator functionCall)
        {
            Active = true;
            Finished = false;
            waitTimer = 0f;
            enumerators.Clear();
            enumerators.Push(functionCall);
            ended = true;
        }
    }
}
