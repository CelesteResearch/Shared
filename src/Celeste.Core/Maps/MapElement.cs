using System;
using System.Collections.Generic;
using System.Globalization;

namespace Celeste.Core.Maps
{
    public sealed class MapElement
    {
        public string Name { get; set; }
        public object ParsedData { get; set; }
        public Dictionary<string, object> Attributes { get; } = new Dictionary<string, object>(StringComparer.Ordinal);

        public List<global::Celeste.Core.Maps.MapElement> Children { get; } =
            new List<global::Celeste.Core.Maps.MapElement>();

        public MapElement(string name)
        {
            Name = name;
        }

        public string Text(string key, string fallback = "") => Attributes.TryGetValue(key, out var value)
            ? Convert.ToString(value, CultureInfo.InvariantCulture)
            : fallback;

        public int Int(string key, int fallback = 0) => Attributes.TryGetValue(key, out var value)
            ? Convert.ToInt32(value, CultureInfo.InvariantCulture)
            : fallback;

        public float Float(string key, float fallback = 0) => Attributes.TryGetValue(key, out var value)
            ? Convert.ToSingle(value, CultureInfo.InvariantCulture)
            : fallback;

        public global::Celeste.Core.Maps.MapElement Child(string name) => Children.Find(e => e.Name == name);
    }
}
