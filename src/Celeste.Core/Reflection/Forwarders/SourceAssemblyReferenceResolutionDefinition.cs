using System;

namespace Celeste.Core.Reflection.Forwarders
{
    public sealed class SourceAssemblyReferenceResolutionDefinition(
        string sourceProfile,
        string requestingAssemblyIdentity,
        string requestingSourcePeSha256,
        string requestedAssemblyIdentity,
        string resolvedAssemblyIdentity,
        string resolvedSourcePeSha256,
        string runtimeIdentity,
        string evidenceSha256)
    {
        public string SourceProfile { get; }
            = sourceProfile ?? throw new ArgumentNullException(nameof(sourceProfile));

        public string RequestingAssemblyIdentity { get; }
            = requestingAssemblyIdentity ??
              throw new ArgumentNullException(nameof(requestingAssemblyIdentity));

        public string RequestingSourcePeSha256 { get; }
            = requestingSourcePeSha256 ??
              throw new ArgumentNullException(nameof(requestingSourcePeSha256));

        public string RequestedAssemblyIdentity { get; }
            = requestedAssemblyIdentity ??
              throw new ArgumentNullException(nameof(requestedAssemblyIdentity));

        public string ResolvedAssemblyIdentity { get; }
            = resolvedAssemblyIdentity ??
              throw new ArgumentNullException(nameof(resolvedAssemblyIdentity));

        public string ResolvedSourcePeSha256 { get; }
            = resolvedSourcePeSha256 ?? throw new ArgumentNullException(nameof(resolvedSourcePeSha256));

        public string RuntimeIdentity { get; }
            = runtimeIdentity ?? throw new ArgumentNullException(nameof(runtimeIdentity));

        public string EvidenceSha256 { get; }
            = evidenceSha256 ?? throw new ArgumentNullException(nameof(evidenceSha256));
    }
}
