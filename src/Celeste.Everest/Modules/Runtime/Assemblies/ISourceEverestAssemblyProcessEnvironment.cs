using System;
using System.IO;
using System.Collections.Generic;
using System.Reflection;

namespace Celeste.Everest.Modules.Runtime.Assemblies
{
    public interface ISourceEverestAssemblyProcessEnvironment
    {
        SourceEverestAssemblyContextProcess AssemblyContexts { get; }
    }
}
