using Celeste.Everest.Diagnostics.Logging;

namespace Celeste.Everest.Modules.Runtime.Assemblies
{
    public interface ISourceRelinkPatcherRuntime
    {
        object CreateRelinkMapEntry(string typeName, string memberName);
        ISourceRelinkPatcher Create(EverestLoggerProcess sameLogger);
        void ConvertToNetCore(ISourceRelinkPatcher patcher, bool sharedDeps);
    }
}
