using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Celeste.Everest.Modules.Runtime.Assemblies
{
    internal sealed class SourceCollectibleAssemblyRuntimeContext : ISourceAssemblyRuntimeContext
    {
        private readonly SourceAssemblyLoadContextApi api;
        private object context;

        public SourceEverestModuleAssemblyContext SourceContext { get; private set; }
        public event Action Unloading;

        public IEnumerable<Assembly> Assemblies =>
            context != null ? api.GetAssemblies(context) : (Assembly[])[];

        public SourceCollectibleAssemblyRuntimeContext(SourceAssemblyLoadContextApi api, string name,
            Func<AssemblyName, Assembly> resolveManaged, Func<string, nint> resolveUnmanaged)
        {
            this.api = api;
            context = api.Create(name, resolveManaged, resolveUnmanaged);
            api.Subscribe(context, "Unloading", this, nameof(OnUnloading));
        }

        public void BindSourceContext(SourceEverestModuleAssemblyContext sourceContext)
        {
            SourceContext = sourceContext ?? throw new ArgumentNullException(nameof(sourceContext));
        }

        public Assembly LoadFromStream(Stream assembly, Stream symbols)
        {
            return context == null
                ? throw new ObjectDisposedException(nameof(SourceCollectibleAssemblyRuntimeContext))
                : api.LoadFromStream(context, assembly, symbols);
        }

        public void Unload()
        {
            if (context == null) return;
            var unloadingContext = context;
            context = null;
            SourceContext = null;
            api.Unload(unloadingContext);
        }

        private void OnUnloading(object sender)
        {
            Unloading?.Invoke();
        }
    }
}
