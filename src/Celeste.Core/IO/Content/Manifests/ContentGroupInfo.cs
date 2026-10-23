using System;
using System.Collections.Generic;

namespace Celeste.Core.IO.Content.Manifests
{
    public sealed class ContentGroupInfo
    {
        public string Id { get; }
        public IReadOnlyList<string> Requires { get; }
        public IReadOnlyList<string> Files { get; }
        public long Size { get; }

        public ContentGroupInfo(string id, IEnumerable<string> requires, IEnumerable<string> files, long size = 0)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("A group identifier is required.", nameof(id));
            Id = id;
            Requires = new List<string>(requires ?? throw new ArgumentNullException(nameof(requires))).AsReadOnly();
            Files = new List<string>(files ?? throw new ArgumentNullException(nameof(files))).AsReadOnly();
            if (size < 0)
                throw new ArgumentOutOfRangeException(nameof(size));
            Size = size;
        }
    }
}
