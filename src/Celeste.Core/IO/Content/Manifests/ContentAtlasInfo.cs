using System;
using System.Collections.Generic;

namespace Celeste.Core.IO.Content.Manifests
{
    public sealed class ContentAtlasInfo(
        string name,
        string metadata,
        string format,
        int version,
        string label,
        int headerValue,
        int entries,
        int links,
        IEnumerable<string> pages)
    {
        public string Name { get; } = name ?? throw new ArgumentNullException(nameof(name));
        public string Metadata { get; } = metadata ?? throw new ArgumentNullException(nameof(metadata));
        public string Format { get; } = format ?? throw new ArgumentNullException(nameof(format));
        public int Version { get; } = version;
        public string Label { get; } = label ?? throw new ArgumentNullException(nameof(label));
        public int HeaderValue { get; } = headerValue;
        public int Entries { get; } = entries;
        public int Links { get; } = links;

        public IReadOnlyList<string> Pages { get; } =
            new List<string>(pages ?? throw new ArgumentNullException(nameof(pages))).AsReadOnly();
    }
}
