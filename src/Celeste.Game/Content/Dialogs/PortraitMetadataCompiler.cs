using System.Collections.Generic;
using System.Xml;
using Celeste.Formats.Graphics.Sprites;
using Celeste.Simulation.Dialogs.Portraits;

namespace Celeste.Game.Content.Dialogs
{
    public static class PortraitMetadataCompiler
    {
        public static PortraitMetadataSources Compile(SpriteBank bank)
        {
            var result = new List<KeyValuePair<string, IReadOnlyList<PortraitMetadataSource>>>();
            foreach (var pair in bank.SpriteData)
            {
                var sources = new List<PortraitMetadataSource>();
                // ReSharper disable once ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator
                foreach (var source in pair.Value.Sources)
                {
                    var xml = source.XML;
                    if (xml == null)
                    {
                        sources.Add(null);
                        continue;
                    }

                    List<PortraitSfxExpression> expressions = null;
                    if (xml["sfxs"] != null)
                    {
                        expressions = [];
                        foreach (var child in xml["sfxs"])
                            if (child is XmlElement expression)
                                expressions.Add(new(expression.Name,
                                    expression.GetAttribute("index")));
                    }

                    sources.Add(new(Attribute(xml, "size"), Attribute(xml, "textbox"),
                        Attribute(xml, "phonestatic"), Attribute(xml, "sfx"), Attribute(xml, "glitchy"),
                        expressions?.AsReadOnly()));
                }

                result.Add(new(pair.Key,
                    sources.AsReadOnly()));
            }

            return new(result);
        }

        private static string Attribute(XmlElement xml, string name)
        {
            return xml.HasAttribute(name) ? xml.GetAttribute(name) : null;
        }
    }
}
