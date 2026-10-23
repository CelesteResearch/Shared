using System;

namespace Celeste.Core.Reflection.Forwarders
{
    public sealed class SourceAssemblyReferenceResolutionDefinition
    {
        public string SourceProfile { get; }
        public string RequestingAssemblyIdentity { get; }
        public string RequestingSourcePeSha256 { get; }
        public string RequestedAssemblyIdentity { get; }
        public string ResolvedAssemblyIdentity { get; }
        public string ResolvedSourcePeSha256 { get; }
        public string RuntimeIdentity { get; }
        public string EvidenceSha256 { get; }

        public SourceAssemblyReferenceResolutionDefinition(string sourceProfile, string requestingAssemblyIdentity,
            string requestingSourcePeSha256, string requestedAssemblyIdentity, string resolvedAssemblyIdentity,
            string resolvedSourcePeSha256, string runtimeIdentity, string evidenceSha256)
        {
            SourceProfile = sourceProfile ?? throw new ArgumentNullException(nameof(sourceProfile));
            RequestingAssemblyIdentity = requestingAssemblyIdentity ??
                                         throw new ArgumentNullException(nameof(requestingAssemblyIdentity));
            RequestingSourcePeSha256 = requestingSourcePeSha256 ??
                                       throw new ArgumentNullException(nameof(requestingSourcePeSha256));
            RequestedAssemblyIdentity = requestedAssemblyIdentity ??
                                        throw new ArgumentNullException(nameof(requestedAssemblyIdentity));
            ResolvedAssemblyIdentity = resolvedAssemblyIdentity ??
                                       throw new ArgumentNullException(nameof(resolvedAssemblyIdentity));
            ResolvedSourcePeSha256 =
                resolvedSourcePeSha256 ?? throw new ArgumentNullException(nameof(resolvedSourcePeSha256));
            RuntimeIdentity = runtimeIdentity ?? throw new ArgumentNullException(nameof(runtimeIdentity));
            EvidenceSha256 = evidenceSha256 ?? throw new ArgumentNullException(nameof(evidenceSha256));
        }
    }
}
