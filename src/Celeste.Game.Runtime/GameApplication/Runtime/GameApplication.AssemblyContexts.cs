using System;
using System.IO;
using System.Reflection;
using Celeste.Everest.Modules.Runtime;
using Celeste.Everest.Modules.Runtime.Assemblies;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ISourceEverestAssemblyProcessEnvironment,
        ISourceEverestRelinkerEnvironment, ISourceAssemblyRuntimeEnvironment, ISourceEverestAssemblyLifecycle
    {
        private SourceEverestAssemblyContextProcess sourceAssemblyContexts;
        private ISourceAssemblyRuntime sourceDynamicAssemblyRuntime;
        private ISourceRelinkPatcherRuntime sourceRelinkPatcherRuntime;
        private string sourceOriginalGamePePath;

        public SourceEverestAssemblyContextProcess AssemblyContexts => sourceAssemblyContexts ??
                                                                       throw new InvalidOperationException(
                                                                           "The actual source assembly-context process is not constructed.");

        internal void ConstructSourceInstalledAssemblyContexts()
        {
            if (sourceAssemblyContexts != null)
                throw new InvalidOperationException(
                    "The actual source assembly-context process is already constructed.");
            sourceDynamicAssemblyRuntime ??= new SourcePortableAssemblyRuntime(
                typeof(SourceEverestModule).Assembly);
            var relinker = new SourceEverestAssemblyRelinker(this);
            sourceAssemblyContexts = new SourceEverestAssemblyContextProcess(this, relinker, this);
        }

        public void BindSourceDynamicAssemblyRuntime(ISourceAssemblyRuntime actualRuntime)
        {
            if (actualRuntime == null) throw new ArgumentNullException(nameof(actualRuntime));
            if (sourceDynamicAssemblyRuntime != null)
                throw new InvalidOperationException("The actual dynamic assembly runtime is already bound.");
            sourceDynamicAssemblyRuntime = actualRuntime;
        }

        public void BindSourceRelinkPatcherRuntime(ISourceRelinkPatcherRuntime actualRuntime)
        {
            if (actualRuntime == null) throw new ArgumentNullException(nameof(actualRuntime));
            if (sourceRelinkPatcherRuntime != null)
                throw new InvalidOperationException("The actual relink patcher runtime is already bound.");
            sourceRelinkPatcherRuntime = actualRuntime;
        }

        public void BindSourceOriginalGamePePath(string qualifiedOriginalGamePePath)
        {
            if (qualifiedOriginalGamePePath == null)
                throw new ArgumentNullException(nameof(qualifiedOriginalGamePePath));
            if (!Path.IsPathRooted(qualifiedOriginalGamePePath))
                throw new ArgumentException("The qualified original Celeste PE path must be absolute.",
                    nameof(qualifiedOriginalGamePePath));
            if (sourceOriginalGamePePath != null)
                throw new InvalidOperationException("The qualified original Celeste PE path is already bound.");
            sourceOriginalGamePePath = qualifiedOriginalGamePePath;
        }

        ISourceAssemblyRuntime ISourceAssemblyRuntimeEnvironment.AssemblyRuntime => sourceDynamicAssemblyRuntime ??
            throw new PlatformNotSupportedException(
                "The selected runtime has no qualified dynamic mod assembly runtime.");

        ISourceRelinkPatcherRuntime ISourceEverestRelinkerEnvironment.PatcherRuntime => sourceRelinkPatcherRuntime ??
            throw new PlatformNotSupportedException(
                "The selected runtime has no qualified actual relink patcher runtime.");

        string ISourceEverestRelinkerEnvironment.OriginalGameAssemblyPath => sourceOriginalGamePePath ??
                                                                             throw new PlatformNotSupportedException(
                                                                                 "The actual original Celeste PE file path has not been qualified and bound.");

        string ISourceEverestRelinkerEnvironment.PathGame => EverestRuntime.PathGame;
        string ISourceEverestRelinkerEnvironment.PathCache => Loader.PathCache;
        string ISourceEverestAssemblyLifecycle.PathCache => Loader.PathCache;
        bool ISourceEverestAssemblyLifecycle.CodeReload => CurrentCoreSettings.CodeReload;

        void ISourceEverestAssemblyLifecycle.UnloadAssembly(EverestModuleMetadata metadata, Assembly assembly)
            => ModulesProcess.UnloadAssembly(metadata, assembly);

        void ISourceEverestAssemblyLifecycle.ReloadMod(EverestModuleMetadata metadata) => Loader.ReloadMod(metadata);

        void ISourceEverestAssemblyLifecycle.CriticalFailureHandler(Exception exception) =>
            Failures.CriticalFailure(exception);
    }
}
