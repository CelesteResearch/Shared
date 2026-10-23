using System.Collections.Generic;
using System.IO;
using Mono.Cecil;

namespace Celeste.Everest.Modules.Runtime.Assemblies
{
    public interface ISourceRelinkPatcher
    {
        bool CleanupEnabled { get; set; }
        Stream Input { get; set; }
        string OutputPath { get; set; }
        Dictionary<string, ModuleDefinition> RelinkModuleMap { get; set; }
        Dictionary<string, object> RelinkMap { get; set; }
        IAssemblyResolver AssemblyResolver { get; set; }
        bool MissingDependencyThrow { get; set; }
        ModuleDefinition Module { get; }
        ReaderParameters ReaderParameters { get; }
        WriterParameters WriterParameters { get; }
        IDictionary<string, object> SharedData { get; }
        void Read();
        void MapDependencies();
        void MapDependencies(ModuleDefinition module);
        void ParseRules(ModuleDefinition module);
        void AutoPatch();
        void Write();
    }
}
