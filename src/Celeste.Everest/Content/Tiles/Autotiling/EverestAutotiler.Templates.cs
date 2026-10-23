using System;
using System.Collections.Generic;
using System.Xml;
using Celeste.Core.Collections;
using Celeste.Core.Scheduling;
using Celeste.Core.Randomness;
using Celeste.Core.Mathematics;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content.Tiles;
using Celeste.Graphics.Content.Tiles.Autotiling;
using Celeste.Core.Serialization.Xml;
using Celeste.Graphics.Content;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Audio.Surfaces;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Chapters.Flow;
using Celeste.Everest.Diagnostics.Logging;
using Generated = Celeste.Graphics.Content.Tiles.Autotiling.AutotileGeneration;
using Behaviour = Celeste.Graphics.Content.Tiles.Autotiling.AutotileBehavior;
using Rectangle = Celeste.Core.Geometry.IntRect;
using MTexture = Celeste.Graphics.Content.Atlas.AtlasEntry;

namespace Celeste.Everest.Content.Tiles.Autotiling
{
    public sealed partial class EverestAutotiler
    {
        private void ReadInto(TerrainType data, Tileset tileset, XmlElement xml)
        {
            if (xml.HasAttr("scanWidth"))
            {
                int num = xml.SourceAttrInt("scanWidth");
                if (num <= 0 || num % 2 == 0)
                {
                    throw new ArgumentException(
                        $"Invalid scan width for tileset with id '{data.ID}'. Scan width must be a positive, odd integer.");
                }

                data.ScanWidth = num;
            }
            else
            {
                data.ScanWidth = 3;
            }

            if (xml.HasAttr("scanHeight"))
            {
                int num2 = xml.SourceAttrInt("scanHeight");
                if (num2 <= 0 || num2 % 2 == 0)
                {
                    throw new ArgumentException(
                        $"Invalid scan height for tileset with id '{data.ID}'. Tileset scan height must be a positive, odd integer.");
                }

                data.ScanHeight = num2;
            }
            else
            {
                data.ScanHeight = 3;
            }

            XmlNodeList xmlNodeList = xml.SelectNodes("set[starts-with(@mask, 'fill')]");
            if (xmlNodeList != null && xmlNodeList.Count > 0)
            {
                data.CustomFills = new List<Tiles>();
                for (int i = 0; i < xmlNodeList.Count; i++)
                {
                    data.CustomFills.Add(new Tiles());
                }
            }

            if (data.CustomFills == null && data.ScanWidth == 3 && data.ScanHeight == 3 &&
                !xml.SourceHasChild("define"))
            {
                orig_ReadInto(data, tileset, xml);
            }
            else
            {
                var sourceMessage1 = Logger.BeginEnabledMessage("Autotiler", EverestLogLevel.Debug);
                if (sourceMessage1.ShouldLog)
                    sourceMessage1.Write("Reading template for tileset with id '" + (data.ID) + "', scan height " +
                                         (data.ScanHeight) + ", and scan width " + (data.ScanWidth) + ".");
                ReadIntoCustomTemplate(data, tileset, xml);
            }

            if (xml.HasAttr("sound"))
            {
                SurfaceIndices.TileToIndex[xml.SourceAttrChar("id")] = xml.SourceAttrInt("sound");
                if (xml.HasAttr("soundPath"))
                {
                    SurfaceIndices.IndexToCustomPath[xml.SourceAttrInt("sound")] =
                        (xml.Attr("soundPath").StartsWith("event:/") ? "" : "event:/") + xml.Attr("soundPath");
                }

                if (xml.HasAttr("soundParam"))
                {
                    SurfaceIndices.IndexToSoundParam[xml.SourceAttrInt("sound")] = xml.SourceAttrInt("soundParam");
                }
            }
            else if (!SurfaceIndices.TileToIndex.ContainsKey(xml.SourceAttrChar("id")))
            {
                SurfaceIndices.TileToIndex[xml.SourceAttrChar("id")] = 0;
            }

            if (xml.HasAttr("debris"))
            {
                data.Debris = xml.Attr("debris");
            }

            if (xml.HasAttr("debrisImpactSfx"))
            {
                data.DebrisImpactSfx = xml.Attr("debrisImpactSfx");
            }

            if (!xml.HasAttr("ignoreExceptions"))
            {
                return;
            }

            string[] array = xml.Attr("ignoreExceptions").Split(',');
            foreach (string text in array)
            {
                if (text.Length > 0)
                {
                    data.IgnoreExceptions.Add(text[0]);
                }
            }
        }

