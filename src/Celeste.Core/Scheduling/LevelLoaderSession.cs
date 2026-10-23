using System;
using System.Threading;

namespace Celeste.Core.Scheduling
{
    // The destination consumes the same data and session exactly once.
    public sealed class LevelLoaderSession<TData, TSession>
        where TData : class where TSession : class
    {
        readonly ILevelLoaderData<TData, TSession> data;
        readonly TData identity;
        readonly TSession session;
        int consumed;

        LevelLoaderSession(ILevelLoaderData<TData, TSession> data, TSession session)
        {
            this.data = data;
            identity = data.Identity;
            this.session = session;
        }

        public bool IsConsumed => Volatile.Read(ref consumed) != 0;

        public static LevelLoaderSession<TData, TSession> Begin(ILevelLoaderData<TData, TSession> data,
            TSession session)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));
            if (session == null) throw new ArgumentNullException(nameof(session));
            data.Validate(session);
            data.Commit(session);
            return new LevelLoaderSession<TData, TSession>(data, session);
        }

        public void Consume(TData dataIdentity, TSession candidate)
        {
            if (!ReferenceEquals(dataIdentity, identity) || !ReferenceEquals(candidate, session)
                                                         || !data.IsCurrent(candidate))
                throw new ArgumentException("The Level must consume the exact file/session committed by its loader.");
            if (Interlocked.CompareExchange(ref consumed, 1, 0) != 0)
                throw new InvalidOperationException("The loader session commit has already been consumed.");
        }
    }
}
