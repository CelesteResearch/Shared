using System;
using System.Runtime.InteropServices;
using Celeste.Core.Interop;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Vertices;

namespace Celeste.Graphics.Rendering.Buffers
{
    public class SourceDynamicIndexBuffer : SourceIndexBuffer
    {
        public bool IsContentLost => false;

#pragma warning disable CS0067 // The source API declares this event without raising it.
        public event EventHandler<EventArgs> ContentLost;
#pragma warning restore CS0067

        public SourceDynamicIndexBuffer(SourceGraphicsDevice graphicsDevice, SourceIndexElementSize indexElementSize,
            int indexCount, SourceBufferUsage usage)
            : base(graphicsDevice, indexElementSize, indexCount, usage, true)
        {
        }

        public SourceDynamicIndexBuffer(SourceGraphicsDevice graphicsDevice, Type indexType, int indexCount,
            SourceBufferUsage usage)
            : base(graphicsDevice, indexType, indexCount, usage, true)
        {
        }

        public void SetData<T>(int offsetInBytes, T[] data, int startIndex, int elementCount,
            SourceSetDataOptions options)
            where T : struct
        {
            var gCHandle = GCHandle.Alloc(data, GCHandleType.Pinned);
            BufferDevice.PhysicalIO.SetIndexBufferData(buffer, offsetInBytes,
                gCHandle.AddrOfPinnedObject() + startIndex * SourceMarshalHelper.SizeOf<T>(),
                elementCount * SourceMarshalHelper.SizeOf<T>(), options);
            gCHandle.Free();
        }

        public void SetData<T>(T[] data, int startIndex, int elementCount, SourceSetDataOptions options)
            where T : struct
        {
            var gCHandle = GCHandle.Alloc(data, GCHandleType.Pinned);
            BufferDevice.PhysicalIO.SetIndexBufferData(buffer, 0,
                gCHandle.AddrOfPinnedObject() + startIndex * SourceMarshalHelper.SizeOf<T>(),
                elementCount * SourceMarshalHelper.SizeOf<T>(), options);
            gCHandle.Free();
        }
    }
}
