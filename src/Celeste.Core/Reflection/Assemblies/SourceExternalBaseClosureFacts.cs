using System;
using System.Collections.Generic;

namespace Celeste.Core.Reflection.Assemblies
{
    public sealed class SourceExternalBaseClosureFacts
    {
        private readonly Dictionary<string, SourceExternalAssemblyClosureNode> nodes;
        private readonly HashSet<string> externalBaseRoots;
        public string SelectedGameAssemblyIdentity { get; }
        public string SelectedGameSourceSha256 { get; }

        public SourceExternalBaseClosureFacts(string selectedGameAssemblyIdentity, string selectedGameSourceSha256,
            string[] actualExternalBaseAssemblyRoots, SourceExternalAssemblyClosureNode[] actualAssemblyNodes)
        {
            SelectedGameAssemblyIdentity = selectedGameAssemblyIdentity ??
                                           throw new ArgumentNullException(nameof(selectedGameAssemblyIdentity));
            SelectedGameSourceSha256 = selectedGameSourceSha256 ??
                                       throw new ArgumentNullException(nameof(selectedGameSourceSha256));
            externalBaseRoots =
                new HashSet<string>(
                    actualExternalBaseAssemblyRoots ??
                    throw new ArgumentNullException(nameof(actualExternalBaseAssemblyRoots)), StringComparer.Ordinal);
            nodes = new Dictionary<string, SourceExternalAssemblyClosureNode>(StringComparer.Ordinal);
            foreach (var node in actualAssemblyNodes ?? throw new ArgumentNullException(nameof(actualAssemblyNodes)))
                nodes.Add(node.AssemblyIdentity, node);
        }

        public void RegisterSupplementalRoot(SourceExternalAssemblyClosureNode node)
        {
            nodes.Add(node.AssemblyIdentity, node);
            externalBaseRoots.Add(node.AssemblyIdentity);
        }

        // False means the exclusion is not proved. It is never a proof of inheritance.
        public bool ProvesNoReferenceToSelectedGame(string externalBaseAssemblyIdentity)
        {
            if (!externalBaseRoots.Contains(externalBaseAssemblyIdentity)) return false;
            var pending = new Stack<string>();
            var visited = new HashSet<string>(StringComparer.Ordinal);
            pending.Push(externalBaseAssemblyIdentity);
            while (pending.Count != 0)
            {
                string identity = pending.Pop();
                if (string.Equals(identity, SelectedGameAssemblyIdentity, StringComparison.Ordinal)) return false;
                if (!visited.Add(identity)) continue;
                if (!nodes.TryGetValue(identity, out var node) || node.HasUnresolvedExportedScope) return false;
                foreach (string dependency in node.AssemblyReferences) pending.Push(dependency);
                foreach (string dependency in node.ExportedTypeAssemblyScopes) pending.Push(dependency);
            }

            return true;
        }
    }
}
