using Celeste.Everest.Modules.Runtime;

namespace Celeste.Everest.Modules.Dependencies
{
    public sealed class EverestDependencyDecision
    {
        public EverestModuleMetadata Required { get; internal set; }

        public EverestDependencyDisposition Disposition { get; internal set; }

        public EverestModUpdateInfo Download { get; internal set; }
        public EverestModuleMetadata InstalledArchive { get; internal set; }
        public string DatabaseVersion { get; internal set; }
    }
}
