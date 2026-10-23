using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Numerics;
using System.Xml;
using Celeste.Core.Scheduling;
using Celeste.Formats.Graphics.Xml;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content.Xml;

namespace Celeste.Formats.Graphics.Sprites
{
    public class SpriteBank : SpriteTemplateCollection
    {
        public AtlasData Atlas;

        public XmlDocument XML;

        public string XMLPath;

        private readonly ISourceEngineContext engine;
        private readonly Dictionary<string, SpriteData> sources;

        public IReadOnlyDictionary<string, SpriteData> SpriteData { get; }

        public SpriteBank(ISourceEngineContext engine,
            AtlasData atlas, XmlDocument xml)
        {
            this.engine = engine;
            Atlas = atlas;
            XML = xml;
            sources =
                new(StringComparer
                    .OrdinalIgnoreCase);
            SpriteData =
                new ReadOnlyDictionary<string,
                    SpriteData>(sources);
            var dictionary = new Dictionary<string, XmlElement>();
            foreach (var childNode in XML["Sprites"].ChildNodes)
                if (childNode is XmlElement)
                {
                    var xmlElement = childNode as XmlElement;
                    dictionary.Add(xmlElement.Name, xmlElement);
                    if (SpriteData.ContainsKey(xmlElement.Name))
                        throw new("Duplicate sprite name in SpriteData: '" + xmlElement.Name + "'!");

                    var spriteData = sources[xmlElement.Name] =
                        new(engine, Atlas);
                    var spriteData3 = spriteData;
                    if (xmlElement.HasAttr("copy"))
                        spriteData3.Add(dictionary[xmlElement.Attr("copy")], xmlElement.Attr("path"));

                    spriteData3.Add(xmlElement);
                    AddTemplate(xmlElement.Name, spriteData.Sprite);
                }
        }

        public SpriteBank(ISourceEngineContext engine,
            AtlasData atlas, string xmlPath)
            : this(engine, atlas, SpriteXml.Load(xmlPath))
        {
            XMLPath = xmlPath;
        }

        public void MergeMod(XmlDocument filteredMod)
        {
            if (filteredMod == null) throw new ArgumentNullException(nameof(filteredMod));
            var mod = new SpriteBank(engine, Atlas, filteredMod);
            foreach (var pair in mod.SpriteData)
            {
                if (!SpriteData.TryGetValue(pair.Key, out var existing))
                {
                    sources[pair.Key] = pair.Value;
                    AddTemplate(pair.Key, pair.Value.Sprite);
                    continue;
                }

                var incoming = pair.Value;
                bool origin = false, position = false;
                for (var i = incoming.Sources.Count - 1; i >= 0; i--)
                {
                    var xml = incoming.Sources[i].XML;
                    if (xml == null) continue;
                    if (!origin)
                    {
                        if (xml.HasChild("Center"))
                        {
                            existing.Sprite.CenterOrigin();
                            existing.Sprite.Justify = new Vector2(.5f, .5f);
                            origin = true;
                        }
                        else if (xml.HasChild("Justify"))
                        {
                            existing.Sprite.JustifyOrigin(xml.ChildPosition("Justify"));
                            existing.Sprite.Justify = xml.ChildPosition("Justify");
                            origin = true;
                        }
                        else if (xml.HasChild("Origin"))
                        {
                            existing.Sprite.Origin = xml.ChildPosition("Origin");
                            origin = true;
                        }
                    }

                    if (!position && xml.HasChild("Position"))
                    {
                        existing.Sprite.Position = xml.ChildPosition("Position");
                        position = true;
                    }

                    if (origin && position) break;
                }

                existing.Sprite.MergeAnimationsFrom(incoming.Sprite);
                existing.Sources.AddRange(incoming.Sources);
                existing.Sprite.Stop();
                if (incoming.Sprite.CurrentAnimationID != "")
                    existing.Sprite.Play(incoming.Sprite.CurrentAnimationID);
            }
        }

        protected override Exception MissingTemplate(string id)
        {
            return new("Missing animation name in SpriteData: '" + id + "'!");
        }
    }
}
