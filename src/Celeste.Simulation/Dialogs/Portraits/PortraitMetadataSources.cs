using System;
using System.Collections.Generic;

namespace Celeste.Simulation.Dialogs.Portraits
{
    public sealed class PortraitMetadataSources
    {
        private readonly Dictionary<string, IReadOnlyList<PortraitMetadataSource>> _sources;

        public PortraitMetadataSources(IEnumerable<KeyValuePair<string, IReadOnlyList<PortraitMetadataSource>>> sources)
        {
            _sources =
                new(StringComparer.OrdinalIgnoreCase);
            foreach (var pair in sources) _sources.Add(pair.Key, pair.Value);
        }

        public bool Has(string id)
        {
            return _sources.ContainsKey(id);
        }

        public IReadOnlyList<PortraitMetadataSource> this[string id] => _sources[id];
    }
}
