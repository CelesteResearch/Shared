using System;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Xml;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content.Tiles;

namespace Celeste.Formats.Graphics.Tiles
{
    public sealed class AnimatedTileDefinitions
    {
        public readonly Dictionary<string, AnimatedTileDefinition> Items = new();

        public AnimatedTileDefinitions(string path, AtlasData atlas) : this(
            LoadXml(path), atlas)
        {
        }

        private static XmlDocument LoadXml(string path)
        {
            var xml = new XmlDocument();
            xml.Load(path);
            return xml;
        }

        public AnimatedTileDefinitions(XmlDocument xml, AtlasData atlas)
        {
            Append(Items, xml, atlas);
        }

        // The caller publishes the empty bank before reading XML. Each completed entry
        // becomes visible immediately; malformed present attributes retain their error.
        public static void Append(
            Dictionary<string, AnimatedTileDefinition> target,
            XmlDocument xml, AtlasData atlas)
        {
            foreach (XmlElement sprite in xml["Data"])
            {
                if (sprite == null) continue;

                float Value(string name)
                {
                    return sprite.HasAttribute(name)
                        ? Convert.ToSingle(sprite.Attributes[name].InnerText,
                            CultureInfo.InvariantCulture)
                        : 0f;
                }

                // Argument evaluation follows AnimatedTilesBank.Add in GFX.LoadData.
                var name = sprite.Attributes["name"].InnerText;
                var delay = Value("delay");
                float offsetX = Value("posX"), offsetY = Value("posY");
                float originX = Value("origX"), originY = Value("origY");
                var frames = atlas.Frames(sprite.Attributes["path"].InnerText);
                var item = new AnimatedTileDefinition
                {
                    Name = name, Delay = delay, OffsetX = offsetX, OffsetY = offsetY,
                    OriginX = originX, OriginY = originY, Frames = frames,
                };
                target.Add(name, item);
            }
        }

        public static void Append(AnimatedTileBank target,
            XmlDocument xml, AtlasData atlas)
        {
            foreach (XmlElement sprite in xml["Data"])
            {
                if (sprite == null) continue;

                float Value(string name)
                {
                    return sprite.HasAttribute(name)
                        ? Convert.ToSingle(sprite.Attributes[name].InnerText,
                            CultureInfo.InvariantCulture)
                        : 0f;
                }

                var name = sprite.Attributes["name"].InnerText;
                var delay = Value("delay");
                var offset = new Vector2(Value("posX"), Value("posY"));
                var origin = new Vector2(Value("origX"), Value("origY"));
                var entries = atlas.Frames(sprite.Attributes["path"].InnerText);
                target.Add(name, delay, offset, origin, entries);
            }
        }
    }
}
