using System;
using System.Collections.Generic;
using System.IO;
using Celeste.Everest.Modules.Runtime.Assemblies;
using Celeste.Everest.Modules.Updating;
using YamlDotNet.Serialization;

namespace Celeste.Everest.Modules.Runtime
{
    public sealed class EverestModuleMetadata
    {
        private string versionString;

        private byte[] hash;

        public byte[] Hash =>
            hash ??= EverestChecksums.GetChecksum(this);

        internal void InvalidateHash()
        {
            hash = null;
        }

        [YamlIgnore] public SourceEverestModuleAssemblyContext AssemblyContext { get; internal set; }

        public string Name { get; set; }
        [YamlIgnore] public string ReferenceVersion { get; set; }
        [YamlIgnore] public Version Version { get; set; } = new(1, 0);

        [YamlMember(Alias = "Version")]
        public string VersionString
        {
            get => versionString;
            set
            {
                versionString = value;
                var hyphen = value.IndexOf('-');
                Version = new(hyphen < 0 ? value : value[..hyphen]);
            }
        }

        public string DLL { get; set; }

        public List<EverestModuleMetadata> Dependencies { get; set; } = [];

        public List<EverestModuleMetadata> OptionalDependencies { get; set; } = [];

        public bool SupportsCodeReload { get; set; } = true;
        public bool IsNetCoreOnlyMod { get; set; }
        public EverestModuleMetadata[] Multimeta { get; set; }
        [YamlIgnore] public string PathArchive { get; set; }
        [YamlIgnore] public string PathDirectory { get; set; }

        public override string ToString()
        {
            return Name + " " + Version;
        }

        public void PostParse(EverestModuleMetadata core)
        {
            if (!string.IsNullOrEmpty(DLL) && !string.IsNullOrEmpty(PathDirectory))
                DLL = Path.Combine(PathDirectory,
                    DLL.Replace('/', Path.DirectorySeparatorChar).Replace('\\', Path.DirectorySeparatorChar));
            var found = false;
            foreach (var dependency in Dependencies)
            {
                if (dependency.Name == "API") dependency.Name = core.Name;
                if (dependency.Name != core.Name && dependency.Name != "EverestCore") continue;
                if (dependency.Name == "EverestCore") IsNetCoreOnlyMod = true;
                found = true;
                break;
            }

            if (!found) Dependencies.Insert(0, core);
        }
    }
}
