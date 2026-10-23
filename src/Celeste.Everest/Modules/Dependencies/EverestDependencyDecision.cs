using System;
using System.Collections.Generic;
using System.Linq;
using Celeste.Everest;

namespace Celeste.Everest.Modules.Dependencies
{
    public sealed class EverestDependencyDecision
    {
        public global::Celeste.Everest.Modules.Runtime.EverestModuleMetadata Required { get; internal set; }

        public global::Celeste.Everest.Modules.Dependencies.EverestDependencyDisposition Disposition
        {
            get;
            internal set;
        }

        public global::Celeste.Everest.Modules.Dependencies.EverestModUpdateInfo Download { get; internal set; }
        public global::Celeste.Everest.Modules.Runtime.EverestModuleMetadata InstalledArchive { get; internal set; }
        public string DatabaseVersion { get; internal set; }
    }
}
