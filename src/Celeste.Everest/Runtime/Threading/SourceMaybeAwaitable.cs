using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Celeste.Everest.Runtime.Threading
{
    public struct SourceMaybeAwaitable<T>
    {
        public struct MaybeAwaiter : ICriticalNotifyCompletion, INotifyCompletion
        {
            private bool _IsImmediate;

            private bool _IsWrapper;

            private T _ImmediateVal;

            private TaskAwaiter<T>? _TaskAwaiter;

            private TaskCompletionSource<T> _CompletionSource;

            internal Func<bool> _CanGetResult;

            private TaskAwaiter<T> TaskAwaiter
            {
                get
                {
                    TaskAwaiter<T> valueOrDefault = _TaskAwaiter.GetValueOrDefault();
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
                _CompletionSource ?? (_CompletionSource = new TaskCompletionSource<T>());

            public bool IsCompleted
            {
                get
                {
                    if (!_IsImmediate)
                    {
                        return TaskAwaiter.IsCompleted;
                    }

                    return true;
                }
            }

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
                _ImmediateVal = default(T);
                _CompletionSource = null;
                _CanGetResult = null;
                _IsWrapper = true;
                _TaskAwaiter = task;
            }

            public T GetResult()
            {
                Func<bool> canGetResult = _CanGetResult;
                if (canGetResult != null && !canGetResult())
                {
                    throw new InvalidOperationException("Can't currently get the result of the MaybeAwaiter");
                }

                if (!_IsImmediate)
                {
                    return TaskAwaiter.GetResult();
                }

                return _ImmediateVal;
            }

            public void SetResult(T result)
            {
                if (_IsImmediate || _IsWrapper)
                {
                    throw new InvalidOperationException(
                        "Can't set the result of a MaybeAwaiter which doesn't expect one");
                }

                CompletionSource.SetResult(result);
            }

            public void OnCompleted(Action continuation)
            {
                if (_IsImmediate)
                {
                    continuation();
                }
                else
                {
                    TaskAwaiter.OnCompleted(continuation);
                }
            }

            public void UnsafeOnCompleted(Action continuation)
            {
                if (_IsImmediate)
                {
                    continuation();
                }
                else
                {
                    TaskAwaiter.UnsafeOnCompleted(continuation);
                }
            }
        }

        private MaybeAwaiter _Awaiter;

        public readonly bool IsValid;

        public SourceMaybeAwaitable(T result)
        {
            IsValid = false;
            _Awaiter = new MaybeAwaiter(result);
        }

        public SourceMaybeAwaitable(TaskAwaiter<T> task)
        {
            IsValid = false;
            _Awaiter = new MaybeAwaiter(task);
        }

        public SourceMaybeAwaitable(Func<bool> canGetResult)
        {
            _Awaiter = default(MaybeAwaiter);
            IsValid = false;
            _Awaiter._CanGetResult = canGetResult;
        }

        public SourceMaybeAwaitable(TaskAwaiter<T> task, Func<bool> canGetResult)
        {
            IsValid = false;
            _Awaiter = new MaybeAwaiter(task)
            {
                _CanGetResult = canGetResult
            };
        }

        internal SourceMaybeAwaitable(ValueTask<T> task)
        {
            IsValid = false;
            if (task.IsCompletedSuccessfully)
            {
                _Awaiter = new MaybeAwaiter(task.Result);
            }
            else
            {
                _Awaiter = new MaybeAwaiter(task.AsTask().GetAwaiter());
            }
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
