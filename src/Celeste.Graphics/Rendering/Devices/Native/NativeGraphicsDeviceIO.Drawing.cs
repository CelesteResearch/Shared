using System;
using Celeste.Graphics.Rendering.Buffers;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Vertices;

namespace Celeste.Graphics.Rendering.Devices.Native
{
    public unsafe partial class NativeGraphicsDeviceIO
    {
        public void ApplyVertexBufferBindings(SourceNativeVertexBufferBinding* bindings,
            int count, byte updated, int baseVertex)
        {
            uint owned = BorrowWriteScope();
            try
            {
                RequireSuccess(api->SetVertexBindings(packet, bindings, count, updated, baseVertex));
            }
            finally
            {
                CompleteWriteScope(owned);
            }
        }

        public void DrawPrimitives(SourcePrimitiveType type, int startVertex, int primitiveCount)
        {
            uint owned = BorrowWriteScope();
            try
            {
                RequireSuccess(api->Draw(packet, type, startVertex, primitiveCount));
            }
            finally
            {
                CompleteWriteScope(owned);
            }
        }

        public void DrawIndexedPrimitives(SourcePrimitiveType type, int baseVertex, int minVertexIndex,
            int numVertices, int startIndex, int primitiveCount, IntPtr indices, SourceIndexElementSize indexSize)
            => DrawIndexed(type, baseVertex, minVertexIndex, numVertices, startIndex, primitiveCount, 1,
                indices, indexSize);

        public void DrawInstancedPrimitives(SourcePrimitiveType type, int baseVertex, int minVertexIndex,
            int numVertices, int startIndex, int primitiveCount, int instanceCount, IntPtr indices,
            SourceIndexElementSize indexSize)
            => DrawIndexed(type, baseVertex, minVertexIndex, numVertices, startIndex, primitiveCount, instanceCount,
                indices, indexSize);

        private void DrawIndexed(SourcePrimitiveType type, int baseVertex, int minVertexIndex,
            int numVertices, int startIndex, int primitiveCount, int instanceCount, IntPtr indices,
            SourceIndexElementSize indexSize)
        {
            uint owned = BorrowWriteScope();
            try
            {
                RequireSuccess(api->DrawIndexed(packet, type, baseVertex, minVertexIndex, numVertices,
                    startIndex, primitiveCount, instanceCount, indices, indexSize));
            }
            finally
            {
                CompleteWriteScope(owned);
            }
        }
    }
}
