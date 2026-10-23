using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using Mono.Cecil;

namespace Celeste.Everest.Modules.Runtime.Assemblies
{
    public sealed class SourceEverestAssemblyContextProcess
    {
        private readonly ISourceAssemblyRuntimeEnvironment runtimeEnvironment;
        public ISourceAssemblyRuntime Runtime => runtimeEnvironment.AssemblyRuntime;
        public readonly ISourceEverestAssemblyRelinker Relinker;
        public readonly ISourceEverestAssemblyLifecycle Lifecycle;

        public SourceEverestAssemblyContextProcess(ISourceAssemblyRuntimeEnvironment runtimeEnvironment,
            ISourceEverestAssemblyRelinker relinker, ISourceEverestAssemblyLifecycle lifecycle)
        {
            this.runtimeEnvironment = runtimeEnvironment ?? throw new ArgumentNullException(nameof(runtimeEnvironment));
            Relinker = relinker;
            Lifecycle = lifecycle;
        }

        internal string[] _AssemblyLoadBlackList;

        /// <summary>
        ///       The folder name where mod unmanaged assemblies will be loaded from.
        ///       </summary>
        internal readonly string UnmanagedLibraryFolder = ((!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            ? (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)
                ? "lib-linux"
                : (RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? "lib-osx" : null))
            : (Environment.Is64BitOperatingSystem ? "lib-win-x64" : "lin-win-x86"));

        internal readonly ReaderWriterLockSlim _AllContextsLock = new ReaderWriterLockSlim();

        internal readonly LinkedList<SourceEverestModuleAssemblyContext> _AllContexts =
            new LinkedList<SourceEverestModuleAssemblyContext>();

        internal readonly Dictionary<string, SourceEverestModuleAssemblyContext> _ContextsByName =
            new Dictionary<string, SourceEverestModuleAssemblyContext>();

        internal readonly Dictionary<string, AssemblyDefinition> _GlobalAssemblyResolveCache =
            new Dictionary<string, AssemblyDefinition>();

        private readonly ThreadLocal<Stack<SourceEverestModuleAssemblyContext>> activeContexts = new();

        internal Stack<SourceEverestModuleAssemblyContext> _ActiveLocalLoadContexts
        {
            get => activeContexts.Value;
            set => activeContexts.Value = value;
        }

        public bool TryGetPhysicalModulePath(Module module, out string path)
        {
            path = null;
            if (module == null || !ReferenceEquals(module, module.Assembly.ManifestModule)) return false;
            _AllContextsLock.EnterReadLock();
            try
            {
                foreach (SourceEverestModuleAssemblyContext context in _AllContexts)
                    if (context.TryGetPhysicalAssemblyPath(module.Assembly, out path))
                        return true;
                return false;
            }
            finally
            {
                _AllContextsLock.ExitReadLock();
            }
        }

        public EverestModuleMetadata GetPhysicalAssemblyOwner(Assembly assembly)
        {
            if (assembly == null || assembly.IsDynamic) return null;
            _AllContextsLock.EnterReadLock();
            try
            {
                foreach (SourceEverestModuleAssemblyContext context in _AllContexts)
                    if (context.TryGetPhysicalAssemblyPath(assembly, out _))
                        return context.ModuleMeta;
                return null;
            }
            finally
            {
                _AllContextsLock.ExitReadLock();
            }
        }

        public void PostBootCleanupAllContexts()
        {
            _AllContextsLock.EnterReadLock();
            try
            {
                foreach (SourceEverestModuleAssemblyContext context in _AllContexts)
                    context.PostBootCleanup();
            }
            finally
            {
                _AllContextsLock.ExitReadLock();
            }
        }
    }
}
