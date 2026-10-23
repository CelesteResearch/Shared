using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace Celeste.Formats.Graphics.Sprites
{
    // LevelLoader always starts with the shipped Sprites.xml. Meta.Sprites is
    // an additional bank whose changed names merge into that vanilla bank.
    public sealed class SpriteDefinitionSources
    {
        public XmlDocument Vanilla { get; }
        public XmlDocument Mod { get; }

        public SpriteDefinitionSources(XmlDocument vanilla, XmlDocument mod = null)
        {
            Vanilla = vanilla ?? throw new ArgumentNullException(nameof(vanilla));
            Mod = mod;
        }

        public static SpriteDefinitionSources Load(string contentDirectory, string modPath,
            Func<string, Stream> openContent, IEnumerable<XmlDocument> globalMods = null)
        {
            var vanilla = new XmlDocument();
            using (var stream = File.OpenRead(Path.Combine(contentDirectory, "Graphics", "Sprites.xml")))
                vanilla.Load(stream);
            // SpriteBank(string) starts with the shipped document, then ingests
            // every loaded package's same-path bank in registration order.
            var global = MergeGlobalBank(vanilla, globalMods);
            if (string.IsNullOrEmpty(modPath)) return new SpriteDefinitionSources(global);
            if (openContent == null) throw new ArgumentNullException(nameof(openContent));
            var mod = new XmlDocument();
            using (var stream = openContent(modPath))
                if (stream != null)
                    mod.Load(stream);
            // LevelLoader's explicit Meta.Sprites path uses Calc.LoadContentXML
            // (the latest virtual asset), filtered against the original file.
            return new SpriteDefinitionSources(global, FilterVanillaCopies(vanilla, mod));
        }

        public static XmlDocument MergeGlobalBank(XmlDocument original, IEnumerable<XmlDocument> globalMods)
        {
            if (original == null) throw new ArgumentNullException(nameof(original));
            if (globalMods == null) return original;
            var merged = (XmlDocument)original.CloneNode(true);
            var root = merged["Sprites"] ??
                       throw new ArgumentException("Sprite XML has no Sprites root", nameof(original));
            foreach (var source in globalMods)
            {
                var filtered = FilterVanillaCopies(original, (XmlDocument)source.CloneNode(true));
                foreach (var sprite in Elements(filtered["Sprites"]))
                {
                    var imported = merged.ImportNode(sprite, true);
                    var previous = root.SelectSingleNode(sprite.Name);
                    if (previous == null) root.AppendChild(imported);
                    else root.ReplaceChild(imported, previous);
                }
            }

            return merged;
        }

        // Installed SpriteBank.GetSpriteBankExcludingVanillaCopyPastes compares
        // ordered attributes and child elements, ignoring comments/text. An
        // identical source is retained when a changed sprite copies it.
        public static XmlDocument FilterVanillaCopies(XmlDocument vanilla, XmlDocument mod)
        {
            var baseline = vanilla?["Sprites"] ??
                           throw new ArgumentException("Vanilla sprite XML has no Sprites root", nameof(vanilla));
            var root = mod?["Sprites"] ??
                       throw new ArgumentException("Mod sprite XML has no Sprites root", nameof(mod));
            var identical = new List<XmlElement>();
            var copiedByChanged = new HashSet<string>(StringComparer.Ordinal);
            foreach (XmlElement node in Elements(root))
            {
                var prior = baseline.SelectSingleNode(node.Name);
                if (prior == null) continue;
                if (Identical(prior, node)) identical.Add(node);
                else if (node.HasAttribute("copy")) copiedByChanged.Add(node.GetAttribute("copy"));
            }

            foreach (var node in identical)
                if (!copiedByChanged.Contains(node.Name))
                    root.RemoveChild(node);
            return mod;
        }

        private static IEnumerable<XmlElement> Elements(XmlNode node) =>
            node.ChildNodes.Cast<XmlNode>().OfType<XmlElement>();

        private static bool Identical(XmlNode left, XmlNode right)
        {
            if (left.Attributes.Count != right.Attributes.Count) return false;
            for (int i = 0; i < left.Attributes.Count; i++)
                if (left.Attributes[i].Name != right.Attributes[i].Name ||
                    left.Attributes[i].Value != right.Attributes[i].Value)
                    return false;
            var a = Elements(left).ToArray();
            var b = Elements(right).ToArray();
            if (a.Length != b.Length) return false;
            for (int i = 0; i < a.Length; i++)
                if (!Identical(a[i], b[i]))
                    return false;
            return true;
        }
    }
}
