using System;
using System.Collections.Generic;
using System.IO;
using YamlDotNet.Serialization;
using Celeste.Everest;

namespace Celeste.Everest.Modules.Runtime
{
    public sealed class EverestModuleMetadata
    {
        private string versionString;
        private byte[] hash;

        public byte[] Hash =>
            hash ?? (hash = global::Celeste.Everest.Modules.Updating.EverestChecksums.GetChecksum(this));

        internal void InvalidateHash() => hash = null;

        [YamlIgnore]
        public global::Celeste.Everest.Modules.Runtime.Assemblies.SourceEverestModuleAssemblyContext AssemblyContext
        {
            get;
            internal set;
        }

        public string Name { get; set; }
        [YamlIgnore] public string ReferenceVersion { get; set; }
        [YamlIgnore] public Version Version { get; set; } = new Version(1, 0);

        [YamlMember(Alias = "Version")]
        public string VersionString
        {
            get => versionString;
            set
            {
                versionString = value;
                int hyphen = value.IndexOf('-');
                Version = new Version(hyphen < 0 ? value : value.Substring(0, hyphen));
            }
        }

        public string DLL { get; set; }

        public List<global::Celeste.Everest.Modules.Runtime.EverestModuleMetadata> Dependencies { get; set; } =
            new List<global::Celeste.Everest.Modules.Runtime.EverestModuleMetadata>();

        public List<global::Celeste.Everest.Modules.Runtime.EverestModuleMetadata> OptionalDependencies { get; set; } =
            new List<global::Celeste.Everest.Modules.Runtime.EverestModuleMetadata>();

        public bool SupportsCodeReload { get; set; } = true;
        public bool IsNetCoreOnlyMod { get; set; }
        public global::Celeste.Everest.Modules.Runtime.EverestModuleMetadata[] Multimeta { get; set; }
        [YamlIgnore] public string PathArchive { get; set; }
        [YamlIgnore] public string PathDirectory { get; set; }
        public override string ToString() => Name + " " + Version;

        public void PostParse(global::Celeste.Everest.Modules.Runtime.EverestModuleMetadata core)
        {
            if (!string.IsNullOrEmpty(DLL) && !string.IsNullOrEmpty(PathDirectory))
                DLL = Path.Combine(PathDirectory,
                    DLL.Replace('/', Path.DirectorySeparatorChar).Replace('\\', Path.DirectorySeparatorChar));
            bool found = false;
            foreach (var dependency in Dependencies)
            {
                if (dependency.Name == "API") dependency.Name = core.Name;
                if (dependency.Name == core.Name || dependency.Name == "EverestCore")
                {
                    if (dependency.Name == "EverestCore") IsNetCoreOnlyMod = true;
                    found = true;
                    break;
                }
            }

            if (!found) Dependencies.Insert(0, core);
        }
    }
}
