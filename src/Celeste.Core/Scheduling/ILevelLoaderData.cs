using System;

namespace Celeste.Core.Scheduling
{
    // A game-specific adapter validates and commits the selected session.
    // Identity is the exact save object that must cross the scene boundary.
    public interface ILevelLoaderData<TData, TSession>
        where TData : class where TSession : class
    {
        TData Identity { get; }
        void Validate(TSession session);
        void Commit(TSession session);
        bool IsCurrent(TSession session);
    }
}
