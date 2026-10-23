using System;
using System.Collections.Generic;

namespace Celeste.Core.Reflection.Assemblies
{
    // Assembly metadata evidence only; this does not define or bind any source type.
    public sealed class SourceExternalAssemblyClosureNode(
        string assemblyIdentity,
        string sourceSha256,
        string[] assemblyReferences,
        string[] exportedTypeAssemblyScopes,
        bool hasUnresolvedExportedScope)
    {
        public string AssemblyIdentity { get; } =
            assemblyIdentity ?? throw new ArgumentNullException(nameof(assemblyIdentity));

        public string SourceSha256 { get; } = sourceSha256 ?? throw new ArgumentNullException(nameof(sourceSha256));

        public IReadOnlyList<string> AssemblyReferences { get; } = Array.AsReadOnly(
            (string[])(assemblyReferences ?? throw new ArgumentNullException(nameof(assemblyReferences))).Clone());

        public IReadOnlyList<string> ExportedTypeAssemblyScopes { get; } = Array.AsReadOnly(
            (string[])(exportedTypeAssemblyScopes ??
                       throw new ArgumentNullException(nameof(exportedTypeAssemblyScopes))).Clone());

        public bool HasUnresolvedExportedScope { get; } = hasUnresolvedExportedScope;
    }
}
