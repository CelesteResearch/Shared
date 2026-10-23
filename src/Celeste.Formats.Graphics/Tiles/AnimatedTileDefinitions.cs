using Celeste.Graphics.Content.Atlas;
using System;
using System.Collections.Generic;
using System.Xml;

namespace Celeste.Formats.Graphics.Tiles
{
    public sealed class AnimatedTileDefinitions
    {
        public readonly Dictionary<string, global::Celeste.Graphics.Content.Tiles.AnimatedTileDefinition> Items =
            new Dictionary<string, global::Celeste.Graphics.Content.Tiles.AnimatedTileDefinition>();

        public AnimatedTileDefinitions(string path, global::Celeste.Graphics.Content.Atlas.AtlasData atlas) : this(
            LoadXml(path), atlas)
        {
        }

        private static XmlDocument LoadXml(string path)
        {
            var xml = new XmlDocument();
            xml.Load(path);
            return xml;
        }

        public AnimatedTileDefinitions(XmlDocument xml, global::Celeste.Graphics.Content.Atlas.AtlasData atlas)
        {
            Append(Items, xml, atlas);
        }

        // The caller publishes the empty bank before reading XML. Each completed entry
        // becomes visible immediately; malformed present attributes retain their error.
        public static void Append(
            Dictionary<string, global::Celeste.Graphics.Content.Tiles.AnimatedTileDefinition> target,
            XmlDocument xml, AtlasData atlas)
        {
            foreach (XmlElement sprite in xml["Data"])
            {
                if (sprite == null) continue;

                float Value(string name) => sprite.HasAttribute(name)
                    ? Convert.ToSingle(sprite.Attributes[name].InnerText,
                        System.Globalization.CultureInfo.InvariantCulture)
                    : 0f;

                // Argument evaluation follows AnimatedTilesBank.Add in GFX.LoadData.
                string name = sprite.Attributes["name"].InnerText;
                float delay = Value("delay");
                float offsetX = Value("posX"), offsetY = Value("posY");
                float originX = Value("origX"), originY = Value("origY");
                var frames = atlas.Frames(sprite.Attributes["path"].InnerText);
                var item = new global::Celeste.Graphics.Content.Tiles.AnimatedTileDefinition
                {
                    Name = name, Delay = delay, OffsetX = offsetX, OffsetY = offsetY,
                    OriginX = originX, OriginY = originY, Frames = frames
                };
                target.Add(name, item);
            }
        }

        public static void Append(global::Celeste.Graphics.Content.Tiles.AnimatedTileBank target,
            XmlDocument xml, AtlasData atlas)
        {
            foreach (XmlElement sprite in xml["Data"])
            {
                if (sprite == null) continue;

                float Value(string name) => sprite.HasAttribute(name)
                    ? Convert.ToSingle(sprite.Attributes[name].InnerText,
                        System.Globalization.CultureInfo.InvariantCulture)
                    : 0f;

                string name = sprite.Attributes["name"].InnerText;
                float delay = Value("delay");
                var offset = new System.Numerics.Vector2(Value("posX"), Value("posY"));
                var origin = new System.Numerics.Vector2(Value("origX"), Value("origY"));
                var entries = atlas.Frames(sprite.Attributes["path"].InnerText);
                target.Add(name, delay, offset, origin, entries);
            }
        }
    }
}