        private void orig_ReadInto(TerrainType data, Tileset tileset, XmlElement xml)
        {
            foreach (object item3 in xml)
            {
                if (item3 is XmlComment)
                {
                    continue;
                }

                XmlElement xml2 = item3 as XmlElement;
                string text = xml2.Attr("mask");
                Tiles tiles;
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
                    Masked masked = new Masked();
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

                string[] array = xml2.Attr("tiles").Split(new char[1] { ';' });
                for (int j = 0; j < array.Length; j++)
                {
                    string[] array2 = array[j].Split(new char[1] { ',' });
                    int x = int.Parse(array2[0]);
                    int y = int.Parse(array2[1]);
                    MTexture item = tileset[x, y];
                    tiles.Textures.Add(item);
                }

                if (xml2.HasAttr("sprites"))
                {
                    array = xml2.Attr("sprites").Split(new char[1] { ',' });
                    foreach (string item2 in array)
                    {
                        tiles.OverlapSprites.Add(item2);
                    }

                    tiles.HasOverlays = true;
                }
            }

            data.Masked.Sort((Masked a, Masked b) =>
            {
                int num2 = 0;
                int num3 = 0;
                for (int k = 0; k < 9; k++)
                {
                    if (a.Mask[k] == 2)
                    {
                        num2++;
                    }

                    if (b.Mask[k] == 2)
                    {
                        num3++;
                    }
                }

                return num2 - num3;
            });
        }

