using Celeste.Everest.Modules.Runtime;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Everest.Chapters.Flow
{
// Required reads borrow the installed process and content registry's actual module objects.
    public interface IInstalledAreaCompleteInfoProcess
    {
        string Build { get; }
        byte[] InstallationHash { get; }
        string GetModePath(ChapterCompletionSession session);
        bool TryGetMapModule(string path, out EverestModuleMetadata module);
    }
}
