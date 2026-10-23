using System;
using System.IO;
using Celeste.Core.Reflection.Members;

namespace Celeste.Game.Reflection.Metadata.Resources
{
    internal static class SourcePico8MapData
    {
        internal static readonly string Value;
        internal static readonly string HexBlob;

        static SourcePico8MapData()
        {
            const string resource = "Celeste.SourceConstant.Pico8.MapData";
            using var stream = typeof(SourcePico8MapData).Assembly.GetManifestResourceStream(resource)
                               ?? throw new InvalidOperationException("The restored Pico8 map constant is missing.");
            using var buffer = new MemoryStream();
            stream.CopyTo(buffer);
            var bytes = buffer.ToArray();
            Value = (string)SourceMetadataConstant.Decode("System.String", bytes);
            const string digits = "0123456789ABCDEF";
            var characters = new char[checked(bytes.Length * 2)];
            for (var index = 0; index < bytes.Length; index++)
            {
                characters[index * 2] = digits[bytes[index] >> 4];
                characters[index * 2 + 1] = digits[bytes[index] & 15];
            }

            HexBlob = new(characters);
        }
    }
}
