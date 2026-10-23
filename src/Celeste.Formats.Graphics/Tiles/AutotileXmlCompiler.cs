using System;
using System.Collections.Generic;
using System.Xml;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content.Tiles;
using Celeste.Graphics.Content.Tiles.Autotiling;
using Celeste.Graphics.Content.Xml;

namespace Celeste.Formats.Graphics.Tiles
{
    public static class AutotileXmlCompiler
    {
        public static AutotileContent Compile(TileDefinitionSources sources, AtlasData atlas)
        {
            return new(Compile(sources.Background, atlas), Compile(sources.Foreground, atlas),
                new AnimatedTileDefinitions(sources.Animated, atlas).Items);
        }

        public static AutotileRules Compile(XmlDocument xml, AtlasData atlas)
        {
            var rules = new AutotileRules { EmptyId = '0', UnsetId = '\0', TileWidth = 8, TileHeight = 8 };
            if (xml == null) throw new ArgumentNullException(nameof(xml));
            var dictionary = new Dictionary<char, XmlElement>();
            foreach (XmlElement item in xml.GetElementsByTagName("Tileset"))
            {
                var c = item.AttrChar("id");
                var tileset =
                    new Tileset(
                        atlas.Entries["tilesets/" + item.Attr("path")], 8, 8);
                var terrainType = new AutotileTerrain(c);
                ReadInto(terrainType, tileset, item);
                if (item.HasAttr("copy"))
                {
                    var key = item.AttrChar("copy");
                    if (!dictionary.ContainsKey(key))
                        throw new("Copied tilesets must be defined before the tilesets that copy them!");

                    ReadInto(terrainType, tileset, dictionary[key]);
                }

                if (item.HasAttr("ignores"))
                {
                    var array = item.Attr("ignores").Split(',');
                    foreach (var text in array)
                        if (text.Length > 0)
                        {
                            terrainType.Ignores.Add(text[0]);
                            if (text[0] == '*') terrainType.IgnoreOtherTerrains = true;
                        }
                }

                dictionary.Add(c, item);
                rules.Terrains.Add(c, terrainType);
            }

            return rules;
        }

        private static void ReadInto(AutotileTerrain data, Tileset tileset,
            XmlElement xml)
        {
            foreach (var item3 in xml)
            {
                if (item3 is XmlComment) continue;

                var xml2 = item3 as XmlElement;
                var text = xml2.Attr("mask");
                AutotileCandidates tiles;
                if (text == "center")
                {
                    tiles = data.Center;
                }
                else if (text == "padding")
                {
                    tiles = data.Padded;
                }
                else
                {
                    var masked = new AutotileMaskRule();
                    tiles = masked.Tiles;
                    var i = 0;
                    var num = 0;
                    for (; i < text.Length; i++)
                        if (text[i] == '0')
                            masked.Mask[num++] = 0;
                        else if (text[i] == '1')
                            masked.Mask[num++] = 1;
                        else if (text[i] == 'x' || text[i] == 'X') masked.Mask[num++] = 2;

                    data.Masked.Add(masked);
                }

                var array = xml2.Attr("tiles").Split(';');
                for (var j = 0; j < array.Length; j++)
                {
                    var array2 = array[j].Split(',');
                    var x = int.Parse(array2[0]);
                    var y = int.Parse(array2[1]);
                    var item = tileset[x, y];
                    tiles.Textures.Add(item);
                }

                if (xml2.HasAttr("sprites"))
                {
                    array = xml2.Attr("sprites").Split(',');
                    foreach (var item2 in array) tiles.OverlapSprites.Add(item2);

                    tiles.HasOverlays = true;
                }
            }

            data.SortMasks();
        }
    }
}
