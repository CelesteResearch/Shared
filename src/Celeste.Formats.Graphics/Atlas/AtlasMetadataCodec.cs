using System;
using System.IO;
using System.Text;

namespace Celeste.Formats.Graphics.Atlas
{
    public static class AtlasMetadataCodec
    {
        public static global::Celeste.Graphics.Content.Atlas.AtlasData ReadMeta(string path, bool packed = true)
        {
            var atlas = new global::Celeste.Graphics.Content.Atlas.AtlasData();
            using (var reader = new BinaryReader(File.OpenRead(path), Encoding.UTF8))
            {
                reader.ReadInt32();
                reader.ReadString();
                reader.ReadInt32();
                int pages = reader.ReadInt16();
                for (int p = 0; p < pages; p++)
                {
                    string page = reader.ReadString().Replace('\\', '/');
                    int count = reader.ReadInt16();
                    for (int i = 0; i < count; i++)
                    {
                        var entry = new global::Celeste.Graphics.Content.Atlas.AtlasEntry
                            { Name = reader.ReadString().Replace('\\', '/') };
                        entry.X = reader.ReadInt16();
                        entry.Y = reader.ReadInt16();
                        entry.Width = reader.ReadInt16();
                        entry.Height = reader.ReadInt16();
                        entry.OffsetX = -reader.ReadInt16();
                        entry.OffsetY = -reader.ReadInt16();
                        entry.FrameWidth = reader.ReadInt16();
                        entry.FrameHeight = reader.ReadInt16();
                        entry.Page = packed ? page + ".data" : page + "/" + entry.Name + ".data";
                        if (!packed)
                        {
                            entry.X = 0;
                            entry.Y = 0;
                        }

                        atlas.Entries.Add(entry.Name, entry);
                    }
                }

                if (reader.BaseStream.Position < reader.BaseStream.Length && reader.ReadString() == "LINKS")
                {
                    int count = reader.ReadInt16();
                    for (int i = 0; i < count; i++) atlas.Links.Add(reader.ReadString(), reader.ReadString());
                }
            }

            return atlas;
        }
    }
}
