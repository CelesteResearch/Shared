using System;
using System.Threading;

namespace Celeste.Core.Scheduling
{
    // The destination consumes the same data and session exactly once.
    public sealed class LevelLoaderSession<TData, TSession>
        where TData : class where TSession : class
    {
        private readonly ILevelLoaderData<TData, TSession> _data;
        private readonly TData _identity;
        private readonly TSession _session;
        private int _consumed;

        private LevelLoaderSession(ILevelLoaderData<TData, TSession> data, TSession session)
        {
            _data = data;
            _identity = data.Identity;
            _session = session;
        }

        public bool IsConsumed => Volatile.Read(ref _consumed) != 0;

        public static LevelLoaderSession<TData, TSession> Begin(ILevelLoaderData<TData, TSession> data,
            TSession session)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));
            if (session == null) throw new ArgumentNullException(nameof(session));
            data.Validate(session);
            data.Commit(session);
            return new(data, session);
        }

        public void Consume(TData dataIdentity, TSession candidate)
        {
            if (!ReferenceEquals(dataIdentity, _identity) || !ReferenceEquals(candidate, _session)
                                                          || !_data.IsCurrent(candidate))
                throw new ArgumentException("The Level must consume the exact file/session committed by its loader.");
            if (Interlocked.CompareExchange(ref _consumed, 1, 0) != 0)
                throw new InvalidOperationException("The loader session commit has already been consumed.");
        }
    }
}
