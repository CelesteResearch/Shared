using System;
using System.Collections.Generic;

namespace Celeste.Core.IO.Content.Manifests
{
    public sealed class ContentAtlasInfo
    {
        public string Name { get; }
        public string Metadata { get; }
        public string Format { get; }
        public int Version { get; }
        public string Label { get; }
        public int HeaderValue { get; }
        public int Entries { get; }
        public int Links { get; }
        public IReadOnlyList<string> Pages { get; }

        public ContentAtlasInfo(string name, string metadata, string format, int version, string label,
            int headerValue, int entries, int links, IEnumerable<string> pages)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Metadata = metadata ?? throw new ArgumentNullException(nameof(metadata));
            Format = format ?? throw new ArgumentNullException(nameof(format));
            Version = version;
            Label = label ?? throw new ArgumentNullException(nameof(label));
            HeaderValue = headerValue;
            Entries = entries;
            Links = links;
            Pages = new List<string>(pages ?? throw new ArgumentNullException(nameof(pages))).AsReadOnly();
        }
    }
}
