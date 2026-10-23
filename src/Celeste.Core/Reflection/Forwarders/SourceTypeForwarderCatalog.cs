using System;
using System.Collections.Generic;
using Celeste.Core.Reflection.Types;

namespace Celeste.Core.Reflection.Forwarders
{
    public sealed class SourceTypeForwarderCatalog
    {
        private readonly Dictionary<(string Assembly, string Type), SourceTypeForwarderDefinition> forwarders = new();

        private readonly Dictionary<(string Assembly, int Token), SourceTypeForwarderDefinition> exportedRows = new();

        private readonly
            Dictionary<(string Requester, string Sha, string Requested), SourceAssemblyReferenceResolutionDefinition>
            assemblyResolutions = new();

        public string SourceProfile { get; }

        public SourceTypeForwarderCatalog(string sourceProfile)
        {
            SourceProfile = sourceProfile ?? throw new ArgumentNullException(nameof(sourceProfile));
        }

        public void RegisterForwarder(SourceTypeForwarderDefinition definition)
        {
            if (definition == null) throw new ArgumentNullException(nameof(definition));
            RequireProfile(definition.SourceProfile);
            var name = (definition.AssemblyIdentity, definition.TypeIdentity);
            var row = (definition.AssemblyIdentity, definition.ExportedTypeToken);
            if (forwarders.ContainsKey(name) || exportedRows.ContainsKey(row))
                throw new InvalidOperationException("The source ExportedType row was already published.");
            forwarders.Add(name, definition);
            exportedRows.Add(row, definition);
        }

        public void RegisterAssemblyReferenceResolution(SourceAssemblyReferenceResolutionDefinition definition)
        {
            if (definition == null) throw new ArgumentNullException(nameof(definition));
            RequireProfile(definition.SourceProfile);
            assemblyResolutions.Add((definition.RequestingAssemblyIdentity, definition.RequestingSourcePeSha256,
                definition.RequestedAssemblyIdentity), definition);
        }

        public bool ContainsForwarder(string assemblyIdentity, string typeIdentity)
        {
            return forwarders.ContainsKey((assemblyIdentity, typeIdentity));
        }

        public SourceTypeForwarderResolution ResolveForwardingPath(SourceTypeReference original)
        {
            if (original == null) throw new ArgumentNullException(nameof(original));
            if (original.Kind != SourceTypeReferenceKind.Named)
                throw new ArgumentException("Resolve a named scope; TypeSpec structure remains unchanged.");
            var path = new List<SourceTypeForwarderDefinition>();
            var bindings = new List<SourceAssemblyReferenceResolutionDefinition>();
            var visited = new HashSet<(string Assembly, string Type)>();
            var current = original;
            while (forwarders.TryGetValue((current.AssemblyIdentity, current.TypeIdentity), out var definition))
            {
                if (!visited.Add((current.AssemblyIdentity, current.TypeIdentity)))
                    throw new InvalidOperationException("The original type forwarding path contains a cycle.");
                RequireTrueForwardingOrigin(definition);
                path.Add(definition);
                var targetAssembly = definition.TargetAssemblyIdentity;
                if (assemblyResolutions.TryGetValue((definition.AssemblyIdentity, definition.SourcePeSha256,
                        targetAssembly), out var resolution))
                {
                    bindings.Add(resolution);
                    targetAssembly = resolution.ResolvedAssemblyIdentity;
                }

                current = new(SourceTypeReferenceKind.Named, targetAssembly,
                    definition.TargetTypeIdentity);
            }

            // This is only a PE forwarding path. The caller must require the terminal real TypeDef
            // from the same selected SourceMembers before admitting any actual CLR type or inheritance.
            return new(original, current, [.. path], [.. bindings]);
        }

        private void RequireTrueForwardingOrigin(SourceTypeForwarderDefinition definition)
        {
            var visited = new HashSet<int>();
            var current = definition;
            while (!current.IsForwarder)
            {
                if (!visited.Add(current.ExportedTypeToken) || !current.DeclaringExportedTypeToken.HasValue
                                                            || !exportedRows.TryGetValue(
                                                                (current.AssemblyIdentity,
                                                                    current.DeclaringExportedTypeToken.Value),
                                                                out var parent)
                                                            || parent.SourcePeSha256 != current.SourcePeSha256 ||
                                                            parent.ModuleMvid != current.ModuleMvid)
                    throw new InvalidOperationException(
                        "The nested ExportedType has no published genuine forwarder parent.");
                current = parent;
            }
        }

        private void RequireProfile(string profile)
        {
            if (profile != SourceProfile)
                throw new InvalidOperationException(
                    "A source PE from another runtime/profile cannot be published into this forwarding catalog.");
        }
    }
}
