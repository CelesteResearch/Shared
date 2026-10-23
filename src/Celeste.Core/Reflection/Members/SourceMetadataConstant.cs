using System;

namespace Celeste.Core.Reflection.Members
{
    public static class SourceMetadataConstant
    {
        public static object Decode(string typeIdentity, byte[] valueBlob)
        {
            if (valueBlob == null) throw new ArgumentNullException(nameof(valueBlob));
            if (typeIdentity == null) return null;
            if (typeIdentity == "System.String")
            {
                if ((valueBlob.Length & 1) != 0)
                    throw new ArgumentException("A metadata string must contain complete UTF-16 code units.",
                        nameof(valueBlob));
                var characters = new char[valueBlob.Length / 2];
                for (int index = 0; index < characters.Length; index++)
                    characters[index] = (char)(valueBlob[index * 2] | (valueBlob[index * 2 + 1] << 8));
                return new string(characters);
            }

            int width = typeIdentity == "System.Boolean" || typeIdentity == "System.Byte"
                                                         || typeIdentity == "System.SByte"
                ? 1
                : typeIdentity == "System.Char" || typeIdentity == "System.Int16" || typeIdentity == "System.UInt16"
                    ? 2
                    : typeIdentity == "System.Int32" || typeIdentity == "System.UInt32" ||
                      typeIdentity == "System.Single"
                        ? 4
                        : typeIdentity == "System.Int64" || typeIdentity == "System.UInt64" ||
                          typeIdentity == "System.Double"
                            ? 8
                            : throw new ArgumentException("Unknown original metadata constant type: " + typeIdentity,
                                nameof(typeIdentity));
            if (valueBlob.Length != width)
                throw new ArgumentException("Invalid metadata constant width.", nameof(valueBlob));
            ulong bits = 0;
            for (int index = valueBlob.Length - 1; index >= 0; index--) bits = (bits << 8) | valueBlob[index];
            switch (typeIdentity)
            {
                case "System.Boolean": return bits != 0;
                case "System.Byte": return (byte)bits;
                case "System.SByte": return unchecked((sbyte)bits);
                case "System.Char": return (char)bits;
                case "System.Int16": return unchecked((short)bits);
                case "System.UInt16": return (ushort)bits;
                case "System.Int32": return unchecked((int)bits);
                case "System.UInt32": return (uint)bits;
                case "System.Int64": return unchecked((long)bits);
                case "System.UInt64": return bits;
                case "System.Single": return BitConverter.Int32BitsToSingle(unchecked((int)bits));
                case "System.Double": return BitConverter.Int64BitsToDouble(unchecked((long)bits));
                default: throw new InvalidOperationException();
            }
        }
    }
}
