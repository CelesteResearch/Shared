using System;
using System.IO;
using System.Collections.Generic;
using System.Reflection;

namespace Celeste.Everest.Modules.Runtime.Assemblies
{
    public interface ISourceEverestAssemblyRelinker
    {
        string GameChecksum { get; }
        bool SkipGameChecksum { get; set; }

        Assembly GetRelinkedAssembly(EverestModuleMetadata metadata, string assemblyName, string path,
            string symbolsPath,
            Func<(Stream stream, Stream symStream)> streamOpener);
    }
}
