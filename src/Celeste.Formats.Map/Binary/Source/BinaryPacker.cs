using System;
using System.Collections.Generic;
using System.IO;

namespace Celeste.Formats.Map.Binary.Source
{
    public static class BinaryPacker
    {
        private static string[] stringLookup;

        public static BinaryPackerElement FromBinary(string filename)
            => FromBinary(File.OpenRead(filename));

        public static BinaryPackerElement FromBinary(Stream input)
        {
            using Stream ownedInput = input;
            BinaryReader binaryReader = new BinaryReader(input);
            binaryReader.ReadString();
            string package = binaryReader.ReadString();
            short num = binaryReader.ReadInt16();
            stringLookup = new string[num];
            for (int i = 0; i < num; i++)
            {
                stringLookup[i] = binaryReader.ReadString();
            }

            BinaryPackerElement element = ReadElement(binaryReader);
            element.Package = package;
            return element;
        }

        private static BinaryPackerElement ReadElement(BinaryReader reader)
        {
            BinaryPackerElement element = new BinaryPackerElement();
            element.Name = stringLookup[reader.ReadInt16()];
            byte b = reader.ReadByte();
            if (b > 0)
            {
                element.Attributes = new Dictionary<string, object>();
            }

            for (int i = 0; i < b; i++)
            {
                string key = stringLookup[reader.ReadInt16()];
                byte b2 = reader.ReadByte();
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
                        short count = reader.ReadInt16();
                        value = RunLengthEncoding.Decode(reader.ReadBytes(count));
                        break;
                    }
                }

                element.Attributes.Add(key, value);
            }

            short num = reader.ReadInt16();
            if (num > 0)
            {
                element.Children = new List<BinaryPackerElement>();
            }

            for (int j = 0; j < num; j++)
            {
                element.Children.Add(ReadElement(reader));
            }

            return element;
        }
    }
}
