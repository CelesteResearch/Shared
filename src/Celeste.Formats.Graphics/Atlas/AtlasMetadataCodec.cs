using System.IO;
using System.Text;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Formats.Graphics.Atlas
{
    public static class AtlasMetadataCodec
    {
        public static AtlasData ReadMeta(string path, bool packed = true)
        {
            var atlas = new AtlasData();
            using var reader = new BinaryReader(File.OpenRead(path), Encoding.UTF8);
            reader.ReadInt32();
            reader.ReadString();
            reader.ReadInt32();
            int pages = reader.ReadInt16();
            for (var p = 0; p < pages; p++)
            {
                var page = reader.ReadString().Replace('\\', '/');
                int count = reader.ReadInt16();
                for (var i = 0; i < count; i++)
                {
                    var entry = new AtlasEntry
                    {
                        Name = reader.ReadString().Replace('\\', '/'),
                        X = reader.ReadInt16(),
                        Y = reader.ReadInt16(),
                        Width = reader.ReadInt16(),
                        Height = reader.ReadInt16(),
                        OffsetX = -reader.ReadInt16(),
                        OffsetY = -reader.ReadInt16(),
                        FrameWidth = reader.ReadInt16(),
                        FrameHeight = reader.ReadInt16(),
                    };
                    entry.Page = packed ? page + ".data" : page + "/" + entry.Name + ".data";
                    if (!packed)
                    {
                        entry.X = 0;
                        entry.Y = 0;
                    }

                    atlas.Entries.Add(entry.Name, entry);
                }
            }

            if (reader.BaseStream.Position >= reader.BaseStream.Length || reader.ReadString() != "LINKS") return atlas;
            int linkCount = reader.ReadInt16();
            for (var i = 0; i < linkCount; i++) atlas.Links.Add(reader.ReadString(), reader.ReadString());
            return atlas;
        }
    }
}
