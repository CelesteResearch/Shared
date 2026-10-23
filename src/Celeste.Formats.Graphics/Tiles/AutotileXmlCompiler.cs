using System;
using System.Collections.Generic;
using System.Xml;
using Celeste.Graphics.Content.Xml;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content.Tiles.Autotiling;

namespace Celeste.Formats.Graphics.Tiles
{
    public static class AutotileXmlCompiler
    {
        public static AutotileContent Compile(TileDefinitionSources sources, AtlasData atlas)
        {
            return new AutotileContent(Compile(sources.Background, atlas), Compile(sources.Foreground, atlas),
                new AnimatedTileDefinitions(sources.Animated, atlas).Items);
        }

        public static AutotileRules Compile(XmlDocument xml, AtlasData atlas)
        {
            var rules = new AutotileRules { EmptyId = '0', UnsetId = '\0', TileWidth = 8, TileHeight = 8 };
            if (xml == null) throw new ArgumentNullException(nameof(xml));
            Dictionary<char, XmlElement> dictionary = new Dictionary<char, XmlElement>();
            foreach (XmlElement item in xml.GetElementsByTagName("Tileset"))
            {
                char c = item.AttrChar("id");
                global::Celeste.Graphics.Content.Tiles.Tileset tileset =
                    new global::Celeste.Graphics.Content.Tiles.Tileset(
                        atlas.Entries["tilesets/" + item.Attr("path")], 8, 8);
                AutotileTerrain terrainType = new AutotileTerrain(c);
                ReadInto(terrainType, tileset, item);
                if (item.HasAttr("copy"))
                {
                    char key = item.AttrChar("copy");
                    if (!dictionary.ContainsKey(key))
                    {
                        throw new Exception("Copied tilesets must be defined before the tilesets that copy them!");
                    }

                    ReadInto(terrainType, tileset, dictionary[key]);
                }

                if (item.HasAttr("ignores"))
                {
                    string[] array = item.Attr("ignores").Split(',');
                    foreach (string text in array)
                    {
                        if (text.Length > 0)
                        {
                            terrainType.Ignores.Add(text[0]);
                            if (text[0] == '*') terrainType.IgnoreOtherTerrains = true;
                        }
                    }
                }

                dictionary.Add(c, item);
                rules.Terrains.Add(c, terrainType);
            }

            return rules;
        }

        private static void ReadInto(AutotileTerrain data, global::Celeste.Graphics.Content.Tiles.Tileset tileset,
            XmlElement xml)
        {
            foreach (object item3 in xml)
            {
                if (item3 is XmlComment)
                {
                    continue;
                }

                XmlElement xml2 = item3 as XmlElement;
                string text = xml2.Attr("mask");
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
                    AutotileMaskRule masked = new AutotileMaskRule();
                    tiles = masked.Tiles;
                    int i = 0;
                    int num = 0;
                    for (; i < text.Length; i++)
                    {
                        if (text[i] == '0')
                        {
                            masked.Mask[num++] = 0;
                        }
                        else if (text[i] == '1')
                        {
                            masked.Mask[num++] = 1;
                        }
                        else if (text[i] == 'x' || text[i] == 'X')
                        {
                            masked.Mask[num++] = 2;
                        }
                    }

                    data.Masked.Add(masked);
                }

                string[] array = xml2.Attr("tiles").Split(';');
                for (int j = 0; j < array.Length; j++)
                {
                    string[] array2 = array[j].Split(',');
                    int x = int.Parse(array2[0]);
                    int y = int.Parse(array2[1]);
                    AtlasEntry item = tileset[x, y];
                    tiles.Textures.Add(item);
                }

                if (xml2.HasAttr("sprites"))
                {
                    array = xml2.Attr("sprites").Split(',');
                    foreach (string item2 in array)
                    {
                        tiles.OverlapSprites.Add(item2);
                    }

                    tiles.HasOverlays = true;
                }
            }

            data.SortMasks();
        }
    }
}
