using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Celeste.Everest.Runtime.Threading
{
    public struct SourceMaybeAwaitable<T>
    {
        public struct MaybeAwaiter : ICriticalNotifyCompletion, INotifyCompletion
        {
            private readonly bool _IsImmediate;

            private readonly bool _IsWrapper;

            private readonly T _ImmediateVal;

            private TaskAwaiter<T>? _TaskAwaiter;

            private TaskCompletionSource<T> _CompletionSource;

            internal Func<bool> _CanGetResult;

            private TaskAwaiter<T> TaskAwaiter
            {
                get
                {
                    var valueOrDefault = _TaskAwaiter.GetValueOrDefault();
                    if (!_TaskAwaiter.HasValue)
                    {
                        valueOrDefault = CompletionSource.Task.GetAwaiter();
                        _TaskAwaiter = valueOrDefault;
                        return valueOrDefault;
                    }

                    return valueOrDefault;
                }
            }

            private TaskCompletionSource<T> CompletionSource =>
                _CompletionSource ?? (_CompletionSource = new());

            public bool IsCompleted => !_IsImmediate ? TaskAwaiter.IsCompleted : true;

            internal MaybeAwaiter(T result)
            {
                _IsWrapper = false;
                _TaskAwaiter = null;
                _CompletionSource = null;
                _CanGetResult = null;
                _IsImmediate = true;
                _ImmediateVal = result;
            }

            internal MaybeAwaiter(TaskAwaiter<T> task)
            {
                _IsImmediate = false;
                _ImmediateVal = default;
                _CompletionSource = null;
                _CanGetResult = null;
                _IsWrapper = true;
                _TaskAwaiter = task;
            }

            public T GetResult()
            {
                var canGetResult = _CanGetResult;
                if (canGetResult != null && !canGetResult())
                    throw new InvalidOperationException("Can't currently get the result of the MaybeAwaiter");

                return !_IsImmediate ? TaskAwaiter.GetResult() : _ImmediateVal;
            }

            public void SetResult(T result)
            {
                if (_IsImmediate || _IsWrapper)
                    throw new InvalidOperationException(
                        "Can't set the result of a MaybeAwaiter which doesn't expect one");

                CompletionSource.SetResult(result);
            }

            public void OnCompleted(Action continuation)
            {
                if (_IsImmediate)
                    continuation();
                else
                    TaskAwaiter.OnCompleted(continuation);
            }

            public void UnsafeOnCompleted(Action continuation)
            {
                if (_IsImmediate)
                    continuation();
                else
                    TaskAwaiter.UnsafeOnCompleted(continuation);
            }
        }

        private MaybeAwaiter _Awaiter;

        public readonly bool IsValid;

        public SourceMaybeAwaitable(T result)
        {
            IsValid = false;
            _Awaiter = new(result);
        }

        public SourceMaybeAwaitable(TaskAwaiter<T> task)
        {
            IsValid = false;
            _Awaiter = new(task);
        }

        public SourceMaybeAwaitable(Func<bool> canGetResult)
        {
            _Awaiter = default;
            IsValid = false;
            _Awaiter._CanGetResult = canGetResult;
        }

        public SourceMaybeAwaitable(TaskAwaiter<T> task, Func<bool> canGetResult)
        {
            IsValid = false;
            _Awaiter = new(task)
            {
                _CanGetResult = canGetResult,
            };
        }

        internal SourceMaybeAwaitable(ValueTask<T> task)
        {
            IsValid = false;
            if (task.IsCompletedSuccessfully)
                _Awaiter = new(task.Result);
            else
                _Awaiter = new(task.AsTask().GetAwaiter());
        }

        public MaybeAwaiter GetAwaiter()
        {
            return _Awaiter;
        }

        public T GetResult()
        {
            return _Awaiter.GetResult();
        }

        public void SetResult(T result)
        {
            _Awaiter.SetResult(result);
        }
    }
}
