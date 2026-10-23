using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using Celeste.Core.Interop;
using Celeste.Core.Rendering.Resources;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Vertices;

namespace Celeste.Graphics.Rendering.Buffers
{
    public class SourceIndexBuffer : SourceGraphicsResource
    {
        internal IntPtr buffer;

        protected SourceGraphicsDevice BufferDevice => (SourceGraphicsDevice)GraphicsDevice;

        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Local
        public SourceBufferUsage BufferUsage { get; private set; }

        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Local
        public int IndexCount { get; private set; }

        public SourceIndexElementSize IndexElementSize { get; private set; }

        public SourceIndexBuffer(SourceGraphicsDevice graphicsDevice, SourceIndexElementSize indexElementSize,
            int indexCount, SourceBufferUsage bufferUsage)
            : this(graphicsDevice, indexElementSize, indexCount, bufferUsage, false)
        {
        }

        public SourceIndexBuffer(SourceGraphicsDevice graphicsDevice, Type indexType, int indexCount,
            SourceBufferUsage usage)
            : this(graphicsDevice, SizeForType(graphicsDevice, indexType), indexCount, usage, false)
        {
        }

        protected SourceIndexBuffer(SourceGraphicsDevice graphicsDevice, Type indexType, int indexCount,
            SourceBufferUsage usage, bool dynamic)
            : this(graphicsDevice, SizeForType(graphicsDevice, indexType), indexCount, usage, dynamic)
        {
        }

        protected SourceIndexBuffer(SourceGraphicsDevice graphicsDevice, SourceIndexElementSize indexElementSize,
            int indexCount, SourceBufferUsage usage, bool dynamic)
        {
            if (graphicsDevice == null) throw new ArgumentNullException("graphicsDevice");

            GraphicsDevice = graphicsDevice;
            IndexElementSize = indexElementSize;
            IndexCount = indexCount;
            BufferUsage = usage;
            buffer = BufferDevice.PhysicalIO.GenIndexBuffer(dynamic ? (byte)1 : (byte)0, usage,
                IndexCount * (indexElementSize == SourceIndexElementSize.ThirtyTwoBits ? 4 : 2));
        }

        protected override void Dispose(bool disposing)
        {
            if (!IsDisposed)
            {
                var intPtr = Interlocked.Exchange(ref buffer, IntPtr.Zero);
                if (intPtr != IntPtr.Zero) BufferDevice.PhysicalIO.AddDisposeIndexBuffer(intPtr);
            }

            base.Dispose(disposing);
        }

        public void GetData<T>(T[] data) where T : struct
        {
            GetData(0, data, 0, data.Length);
        }

        public void GetData<T>(T[] data, int startIndex, int elementCount) where T : struct
        {
            GetData(0, data, startIndex, elementCount);
        }

        public void GetData<T>(int offsetInBytes, T[] data, int startIndex, int elementCount) where T : struct
        {
            if (data == null) throw new ArgumentNullException("data");

            if (data.Length < startIndex + elementCount)
                throw new InvalidOperationException(
                    "The array specified in the data parameter is not the correct size for the amount of data requested.");

            if (BufferUsage == SourceBufferUsage.WriteOnly)
                throw new NotSupportedException(
                    "This IndexBuffer was created with a usage type of BufferUsage.WriteOnly. Calling GetData on a resource that was created with BufferUsage.WriteOnly is not supported.");

            var num = SourceMarshalHelper.SizeOf<T>();
            var gCHandle = GCHandle.Alloc(data, GCHandleType.Pinned);
            BufferDevice.PhysicalIO.GetIndexBufferData(buffer, offsetInBytes,
                gCHandle.AddrOfPinnedObject() + startIndex * num, elementCount * num);
            gCHandle.Free();
        }

        public void SetData<T>(T[] data) where T : struct
        {
            var gCHandle = GCHandle.Alloc(data, GCHandleType.Pinned);
            BufferDevice.PhysicalIO.SetIndexBufferData(buffer, 0, gCHandle.AddrOfPinnedObject(),
                data.Length * SourceMarshalHelper.SizeOf<T>(), SourceSetDataOptions.None);
            gCHandle.Free();
        }

        public void SetData<T>(T[] data, int startIndex, int elementCount) where T : struct
        {
            var gCHandle = GCHandle.Alloc(data, GCHandleType.Pinned);
            BufferDevice.PhysicalIO.SetIndexBufferData(buffer, 0,
                gCHandle.AddrOfPinnedObject() + startIndex * SourceMarshalHelper.SizeOf<T>(),
                elementCount * SourceMarshalHelper.SizeOf<T>(), SourceSetDataOptions.None);
            gCHandle.Free();
        }

        public void SetData<T>(int offsetInBytes, T[] data, int startIndex, int elementCount) where T : struct
        {
            var gCHandle = GCHandle.Alloc(data, GCHandleType.Pinned);
            BufferDevice.PhysicalIO.SetIndexBufferData(buffer, offsetInBytes,
                gCHandle.AddrOfPinnedObject() + startIndex * SourceMarshalHelper.SizeOf<T>(),
                elementCount * SourceMarshalHelper.SizeOf<T>(), SourceSetDataOptions.None);
            gCHandle.Free();
        }

        public void SetDataPointerEXT(int offsetInBytes, IntPtr data, int dataLength, SourceSetDataOptions options)
        {
            BufferDevice.PhysicalIO.SetIndexBufferData(buffer, offsetInBytes, data, dataLength, options);
        }

        [Conditional("DEBUG")]
        internal void ErrorCheck<T>(T[] data, int startIndex, int elementCount) where T : struct
        {
            if (data == null) throw new ArgumentNullException("data");

            if (data.Length < startIndex + elementCount)
                throw new InvalidOperationException(
                    "The array specified in the data parameter is not the correct size for the amount of data requested.");
        }

        protected override void GraphicsDeviceResetting()
        {
        }

        private static SourceIndexElementSize SizeForType(SourceGraphicsDevice graphicsDevice, Type type)
        {
            return Marshal.SizeOf(type) switch
            {
                2 => SourceIndexElementSize.SixteenBits,
                4 => SourceIndexElementSize.ThirtyTwoBits,
                _ => throw new ArgumentOutOfRangeException("type",
                    "Index buffers can only be created for types that are sixteen or thirty two bits in length"),
            };
        }
    }
}
