using System;
using System.IO;
using System.Xml;
using Celeste.Core.Geometry;
using Celeste.Core.IO.Content;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Formats.Graphics.Atlas
{
    public static class SourceAtlasLoader
    {
        public static AtlasData FromAtlas(string path, AtlasDataFormat format,
            ISourceAtlasLoaderEnvironment environment)
        {
            var obj = environment.AtlasConstruction.CreateAtlas();
            obj.Sources = [];
            ReadAtlasData(obj, path, format, environment);
            if (environment.AtlasConstruction is ISourceAtlasLoadProvenance provenance)
                provenance.PublishProvenance(obj, "FromAtlas", path, null, format);
            return obj;
        }

        private static void ReadAtlasData(AtlasData atlas, string path, AtlasDataFormat format,
            ISourceAtlasLoaderEnvironment environment)
        {
            path = ContentFilePath.Normalize(path);
            var installed = environment.AtlasConstruction.UsesInstalledReadPolicy;
            switch (format)
            {
                case AtlasDataFormat.TexturePacker_Sparrow:
                {
                    var xmlElement = environment.LoadContentXml(path)["TextureAtlas"];
                    if (installed && xmlElement == null) break;
                    var virtualTexture2 = environment.VirtualContent.CreateTexture(
                        Path.Combine(path2: xmlElement.Attr("imagePath", ""), path1: Path.GetDirectoryName(path)));
                    var parent2 = environment.AtlasConstruction.CreateEntry(virtualTexture2, atlas);
                    atlas.Sources.Add(virtualTexture2);
                    {
                        foreach (XmlElement item in xmlElement.GetElementsByTagName("SubTexture"))
                        {
                            var text2 = item.Attr("name");
                            var clipRect2 = item.Rect();
                            if (item.HasAttr("frameX"))
                                atlas.Entries[text2] = environment.AtlasConstruction.CreateEntry(parent2, text2,
                                    clipRect2,
                                    new(-item.AttrInt("frameX"), -item.AttrInt("frameY")),
                                    item.AttrInt("frameWidth"), item.AttrInt("frameHeight"));
                            else
                                atlas.Entries[text2] =
                                    environment.AtlasConstruction.CreateEntry(parent2, text2, clipRect2);
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
                        var virtualTexture = environment.VirtualContent.CreateTexture(
                            Path.Combine(path2: item2.Attr("n", "") + ".png", path1: Path.GetDirectoryName(path)));
                        var parent = environment.AtlasConstruction.CreateEntry(virtualTexture, atlas);
                        atlas.Sources.Add(virtualTexture);
                        foreach (XmlElement item3 in item2)
                        {
                            var text = item3.Attr("n");
                            var clipRect = new IntRect(item3.AttrInt("x"), item3.AttrInt("y"), item3.AttrInt("w"),
                                item3.AttrInt("h"));
                            if (item3.HasAttr("fx"))
                                atlas.Entries[text] = environment.AtlasConstruction.CreateEntry(parent, text, clipRect,
                                    new(-item3.AttrInt("fx"), -item3.AttrInt("fy")), item3.AttrInt("fw"),
                                    item3.AttrInt("fh"));
                            else
                                atlas.Entries[text] = environment.AtlasConstruction.CreateEntry(parent, text, clipRect);
                        }
                    }

                    break;
                }
                case AtlasDataFormat.CrunchBinary:
                {
                    if (installed &&
                        !environment.ContentFiles.FileExists(Path.Combine(environment.ContentDirectory, path))) break;
                    using var input2 =
                        environment.ContentFiles.OpenTitleStream(Path.Combine(environment.ContentDirectory, path));
                    var binaryReader4 = new BinaryReader(input2);
                    var num17 = binaryReader4.ReadInt16();
                    for (var num18 = 0; num18 < num17; num18++)
                    {
                        var text7 = binaryReader4.ReadNullTerminatedString();
                        var virtualTexture6 =
                            environment.VirtualContent.CreateTexture(Path.Combine(Path.GetDirectoryName(path),
                                text7 + ".png"));
                        if (!installed) atlas.Sources.Add(virtualTexture6);
                        var parent4 = environment.AtlasConstruction.CreateEntry(virtualTexture6, atlas);
                        if (installed) atlas.Sources.Add(virtualTexture6);
                        var num19 = binaryReader4.ReadInt16();
                        for (var num20 = 0; num20 < num19; num20++)
                        {
                            var text8 = binaryReader4.ReadNullTerminatedString();
                            var x2 = binaryReader4.ReadInt16();
                            var y2 = binaryReader4.ReadInt16();
                            var width3 = binaryReader4.ReadInt16();
                            var height3 = binaryReader4.ReadInt16();
                            var num21 = binaryReader4.ReadInt16();
                            var num22 = binaryReader4.ReadInt16();
                            var width4 = binaryReader4.ReadInt16();
                            var height4 = binaryReader4.ReadInt16();
                            atlas.Entries[text8] = environment.AtlasConstruction.CreateEntry(parent4, text8,
                                new(x2, y2, width3, height3), new(-num21, -num22), width4, height4);
                        }
                    }

                    break;
                }
                case AtlasDataFormat.CrunchBinaryNoAtlas:
                {
                    if (installed &&
                        !environment.ContentFiles.FileExists(Path.Combine(environment.ContentDirectory, path + ".bin")))
                        break;
                    using var input =
                        environment.ContentFiles.OpenTitleStream(Path.Combine(environment.ContentDirectory,
                            path + ".bin"));
                    var binaryReader3 = new BinaryReader(input);
                    var num11 = binaryReader3.ReadInt16();
                    for (var num12 = 0; num12 < num11; num12++)
                    {
                        var path4 = binaryReader3.ReadNullTerminatedString();
                        var path5 = Path.Combine(Path.GetDirectoryName(path), path4);
                        var num13 = binaryReader3.ReadInt16();
                        for (var num14 = 0; num14 < num13; num14++)
                        {
                            var text6 = binaryReader3.ReadNullTerminatedString();
                            binaryReader3.ReadInt16();
                            binaryReader3.ReadInt16();
                            binaryReader3.ReadInt16();
                            binaryReader3.ReadInt16();
                            var num15 = binaryReader3.ReadInt16();
                            var num16 = binaryReader3.ReadInt16();
                            var frameWidth2 = binaryReader3.ReadInt16();
                            var frameHeight2 = binaryReader3.ReadInt16();
                            var virtualTexture5 =
                                environment.VirtualContent.CreateTexture(Path.Combine(path5, text6 + ".png"));
                            if (!installed) atlas.Sources.Add(virtualTexture5);
                            atlas.Entries[text6] = environment.AtlasConstruction.CreateEntry(virtualTexture5,
                                new(-num15, -num16), frameWidth2, frameHeight2, atlas);
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
                    using var fileStream2 =
                        environment.ContentFiles.OpenTitleStream(Path.Combine(environment.ContentDirectory,
                            path + ".meta"));
                    var binaryReader2 = new BinaryReader(fileStream2);
                    binaryReader2.ReadInt32();
                    binaryReader2.ReadString();
                    binaryReader2.ReadInt32();
                    var num6 = binaryReader2.ReadInt16();
                    for (var l = 0; l < num6; l++)
                    {
                        var text4 = binaryReader2.ReadString();
                        var virtualTexture4 =
                            environment.VirtualContent.CreateTexture(Path.Combine(Path.GetDirectoryName(path),
                                text4 + ".data"));
                        if (!installed) atlas.Sources.Add(virtualTexture4);
                        var parent3 = environment.AtlasConstruction.CreateEntry(virtualTexture4, atlas);
                        if (installed) atlas.Sources.Add(virtualTexture4);
                        var num7 = binaryReader2.ReadInt16();
                        for (var m = 0; m < num7; m++)
                        {
                            var text5 = binaryReader2.ReadString().Replace('\\', '/');
                            var x = binaryReader2.ReadInt16();
                            var y = binaryReader2.ReadInt16();
                            var width = binaryReader2.ReadInt16();
                            var height = binaryReader2.ReadInt16();
                            var num8 = binaryReader2.ReadInt16();
                            var num9 = binaryReader2.ReadInt16();
                            var width2 = binaryReader2.ReadInt16();
                            var height2 = binaryReader2.ReadInt16();
                            atlas.Entries[text5] = environment.AtlasConstruction.CreateEntry(parent3, text5,
                                new(x, y, width, height), new(-num8, -num9), width2, height2);
                        }
                    }

                    if (fileStream2.Position < fileStream2.Length && binaryReader2.ReadString() == "LINKS")
                    {
                        var num10 = binaryReader2.ReadInt16();
                        for (var n = 0; n < num10; n++)
                        {
                            var key2 = binaryReader2.ReadString();
                            var value2 = binaryReader2.ReadString();
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
                    using var fileStream =
                        environment.ContentFiles.OpenTitleStream(Path.Combine(environment.ContentDirectory,
                            path + ".meta"));
                    var binaryReader = new BinaryReader(fileStream);
                    binaryReader.ReadInt32();
                    binaryReader.ReadString();
                    binaryReader.ReadInt32();
                    var num = binaryReader.ReadInt16();
                    for (var i = 0; i < num; i++)
                    {
                        var path2 = binaryReader.ReadString();
                        var path3 = Path.Combine(Path.GetDirectoryName(path), path2);
                        var num2 = binaryReader.ReadInt16();
                        for (var j = 0; j < num2; j++)
                        {
                            var text3 = binaryReader.ReadString().Replace('\\', '/');
                            binaryReader.ReadInt16();
                            binaryReader.ReadInt16();
                            binaryReader.ReadInt16();
                            binaryReader.ReadInt16();
                            var num3 = binaryReader.ReadInt16();
                            var num4 = binaryReader.ReadInt16();
                            var frameWidth = binaryReader.ReadInt16();
                            var frameHeight = binaryReader.ReadInt16();
                            var virtualTexture3 =
                                environment.VirtualContent.CreateTexture(Path.Combine(path3, text3 + ".data"));
                            if (!installed) atlas.Sources.Add(virtualTexture3);
                            atlas.Entries[text3] = environment.AtlasConstruction.CreateEntry(virtualTexture3,
                                new(-num3, -num4), frameWidth, frameHeight, atlas);
                            atlas.Entries[text3].Name = text3;
                            atlas.Entries[text3].AtlasPath = text3;
                            if (installed) atlas.Sources.Add(virtualTexture3);
                        }
                    }

                    if (fileStream.Position < fileStream.Length && binaryReader.ReadString() == "LINKS")
                    {
                        var num5 = binaryReader.ReadInt16();
                        for (var k = 0; k < num5; k++)
                        {
                            var key = binaryReader.ReadString();
                            var value = binaryReader.ReadString();
                            atlas.Links.Add(key, value);
                        }
                    }

                    break;
                }
                case AtlasDataFormat.CrunchXmlOrBinary:
                    if (environment.ContentFiles.FileExists(Path.Combine(environment.ContentDirectory, path + ".bin")))
                        ReadAtlasData(atlas, path + ".bin", AtlasDataFormat.CrunchBinary, environment);
                    else if (!installed ||
                             environment.ContentFiles.FileExists(Path.Combine(environment.ContentDirectory,
                                 path + ".xml")))
                        ReadAtlasData(atlas, path + ".xml", AtlasDataFormat.CrunchXml, environment);

                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        public static AtlasData FromMultiAtlas(string rootPath, string[] dataPath, AtlasDataFormat format,
            ISourceAtlasLoaderEnvironment environment)
        {
            var atlas = environment.AtlasConstruction.CreateAtlas();
            atlas.Sources = [];
            for (var i = 0; i < dataPath.Length; i++)
                ReadAtlasData(atlas, Path.Combine(rootPath, dataPath[i]), format, environment);

            if (environment.AtlasConstruction is ISourceAtlasLoadProvenance provenance)
                provenance.PublishProvenance(atlas, "FromMultiAtlas", rootPath, dataPath, format);
            return atlas;
        }

        public static AtlasData FromMultiAtlas(string rootPath, string filename, AtlasDataFormat format,
            ISourceAtlasLoaderEnvironment environment)
        {
            var atlas = environment.AtlasConstruction.CreateAtlas();
            atlas.Sources = [];
            var num = 0;
            while (true)
            {
                var text = Path.Combine(rootPath, filename + num + ".xml");
                if (!environment.ContentFiles.FileExists(Path.Combine(environment.ContentDirectory, text))) break;

                ReadAtlasData(atlas, text, format, environment);
                num++;
            }

            if (environment.AtlasConstruction is ISourceAtlasLoadProvenance provenance)
                provenance.PublishProvenance(atlas, "FromMultiAtlas", rootPath, [filename], format);
            return atlas;
        }

        public static AtlasData FromDirectory(string path, ISourceAtlasLoaderEnvironment environment)
        {
            var atlas = environment.AtlasConstruction.CreateAtlas();
            atlas.Sources = [];
            var contentDirectory = environment.ContentDirectory;
            var length = contentDirectory.Length;
            var text = Path.Combine(contentDirectory, path);
            var length2 = text.Length;
            var files = environment.ContentFiles.GetFiles(text, SearchOption.AllDirectories);
            foreach (var text2 in files)
            {
                var extension = Path.GetExtension(text2);
                if (!(extension != ".png") || !(extension != ".xnb"))
                {
                    var virtualTexture =
                        environment.VirtualContent.CreateTexture(text2.Substring(length + 1));
                    atlas.Sources.Add(virtualTexture);
                    var text3 = text2.Substring(length2 + 1);
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
