using System;
using System.Threading;

namespace Celeste.Core.Threading
{
    public sealed class SourceThreadLocal<T>
    {
        private readonly ThreadLocal<T> storage;

        public SourceThreadLocal(Func<T> createInitialValue)
        {
            storage = new ThreadLocal<T>(createInitialValue ??
                                         throw new ArgumentNullException(nameof(createInitialValue)));
        }

        public T Value => storage.Value;
    }
}
