using System;
using System.IO;
using System.Text;
using Celeste.Core.Reflection.Members;

namespace Celeste.Core.Reflection.Interop
{
    public static class SourceModInteropAttributeData
    {
        public const string ImportAttributeIdentity = "MonoMod.ModInterop.ModImportNameAttribute";
        public const string ExportAttributeIdentity = "MonoMod.ModInterop.ModExportNameAttribute";

        public static string ReadName(SourceDeclaredAttribute attribute)
        {
            if (attribute.TypeIdentity != ImportAttributeIdentity && attribute.TypeIdentity != ExportAttributeIdentity)
                throw new ArgumentException("The original attribute is not a ModInterop name attribute.",
                    nameof(attribute));
            var blob = attribute.ValueBlob;
            int offset = 0;

            byte ReadByte()
            {
                if (offset >= blob.Count)
                    throw new InvalidDataException("Truncated original ModInterop attribute value.");
                return blob[offset++];
            }

            if (ReadByte() != 1 || ReadByte() != 0)
                throw new InvalidDataException("Invalid original ModInterop attribute prolog.");
            int first = ReadByte();
            if (first == 0xff) return null;
            int length;
            if ((first & 0x80) == 0) length = first;
            else if ((first & 0xc0) == 0x80) length = ((first & 0x3f) << 8) | ReadByte();
            else if ((first & 0xe0) == 0xc0)
                length = ((first & 0x1f) << 24) | (ReadByte() << 16) | (ReadByte() << 8) | ReadByte();
            else throw new InvalidDataException("Invalid original ModInterop serialized string length.");
            if (length > blob.Count - offset)
                throw new InvalidDataException("Truncated original ModInterop attribute name.");
            byte[] bytes = new byte[length];
            for (int index = 0; index < length; index++) bytes[index] = ReadByte();
            // Both original SDK attributes only assign their readonly Name in ctor(string).
            return Encoding.UTF8.GetString(bytes);
        }
    }
}
