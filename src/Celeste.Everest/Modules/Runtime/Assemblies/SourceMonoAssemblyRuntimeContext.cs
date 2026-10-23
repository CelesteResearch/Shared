using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Celeste.Everest.Modules.Runtime.Assemblies
{
    internal sealed class SourceMonoAssemblyRuntimeContext : ISourceAssemblyRuntimeContext
    {
        private readonly Func<AssemblyName, Assembly> resolveManaged;
        private readonly List<Assembly> assemblies = [];
        private bool disposed;

        public SourceEverestModuleAssemblyContext SourceContext { get; private set; }

        public IEnumerable<Assembly> Assemblies
        {
            get
            {
                lock (assemblies)
                {
                    return (Assembly[])[.. assemblies];
                }
            }
        }

        // Mono cannot unload loaded assemblies. Native libraries must remain mapped while their code exists.
        public event Action Unloading
        {
            add { }
            remove { }
        }

        public SourceMonoAssemblyRuntimeContext(Func<AssemblyName, Assembly> resolveManaged)
        {
            this.resolveManaged = resolveManaged;
            AppDomain.CurrentDomain.AssemblyResolve += ResolveManaged;
        }

        public void BindSourceContext(SourceEverestModuleAssemblyContext sourceContext)
        {
            SourceContext = sourceContext ?? throw new ArgumentNullException(nameof(sourceContext));
        }

        public Assembly LoadFromStream(Stream assembly, Stream symbols)
        {
            if (disposed) throw new ObjectDisposedException(nameof(SourceMonoAssemblyRuntimeContext));
            var image = ReadRemaining(assembly);
            var loaded = symbols != null ? Assembly.Load(image, ReadRemaining(symbols)) : Assembly.Load(image);
            lock (assemblies)
            {
                assemblies.Add(loaded);
            }

            return loaded;
        }

        public void Unload()
        {
            if (disposed) return;
            disposed = true;
            AppDomain.CurrentDomain.AssemblyResolve -= ResolveManaged;
            SourceContext = null;
            // Logical context disposal only; code remains in the AppDomain until application exit.
        }

        private Assembly ResolveManaged(object sender, ResolveEventArgs arguments)
        {
            lock (assemblies)
            {
                if (disposed || arguments.RequestingAssembly == null ||
                    !assemblies.Contains(arguments.RequestingAssembly))
                    return null;
            }

            return resolveManaged(new(arguments.Name));
        }

        private static byte[] ReadRemaining(Stream stream)
        {
            using var copy = new MemoryStream();
            stream.CopyTo(copy);
            return copy.ToArray();
        }
    }
}
