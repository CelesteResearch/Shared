using System;
using System.Reflection;

namespace Celeste.Everest.Modules.Runtime.Assemblies
{
    public interface ISourceEverestAssemblyLifecycle
    {
        bool CodeReload { get; }
        string PathCache { get; }
        void UnloadAssembly(EverestModuleMetadata metadata, Assembly assembly);
        void ReloadMod(EverestModuleMetadata metadata);
        void CriticalFailureHandler(Exception exception);
    }
}
