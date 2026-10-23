using System;
using System.IO;
using System.Text;

namespace Celeste.Formats.Graphics.Textures
{
    public static class TextureDataCodec
    {
        public static global::Celeste.Graphics.Content.Textures.TextureData Read(string path)
        {
            using (var stream = File.OpenRead(path)) return Read(stream);
        }

        public static global::Celeste.Graphics.Content.Textures.TextureData Read(Stream stream)
        {
            using (var reader = new BinaryReader(stream, Encoding.UTF8, true))
            {
                int width = reader.ReadInt32(), height = reader.ReadInt32();
                if (width < 1 || height < 1 || (long)width * height > 67108864)
                    throw new InvalidDataException("Invalid texture dimensions.");
                bool alpha = reader.ReadBoolean();
                var image = new global::Celeste.Graphics.Content.Textures.TextureData(width, height);
                for (int offset = 0; offset < image.Rgba.Length;)
                {
                    int count = reader.ReadByte();
                    if (count == 0 || offset + count * 4 > image.Rgba.Length)
                        throw new InvalidDataException("Invalid pixel run.");
                    byte a = alpha ? reader.ReadByte() : (byte)255;
                    byte b = 0, g = 0, r = 0;
                    if (a > 0)
                    {
                        b = reader.ReadByte();
                        g = reader.ReadByte();
                        r = reader.ReadByte();
                    }

                    for (int end = offset + count * 4; offset < end; offset += 4)
                    {
                        image.Rgba[offset] = r;
                        image.Rgba[offset + 1] = g;
                        image.Rgba[offset + 2] = b;
                        image.Rgba[offset + 3] = a;
                    }
                }

                if (stream.CanSeek && stream.Position != stream.Length)
                    throw new InvalidDataException("Trailing texture data.");
                return image;
            }
        }
    }
}
