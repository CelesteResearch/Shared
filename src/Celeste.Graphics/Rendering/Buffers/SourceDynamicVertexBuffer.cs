using System;
using System.Runtime.InteropServices;
using Celeste.Core.Interop;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Vertices;

namespace Celeste.Graphics.Rendering.Buffers
{
    public class SourceDynamicVertexBuffer : SourceVertexBuffer
    {
        public bool IsContentLost => false;

#pragma warning disable CS0067 // The source API declares this event without raising it.
        public event EventHandler<EventArgs> ContentLost;
#pragma warning restore CS0067

        public SourceDynamicVertexBuffer(SourceGraphicsDevice graphicsDevice, SourceVertexDeclaration vertexDeclaration,
            int vertexCount, SourceBufferUsage bufferUsage)
            : base(graphicsDevice, vertexDeclaration, vertexCount, bufferUsage, true)
        {
        }

        public SourceDynamicVertexBuffer(SourceGraphicsDevice graphicsDevice, Type type, int vertexCount,
            SourceBufferUsage bufferUsage)
            : base(graphicsDevice, SourceVertexDeclaration.FromType(type), vertexCount, bufferUsage, true)
        {
        }

        public void SetData<T>(int offsetInBytes, T[] data, int startIndex, int elementCount, int vertexStride,
            SourceSetDataOptions options) where T : struct
        {
            var num = SourceMarshalHelper.SizeOf<T>();
            var gCHandle = GCHandle.Alloc(data, GCHandleType.Pinned);
            BufferDevice.PhysicalIO.SetVertexBufferData(buffer, offsetInBytes,
                gCHandle.AddrOfPinnedObject() + startIndex * num, elementCount, num, vertexStride, options);
            gCHandle.Free();
        }

        public void SetData<T>(T[] data, int startIndex, int elementCount, SourceSetDataOptions options)
            where T : struct
        {
            var num = SourceMarshalHelper.SizeOf<T>();
            var gCHandle = GCHandle.Alloc(data, GCHandleType.Pinned);
            BufferDevice.PhysicalIO.SetVertexBufferData(buffer, 0, gCHandle.AddrOfPinnedObject() + startIndex * num,
                elementCount, num, num, options);
            gCHandle.Free();
        }
    }
}
