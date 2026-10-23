using System;
using System.Collections.Generic;
using System.IO;

namespace Celeste.Everest.Content.Sources
{
    public sealed class SourcePeAssemblyContentResources : ISourceAssemblyContentResources
    {
        private readonly string[] names;
        private readonly Dictionary<string, byte[]> embedded = new Dictionary<string, byte[]>(StringComparer.Ordinal);
        public string AssemblyName { get; }

        public SourcePeAssemblyContentResources(Mono.Cecil.AssemblyDefinition sourceAssembly)
        {
            if (sourceAssembly == null) throw new ArgumentNullException(nameof(sourceAssembly));
            AssemblyName = sourceAssembly.Name.Name;
            names = new string[sourceAssembly.MainModule.Resources.Count];
            for (int index = 0; index < names.Length; index++)
            {
                var resource = sourceAssembly.MainModule.Resources[index];
                names[index] = resource.Name;
                if (!(resource is Mono.Cecil.EmbeddedResource actualEmbedded))
                    throw new NotSupportedException(
                        "This source PE resource provider requires actual embedded resource data: " + resource.Name);
                embedded.Add(resource.Name, actualEmbedded.GetResourceData());
            }
        }

        public string[] GetManifestResourceNames() => (string[])names.Clone();

        public Stream GetManifestResourceStream(string resourceName)
            => embedded.TryGetValue(resourceName, out var bytes)
                ? new MemoryStream((byte[])bytes.Clone(), 0, bytes.Length, false, true)
                : null;
    }
}
