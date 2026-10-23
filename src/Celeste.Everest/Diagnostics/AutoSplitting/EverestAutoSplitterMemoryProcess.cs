using System;
using System.Buffers.Binary;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Celeste.Everest.Diagnostics.AutoSplitting
{
    public sealed class EverestAutoSplitterMemoryProcess
    {
        private readonly IEverestAutoSplitterMemoryDevice device;
        private bool isInitialized;
        private IEverestAutoSplitterMappedFile splitterInfoFile;
        private IEverestAutoSplitterMemoryManager splitterInfoMemoryManager;
        private Memory<byte> splitterInfoBuffer;
        private Memory<byte> stringPoolA;
        private Memory<byte> stringPoolB;
        private bool useStringPoolB;
        private int stringPoolOffset;
        private byte[] magicBytes;

        public EverestAutoSplitterMemoryProcess(IEverestAutoSplitterMemoryDevice device)
        {
            this.device = device;
        }

        public unsafe ref EverestAutoSplitterInfo SplitterInfo
        {
            get
            {
                var span = splitterInfoBuffer.Span;
                if (span.Length < sizeof(EverestAutoSplitterInfo))
                    throw new ArgumentOutOfRangeException("length");
                fixed (byte* pointer = span)
                {
                    return ref *(EverestAutoSplitterInfo*)pointer;
                }
            }
        }

        public void Initialize(IEverestAutoSplitterInitializationEnvironment engine)
        {
            Trace.Assert(!isInitialized);
            splitterInfoFile = device.CreateNew(null, 12288L);
            splitterInfoMemoryManager = splitterInfoFile.CreateMemoryManager();
            var memory = splitterInfoMemoryManager.Memory;
            splitterInfoBuffer = memory.Slice(0, 4096);
            stringPoolB = memory.Slice(8192, 4096);
            stringPoolA = memory.Slice(4096, 4096);
            ref var info = ref SplitterInfo;
            if (magicBytes == null)
            {
                magicBytes =
                [
                    .. Encoding.ASCII.GetBytes("EVERESTAUTOSPLIT")
                        .Concat(new byte[] { 240, 241, 242, 243 }),
                ];
                Trace.Assert(magicBytes.Length == 20);
            }

            magicBytes.AsSpan().CopyTo(splitterInfoBuffer.Span.Slice(0, 20));
            info.CelesteVersionMajor = unchecked((byte)engine.CelesteVersion.Major);
            info.CelesteVersionMinor = unchecked((byte)engine.CelesteVersion.Minor);
            info.CelesteVersionBuild = unchecked((byte)engine.CelesteVersion.Build);
            info.InfoVersion = 3;
            var offset = Marshal.SizeOf<EverestAutoSplitterInfo>();
            info.EverestVersionStrPtr = WriteString(splitterInfoBuffer, 0, ref offset, engine.EverestVersionString);
            isInitialized = true;
        }

        public void Shutdown()
        {
            if (!isInitialized)
                return;
            splitterInfoBuffer = Memory<byte>.Empty;
            stringPoolA = Memory<byte>.Empty;
            stringPoolB = Memory<byte>.Empty;
            splitterInfoFile.Dispose();
            isInitialized = false;
        }

        private IntPtr WriteString(Memory<byte> memory, int memoryOffset, ref int offset, string value)
        {
            if (string.IsNullOrEmpty(value)) return IntPtr.Zero;
            var bytes = Encoding.UTF8.GetBytes(value);
            var start = offset;
            var span = memory.Span.Slice(start, memory.Length - start);
            offset = unchecked(offset + 2 + bytes.Length + 1);
            BinaryPrimitives.WriteUInt16LittleEndian(span.Slice(0, 2), unchecked((ushort)bytes.Length));
            bytes.AsSpan().CopyTo(span.Slice(2, bytes.Length));
            span[2 + bytes.Length] = 0;
            return splitterInfoMemoryManager.GetAddress(memoryOffset + start + 2);
        }

        public void ResetStringPool()
        {
            useStringPoolB = !useStringPoolB;
            stringPoolOffset = 0;
        }

        public IntPtr AppendStringToPool(string value)
        {
            return WriteString(useStringPoolB ? stringPoolB : stringPoolA,
                useStringPoolB ? 8192 : 4096, ref stringPoolOffset, value);
        }
    }
}
