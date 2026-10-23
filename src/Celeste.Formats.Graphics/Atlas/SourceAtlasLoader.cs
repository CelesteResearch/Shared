using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Xml;
using Celeste.Graphics.Content.Atlas;
using Celeste.Core.Geometry;
using Celeste.Core.IO.Content;
using Celeste.Graphics.Content.VirtualAssets;

namespace Celeste.Formats.Graphics.Atlas
{
    public static class SourceAtlasLoader
    {
        public static AtlasData FromAtlas(string path, AtlasDataFormat format,
            ISourceAtlasLoaderEnvironment environment)
        {
            AtlasData obj = environment.AtlasConstruction.CreateAtlas();
            obj.Sources = new List<VirtualTexture>();
            ReadAtlasData(obj, path, format, environment);
            if (environment.AtlasConstruction is ISourceAtlasLoadProvenance provenance)
                provenance.PublishProvenance(obj, "FromAtlas", path, null, format);
            return obj;
        }

        private static void ReadAtlasData(AtlasData atlas, string path, AtlasDataFormat format,
            ISourceAtlasLoaderEnvironment environment)
        {
            path = ContentFilePath.Normalize(path);
            bool installed = environment.AtlasConstruction.UsesInstalledReadPolicy;
            switch (format)
            {
                case AtlasDataFormat.TexturePacker_Sparrow:
                {
                    XmlElement xmlElement = environment.LoadContentXml(path)["TextureAtlas"];
                    if (installed && xmlElement == null) break;
                    VirtualTexture virtualTexture2 = environment.VirtualContent.CreateTexture(
                        Path.Combine(path2: xmlElement.Attr("imagePath", ""), path1: Path.GetDirectoryName(path)));
                    AtlasEntry parent2 = environment.AtlasConstruction.CreateEntry(virtualTexture2, atlas);
                    atlas.Sources.Add(virtualTexture2);
                    {
                        foreach (XmlElement item in xmlElement.GetElementsByTagName("SubTexture"))
                        {
                            string text2 = item.Attr("name");
                            IntRect clipRect2 = item.Rect();
                            if (item.HasAttr("frameX"))
                            {
                                atlas.Entries[text2] = environment.AtlasConstruction.CreateEntry(parent2, text2,
                                    clipRect2,
                                    new Vector2(-item.AttrInt("frameX"), -item.AttrInt("frameY")),
                                    item.AttrInt("frameWidth"), item.AttrInt("frameHeight"));
                            }
                            else
                            {
                                atlas.Entries[text2] =
                                    environment.AtlasConstruction.CreateEntry(parent2, text2, clipRect2);
                            }
                        }

                        break;
                    }
                }
                case AtlasDataFormat.CrunchXml:
                {
                    if (installed &&
                        !environment.ContentFiles.FileExists(Path.Combine(environment.ContentDirectory, path))) break;
                    foreach (XmlElement item2 in environment.LoadContentXml(path)["atlas"])
                    {
                        VirtualTexture virtualTexture = environment.VirtualContent.CreateTexture(
                            Path.Combine(path2: item2.Attr("n", "") + ".png", path1: Path.GetDirectoryName(path)));
                        AtlasEntry parent = environment.AtlasConstruction.CreateEntry(virtualTexture, atlas);
                        atlas.Sources.Add(virtualTexture);
                        foreach (XmlElement item3 in item2)
                        {
                            string text = item3.Attr("n");
                            IntRect clipRect = new IntRect(item3.AttrInt("x"), item3.AttrInt("y"), item3.AttrInt("w"),
                                item3.AttrInt("h"));
                            if (item3.HasAttr("fx"))
                            {
                                atlas.Entries[text] = environment.AtlasConstruction.CreateEntry(parent, text, clipRect,
                                    new Vector2(-item3.AttrInt("fx"), -item3.AttrInt("fy")), item3.AttrInt("fw"),
                                    item3.AttrInt("fh"));
                            }
                            else
                            {
                                atlas.Entries[text] = environment.AtlasConstruction.CreateEntry(parent, text, clipRect);
                            }
                        }
                    }

                    break;
                }
                case AtlasDataFormat.CrunchBinary:
                {
                    if (installed &&
                        !environment.ContentFiles.FileExists(Path.Combine(environment.ContentDirectory, path))) break;
                    using Stream input2 =
                        environment.ContentFiles.OpenTitleStream(Path.Combine(environment.ContentDirectory, path));
                    BinaryReader binaryReader4 = new BinaryReader(input2);
                    short num17 = binaryReader4.ReadInt16();
                    for (int num18 = 0; num18 < num17; num18++)
                    {
                        string text7 = binaryReader4.ReadNullTerminatedString();
                        VirtualTexture virtualTexture6 =
                            environment.VirtualContent.CreateTexture(Path.Combine(Path.GetDirectoryName(path),
                                text7 + ".png"));
                        if (!installed) atlas.Sources.Add(virtualTexture6);
                        AtlasEntry parent4 = environment.AtlasConstruction.CreateEntry(virtualTexture6, atlas);
                        if (installed) atlas.Sources.Add(virtualTexture6);
                        short num19 = binaryReader4.ReadInt16();
                        for (int num20 = 0; num20 < num19; num20++)
                        {
                            string text8 = binaryReader4.ReadNullTerminatedString();
                            short x2 = binaryReader4.ReadInt16();
                            short y2 = binaryReader4.ReadInt16();
                            short width3 = binaryReader4.ReadInt16();
                            short height3 = binaryReader4.ReadInt16();
                            short num21 = binaryReader4.ReadInt16();
                            short num22 = binaryReader4.ReadInt16();
                            short width4 = binaryReader4.ReadInt16();
                            short height4 = binaryReader4.ReadInt16();
                            atlas.Entries[text8] = environment.AtlasConstruction.CreateEntry(parent4, text8,
                                new IntRect(x2, y2, width3, height3), new Vector2(-num21, -num22), width4, height4);
                        }
                    }

                    break;
                }
                case AtlasDataFormat.CrunchBinaryNoAtlas:
                {
                    if (installed &&
                        !environment.ContentFiles.FileExists(Path.Combine(environment.ContentDirectory, path + ".bin")))
                        break;
                    using Stream input =
                        environment.ContentFiles.OpenTitleStream(Path.Combine(environment.ContentDirectory,
                            path + ".bin"));
                    BinaryReader binaryReader3 = new BinaryReader(input);
                    short num11 = binaryReader3.ReadInt16();
                    for (int num12 = 0; num12 < num11; num12++)
                    {
                        string path4 = binaryReader3.ReadNullTerminatedString();
                        string path5 = Path.Combine(Path.GetDirectoryName(path), path4);
                        short num13 = binaryReader3.ReadInt16();
                        for (int num14 = 0; num14 < num13; num14++)
                        {
                            string text6 = binaryReader3.ReadNullTerminatedString();
                            binaryReader3.ReadInt16();
                            binaryReader3.ReadInt16();
                            binaryReader3.ReadInt16();
                            binaryReader3.ReadInt16();
                            short num15 = binaryReader3.ReadInt16();
                            short num16 = binaryReader3.ReadInt16();
                            short frameWidth2 = binaryReader3.ReadInt16();
                            short frameHeight2 = binaryReader3.ReadInt16();
                            VirtualTexture virtualTexture5 =
                                environment.VirtualContent.CreateTexture(Path.Combine(path5, text6 + ".png"));
                            if (!installed) atlas.Sources.Add(virtualTexture5);
                            atlas.Entries[text6] = environment.AtlasConstruction.CreateEntry(virtualTexture5,
                                new Vector2(-num15, -num16), frameWidth2, frameHeight2, atlas);
                            atlas.Entries[text6].Name = text6;
                            atlas.Entries[text6].AtlasPath = text6;
                            if (installed) atlas.Sources.Add(virtualTexture5);
                        }
                    }

                    break;
                }
                case AtlasDataFormat.Packer:
                {
                    if (installed &&
                        !environment.ContentFiles.FileExists(Path.Combine(environment.ContentDirectory,
                            path + ".meta"))) break;
                    using Stream fileStream2 =
                        environment.ContentFiles.OpenTitleStream(Path.Combine(environment.ContentDirectory,
                            path + ".meta"));
                    BinaryReader binaryReader2 = new BinaryReader(fileStream2);
                    binaryReader2.ReadInt32();
                    binaryReader2.ReadString();
                    binaryReader2.ReadInt32();
                    short num6 = binaryReader2.ReadInt16();
                    for (int l = 0; l < num6; l++)
                    {
                        string text4 = binaryReader2.ReadString();
                        VirtualTexture virtualTexture4 =
                            environment.VirtualContent.CreateTexture(Path.Combine(Path.GetDirectoryName(path),
                                text4 + ".data"));
                        if (!installed) atlas.Sources.Add(virtualTexture4);
                        AtlasEntry parent3 = environment.AtlasConstruction.CreateEntry(virtualTexture4, atlas);
                        if (installed) atlas.Sources.Add(virtualTexture4);
                        short num7 = binaryReader2.ReadInt16();
                        for (int m = 0; m < num7; m++)
                        {
                            string text5 = binaryReader2.ReadString().Replace('\\', '/');
                            short x = binaryReader2.ReadInt16();
                            short y = binaryReader2.ReadInt16();
                            short width = binaryReader2.ReadInt16();
                            short height = binaryReader2.ReadInt16();
                            short num8 = binaryReader2.ReadInt16();
                            short num9 = binaryReader2.ReadInt16();
                            short width2 = binaryReader2.ReadInt16();
                            short height2 = binaryReader2.ReadInt16();
                            atlas.Entries[text5] = environment.AtlasConstruction.CreateEntry(parent3, text5,
                                new IntRect(x, y, width, height), new Vector2(-num8, -num9), width2, height2);
                        }
                    }

                    if (fileStream2.Position < fileStream2.Length && binaryReader2.ReadString() == "LINKS")
                    {
                        short num10 = binaryReader2.ReadInt16();
                        for (int n = 0; n < num10; n++)
                        {
                            string key2 = binaryReader2.ReadString();
                            string value2 = binaryReader2.ReadString();
                            atlas.Links.Add(key2, value2);
                        }
                    }

                    break;
                }
                case AtlasDataFormat.PackerNoAtlas:
                {
                    if (installed &&
                        !environment.ContentFiles.FileExists(Path.Combine(environment.ContentDirectory,
                            path + ".meta"))) break;
                    using Stream fileStream =
                        environment.ContentFiles.OpenTitleStream(Path.Combine(environment.ContentDirectory,
                            path + ".meta"));
                    BinaryReader binaryReader = new BinaryReader(fileStream);
                    binaryReader.ReadInt32();
                    binaryReader.ReadString();
                    binaryReader.ReadInt32();
                    short num = binaryReader.ReadInt16();
                    for (int i = 0; i < num; i++)
                    {
                        string path2 = binaryReader.ReadString();
                        string path3 = Path.Combine(Path.GetDirectoryName(path), path2);
                        short num2 = binaryReader.ReadInt16();
                        for (int j = 0; j < num2; j++)
                        {
                            string text3 = binaryReader.ReadString().Replace('\\', '/');
                            binaryReader.ReadInt16();
                            binaryReader.ReadInt16();
                            binaryReader.ReadInt16();
                            binaryReader.ReadInt16();
                            short num3 = binaryReader.ReadInt16();
                            short num4 = binaryReader.ReadInt16();
                            short frameWidth = binaryReader.ReadInt16();
                            short frameHeight = binaryReader.ReadInt16();
                            VirtualTexture virtualTexture3 =
                                environment.VirtualContent.CreateTexture(Path.Combine(path3, text3 + ".data"));
                            if (!installed) atlas.Sources.Add(virtualTexture3);
                            atlas.Entries[text3] = environment.AtlasConstruction.CreateEntry(virtualTexture3,
                                new Vector2(-num3, -num4), frameWidth, frameHeight, atlas);
                            atlas.Entries[text3].Name = text3;
                            atlas.Entries[text3].AtlasPath = text3;
                            if (installed) atlas.Sources.Add(virtualTexture3);
                        }
                    }

                    if (fileStream.Position < fileStream.Length && binaryReader.ReadString() == "LINKS")
                    {
                        short num5 = binaryReader.ReadInt16();
                        for (int k = 0; k < num5; k++)
                        {
                            string key = binaryReader.ReadString();
                            string value = binaryReader.ReadString();
                            atlas.Links.Add(key, value);
                        }
                    }

                    break;
                }
                case AtlasDataFormat.CrunchXmlOrBinary:
                    if (environment.ContentFiles.FileExists(Path.Combine(environment.ContentDirectory, path + ".bin")))
                    {
                        ReadAtlasData(atlas, path + ".bin", AtlasDataFormat.CrunchBinary, environment);
                    }
                    else if (!installed ||
                             environment.ContentFiles.FileExists(Path.Combine(environment.ContentDirectory,
                                 path + ".xml")))
                    {
                        ReadAtlasData(atlas, path + ".xml", AtlasDataFormat.CrunchXml, environment);
                    }

                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        public static AtlasData FromMultiAtlas(string rootPath, string[] dataPath, AtlasDataFormat format,
            ISourceAtlasLoaderEnvironment environment)
        {
            AtlasData atlas = environment.AtlasConstruction.CreateAtlas();
            atlas.Sources = new List<VirtualTexture>();
            for (int i = 0; i < dataPath.Length; i++)
            {
                ReadAtlasData(atlas, Path.Combine(rootPath, dataPath[i]), format, environment);
            }

            if (environment.AtlasConstruction is ISourceAtlasLoadProvenance provenance)
                provenance.PublishProvenance(atlas, "FromMultiAtlas", rootPath, dataPath, format);
            return atlas;
        }

        public static AtlasData FromMultiAtlas(string rootPath, string filename, AtlasDataFormat format,
            ISourceAtlasLoaderEnvironment environment)
        {
            AtlasData atlas = environment.AtlasConstruction.CreateAtlas();
            atlas.Sources = new List<VirtualTexture>();
            int num = 0;
            while (true)
            {
                string text = Path.Combine(rootPath, filename + num + ".xml");
                if (!environment.ContentFiles.FileExists(Path.Combine(environment.ContentDirectory, text)))
                {
                    break;
                }

                ReadAtlasData(atlas, text, format, environment);
                num++;
            }

            if (environment.AtlasConstruction is ISourceAtlasLoadProvenance provenance)
                provenance.PublishProvenance(atlas, "FromMultiAtlas", rootPath, new[] { filename }, format);
            return atlas;
        }

        public static AtlasData FromDirectory(string path, ISourceAtlasLoaderEnvironment environment)
        {
            AtlasData atlas = environment.AtlasConstruction.CreateAtlas();
            atlas.Sources = new List<VirtualTexture>();
            string contentDirectory = environment.ContentDirectory;
            int length = contentDirectory.Length;
            string text = Path.Combine(contentDirectory, path);
            int length2 = text.Length;
            string[] files = environment.ContentFiles.GetFiles(text, SearchOption.AllDirectories);
            foreach (string text2 in files)
            {
                string extension = Path.GetExtension(text2);
                if (!(extension != ".png") || !(extension != ".xnb"))
                {
                    VirtualTexture virtualTexture =
                        environment.VirtualContent.CreateTexture(text2.Substring(length + 1));
                    atlas.Sources.Add(virtualTexture);
                    string text3 = text2.Substring(length2 + 1);
                    text3 = text3.Substring(0, text3.Length - 4);
                    text3 = text3.Replace('\\', '/');
                    var entry = environment.AtlasConstruction.CreateEntry(virtualTexture, null);
                    entry.Name = text3;
                    entry.AtlasPath = text3;
                    atlas.Entries.Add(text3, entry);
                }
            }

            if (environment.AtlasConstruction is ISourceAtlasLoadProvenance provenance)
                provenance.PublishProvenance(atlas, "FromDirectory", path, null, null);
            return atlas;
        }
    }
}
