using System;
using Celeste.Core.Diagnostics.Runtime;

namespace Celeste.Game.Runtime.Physical.Runtime
{
    // Static physical providers are selected by the host; no runtime code generation is required.
    public sealed class SourceRuntimeDiagnostics : ISourceRuntimeDiagnosticsIO
    {
        private readonly ISourceRuntimeMemoryCapacity capacity;
        private readonly ISourceRuntimeMemoryDiagnostics? memory;
        private readonly ISourceRuntimeIdentityDiagnostics? identity;

        public SourceRuntimeDiagnostics(ISourceRuntimeMemoryCapacity capacity,
            ISourceRuntimeMemoryDiagnostics? memory = null, ISourceRuntimeIdentityDiagnostics? identity = null)
        {
            this.capacity = capacity ?? throw new ArgumentNullException(nameof(capacity));
            this.memory = memory;
            this.identity = identity;
        }

        public SourceRuntimeMemoryAvailability Availability => memory?.Availability ??
                                                               SourceRuntimeMemoryAvailability.Unavailable;

        public SourceRuntimeIdentifierAvailability RuntimeIdentifierAvailability =>
            identity?.RuntimeIdentifierAvailability ?? SourceRuntimeIdentifierAvailability.Unavailable;

        public string RuntimeIdentifier => identity?.RuntimeIdentifier ??
                                           throw new PlatformNotSupportedException(
                                               "The selected physical runtime has no identifier provider.");

        public SourceRuntimeGcMemorySnapshot? ReadMemoryInfo() => memory?.ReadMemoryInfo();

        public long ReadTotalAvailableMemoryBytes() => ReadMemoryInfo()?.TotalAvailableMemoryBytes ??
                                                       capacity.ReadTotalAvailableMemoryBytes();
    }
}
