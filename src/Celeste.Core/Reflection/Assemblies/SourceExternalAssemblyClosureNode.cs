using System;
using System.Collections.Generic;

namespace Celeste.Core.Reflection.Assemblies
{
    // Assembly metadata evidence only; this does not define or bind any source type.
    public sealed class SourceExternalAssemblyClosureNode
    {
        public string AssemblyIdentity { get; }
        public string SourceSha256 { get; }
        public IReadOnlyList<string> AssemblyReferences { get; }
        public IReadOnlyList<string> ExportedTypeAssemblyScopes { get; }
        public bool HasUnresolvedExportedScope { get; }

        public SourceExternalAssemblyClosureNode(string assemblyIdentity, string sourceSha256,
            string[] assemblyReferences, string[] exportedTypeAssemblyScopes, bool hasUnresolvedExportedScope)
        {
            AssemblyIdentity = assemblyIdentity ?? throw new ArgumentNullException(nameof(assemblyIdentity));
            SourceSha256 = sourceSha256 ?? throw new ArgumentNullException(nameof(sourceSha256));
            AssemblyReferences =
                Array.AsReadOnly(
                    (string[])(assemblyReferences ?? throw new ArgumentNullException(nameof(assemblyReferences)))
                    .Clone());
            ExportedTypeAssemblyScopes = Array.AsReadOnly((string[])(exportedTypeAssemblyScopes ??
                                                                     throw new ArgumentNullException(
                                                                         nameof(exportedTypeAssemblyScopes))).Clone());
            HasUnresolvedExportedScope = hasUnresolvedExportedScope;
        }
    }
}
