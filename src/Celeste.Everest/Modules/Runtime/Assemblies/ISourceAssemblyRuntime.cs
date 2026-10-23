using System;
using System.Collections.Generic;
using System.Reflection;

namespace Celeste.Everest.Modules.Runtime.Assemblies
{
    public interface ISourceAssemblyRuntime
    {
        SourceAssemblyRuntimeCapabilities Capabilities { get; }
        IEnumerable<Assembly> DefaultAssemblies { get; }
        Assembly LoadDefaultAssembly(AssemblyName name);

        ISourceAssemblyRuntimeContext CreateContext(string name, Func<AssemblyName, Assembly> resolveManaged,
            Func<string, nint> resolveUnmanaged);

        bool TryLoadNativeLibrary(string path, out nint handle);
        void FreeNativeLibrary(nint handle);
    }
}
