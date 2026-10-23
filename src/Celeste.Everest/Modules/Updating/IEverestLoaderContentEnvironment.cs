using Celeste.Everest.Content.Registry;
using Celeste.Everest.Tasks.Queuing;

namespace Celeste.Everest.Modules.Updating
{
    public interface IEverestLoaderContentEnvironment
    {
        IEverestContentDiagnostics ContentDiagnostics { get; }
        QueuedTaskScheduler QueuedTasks { get; }
    }
}
