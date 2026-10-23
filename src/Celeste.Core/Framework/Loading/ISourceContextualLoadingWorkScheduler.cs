using System;
using System.Threading.Tasks;

namespace Celeste.Core.Framework.Loading
{
    public interface ISourceContextualLoadingWorkScheduler : ISourceLoadingWorkScheduler
    {
        bool SourceUpdatesBlocked { get; }
        Task Schedule(Action work, Action<Exception> preparationFailed, SourceLoadingWorkInfo info, bool highPriority);
    }
}
