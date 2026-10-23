using System;
using System.IO;

namespace Celeste.Graphics.Content.Compiled
{
    public partial class SourceContentManager
    {
        private SourceContentReader GetSourceContentReaderFromXnb(string originalAssetName, ref Stream stream,
            BinaryReader xnbReader, char platform, Action<IDisposable> recordDisposableObject)
        {
            byte b = xnbReader.ReadByte();
            bool num = (xnbReader.ReadByte() & 0x80) != 0;
            if (b != 5 && b != 4)
            {
                throw new SourceContentLoadException("Invalid XNB version");
            }

            int num2 = xnbReader.ReadInt32();
            if (num)
            {
                int num3 = num2 - 14;
                int num4 = xnbReader.ReadInt32();
                MemoryStream memoryStream =
                    new MemoryStream(new byte[num4], 0, num4, writable: true, publiclyVisible: true);
                MemoryStream memoryStream2 =
                    new MemoryStream(new byte[num3], 0, num3, writable: true, publiclyVisible: true);
                stream.Read(memoryStream2.GetBuffer(), 0, num3);
                SourceLzxDecoder lzxDecoder = new SourceLzxDecoder(16, process);
                int num5 = 0;
                long num6 = 0L;
                while (num6 < num3)
                {
                    int num7 = memoryStream2.ReadByte();
                    int num8 = memoryStream2.ReadByte();
                    int num9 = (num7 << 8) | num8;
                    int num10 = 32768;
                    if (num7 == 255)
                    {
                        int num11 = num8;
                        num8 = (byte)memoryStream2.ReadByte();
                        num10 = (num11 << 8) | num8;
                        byte num12 = (byte)memoryStream2.ReadByte();
                        num8 = (byte)memoryStream2.ReadByte();
                        num9 = (num12 << 8) | num8;
                        num6 += 5;
                    }
                    else
                    {
                        num6 += 2;
                    }

                    if (num9 == 0 || num10 == 0)
                    {
                        break;
                    }

                    lzxDecoder.Decompress(memoryStream2, num9, memoryStream, num10);
                    num6 += num9;
                    num5 += num10;
                    memoryStream2.Seek(num6, SeekOrigin.Begin);
                }

                if (memoryStream.Position != num4)
                {
                    throw new SourceContentLoadException("Decompression of " + originalAssetName + " failed. ");
                }

                memoryStream.Seek(0L, SeekOrigin.Begin);
                return new SourceContentReader(this, memoryStream, originalAssetName, b, platform,
                    recordDisposableObject);
            }

            return new SourceContentReader(this, stream, originalAssetName, b, platform, recordDisposableObject);
        }
    }
}
