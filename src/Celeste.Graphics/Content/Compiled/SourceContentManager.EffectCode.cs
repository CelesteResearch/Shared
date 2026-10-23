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
            for (var i = 0; i < Process.XnbHeader.Length; i++) Process.XnbHeader[i] = xnbReader.ReadByte();
            if (Process.XnbHeader[0] != 88 || Process.XnbHeader[1] != 78 || Process.XnbHeader[2] != 66 ||
                !Process.targetPlatformIdentifiers.Contains((char)Process.XnbHeader[3]))
                throw new SourceContentLoadException("Invalid XNB header: " + assetName);
            using var reader = GetSourceContentReaderFromXnb(assetName, ref stream, xnbReader,
                (char)Process.XnbHeader[3], null);
            return reader.ReadEffectCode();
        }
    }
}
