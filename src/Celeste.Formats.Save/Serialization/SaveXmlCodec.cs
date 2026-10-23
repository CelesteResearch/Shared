using System;
using System.IO;
using Celeste.Formats.Save.Xml;

namespace Celeste.Formats.Save.Serialization
{
    // Serializes the SaveData wire graph; runtime mapping belongs to the game adapter.
    public static class SaveXmlCodec
    {
        private static readonly ISaveXmlSerializer Serializer = new SaveXmlSerializer();

        public static byte[] Serialize(SaveData save)
        {
            using var stream = new MemoryStream();
            Serialize(stream, save);
            return stream.ToArray();
        }

        public static void Serialize(Stream stream, SaveData save)
        {
            Serializer.Serialize(stream, save);
        }

        public static SaveData Deserialize(byte[] bytes)
        {
            if (bytes == null) throw new ArgumentNullException(nameof(bytes));
            using var stream = new MemoryStream(bytes, false);
            return Deserialize(stream);
        }

        public static SaveData Deserialize(Stream stream)
        {
            return Serializer.Deserialize(stream);
        }
    }
}
