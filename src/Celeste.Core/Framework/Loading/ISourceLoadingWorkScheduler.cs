using System;
using System.Threading.Tasks;

namespace Celeste.Core.Framework.Loading
{
    public interface ISourceLoadingWorkScheduler
    {
        Task Schedule(Action work, Action<Exception> preparationFailed, string name, bool highPriority);
        void Pump();
    }
}
