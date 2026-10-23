using System;

namespace Celeste.Core.Reflection.Members
{
    public static class SourceMetadataConstant
    {
        public static object Decode(string typeIdentity, byte[] valueBlob)
        {
            if (valueBlob == null) throw new ArgumentNullException(nameof(valueBlob));
            switch (typeIdentity)
            {
                case null:
                    return null;
                case "System.String":
                {
                    if ((valueBlob.Length & 1) != 0)
                        throw new ArgumentException("A metadata string must contain complete UTF-16 code units.",
                            nameof(valueBlob));
                    var characters = new char[valueBlob.Length / 2];
                    for (var index = 0; index < characters.Length; index++)
                        characters[index] = (char)(valueBlob[index * 2] | (valueBlob[index * 2 + 1] << 8));
                    return new string(characters);
                }
            }

            var width = typeIdentity switch
            {
                "System.Boolean" or "System.Byte" or "System.SByte" => 1,
                "System.Char" or "System.Int16" or "System.UInt16" => 2,
                "System.Int32" or "System.UInt32" or "System.Single" => 4,
                "System.Int64" or "System.UInt64" or "System.Double" => 8,
                _ => throw new ArgumentException("Unknown original metadata constant type: " + typeIdentity,
                    nameof(typeIdentity)),
            };
            if (valueBlob.Length != width)
                throw new ArgumentException("Invalid metadata constant width.", nameof(valueBlob));
            ulong bits = 0;
            for (var index = valueBlob.Length - 1; index >= 0; index--) bits = (bits << 8) | valueBlob[index];
            return typeIdentity switch
            {
                "System.Boolean" => bits != 0,
                "System.Byte" => (byte)bits,
                "System.SByte" => unchecked((sbyte)bits),
                "System.Char" => (char)bits,
                "System.Int16" => unchecked((short)bits),
                "System.UInt16" => (ushort)bits,
                "System.Int32" => unchecked((int)bits),
                "System.UInt32" => (uint)bits,
                "System.Int64" => unchecked((long)bits),
                "System.UInt64" => bits,
                "System.Single" => BitConverter.Int32BitsToSingle(unchecked((int)bits)),
                "System.Double" => BitConverter.Int64BitsToDouble(unchecked((long)bits)),
                _ => throw new InvalidOperationException(),
            };
        }
    }
}
