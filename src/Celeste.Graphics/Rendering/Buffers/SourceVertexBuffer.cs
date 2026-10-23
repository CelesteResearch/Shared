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
    public class SourceVertexBuffer : SourceGraphicsResource
    {
        internal IntPtr buffer;

        protected SourceGraphicsDevice BufferDevice => (SourceGraphicsDevice)GraphicsDevice;

        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Local
        public SourceBufferUsage BufferUsage { get; private set; }

        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Local
        public int VertexCount { get; private set; }

        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Local
        public SourceVertexDeclaration VertexDeclaration { get; private set; }

        public SourceVertexBuffer(SourceGraphicsDevice graphicsDevice, SourceVertexDeclaration vertexDeclaration,
            int vertexCount, SourceBufferUsage bufferUsage)
            : this(graphicsDevice, vertexDeclaration, vertexCount, bufferUsage, false)
        {
        }

        public SourceVertexBuffer(SourceGraphicsDevice graphicsDevice, Type type, int vertexCount,
            SourceBufferUsage bufferUsage)
            : this(graphicsDevice, SourceVertexDeclaration.FromType(type), vertexCount, bufferUsage, false)
        {
        }

        protected SourceVertexBuffer(SourceGraphicsDevice graphicsDevice, SourceVertexDeclaration vertexDeclaration,
            int vertexCount, SourceBufferUsage bufferUsage, bool dynamic)
        {
            if (graphicsDevice == null) throw new ArgumentNullException("graphicsDevice");

            GraphicsDevice = graphicsDevice;
            VertexDeclaration = vertexDeclaration;
            VertexCount = vertexCount;
            BufferUsage = bufferUsage;
            if (vertexDeclaration.GraphicsDevice != graphicsDevice)
                vertexDeclaration.AssignSourceGraphicsDevice(graphicsDevice);

            buffer = BufferDevice.PhysicalIO.GenVertexBuffer(dynamic ? (byte)1 : (byte)0, bufferUsage,
                VertexCount * VertexDeclaration.VertexStride);
        }

        protected override void Dispose(bool disposing)
        {
            if (!IsDisposed)
            {
                var intPtr = Interlocked.Exchange(ref buffer, IntPtr.Zero);
                if (intPtr != IntPtr.Zero) BufferDevice.PhysicalIO.AddDisposeVertexBuffer(intPtr);
            }

            base.Dispose(disposing);
        }

        public void GetData<T>(T[] data) where T : struct
        {
            GetData(0, data, 0, data.Length, SourceMarshalHelper.SizeOf<T>());
        }

        public void GetData<T>(T[] data, int startIndex, int elementCount) where T : struct
        {
            GetData(0, data, startIndex, elementCount, SourceMarshalHelper.SizeOf<T>());
        }

        public void GetData<T>(int offsetInBytes, T[] data, int startIndex, int elementCount, int vertexStride)
            where T : struct
        {
            if (data == null) throw new ArgumentNullException("data");

            if (data.Length < startIndex + elementCount)
                throw new ArgumentOutOfRangeException("elementCount",
                    "This parameter must be a valid index within the array.");

            if (BufferUsage == SourceBufferUsage.WriteOnly)
                throw new NotSupportedException(
                    "Calling GetData on a resource that was created with BufferUsage.WriteOnly is not supported.");

            var num = SourceMarshalHelper.SizeOf<T>();
            if (vertexStride == 0)
                vertexStride = num;
            else if (vertexStride < num)
                throw new ArgumentOutOfRangeException("vertexStride",
                    "The vertex stride is too small for the type of data requested. This is not allowed.");

            if (elementCount > 1 && elementCount * vertexStride > VertexCount * VertexDeclaration.VertexStride)
                throw new InvalidOperationException(
                    "The array is not the correct size for the amount of data requested.");

            var gCHandle = GCHandle.Alloc(data, GCHandleType.Pinned);
            BufferDevice.PhysicalIO.GetVertexBufferData(buffer, offsetInBytes,
                gCHandle.AddrOfPinnedObject() + startIndex * num, elementCount, num, vertexStride);
            gCHandle.Free();
        }

        public void SetData<T>(T[] data) where T : struct
        {
            SetData(0, data, 0, data.Length, SourceMarshalHelper.SizeOf<T>());
        }

        public void SetData<T>(T[] data, int startIndex, int elementCount) where T : struct
        {
            SetData(0, data, startIndex, elementCount, SourceMarshalHelper.SizeOf<T>());
        }

        public void SetData<T>(int offsetInBytes, T[] data, int startIndex, int elementCount, int vertexStride)
            where T : struct
        {
            var num = SourceMarshalHelper.SizeOf<T>();
            var gCHandle = GCHandle.Alloc(data, GCHandleType.Pinned);
            BufferDevice.PhysicalIO.SetVertexBufferData(buffer, offsetInBytes,
                gCHandle.AddrOfPinnedObject() + startIndex * num, elementCount, num, vertexStride,
                SourceSetDataOptions.None);
            gCHandle.Free();
        }

        public void SetDataPointerEXT(int offsetInBytes, IntPtr data, int dataLength, SourceSetDataOptions options)
        {
            BufferDevice.PhysicalIO.SetVertexBufferData(buffer, offsetInBytes, data, dataLength, 1, 1, options);
        }

        [Conditional("DEBUG")]
        internal void ErrorCheck<T>(T[] data, int startIndex, int elementCount, int vertexStride) where T : struct
        {
            if (data == null) throw new ArgumentNullException("data");

            if (startIndex + elementCount > data.Length || elementCount <= 0)
                throw new InvalidOperationException(
                    "The array specified in the data parameter is not the correct size for the amount of data requested.");

            if (elementCount > 1 && elementCount * vertexStride > VertexCount * VertexDeclaration.VertexStride)
                throw new InvalidOperationException("The vertex stride is larger than the vertex buffer.");

            var num = SourceMarshalHelper.SizeOf<T>();
            if (vertexStride == 0) vertexStride = num;

            if (vertexStride < num)
                throw new ArgumentOutOfRangeException(
                    "The vertex stride must be greater than or equal to the size of the specified data (" + num + ").");
        }

        protected override void GraphicsDeviceResetting()
        {
        }
    }
}
