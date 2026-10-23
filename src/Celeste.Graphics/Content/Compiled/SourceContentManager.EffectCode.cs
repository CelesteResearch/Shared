using System;
using System.IO;

namespace Celeste.Graphics.Content.Compiled
{
    public partial class SourceContentManager
    {
        public byte[] ReadEffectCode(Stream stream, string assetName)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            if (string.IsNullOrEmpty(assetName)) throw new ArgumentNullException(nameof(assetName));
            if (disposed) throw new ObjectDisposedException(nameof(SourceContentManager));
            using var xnbReader = new BinaryReader(stream);
            for (int i = 0; i < process.XnbHeader.Length; i++) process.XnbHeader[i] = xnbReader.ReadByte();
            if (process.XnbHeader[0] != 88 || process.XnbHeader[1] != 78 || process.XnbHeader[2] != 66 ||
                !process.targetPlatformIdentifiers.Contains((char)process.XnbHeader[3]))
                throw new SourceContentLoadException("Invalid XNB header: " + assetName);
            using var reader = GetSourceContentReaderFromXnb(assetName, ref stream, xnbReader,
                (char)process.XnbHeader[3], null);
            return reader.ReadEffectCode();
        }
    }
}
