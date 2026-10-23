using System;
using System.Threading;

namespace Celeste.Core.Threading
{
    public sealed class SourceThreadLocal<T>
    {
        private readonly ThreadLocal<T> _storage;

        public SourceThreadLocal(Func<T> createInitialValue)
        {
            _storage = new(createInitialValue ?? throw new ArgumentNullException(nameof(createInitialValue)));
        }

        public T Value => _storage.Value;
    }
}