        private void ReadIntoCustomTemplate(TerrainType data, Tileset tileset, XmlElement xml)
        {
            foreach (XmlNode item2 in xml)
            {
                if (!(item2 is XmlElement xmlElement))
                {
                    continue;
                }

                if (xmlElement.Name == "set")
                {
                    string text = xmlElement.Attr("mask");
                    Tiles tiles;
                    if (text == "center")
                    {
                        if (data.CustomFills != null)
                        {
                            var sourceMessage3 = Logger.BeginEnabledMessage("Autotiler", EverestLogLevel.Warn);
                            if (sourceMessage3.ShouldLog)
                                sourceMessage3.Write("\"Center\" tiles for tileset with id '" + (data.ID) +
                                                     "' will not be used if custom fills are present.");
                        }

                        tiles = data.Center;
                    }
                    else if (text == "padding")
                    {
                        if (data.CustomFills != null)
                        {
                            var sourceMessage4 = Logger.BeginEnabledMessage("Autotiler", EverestLogLevel.Warn);
                            if (sourceMessage4.ShouldLog)
                                sourceMessage4.Write("\"Padding\" tiles for tileset with id '" + (data.ID) +
                                                     "' will not be used if custom fills are present.");
                        }

                        tiles = data.Padded;
                    }
                    else if (text.StartsWith("fill"))
                    {
                        tiles = data.CustomFills[int.Parse(text.Substring(4))];
                    }
                    else
                    {
                        Masked masked = new Masked();
                        masked.Mask = new byte[data.ScanWidth * data.ScanHeight];
                        tiles = masked.Tiles;
                        try
                        {
                            int num = 0;
                            string text2 = text;
                            foreach (char c in text2)
                            {
                                switch (c)
                                {
                                    case '0':
                                        masked.Mask[num++] = 0;
                                        continue;
                                    case '1':
                                        masked.Mask[num++] = 1;
                                        continue;
                                    case 'X':
                                    case 'x':
                                        masked.Mask[num++] = 2;
                                        continue;
                                    case 'Y':
                                    case 'y':
                                        masked.Mask[num++] = 3;
                                        continue;
                                    case 'Z':
                                    case 'z':
                                        continue;
                                }

                                if (char.IsLetter(c))
                                {
                                    masked.Mask[num++] = GetByteLookup(c);
                                }
                            }
                        }
                        catch (IndexOutOfRangeException innerException)
                        {
                            throw new IndexOutOfRangeException(
                                $"Mask size in tileset with id '{data.ID}' is greater than the size specified by scanWidth and scanHeight (defaults to 3x3).",
                                innerException);
                        }

                        data.Masked.Add(masked);
                    }

                    string[] array = xmlElement.Attr("tiles").Split(';');
                    for (int i = 0; i < array.Length; i++)
                    {
                        string[] array2 = array[i].Split(',');
                        int num2 = int.Parse(array2[0]);
                        int num3 = int.Parse(array2[1]);
                        try
                        {
                            tiles.Textures.Add(tileset[num2, num3]);
                        }
                        catch (IndexOutOfRangeException innerException2)
                        {
                            throw new IndexOutOfRangeException(
                                $"Tileset with id '{data.ID}' missing tile at ({num2}, {num3}).", innerException2);
                        }
                    }

                    if (xmlElement.HasAttr("sprites"))
                    {
                        array = xmlElement.Attr("sprites").Split(',');
                        foreach (string item in array)
                        {
                            tiles.OverlapSprites.Add(item);
                        }

                        tiles.HasOverlays = true;
                    }
                }
                else if (xmlElement.Name == "define")
                {
                    byte byteLookup = GetByteLookup(xmlElement.SourceAttrChar("id"));
                    string value = xmlElement.Attr("filter");
                    if (xmlElement.SourceAttrBool("ignore"))
                    {
                        data.blacklists[byteLookup] = value;
                    }
                    else
                    {
                        data.whitelists[byteLookup] = value;
                    }
                }
            }

            data.Masked.Sort(delegate(Masked a, Masked b)
            {
                int num4 = 0;
                int num5 = 0;
                int num6 = 0;
                int num7 = 0;
                int num8 = 0;
                int num9 = 0;
                for (int j = 0; j < data.ScanWidth * data.ScanHeight; j++)
                {
                    if (a.Mask[j] >= 10)
                    {
                        num4++;
                    }

                    if (b.Mask[j] >= 10)
                    {
                        num5++;
                    }

                    if (a.Mask[j] == 3)
                    {
                        num6++;
                    }

                    if (b.Mask[j] == 3)
                    {
                        num7++;
                    }

                    if (a.Mask[j] == 2)
                    {
                        num8++;
                    }

                    if (b.Mask[j] == 2)
                    {
                        num9++;
                    }
                }

                if (num4 > 0 || num5 > 0)
                {
                    return num4 - num5;
                }

                return (num6 > 0 || num7 > 0) ? (num6 - num7) : (num8 - num9);
            });
        }

        private byte GetByteLookup(char c)
        {
            if (char.IsLower(c))
            {
                return (byte)(c - 97 + 10);
            }

            if (char.IsUpper(c))
            {
                return (byte)(c - 65 + 37);
            }

            throw new ArgumentException("Custom tileset mask filter must be an uppercase or lowercase letter.");
        }

        private void ThrowOnDuplicateId(char id, string xmlName)
        {
            if (!lookup.ContainsKey(id))
            {
                return;
            }

            string text = id.ToString();
            ushort num = id;
            string text2 = num.ToString("X4");
            if (Text.Dialog?.Languages != null)
            {
                LevelEnterState.ErrorMessage = Text.Dialog.Get("POSTCARD_DUPLICATETILEID").Replace("((tilechar))", text)
                    .Replace("((tilehex))", text2)
                    .Replace("((filename))", xmlName.Replace('\\', '/'));
            }

            throw new InvalidOperationException($"Duplicate tileset ID '{text}' (U+{text2}) found in {xmlName}.");
        }
    }
}
