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
                foreach (var source in pair.Value.Sources)
                {
                    XmlElement xml = source.XML;
                    if (xml == null)
                    {
                        sources.Add(null);
                        continue;
                    }

                    List<PortraitSfxExpression> expressions = null;
                    if (xml["sfxs"] != null)
                    {
                        expressions = new List<PortraitSfxExpression>();
                        foreach (object child in xml["sfxs"])
                            if (child is XmlElement expression)
                                expressions.Add(new PortraitSfxExpression(expression.Name,
                                    expression.GetAttribute("index")));
                    }

                    sources.Add(new PortraitMetadataSource(Attribute(xml, "size"), Attribute(xml, "textbox"),
                        Attribute(xml, "phonestatic"), Attribute(xml, "sfx"), Attribute(xml, "glitchy"),
                        expressions == null ? null : expressions.AsReadOnly()));
                }

                result.Add(new KeyValuePair<string, IReadOnlyList<PortraitMetadataSource>>(pair.Key,
                    sources.AsReadOnly()));
            }

            return new PortraitMetadataSources(result);
        }

        private static string Attribute(XmlElement xml, string name) =>
            xml.HasAttribute(name) ? xml.GetAttribute(name) : null;
    }
}
