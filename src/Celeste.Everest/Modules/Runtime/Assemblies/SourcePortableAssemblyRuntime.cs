using System;
using System.Collections.Generic;
using System.Reflection;
using MonoMod.Utils;

namespace Celeste.Everest.Modules.Runtime.Assemblies
{
    public sealed class SourcePortableAssemblyRuntime : ISourceAssemblyRuntime
    {
        private readonly SourceAssemblyLoadContextApi contextApi;
        private readonly object applicationContext;

        public SourceAssemblyRuntimeCapabilities Capabilities { get; }

        public SourcePortableAssemblyRuntime(Assembly applicationAssembly)
        {
            if (applicationAssembly == null) throw new ArgumentNullException(nameof(applicationAssembly));
            // Mono may expose compatibility ALC APIs without implementing collectible contexts.
            if (Type.GetType("Mono.Runtime") == null)
                contextApi = SourceAssemblyLoadContextApi.TryCreate();
            if (contextApi != null) applicationContext = contextApi.GetContext(applicationAssembly);
            Capabilities = new SourceAssemblyRuntimeCapabilities(contextApi != null, contextApi != null,
                contextApi != null);
        }

        public IEnumerable<Assembly> DefaultAssemblies => contextApi != null
            ? contextApi.GetAssemblies(applicationContext)
            : AppDomain.CurrentDomain.GetAssemblies();

        public Assembly LoadDefaultAssembly(AssemblyName name)
        {
            return contextApi != null ? contextApi.LoadByName(applicationContext, name) : Assembly.Load(name);
        }

        public ISourceAssemblyRuntimeContext CreateContext(string name,
            Func<AssemblyName, Assembly> resolveManaged, Func<string, nint> resolveUnmanaged)
        {
            if (resolveManaged == null) throw new ArgumentNullException(nameof(resolveManaged));
            if (resolveUnmanaged == null) throw new ArgumentNullException(nameof(resolveUnmanaged));
            return contextApi != null
                ? new SourceCollectibleAssemblyRuntimeContext(contextApi, name, resolveManaged, resolveUnmanaged)
                : new SourceMonoAssemblyRuntimeContext(resolveManaged);
        }

        public bool TryLoadNativeLibrary(string path, out nint handle)
        {
            return DynDll.TryOpenLibrary(path, out handle);
        }

        public void FreeNativeLibrary(nint handle)
        {
            if (handle != 0) DynDll.CloseLibrary(handle);
        }
    }
}
