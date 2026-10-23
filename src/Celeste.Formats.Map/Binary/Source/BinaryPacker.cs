using System;
using System.IO;

namespace Celeste.Formats.Map.Binary.Source
{
    public static class BinaryPacker
    {
        private static string[] stringLookup;

        public static BinaryPackerElement FromBinary(string filename)
        {
            return FromBinary(File.OpenRead(filename));
        }

        public static BinaryPackerElement FromBinary(Stream input)
        {
            using var ownedInput = input;
            var binaryReader = new BinaryReader(input);
            binaryReader.ReadString();
            var package = binaryReader.ReadString();
            var num = binaryReader.ReadInt16();
            stringLookup = new string[num];
            for (var i = 0; i < num; i++) stringLookup[i] = binaryReader.ReadString();

            var element = ReadElement(binaryReader);
            element.Package = package;
            return element;
        }

        private static BinaryPackerElement ReadElement(BinaryReader reader)
        {
            var element = new BinaryPackerElement();
            element.Name = stringLookup[reader.ReadInt16()];
            var b = reader.ReadByte();
            if (b > 0) element.Attributes = new();

            for (var i = 0; i < b; i++)
            {
                var key = stringLookup[reader.ReadInt16()];
                var b2 = reader.ReadByte();
                object value = null;
                switch (b2)
                {
                    case 0:
                        value = reader.ReadBoolean();
                        break;
                    case 1:
                        value = Convert.ToInt32(reader.ReadByte());
                        break;
                    case 2:
                        value = Convert.ToInt32(reader.ReadInt16());
                        break;
                    case 3:
                        value = reader.ReadInt32();
                        break;
                    case 4:
                        value = reader.ReadSingle();
                        break;
                    case 5:
                        value = stringLookup[reader.ReadInt16()];
                        break;
                    case 6:
                        value = reader.ReadString();
                        break;
                    case 7:
                    {
                        var count = reader.ReadInt16();
                        value = RunLengthEncoding.Decode(reader.ReadBytes(count));
                        break;
                    }
                }

                element.Attributes.Add(key, value);
            }

            var num = reader.ReadInt16();
            if (num > 0) element.Children = [];

            for (var j = 0; j < num; j++) element.Children.Add(ReadElement(reader));

            return element;
        }
    }
}
