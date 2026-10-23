using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Celeste.Core.Maps;
using Celeste.Formats.Map.Binary;

namespace Celeste.Formats.Map
{
    // Celeste.BinaryPacker format. Unknown entities, attributes, nodes and stylegrounds are retained.
    public static class MapBinaryCodec
    {
        public static MapBinaryData Read(string path)
        {
            using (var stream = File.OpenRead(path))
            {
                return Read(stream);
            }
        }

        public static MapBinaryData Read(Stream stream)
        {
            using (var reader = new BinaryReader(stream, Encoding.UTF8, true))
            {
                if (reader.ReadString() != "CELESTE MAP") throw new InvalidDataException("Invalid map signature.");
                var package = reader.ReadString();
                int count = reader.ReadInt16();
                if (count < 0) throw new InvalidDataException("Invalid lookup count.");
                var lookup = new string[count];
                for (var i = 0; i < count; i++) lookup[i] = reader.ReadString();
                var result = new MapBinaryData(package, ReadElement(reader, lookup, 0));
                if (stream.CanSeek && stream.Position != stream.Length)
                    throw new InvalidDataException("Trailing map data.");
                return result;
            }
        }

        private static string Lookup(BinaryReader reader, string[] lookup)
        {
            int index = reader.ReadInt16();
            if (index < 0 || index >= lookup.Length) throw new InvalidDataException("Invalid string lookup index.");
            return lookup[index];
        }

        private static MapElement ReadElement(BinaryReader reader, string[] lookup, int depth)
        {
            if (depth > 256) throw new InvalidDataException("Map nesting limit exceeded.");
            var element =
                new MapElement(Lookup(reader, lookup));
            int count = reader.ReadByte();
            for (var i = 0; i < count; i++)
            {
                var key = Lookup(reader, lookup);
                object value;
                switch (reader.ReadByte())
                {
                    case 0: value = reader.ReadBoolean(); break;
                    case 1: value = (int)reader.ReadByte(); break;
                    case 2: value = (int)reader.ReadInt16(); break;
                    case 3: value = reader.ReadInt32(); break;
                    case 4: value = reader.ReadSingle(); break;
                    case 5: value = Lookup(reader, lookup); break;
                    case 6: value = reader.ReadString(); break;
                    case 7:
                        int length = reader.ReadInt16();
                        if (length < 0 || length % 2 != 0) throw new InvalidDataException("Invalid RLE length.");
                        var text = new StringBuilder();
                        for (var j = 0; j < length; j += 2)
                        {
                            int repeat = reader.ReadByte();
                            var character = (char)reader.ReadByte();
                            text.Append(character, repeat);
                        }

                        value = text.ToString();
                        break;
                    default: throw new InvalidDataException("Unknown attribute type.");
                }

                element.Attributes.Add(key, value);
            }

            int children = reader.ReadInt16();
            if (children < 0) throw new InvalidDataException("Invalid child count.");
            for (var i = 0; i < children; i++) element.Children.Add(ReadElement(reader, lookup, depth + 1));
            return element;
        }

        public static void Write(MapBinaryData document, Stream stream)
        {
            var lookup = new Dictionary<string, short>(StringComparer.Ordinal);
            Gather(document.Root, lookup);
            using (var writer = new BinaryWriter(stream, Encoding.UTF8, true))
            {
                writer.Write("CELESTE MAP");
                writer.Write(document.Package);
                writer.Write(checked((short)lookup.Count));
                foreach (var entry in lookup.OrderBy(e => e.Value)) writer.Write(entry.Key);
                WriteElement(writer, document.Root, lookup);
            }
        }

        private static void Gather(MapElement element, Dictionary<string, short> lookup)
        {
            if (!lookup.ContainsKey(element.Name)) lookup.Add(element.Name, checked((short)lookup.Count));
            foreach (var key in element.Attributes.Keys)
                if (!lookup.ContainsKey(key))
                    lookup.Add(key, checked((short)lookup.Count));
            foreach (var child in element.Children) Gather(child, lookup);
        }

        private static void WriteElement(BinaryWriter writer, MapElement element,
            Dictionary<string, short> lookup)
        {
            writer.Write(lookup[element.Name]);
            writer.Write(checked((byte)element.Attributes.Count));
            foreach (var pair in element.Attributes)
            {
                writer.Write(lookup[pair.Key]);
                switch (pair.Value)
                {
                    case bool b:
                        writer.Write((byte)0);
                        writer.Write(b);
                        break;
                    case int n:
                        writer.Write((byte)3);
                        writer.Write(n);
                        break;
                    case float f:
                        writer.Write((byte)4);
                        writer.Write(f);
                        break;
                    case string s:
                        writer.Write((byte)6);
                        writer.Write(s);
                        break;
                    default: throw new InvalidDataException("Unsupported attribute value: " + pair.Key);
                }
            }

            writer.Write(checked((short)element.Children.Count));
            foreach (var child in element.Children)
                WriteElement(writer, child, lookup);
        }
    }
}
