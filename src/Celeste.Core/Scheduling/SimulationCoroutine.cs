using System;
using System.Collections;
using System.Collections.Generic;
using Celeste.Core.Components;

namespace Celeste.Core.Scheduling
{
    public class SimulationCoroutine : SourceComponentState
    {
        private readonly ISourceEngineContext _engine;
        public bool RemoveOnComplete = true;

        public bool UseRawDeltaTime;

        private readonly Stack<IEnumerator> _enumerators;

        private float waitTimer;

        private bool _ended;

        public bool Finished { get; private set; }

        public SimulationCoroutine(ISourceEngineContext engine, IEnumerator functionCall, bool removeOnComplete = true)
            : base(true, false)
        {
            _engine = engine;
            _enumerators = new();
            _enumerators.Push(functionCall);
            RemoveOnComplete = removeOnComplete;
        }

        public SimulationCoroutine(ISourceEngineContext engine, bool removeOnComplete = true)
            : base(false, false)
        {
            RemoveOnComplete = removeOnComplete;
            _engine = engine;
            _enumerators = new();
        }

        public IEnumerator Current => _enumerators.Count <= 0 ? null : _enumerators.Peek();

        public void Jump()
        {
            waitTimer = 0f;
        }

        public override void Update()
        {
            if (!((ISourceCoroutineUpdateEnvironment)_engine).SourceUsesInstalledCoroutine)
            {
                OriginalUpdate();
                return;
            }

            while (true)
            {
                var current = Current;
                if (current != null && !(current is SourceSwapImmediatelyExtension.Flattened))
                {
                    _enumerators.Pop();
                    _enumerators.Push(current.SafeEnumerate());
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
            _ended = false;
            if (waitTimer > 0f)
            {
                waitTimer -= UseRawDeltaTime ? _engine.RawDeltaTime : _engine.DeltaTime;
            }
            else
            {
                if (_enumerators.Count <= 0) return;

                var enumerator = _enumerators.Peek();
                if (enumerator.MoveNext() && !_ended)
                {
                    if (enumerator.Current is int) waitTimer = (int)enumerator.Current;

                    if (enumerator.Current is float)
                        waitTimer = (float)enumerator.Current;
                    else if (enumerator.Current is IEnumerator) _enumerators.Push(enumerator.Current as IEnumerator);
                }
                else
                {
                    if (_ended) return;

                    _enumerators.Pop();
                    if (_enumerators.Count == 0)
                    {
                        Finished = true;
                        Active = false;
                        if (RemoveOnComplete) RemoveSelf();
                    }
                }
            }
        }

        public void Cancel()
        {
            Active = false;
            Finished = true;
            waitTimer = 0f;
            _enumerators.Clear();
            _ended = true;
        }

        public void Replace(IEnumerator functionCall)
        {
            Active = true;
            Finished = false;
            waitTimer = 0f;
            _enumerators.Clear();
            _enumerators.Push(functionCall);
            _ended = true;
        }
    }
}
