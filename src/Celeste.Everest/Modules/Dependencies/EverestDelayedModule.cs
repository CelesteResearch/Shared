using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;
using Celeste.Simulation;
using Celeste.Everest;

namespace Celeste.Everest.Modules.Dependencies
{
    public sealed class EverestDelayedModule
    {
        public global::Celeste.Everest.Modules.Runtime.EverestModuleMetadata Metadata { get; }
        public IReadOnlyList<global::Celeste.Everest.Modules.Runtime.EverestModuleMetadata> MissingDependencies { get; }

        public EverestDelayedModule(global::Celeste.Everest.Modules.Runtime.EverestModuleMetadata metadata,
            IReadOnlyList<global::Celeste.Everest.Modules.Runtime.EverestModuleMetadata> missingDependencies)
        {
            Metadata = metadata ?? throw new ArgumentNullException(nameof(metadata));
            MissingDependencies = missingDependencies == null
                ? throw new ArgumentNullException(nameof(missingDependencies))
                : Array.AsReadOnly(missingDependencies.ToArray());
        }
    }
}
