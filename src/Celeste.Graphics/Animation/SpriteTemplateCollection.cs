using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Celeste.Graphics.Animation
{
    public class SpriteTemplateCollection : ISpriteFactory
    {
        private readonly Dictionary<string, Sprite> templates;

        public IReadOnlyDictionary<string, Sprite> Templates { get; }

        public SpriteTemplateCollection(IEqualityComparer<string> comparer = null)
        {
            templates = new Dictionary<string, Sprite>(comparer ?? StringComparer.OrdinalIgnoreCase);
            Templates = new ReadOnlyDictionary<string, Sprite>(templates);
        }

        public SpriteTemplateCollection(IEnumerable<KeyValuePair<string, Sprite>> templates,
            IEqualityComparer<string> comparer = null) : this(comparer)
        {
            foreach (var pair in templates) AddTemplate(pair.Key, pair.Value);
        }

        protected void AddTemplate(string id, Sprite template)
        {
            templates.Add(id, template);
        }

        public bool Has(string id)
        {
            return templates.ContainsKey(id);
        }

        public Sprite Create(string id)
        {
            if (templates.ContainsKey(id)) return templates[id].CreateClone();
            throw MissingTemplate(id);
        }

        public Sprite CreateOn(Sprite sprite, string id)
        {
            if (templates.ContainsKey(id)) return templates[id].CloneInto(sprite);
            throw MissingTemplate(id);
        }

        protected virtual Exception MissingTemplate(string id)
        {
            return new Exception("Missing sprite template: '" + id + "'!");
        }
    }
}
