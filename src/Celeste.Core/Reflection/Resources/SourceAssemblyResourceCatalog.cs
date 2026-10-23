using System;
using System.Collections.Generic;
using System.IO;

namespace Celeste.Core.Reflection.Resources
{
    public sealed class SourceAssemblyResourceCatalog
    {
        private sealed class EmbeddedResourceTable(Dictionary<string, byte[]> bytes, string[] originalNames)
        {
            public readonly Dictionary<string, byte[]> Bytes = bytes;
            public readonly string[] OriginalNames = originalNames;
        }

        private readonly Dictionary<string, EmbeddedResourceTable> _assemblies = new(StringComparer.Ordinal);

        public void RegisterCompleteEmbeddedResourceTable(string originalAssemblyIdentity,
            IReadOnlyDictionary<string, byte[]> originalResourceBytes, IReadOnlyList<string> originalResourceNames)
        {
            if (originalAssemblyIdentity == null)
                throw new ArgumentNullException(nameof(originalAssemblyIdentity));
            if (originalResourceBytes == null)
                throw new ArgumentNullException(nameof(originalResourceBytes));
            if (originalResourceNames == null)
                throw new ArgumentNullException(nameof(originalResourceNames));
            if (originalResourceNames.Count != originalResourceBytes.Count)
                throw new ArgumentException("Complete original PE resource names and payload counts must match.",
                    nameof(originalResourceNames));
            var names = new string[originalResourceNames.Count];
            var seen = new HashSet<string>(StringComparer.Ordinal);
            for (var index = 0; index < names.Length; index++)
            {
                var name = originalResourceNames[index];
                if (name == null || !originalResourceBytes.ContainsKey(name) || !seen.Add(name))
                    throw new ArgumentException("Original PE resource names must identify every payload exactly once.",
                        nameof(originalResourceNames));
                names[index] = name;
            }

            var resources = new Dictionary<string, byte[]>(StringComparer.Ordinal);
            foreach (var resource in originalResourceBytes)
            {
                if (resource.Value == null)
                    throw new ArgumentException("Embedded resource bytes are missing.", nameof(originalResourceBytes));
                resources.Add(resource.Key, (byte[])resource.Value.Clone());
            }

            _assemblies.Add(originalAssemblyIdentity, new(resources, names));
        }

        public Stream GetManifestResourceStream(string originalAssemblyIdentity, string resourceName)
        {
            if (resourceName == null)
                throw new ArgumentNullException(nameof(resourceName));
            if (resourceName.Length == 0)
                throw new ArgumentException("Resource name must not be empty.", nameof(resourceName));
            if (!_assemblies.TryGetValue(originalAssemblyIdentity, out var resources))
                throw new InvalidOperationException("Original assembly resource metadata is not published: " +
                                                    originalAssemblyIdentity);
            return resources.Bytes.TryGetValue(resourceName, out var bytes)
                ? new MemoryStream(bytes, 0, bytes.Length, false, false)
                : null;
        }

        public string[] GetManifestResourceNames(string originalAssemblyIdentity)
        {
            if (!_assemblies.TryGetValue(originalAssemblyIdentity, out var resources))
                throw new InvalidOperationException("Original assembly resource metadata is not published: " +
                                                    originalAssemblyIdentity);
            return (string[])resources.OriginalNames.Clone();
        }
    }
}
