using System;
using System.Collections.Generic;

namespace Celeste.Core.Reflection.Assemblies
{
    public sealed class SourceExternalBaseClosureFacts
    {
        private readonly Dictionary<string, SourceExternalAssemblyClosureNode> _nodes;
        private readonly HashSet<string> _externalBaseRoots;
        public string SelectedGameAssemblyIdentity { get; }
        public string SelectedGameSourceSha256 { get; }

        public SourceExternalBaseClosureFacts(string selectedGameAssemblyIdentity, string selectedGameSourceSha256,
            string[] actualExternalBaseAssemblyRoots, SourceExternalAssemblyClosureNode[] actualAssemblyNodes)
        {
            SelectedGameAssemblyIdentity = selectedGameAssemblyIdentity ??
                                           throw new ArgumentNullException(nameof(selectedGameAssemblyIdentity));
            SelectedGameSourceSha256 = selectedGameSourceSha256 ??
                                       throw new ArgumentNullException(nameof(selectedGameSourceSha256));
            _externalBaseRoots =
                new(
                    actualExternalBaseAssemblyRoots ??
                    throw new ArgumentNullException(nameof(actualExternalBaseAssemblyRoots)), StringComparer.Ordinal);
            _nodes = new(StringComparer.Ordinal);
            foreach (var node in actualAssemblyNodes ?? throw new ArgumentNullException(nameof(actualAssemblyNodes)))
                _nodes.Add(node.AssemblyIdentity, node);
        }

        public void RegisterSupplementalRoot(SourceExternalAssemblyClosureNode node)
        {
            _nodes.Add(node.AssemblyIdentity, node);
            _externalBaseRoots.Add(node.AssemblyIdentity);
        }

        // False means the exclusion is not proved. It is never a proof of inheritance.
        public bool ProvesNoReferenceToSelectedGame(string externalBaseAssemblyIdentity)
        {
            if (!_externalBaseRoots.Contains(externalBaseAssemblyIdentity)) return false;
            var pending = new Stack<string>();
            var visited = new HashSet<string>(StringComparer.Ordinal);
            pending.Push(externalBaseAssemblyIdentity);
            while (pending.Count != 0)
            {
                var identity = pending.Pop();
                if (string.Equals(identity, SelectedGameAssemblyIdentity, StringComparison.Ordinal)) return false;
                if (!visited.Add(identity)) continue;
                if (!_nodes.TryGetValue(identity, out var node) || node.HasUnresolvedExportedScope) return false;
                foreach (var dependency in node.AssemblyReferences) pending.Push(dependency);
                foreach (var dependency in node.ExportedTypeAssemblyScopes) pending.Push(dependency);
            }

            return true;
        }
    }
}
