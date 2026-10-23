using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Celeste.Graphics.Content.Images
{
    public sealed class SourceImageStreamProcess : global::Celeste.Graphics.Content.Textures.ISourceRawImageCodec
    {
        private SourceImageReadCallback readFunc;
        private SourceImageSkipCallback skipFunc;
        private SourceImageEofCallback eofFunc;
        private int readGlobal;
        private Dictionary<IntPtr, Stream> readStreams;
        private SourceImageWriteCallback writeFunc;
        private int writeGlobal;
        private Dictionary<IntPtr, Stream> writeStreams;
        private readonly ISourceImageCodecDevice device;

        public void FreeImage(IntPtr pointer) => device.FreeImage(pointer);

        IntPtr global::Celeste.Graphics.Content.Textures.ISourceRawImageCodec.ReadImageStream(
            Stream stream, out int width, out int height, out int byteCount) =>
            ReadImageStream(stream, out width, out height, out byteCount);

        void global::Celeste.Graphics.Content.Textures.ISourceRawImageCodec.Free(IntPtr buffer) => FreeImage(buffer);

        public SourceImageStreamProcess(ISourceImageCodecDevice device)
        {
            this.device = device;
            readFunc = INTERNAL_Read;
            skipFunc = INTERNAL_Skip;
            eofFunc = INTERNAL_EOF;
            readGlobal = 0;
            readStreams = new Dictionary<IntPtr, Stream>();
            writeFunc = INTERNAL_Write;
            writeGlobal = 0;
            writeStreams = new Dictionary<IntPtr, Stream>();
        }

        private int INTERNAL_Read(IntPtr context, IntPtr data, int size)
        {
            Stream stream;
            lock (readStreams)
            {
                stream = readStreams[context];
            }

            byte[] array = new byte[size];
            int num = stream.Read(array, 0, size);
            Marshal.Copy(array, 0, data, num);
            return num;
        }

        private void INTERNAL_Skip(IntPtr context, int n)
        {
            Stream stream;
            lock (readStreams)
            {
                stream = readStreams[context];
            }

            stream.Seek(n, SeekOrigin.Current);
        }

        private int INTERNAL_EOF(IntPtr context)
        {
            Stream stream;
            lock (readStreams)
            {
                stream = readStreams[context];
            }

            return (stream.Position == stream.Length) ? 1 : 0;
        }

        public IntPtr ReadImageStream(Stream stream, out int width, out int height, out int len, int forceW = -1,
            int forceH = -1, bool zoom = false)
        {
            IntPtr intPtr;
            lock (readStreams)
            {
                intPtr = (IntPtr)(readGlobal++);
                readStreams.Add(intPtr, stream);
            }

            IntPtr result = device.Load(readFunc, skipFunc, eofFunc, intPtr, out width, out height, out len, forceW,
                forceH,
                zoom ? ((byte)1) : ((byte)0));
            lock (readStreams)
            {
                readStreams.Remove(intPtr);
                return result;
            }
        }


        private void INTERNAL_Write(IntPtr context, IntPtr data, int size)
        {
            Stream stream;
            lock (writeStreams)
            {
                stream = writeStreams[context];
            }

            byte[] array = new byte[size];
            Marshal.Copy(data, array, 0, size);
            stream.Write(array, 0, size);
        }

        public void WritePNGStream(Stream stream, int srcW, int srcH, int dstW, int dstH, IntPtr data)
        {
            IntPtr intPtr;
            lock (writeStreams)
            {
                intPtr = (IntPtr)(writeGlobal++);
                writeStreams.Add(intPtr, stream);
            }

            device.SavePNG(writeFunc, intPtr, srcW, srcH, dstW, dstH, data);
            lock (writeStreams)
            {
                writeStreams.Remove(intPtr);
            }
        }

        public void WriteJPGStream(Stream stream, int srcW, int srcH, int dstW, int dstH, IntPtr data, int quality)
        {
            IntPtr intPtr;
            lock (writeStreams)
            {
                intPtr = (IntPtr)(writeGlobal++);
                writeStreams.Add(intPtr, stream);
            }

            device.SaveJPG(writeFunc, intPtr, srcW, srcH, dstW, dstH, data, quality);
            lock (writeStreams)
            {
                writeStreams.Remove(intPtr);
            }
        }
    }
}
