using System;
using System.Collections.Generic;

namespace Celeste.Simulation.Dialogs.Portraits
{
    public sealed class PortraitMetadataSources
    {
        private readonly Dictionary<string, IReadOnlyList<PortraitMetadataSource>> sources;

        public PortraitMetadataSources(IEnumerable<KeyValuePair<string, IReadOnlyList<PortraitMetadataSource>>> sources)
        {
            this.sources =
                new Dictionary<string, IReadOnlyList<PortraitMetadataSource>>(StringComparer.OrdinalIgnoreCase);
            foreach (var pair in sources) this.sources.Add(pair.Key, pair.Value);
        }

        public bool Has(string id) => sources.ContainsKey(id);
        public IReadOnlyList<PortraitMetadataSource> this[string id] => sources[id];
    }
}
