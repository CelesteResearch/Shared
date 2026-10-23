using System;
using System.Collections.Generic;
using Celeste.Core.Reflection.Types;

namespace Celeste.Core.Reflection.Forwarders
{
    public sealed class SourceTypeForwarderResolution
    {
        public SourceTypeReference OriginalReference { get; }
        public SourceTypeReference TerminalReference { get; }
        public IReadOnlyList<SourceTypeForwarderDefinition> Forwarders { get; }
        public IReadOnlyList<SourceAssemblyReferenceResolutionDefinition> AssemblyResolutions { get; }

        internal SourceTypeForwarderResolution(SourceTypeReference original, SourceTypeReference terminal,
            SourceTypeForwarderDefinition[] forwarders,
            SourceAssemblyReferenceResolutionDefinition[] assemblyResolutions)
        {
            OriginalReference = original;
            TerminalReference = terminal;
            Forwarders = Array.AsReadOnly((SourceTypeForwarderDefinition[])forwarders.Clone());
            AssemblyResolutions =
                Array.AsReadOnly((SourceAssemblyReferenceResolutionDefinition[])assemblyResolutions.Clone());
        }
    }
}
