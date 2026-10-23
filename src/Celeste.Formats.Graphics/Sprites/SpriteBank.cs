using Celeste.Core.Randomness;
using Celeste.Graphics.Content.Xml;
using Celeste.Formats.Graphics.Xml;
using System;
using System.Collections.Generic;
using System.Xml;

namespace Celeste.Formats.Graphics.Sprites
{
    public class SpriteBank : global::Celeste.Graphics.Animation.SpriteTemplateCollection
    {
        public global::Celeste.Graphics.Content.Atlas.AtlasData Atlas;

        public XmlDocument XML;

        public string XMLPath;

        private readonly global::Celeste.Core.Scheduling.ISourceEngineContext engine;
        private readonly Dictionary<string, global::Celeste.Formats.Graphics.Sprites.SpriteData> sources;

        public IReadOnlyDictionary<string, global::Celeste.Formats.Graphics.Sprites.SpriteData> SpriteData { get; }

        public SpriteBank(global::Celeste.Core.Scheduling.ISourceEngineContext engine,
            global::Celeste.Graphics.Content.Atlas.AtlasData atlas, XmlDocument xml)
        {
            this.engine = engine;
            Atlas = atlas;
            XML = xml;
            sources =
                new Dictionary<string, global::Celeste.Formats.Graphics.Sprites.SpriteData>(StringComparer
                    .OrdinalIgnoreCase);
            SpriteData =
                new System.Collections.ObjectModel.ReadOnlyDictionary<string,
                    global::Celeste.Formats.Graphics.Sprites.SpriteData>(sources);
            Dictionary<string, XmlElement> dictionary = new Dictionary<string, XmlElement>();
            foreach (object childNode in XML["Sprites"].ChildNodes)
            {
                if (childNode is XmlElement)
                {
                    XmlElement xmlElement = childNode as XmlElement;
                    dictionary.Add(xmlElement.Name, xmlElement);
                    if (SpriteData.ContainsKey(xmlElement.Name))
                    {
                        throw new Exception("Duplicate sprite name in SpriteData: '" + xmlElement.Name + "'!");
                    }

                    global::Celeste.Formats.Graphics.Sprites.SpriteData spriteData = (sources[xmlElement.Name] =
                        new global::Celeste.Formats.Graphics.Sprites.SpriteData(engine, Atlas));
                    global::Celeste.Formats.Graphics.Sprites.SpriteData spriteData3 = spriteData;
                    if (xmlElement.HasAttr("copy"))
                    {
                        spriteData3.Add(dictionary[xmlElement.Attr("copy")], xmlElement.Attr("path"));
                    }

                    spriteData3.Add(xmlElement);
                    AddTemplate(xmlElement.Name, spriteData.Sprite);
                }
            }
        }

        public SpriteBank(global::Celeste.Core.Scheduling.ISourceEngineContext engine,
            global::Celeste.Graphics.Content.Atlas.AtlasData atlas, string xmlPath)
            : this(engine, atlas, global::Celeste.Formats.Graphics.Xml.SpriteXml.Load(xmlPath))
        {
            XMLPath = xmlPath;
        }

        public void MergeMod(XmlDocument filteredMod)
        {
            if (filteredMod == null) throw new ArgumentNullException(nameof(filteredMod));
            var mod = new global::Celeste.Formats.Graphics.Sprites.SpriteBank(engine, Atlas, filteredMod);
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
                for (int i = incoming.Sources.Count - 1; i >= 0; i--)
                {
                    var xml = incoming.Sources[i].XML;
                    if (xml == null) continue;
                    if (!origin)
                    {
                        if (xml.HasChild("Center"))
                        {
                            existing.Sprite.CenterOrigin();
                            existing.Sprite.Justify = new System.Numerics.Vector2(.5f, .5f);
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
            return new Exception("Missing animation name in SpriteData: '" + id + "'!");
        }
    }
}
