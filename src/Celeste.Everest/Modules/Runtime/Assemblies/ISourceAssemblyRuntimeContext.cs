using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Celeste.Everest.Modules.Runtime.Assemblies
{
    public interface ISourceAssemblyRuntimeContext
    {
        IEnumerable<Assembly> Assemblies { get; }
        void BindSourceContext(SourceEverestModuleAssemblyContext sourceContext);
        event Action Unloading;
        Assembly LoadFromStream(Stream assembly, Stream symbols);
        void Unload();
    }
}
