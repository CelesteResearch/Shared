using System;
using System.Collections.Generic;
using Celeste.Everest.Modules.Runtime;

namespace Celeste.Everest.Modules.Dependencies
{
    public sealed class EverestDelayedModule
    {
        public EverestModuleMetadata Metadata { get; }
        public IReadOnlyList<EverestModuleMetadata> MissingDependencies { get; }

        public EverestDelayedModule(EverestModuleMetadata metadata,
            IReadOnlyList<EverestModuleMetadata> missingDependencies)
        {
            Metadata = metadata ?? throw new ArgumentNullException(nameof(metadata));
            MissingDependencies = missingDependencies == null
                ? throw new ArgumentNullException(nameof(missingDependencies))
                : Array.AsReadOnly([.. missingDependencies]);
        }
    }
}
